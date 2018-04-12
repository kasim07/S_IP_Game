﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyManager : SingletonManager<EnemyManager>
{
    [Header("Prefab")]
    [SerializeField]
    private EnemyScript m_EnemyPrefab;
    [Header("Parent")]
    [SerializeField]
    private Transform m_EnemyParent;

    private UnitPooling<EnemyScript> m_EnemyPool;

    protected EnemyManager() { }

    private void Awake()
    {
        m_EnemyPool = new UnitPooling<EnemyScript>();
        m_EnemyPool.InitPoolingData(m_EnemyPrefab, m_EnemyParent, 30);
    }

    public EnemyScript GetNewActiveEnemy(UnitData data, Vector2 pos, string spriteName)
    {
        EnemyScript enemy = m_EnemyPool.GetDisableObject();

        enemy.SetData(data);
        enemy.SetSpriteName(spriteName);
        SetEnableEnemy(enemy);

        return enemy;
    }

    private void SetEnableEnemy(EnemyScript enemy)
    {
        enemy.SetActive(true);
        m_EnemyPool.SetEnableObject(enemy);
    }
    public void SetDisableEnemy(EnemyScript enemy)
    {
        enemy.SetActive(false);
        m_EnemyPool.SetDisableObject(enemy);
    }

}
