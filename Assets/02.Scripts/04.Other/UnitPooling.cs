using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UnitPooling<PoolObject> : IObjectPooling<PoolObject> where PoolObject : MonoBehaviour, IPoolObject, Itk2dSprite, IUnit
{
    private List<PoolObject> m_Pool;
    private PoolObject m_Prefab;
    private Transform m_Parent;

    public void InitPoolingData(PoolObject obj, Transform parent, int count)
    {
        m_Pool = new List<PoolObject>(count);
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
            m_Pool.Add(obj);
        }
    }

    public PoolObject GetDisableObject()
    {
        int count = m_Pool.Count;

        for (int i = 0; i < count; i++)
        {
            if (m_Pool[i].GetActive() == false)
            {
                return m_Pool[i];
            }
        }

        CreateObjects(10);

        return GetDisableObject();
    }    
}
