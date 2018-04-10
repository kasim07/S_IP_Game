using UnityEngine;
using System.Collections;

public class PlayerScript : UnitBase
{
    private void Awake()
    {
        GetScripts();
        SetData(new UnitData(UnitType.Player, 3f, 10, 3, true));
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
