using UnityEngine;
using System.Collections;

public interface IPoolObject
{
    void InitCreate();
    Transform GetTransfrom();
    GameObject GetGameObject();
    bool GetActive();
    void SetActive(bool isAwake);   
}
