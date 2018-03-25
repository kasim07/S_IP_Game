using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonManager<T> : MonoBehaviour where T : class
{
    private T m_Instance;

    public T Instance()
    {
        if(m_Instance == null)
        {
            m_Instance = GetComponent<T>();
        }
        
        return m_Instance;
    }
}
