
using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class cVector2
{
    public float x, y;

    public cVector2()
    {
        x = 0f;
        y = 0f;
    }

    public cVector2(float x, float y)
    {
        this.x = x;
        this.y = y;
    }

    //public Vector2 GetVector()
    //{
    //    return new Vector2(x, y);
    //}

    //public void SetVector(Vector2 vec)
    //{
    //    x = vec.x;
    //    y = vec.y;
    //}
}

[Serializable]
public class EnemyBuildData
{
    public UnitData baseData;
    public string spriteName;
    
    public cVector2 size;
    public ColorType colorType;
    public ActionType actionType;

    public float waitTime;
    public bool holdTimeUntilDead;

    //fix Action -> id
    //public IAction action;

    public EnemyBuildData()
    {
        SetData(new UnitData()
            , SpriteNames.Enemy_Normal
            , new cVector2(1f, 1f)
            , ColorType.White
            , ActionType.Enemy_Normal
            , 1f
            , false);
    }

    public EnemyBuildData(UnitData data, string spriteName, cVector2 size, ColorType colorType, ActionType actionType, float waitTime, bool holdTimeUntilDead)
    {
        SetData(data, spriteName, size, colorType, actionType, waitTime, holdTimeUntilDead);
    }

    public void SetData(UnitData data, string spriteName, cVector2 size, ColorType colorType, ActionType actionType, float waitTime, bool holdTimeUntilDead)
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
        this.size = size;
        this.colorType = colorType;
        this.actionType = actionType;
        this.waitTime = waitTime;
        this.holdTimeUntilDead = holdTimeUntilDead;
    }

    public void SetData(EnemyBuildData data)
    {
        if (data == null)
        {
            SetData(new UnitData()
            , SpriteNames.Enemy_Normal
            , new cVector2(1f, 1f)
            , ColorType.White
            , ActionType.Enemy_Normal
            , 1f
            , false);
        }
        else
        {
            SetData(data.baseData, data.spriteName, data.size, data.colorType, data.actionType, data.waitTime, data.holdTimeUntilDead);
        }
    }
}


[Serializable]
public class EnemyStageDictionary
{
    public Dictionary<string, EnemyStageList> m_Dictionary = new Dictionary<string, EnemyStageList>();

    public EnemyStageDictionary()
    {
    }
}
[Serializable]
public class EnemyStageList
{
    public List<EnemyBuildData> m_List = new List<EnemyBuildData>();

    public EnemyStageList()
    {
    }

    public EnemyStageList(List<EnemyBuildData> data)
    {
        m_List = data;
    }
}
