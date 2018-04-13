using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUnit {

    void Shoot();
    void Action();
    void Move(Vector2 position);
    void Hit(int damage);
    void Dead();

    UnitData GetData();
    void SetData(UnitData data);

    Vector2 GetPosition();
    void SetPosition(Vector2 position);

    string GetTag();
    void SetTag(string str);    
}


[Serializable]
public class UnitData
{
    public UnitType type;
    public float moveSpeed;
    public float shootSpeed;
    public int damage;

    public int maxHealthPoint;
    public int currentHealthPoint;

    public int lifePoint;
    public bool life;

    public UnitData(UnitType type, float moveSpeed, float shootSpeed, int damage, int healthPoint, int lifePoint, bool life)
    {
        SetData(type, moveSpeed, shootSpeed, damage, healthPoint, lifePoint, life);
    }

    public void SetData(UnitType type, float moveSpeed, float shootSpeed, int damage, int healthPoint, int lifePoint, bool life)
    {
        this.type = type;
        this.moveSpeed = moveSpeed;
        this.shootSpeed = shootSpeed;
        this.damage = damage;
        this.maxHealthPoint = healthPoint;
        this.currentHealthPoint = healthPoint;
        this.lifePoint = lifePoint;
        this.life = life;
    }

    public void Copy(UnitData data)
    {
        this.type = data.type;
        this.moveSpeed = data.moveSpeed;
        this.shootSpeed = data.shootSpeed;
        this.damage = data.damage;
        this.maxHealthPoint = data.maxHealthPoint;
        this.currentHealthPoint = data.currentHealthPoint;
        this.lifePoint = data.lifePoint;
        this.life = data.life;
    }


    public void Hit(int damage)
    {
        if(currentHealthPoint <= damage)
        {
            if(lifePoint > 1)
            {
                lifePoint -= 1;
                currentHealthPoint = maxHealthPoint;
            }
            else
            {
                lifePoint = 0;
                life = false;
            }
        }
        else
        {
            currentHealthPoint -= damage;
        }
    }

    public void FillHealthPoint()
    {
        currentHealthPoint = maxHealthPoint;
    }

    public void FillHealthPoint(int maxHealthPoint)
    {
        this.maxHealthPoint = maxHealthPoint;
        FillHealthPoint();
    }
}

[Serializable]
public class EnemyBuildData
{
    public UnitData baseData;
    public string spriteName;
    public EnemyType enemyType;

    public EnemyBuildData()
    {
        SetData(new UnitData(UnitType.Enemy, 0f, 0f, 0, 0, 0, true)
            , SpriteNames.Enemy_Normal
            , EnemyType.Enemy_Normal);
    }

    public EnemyBuildData(UnitData data, string spriteName, EnemyType type)
    {
        SetData(data, spriteName, type);
    }

    public void SetData(UnitData data, string spriteName, EnemyType type)
    {
        if(baseData == null)
        {
            baseData = data;
        }
        else
        {
            baseData.Copy(data);
        }

        this.spriteName = spriteName;
        this.enemyType = type;
    }

    public void SetData(EnemyBuildData data)
    {
        SetData(data.baseData, data.spriteName, data.enemyType);
    }
}
