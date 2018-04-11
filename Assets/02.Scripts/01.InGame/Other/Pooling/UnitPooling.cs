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
        int count = m_DisablePool.Count;

        if (count == 0)
        {
            CreateObjects(10);
        }

        PoolObject result = m_DisablePool[0];

        m_DisablePool.Remove(result);
        m_EnablePool.Add(result);
        
        return result;
    }

    public void SetDisabeObject(PoolObject obj)
    {
        obj.SetActive(false);
        m_EnablePool.Remove(obj);
        m_DisablePool.Add(obj);
    }

    public void AllEnableAction()
    {
        int count = m_EnablePool.Count;

        for (int i = 0; i < count; i++)
        {
            m_EnablePool[i].Action();
        }
    }
}
