using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUnit {
    void Shoot();
    void Hit(uint damage);
    void Dead();
    UnitData GetData();
    void SetData(UnitData data);
    Vector2 GetPosition();
    void SetPosition(Vector2 position);
    void MovePosition(Vector2 position);
}


public struct UnitData
{
    public UnitType type;
    public float speed;
    public uint healthPoint;
    public uint lifePoint;
    public bool life;

    public UnitData(UnitType type, float speed, uint healthPoint, uint lifePoint, bool life)
    {
        this.type = type;
        this.speed = speed;
        this.healthPoint = healthPoint;
        this.lifePoint = lifePoint;
        this.life = life;
    }
}

public enum UnitType
{
    Player,
    Enemy,
    PlayerShoot,
    EnemyShoot,
}
