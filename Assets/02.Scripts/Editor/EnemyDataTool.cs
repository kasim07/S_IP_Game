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
        private Vector2 tileScrollPosition;

        static public void CreateWindow(EnemyBuildData data)
        {
            window = GetWindow<EnemyDataTool>("Enemy Data Tool");
            window.InitData();
            window.SetData(data);
            window.Show();
        }
        static public void CloseWindow()
        {
            if (window != null)
                window.Close();
        }

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
        public void SetData(EnemyBuildData data)
        {
            this.data = data;
        }

        ///*
        private void OnGUI()
        {
            SpriteButton();

            GUILayout.Label("Input Data");
            var columnWidth = GUILayout.Width(position.width / 2f - 6f);
            GUILayout.BeginVertical(columnWidth);
            data.baseData.type = UnitType.Enemy;
            data.baseData.moveSpeed = EditorGUILayout.FloatField("Move Speed", data.baseData.moveSpeed);
            data.baseData.shootSpeed = EditorGUILayout.FloatField("Shoot Speed", data.baseData.shootSpeed);
            data.baseData.damage = EditorGUILayout.IntField("Default Damage", data.baseData.damage);            
            data.baseData.FillHealthPoint(EditorGUILayout.IntField("Health Point", data.baseData.maxHealthPoint));
            data.baseData.lifePoint = EditorGUILayout.IntField("Life Point", data.baseData.lifePoint);
            data.baseData.life = true;

            Vector2 size = new Vector2(data.size.x, data.size.y);
            size = EditorGUILayout.Vector2Field("Size", size);
            data.size = new cVector2(size.x, size.y);

            //Vector2 size = data.size.GetVector();
            //size = EditorGUILayout.Vector2Field("Size", size);
            //data.size.SetVector(size);

            data.colorType = (ColorType)EditorGUILayout.EnumPopup("Color Type", data.colorType);
            //data.waitTime = EditorGUILayout.FloatField("Wait Time",data.waitTime);
            //data.holdUntilDead = EditorGUILayout.Toggle("Hold end ReStart Time", data.holdUntilDead);
            GUILayout.EndVertical();

            if (GUILayout.Button("Done"))
            {
                CloseWindow();
            }
        }
        //*/

        private void SpriteButton()
        {
            int i = 0, j = 0;
            int x = 64, y = 64;
            int columnCount = Mathf.RoundToInt((position.width) / y) - 2;

            GUILayout.Label("Image Select");
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

                if (q == selectIndex)
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
        }
    }
}
