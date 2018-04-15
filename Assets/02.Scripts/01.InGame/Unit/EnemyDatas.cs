
using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class EnemyBuildData
{
    public UnitData baseData;
    public string spriteName;
    //public float waitTime;
    //public bool isPrevDead;
    //public ColorType colorType;
    //public Vector2 size;

    //fix Action -> id
    //public IAction action;

    public EnemyBuildData()
    {
        SetData(new UnitData(UnitType.Enemy, 0f, 0f, 0, 0, 0, true)
            , SpriteNames.Enemy_Normal);
    }

    public EnemyBuildData(UnitData data, string spriteName)
    {
        SetData(data, spriteName);
    }

    public void SetData(UnitData data, string spriteName)
    {
        if (baseData == null)
        {
            baseData = data;
        }
        else
        {
            baseData.Copy(data);
        }

        this.spriteName = spriteName;
    }

    public void SetData(EnemyBuildData data)
    {
        SetData(data.baseData, data.spriteName);
    }
}

[Serializable]
public class EnemyStageList
{
    public Dictionary<string, List<EnemyBuildData>> m_StageList = new Dictionary<string, List<EnemyBuildData>>();

    public EnemyStageList()
    {
    }
}