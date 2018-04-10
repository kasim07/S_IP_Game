using UnityEngine;
using System.Collections;

public class EnemyScript : UnitBase, IPoolObject
{
    public void InitCreate()
    {
        GetScripts();
        SetActive(false);
    }

    public Transform GetTransfrom()
    {
        return m_Trans;
    }
    public GameObject GetGameObject()
    {
        return m_GameObject;
    }

    public bool GetActive()
    {
        return m_GameObject.activeSelf;
    }
    public void SetActive(bool isAwake)
    {
        if (GetActive() != isAwake)
            m_GameObject.SetActive(isAwake);
    }


    public override void Shoot()
    {
        throw new System.NotImplementedException();
    }

    public override void Hit(uint damage)
    {
        throw new System.NotImplementedException();
    }

    public override void Dead()
    {
        throw new System.NotImplementedException();
    }

    
}
