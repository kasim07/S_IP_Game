using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public interface IObjectPooling<T> where T : IPoolObject
{
    void InitPoolingData(T obj, Transform parent, int count);
    void CreateObjects(int count);
    T GetDisableObject();
}
