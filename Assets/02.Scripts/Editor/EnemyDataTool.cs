using System.Collections;
using System.Collections.Generic;
using System.IO;
using tk2dEditor.SpriteCollectionEditor;
using UnityEditor;
using UnityEngine;


namespace Editors {
    public class EnemyDataTool : EditorWindow {
        static private EnemyDataTool window;

        private EnemyBuildData data = new EnemyBuildData();
        private tk2dSpriteCollection collection;
        private SpriteCollectionProxy proxy;
        private List<Texture> textures;
        private Texture2D selectTexture;
        private int selectIndex = -1;
        private string path = "Assets/Collection/Unit/UnitCollection.prefab";

        public void InitData()
        {
            textures = new List<Texture>(10);
            collection = AssetDatabase.LoadAssetAtPath<tk2dSpriteCollection>(path);
            proxy = new SpriteCollectionProxy(collection);
            var list = proxy.textureParams;

            for (int i = 0; i < list.Count; i++)
            {
                var param = proxy.textureParams[i];
                if(param.name != string.Empty)
                {
                    textures.Add(param.texture);
                }
            }

            selectTexture = new Texture2D(1, 1);
            selectTexture.alphaIsTransparency = true;
            selectTexture.filterMode = FilterMode.Point;
            selectTexture.SetPixel(0, 0, new Color(.5f, .5f, 1f, .5f));
            selectTexture.Apply();
        }

        [MenuItem("CustumTool/Input Enemy Data")]
        static public void CreateWindow()
        {
            window = GetWindow<EnemyDataTool>();
            window.InitData();
            window.Show();
        }
        [MenuItem("CustumTool/Close")]
        static public void CloseWindow()
        {
            if(window != null)
                window.Close();
        }
        ///*
        private void OnGUI()
        {
            int i = 0, j = 0;
            int x = 64, y = 64;

                        

            int columnCount = Mathf.RoundToInt((position.width) / 38) - 2;

            GUILayout.Label("Image Select");
            Vector2 tileScrollPosition = Vector2.zero;

            tileScrollPosition = EditorGUILayout.BeginScrollView(tileScrollPosition, false, true, GUILayout.Width(position.width));

            GUILayout.BeginHorizontal();
            int length = textures.Count;
            

            for (int q = 0; q < length; q++)
            {
                if (GUILayout.Button(textures[q], GUILayout.Width(x + 8), GUILayout.Height(y + 8)))
                {
                    data.spriteName = textures[q].name;
                    selectIndex = q;                    
                }

                //GUI.DrawTexture(new Rect(8 + (j * (x + 12)), 8 + (i * (y + 8)), x, y), textures[q], ScaleMode.ScaleToFit);

                if(q == selectIndex)
                {
                    GUI.DrawTexture(new Rect(8 + (j * (x + 12)), 8 + (i * (y + 8)), x, y), selectTexture, ScaleMode.ScaleToFit);
                }

                if (j < columnCount)
                {
                    j++;
                }
                else
                {
                    // if we have enough columns to fill the scroll area, reset the column count and start a new line of buttons
                    j = 0;
                    i++;
                    GUILayout.EndHorizontal();
                    GUILayout.BeginHorizontal();
                }
            }

            GUILayout.EndHorizontal(); 
            EditorGUILayout.EndScrollView();


            GUILayout.Label("Input Data");
            data.baseData.type = UnitType.Enemy;
            data.baseData.moveSpeed = EditorGUILayout.FloatField("Move Speed", data.baseData.moveSpeed);
            data.baseData.shootSpeed = EditorGUILayout.FloatField("Shoot Speed", data.baseData.shootSpeed);
            data.baseData.damage = EditorGUILayout.IntField("Default Damage", data.baseData.damage);            
            data.baseData.FillHealthPoint(EditorGUILayout.IntField("Health Point", data.baseData.maxHealthPoint));
            data.baseData.lifePoint = EditorGUILayout.IntField("Life Point", data.baseData.lifePoint);
            data.baseData.life = true;
            
            

            if (GUILayout.Button("Done"))
            {
                CloseWindow();
            }
        }
        //*/
    }
}
