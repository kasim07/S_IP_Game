using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using Rotorz.ReorderableList;
using System.Text;

namespace Editors
{
    public class StageEnemyTool : EditorWindow
    {
        static private StageEnemyTool window;
        static private EnemyStageDictionary stageData;
        static private EnemyDataTool enemyDataWindow;
        static private string path = "Assets/02.Scripts/Editor/StageList.txt";
        static private int[] stageLevel;
        static private string[] stageNames;
        private Vector2 _scrollPosition;
        private int frontLevel = 1, backLevel = 1;
        private EnemyStageList copyDataList;

        [MenuItem("CustumTools/Stage Enemy Data")]
        static public void CreateWindow()
        {
            window = GetWindow<StageEnemyTool>("Stage Enemy Tool");
            stageLevel = new int[9] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            stageNames = new string[9] { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            LoadData();
            window.Show();
        }

        [MenuItem("CustumTools/Close")]
        static public void CloseWindow()
        {
            if (window != null)
                window.Close();
        }

        static public void LoadData()
        {
            //stageData = Json<EnemyStageList>.Read(FileIO.ReadStringFromFile(path));
            //Debug.Log("Load :  StageList");
            //string str = Json<string>.Read(FileIO.ReadStringFromFile(path));
            //Debug.Log(str);

            ///*
            try
            {
                stageData = Json<EnemyStageDictionary>.Read(FileIO.ReadStringFromFile(path));                
            }
            catch (System.Exception e)
            {
                Debug.Log(e.ToString());
                Debug.Log("load error :  stagelist");
                Debug.Log(stageData);
                Debug.Log(path);
            }
            //*/
            if (stageData == null)
            {
                stageData = new EnemyStageDictionary();
            }
        }

        static public void SaveData()
        {
            string data = Json<EnemyStageDictionary>.Write(stageData);
            FileIO.WriteStringToFile(data, path);
        }

        private void OnGUI()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(frontLevel);
            builder.Append("_");
            builder.Append(backLevel);

            if(!stageData.m_Dictionary.ContainsKey(builder.ToString()))
            {
                stageData.m_Dictionary.Add(builder.ToString(), new EnemyStageList(new List<EnemyBuildData>()));
            }

            ViewList(builder.ToString(), stageData.m_Dictionary[builder.ToString()]);

            GUILayout.BeginHorizontal(GUILayout.Width(position.width / 2f - 6f));
            EditorGUILayout.LabelField("Stage");
            frontLevel = EditorGUILayout.IntPopup(frontLevel, stageNames, stageLevel);
            backLevel = EditorGUILayout.IntPopup(backLevel, stageNames, stageLevel);
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            if (GUILayout.Button("Save"))
            {
                SaveData();
            }
            GUILayout.EndHorizontal();
        }

        private void ViewList(string stageName, EnemyStageList stageList)
        {
            _scrollPosition = GUILayout.BeginScrollView(_scrollPosition);
            copyDataList = stageList;
            
            ReorderableListGUI.Title(stageName + " Stage");
            ReorderableListGUI.ListField(stageList.m_List, PendingItemDrawer, DrawEmpty);

            GUILayout.EndScrollView();
        }

        private EnemyBuildData PendingItemDrawer(Rect pos, EnemyBuildData itemValue)
        {
            if(itemValue == null)
            {
                itemValue = new EnemyBuildData();

                if(copyDataList.m_List.Count > 1)
                    itemValue.SetData(copyDataList.m_List[copyDataList.m_List.Count - 2]);
            }

            pos.width -= 450;
            EditorGUI.LabelField(pos, itemValue.spriteName);

            pos.x = pos.xMax + 5;
            pos.width = 70;
            EditorGUI.LabelField(pos, "ActionType");
            pos.x = pos.xMax + 5;
            pos.width = 120;
            itemValue.actionType = (ActionType)EditorGUI.EnumPopup(pos, itemValue.actionType);

            pos.x = pos.xMax + 5;
            pos.width = 35;
            EditorGUI.LabelField(pos, "Time");
            pos.x = pos.xMax + 5;
            itemValue.waitTime = EditorGUI.FloatField(pos, itemValue.waitTime);

            pos.x = pos.xMax + 5;            
            EditorGUI.LabelField(pos, "Hold");
            pos.x = pos.xMax + 5;
            itemValue.holdTimeUntilDead = EditorGUI.Toggle(pos, itemValue.holdTimeUntilDead);

            pos.x = pos.xMax + 5;
            pos.width = 45;
            if (GUI.Button(pos, "Info"))
            {
                EnemyDataTool.CreateWindow(itemValue);
            }

            return itemValue;
        }

        private void DrawEmpty()
        {
            GUILayout.Label("No items in list.", EditorStyles.miniLabel);
        }
    }
}