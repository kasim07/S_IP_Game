using UnityEngine;
using System.Collections;

public class PlayerScript : UnitBase
{
    private void Awake()
    {
        GetScripts();
        SetData(new UnitData(UnitType.Player, 2f, 10, 3, true));
    }

    public override void Shoot()
    {
        Debug.Log(m_Sprite.scale.x);
        BulletScript bullet =
            BulletManager.Instance.GetNewActiveBullet(
                new UnitData(UnitType.PlayerBullet, 10f, 1, 1, true)
                , GetPosition()
                , SpriteNames.bullet_Normal
                , new NormalBulletAction()
            );
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
