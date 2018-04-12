using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUnit {

    void Shoot();
    void Action();
    void Move(Vector2 position);
    void Hit(uint damage);
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
    public uint damage;

    public uint maxHealthPoint;
    public uint currentHealthPoint;

    public uint lifePoint;
    public bool life;

    public UnitData(UnitType type, float moveSpeed, float shootSpeed, uint damage, uint healthPoint, uint lifePoint, bool life)
    {
        SetData(type, moveSpeed, shootSpeed, damage, healthPoint, lifePoint, life);
    }

    public void SetData(UnitType type, float moveSpeed, float shootSpeed, uint damage, uint healthPoint, uint lifePoint, bool life)
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


    public void Hit(uint damage)
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
                life = false;
            }
        }
        else
        {
            currentHealthPoint -= damage;
        }
    }
}

