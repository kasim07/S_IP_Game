using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPrefabDisable : MonoBehaviour {
    private void Awake()
    {
        gameObject.SetActive(false);
    }
}
