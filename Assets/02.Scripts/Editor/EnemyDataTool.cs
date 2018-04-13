using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


namespace Editors {
    public class EnemyDataTool : EditorWindow {

        static private EnemyBuildData data = new EnemyBuildData();

        [MenuItem("CustumTool/Input Enemy Data")]
        static private void CreateWindow()
        {
            EnemyDataTool window = GetWindow<EnemyDataTool>();
            window.Show();
        }

        private void OnGUI()
        {
            data.enemyType = (EnemyType)EditorGUILayout.EnumMaskPopup("Enemy Type", data.enemyType);
            
            GUILayout.Label("Image Select");

            GUILayout.Label("Input Data");
            data.baseData.type = UnitType.Enemy;
            data.baseData.moveSpeed = EditorGUILayout.FloatField("Move Speed", data.baseData.moveSpeed);
            data.baseData.shootSpeed = EditorGUILayout.FloatField("Shoot Speed", data.baseData.shootSpeed);
            data.baseData.damage = EditorGUILayout.IntField("Default Damage", data.baseData.damage);            
            data.baseData.FillHealthPoint(EditorGUILayout.IntField("Health Point", data.baseData.maxHealthPoint));
            data.baseData.lifePoint = EditorGUILayout.IntField("Life Point", data.baseData.lifePoint);
            data.baseData.life = true;

            //tk2dSpriteCollection collection = new tk2dSpriteCollection();
            //collection.spriteSheets[0].texture

            if (GUILayout.Button("Done"))
            {
                
            }
        }
    }
}
