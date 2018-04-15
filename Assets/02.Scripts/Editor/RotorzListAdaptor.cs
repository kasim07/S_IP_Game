using UnityEngine;
using UnityEditor;
using Rotorz.ReorderableList;
using System.Collections.Generic;
using System;
using System.Collections;

namespace Editors
{
    public class RotorzListAdaptor<T> : 
        GenericListAdaptor<T>, IReorderableListDropTarget
        where T : IComparable
    {

        private const float MouseDragThresholdInPixels = 0.6f;

        // Static reference to the list adaptor of the selected item.
        private static RotorzListAdaptor<T> s_SelectedList;
        // Static reference limits selection to one item in one list.
        private static T s_SelectedItem;
        // Position in GUI where mouse button was anchored before dragging occurred.
        private static Vector2 s_MouseDownPosition;
        
        // Holds data representing the item that is being dragged.
        private class DraggedItem
        {

            public static readonly string TypeName = typeof(DraggedItem).FullName;

            public readonly RotorzListAdaptor<T> SourceListAdaptor;
            public readonly int Index;
            public readonly string ShoppingItem;

            public DraggedItem(RotorzListAdaptor<T> sourceList, int index, string shoppingItem)
            {
                SourceListAdaptor = sourceList;
                Index = index;
                ShoppingItem = shoppingItem;
            }

        }

        public RotorzListAdaptor(IList<T> list) : base(list, null, 16f)
        {
        }

        public override void DrawItemBackground(Rect position, int index)
        {
            if (this == s_SelectedList && List[index].CompareTo(s_SelectedItem) == 0)
            {
                Color restoreColor = GUI.color;
                GUI.color = ReorderableListStyles.SelectionBackgroundColor;
                GUI.DrawTexture(position, EditorGUIUtility.whiteTexture);
                GUI.color = restoreColor;
            }
        }

        public override void DrawItem(Rect position, int index)
        {
            T shoppingItem = List[index];

            int controlID = GUIUtility.GetControlID(FocusType.Passive);

            switch (Event.current.GetTypeForControl(controlID))
            {
                case EventType.MouseDown:
                    Rect totalItemPosition = ReorderableListGUI.CurrentItemTotalPosition;
                    if (totalItemPosition.Contains(Event.current.mousePosition))
                    {
                        // Select this list item.
                        s_SelectedList = this;
                        s_SelectedItem = shoppingItem;
                    }

                    // Calculate rectangle of draggable area of the list item.
                    // This example excludes the grab handle at the left.
                    Rect draggableRect = totalItemPosition;
                    draggableRect.x = position.x;
                    draggableRect.width = position.width;

                    if (Event.current.button == 0 && draggableRect.Contains(Event.current.mousePosition))
                    {
                        // Select this list item.
                        s_SelectedList = this;
                        s_SelectedItem = shoppingItem;

                        // Lock onto this control whilst left mouse button is held so
                        // that we can start a drag-and-drop operation when user drags.
                        GUIUtility.hotControl = controlID;
                        s_MouseDownPosition = Event.current.mousePosition;
                        Event.current.Use();
                    }
                    break;

                case EventType.MouseDrag:
                    if (GUIUtility.hotControl == controlID)
                    {
                        GUIUtility.hotControl = 0;

                        // Begin drag-and-drop operation when the user drags the mouse
                        // pointer across the threshold. This threshold helps to avoid
                        // inadvertently starting a drag-and-drop operation.
                        if (Vector2.Distance(s_MouseDownPosition, Event.current.mousePosition) >= MouseDragThresholdInPixels)
                        {
                            // Prepare data that will represent the item.
                            var item = new DraggedItem(this, index, shoppingItem.ToString());

                            // Start drag-and-drop operation with the Unity API.
                            DragAndDrop.PrepareStartDrag();
                            // Need to reset `objectReferences` and `paths` because `PrepareStartDrag`
                            // doesn't seem to reset these (at least, in Unity 4.x).
                            DragAndDrop.objectReferences = new UnityEngine.Object[0];
                            DragAndDrop.paths = new string[0];

                            DragAndDrop.SetGenericData(DraggedItem.TypeName, item);
                            DragAndDrop.StartDrag(shoppingItem.ToString());
                        }

                        // Use this event so that the host window gets repainted with
                        // each mouse movement.
                        Event.current.Use();
                    }
                    break;

                case EventType.Repaint:
                    EditorStyles.label.Draw(position, shoppingItem.ToString(), false, false, false, false);
                    break;
            }
        }

        public bool CanDropInsert(int insertionIndex)
        {
            if (!ReorderableListControl.CurrentListPosition.Contains(Event.current.mousePosition))
                return false;

            // Drop insertion is possible if the current drag-and-drop operation contains
            // the supported type of custom data.
            return DragAndDrop.GetGenericData(DraggedItem.TypeName) is DraggedItem;
        }

        public void ProcessDropInsertion(int insertionIndex)
        {
            if (Event.current.type == EventType.DragPerform)
            {
                var draggedItem = DragAndDrop.GetGenericData(DraggedItem.TypeName) as DraggedItem;

                // Are we just reordering within the same list?
                if (draggedItem.SourceListAdaptor == this)
                {
                    Move(draggedItem.Index, insertionIndex);
                }
                else
                {
                    // Nope, we are moving the item!
                    List.Insert(insertionIndex, draggedItem.SourceListAdaptor[draggedItem.Index]);
                    draggedItem.SourceListAdaptor.Remove(draggedItem.Index);

                    // Ensure that the item remains selected at its new location!
                    s_SelectedList = this;
                }
            }
        }
    }
}