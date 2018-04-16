using UnityEngine;
using System.Collections;

public class PlayerScript : UnitBase
{
    private void Awake()
    {
        GetScripts();
    }

    public override void Shoot()
    {
        BulletScript bullet =
            BulletManager.Instance.GetNewActiveBullet(
                new UnitData(UnitType.Player_Bullet, 5f, 0f, 1, 1, 1, true)
                , GetPosition()
                , SpriteNames.Bullet_Normal
                , new BulletNormalAction()
            );
    }

    public override void Dead()
    {
        SetActive(false);
    }
}
