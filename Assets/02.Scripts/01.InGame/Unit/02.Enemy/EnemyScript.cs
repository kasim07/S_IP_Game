using UnityEngine;
using System.Collections;

public class EnemyScript : UnitBase
{
    // Test : Not use Awake plz Delete
    private void Awake()
    {
        //GetScripts();
        //SetData(new UnitData(UnitType.Enemy, 2f, 10, 1, true));
    }

    public override void Dead()
    {
        EnemyManager.Instance.SetDisableEnemy(this);
    }
}