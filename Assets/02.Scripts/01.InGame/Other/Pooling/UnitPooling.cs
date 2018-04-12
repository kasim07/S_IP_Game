using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UnitPooling<PoolObject> : IObjectPooling<PoolObject> where PoolObject : MonoBehaviour, IPoolObject, Itk2dSprite, IUnit
{
    private List<PoolObject> m_DisablePool;
    private List<PoolObject> m_EnablePool;
    private PoolObject m_Prefab;
    private Transform m_Parent;

    public void InitPoolingData(PoolObject obj, Transform parent, int count)
    {
        m_DisablePool = new List<PoolObject>(count);
        m_EnablePool = new List<PoolObject>(count);

        m_Parent = parent;
        m_Prefab = obj;
        CreateObjects(count);
    }

    public void CreateObjects(int count)
    {
        for (int i = 0; i < count; i++)
        {
            PoolObject obj = GameObject.Instantiate(m_Prefab);
            obj.InitCreate();
            obj.GetTransfrom().SetParent(m_Parent);
            m_DisablePool.Add(obj);
        }
    }

    public PoolObject GetDisableObject()
    {
        if (m_DisablePool.Count == 0)
        {
            CreateObjects(10);
        }

        PoolObject result = m_DisablePool[0];
        SetEnableObject(result);

        return result;
    }

    public void SetEnableObject(PoolObject obj)
    {
        m_EnablePool.Add(obj);
        m_DisablePool.Remove(obj);
    }

    public void SetDisableObject(PoolObject obj)
    {
        m_EnablePool.Remove(obj);
        m_DisablePool.Add(obj);
    }

    public void AllEnableAction()
    {
        for (int i = 0; i < m_EnablePool.Count; i++)
        {
            m_EnablePool[i].Action();
        }
    }
}
