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
        static private EnemyStageList stageData;
        static private EnemyDataTool enemyDataWindow;
        static private string path = "Assets/02.Scripts/Editor/StageList.txt";
        static private int[] stageLevel;
        static private string[] stageNames;
        private Vector2 _scrollPosition;
        private int frontLevel = 1, backLevel = 1;

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
            try
            {
                stageData = Json<EnemyStageList>.Read(FileIO.ReadStringFromFile(path));
            }
            catch
            {
                Debug.Log("Load Error :  StageList");
            }

            if(stageData == null)
            {
                stageData = new EnemyStageList();
            }

            Debug.Log(stageData);
        }

        static public void SaveData()
        {
            //string test = "absc";
            string data = Json<EnemyStageList>.Write(stageData);
            //string data = Json<string>.Write(test);
            FileIO.WriteStringToFile(data, path);
        }

        private void OnGUI()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(frontLevel);
            builder.Append("_");
            builder.Append(backLevel);

            if(!stageData.m_StageList.ContainsKey(builder.ToString()))
            {
                stageData.m_StageList.Add(builder.ToString(), new List<EnemyBuildData>());
            }

            ViewList(builder.ToString(), stageData.m_StageList[builder.ToString()]);

            GUILayout.BeginHorizontal();
            EditorGUILayout.LabelField("Stage");
            frontLevel = EditorGUILayout.IntPopup("", frontLevel, stageNames, stageLevel);
            backLevel = EditorGUILayout.IntPopup("", backLevel, stageNames, stageLevel);
            GUILayout.EndHorizontal();

            GUILayout.BeginHorizontal();
            if (GUILayout.Button("Save"))
            {
                SaveData();
            }
            GUILayout.EndHorizontal();
        }

        private void ViewList(string stageName, List<EnemyBuildData> list)
        {
            _scrollPosition = GUILayout.BeginScrollView(_scrollPosition);

            ReorderableListGUI.Title(stageName);
            ReorderableListGUI.ListField(list, PendingItemDrawer, DrawEmpty);

            GUILayout.EndScrollView();
        }

        private EnemyBuildData PendingItemDrawer(Rect position, EnemyBuildData itemValue)
        {
            if(itemValue == null)
            {
                itemValue = new EnemyBuildData();                   
            }
            position.width -= 50;
            itemValue.spriteName = EditorGUI.TextField(position, itemValue.spriteName);


            position.x = position.xMax + 5;
            position.width = 45;           
            if (GUI.Button(position, "Info"))
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