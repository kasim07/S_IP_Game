using UnityEngine;
using System.Collections;

public class BulletScript : UnitBase
{
    private uint m_Damage;

    private BulletActionController m_BulletActionCtrl;

    private void Awake()
    {
        m_Damage = 2;
        m_BulletActionCtrl = new BulletActionController();
    }

    public void ChangeAction(IAction action)
    {
        m_BulletActionCtrl.ChangeAction(action);
    }

    public override void Dead()
    {
        BulletManager.Instance.SetDisableBullet(this);
    }

    public override void Action()
    {
        m_BulletActionCtrl.Action();

        if (CheckScreenOut())
        {
            Dead();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (CheckHit(other))
        {
            other.SendMessage(FunctionName.Hit, m_Damage);
            Debug.Log("OntriggerEnter Hit");
            Hit(GetData().damage);
        }
    }

    private bool CheckHit(Collider other)
    {
        if (GetData().type == UnitType.Player_Bullet)
        {
            if (other.tag.Contains(Tags.Enemy))
            {
                return true;
            }
        }
        else if (GetData().type == UnitType.Enemy_Bullet)
        {
            if (other.tag.Contains(Tags.Player))
            {
                return true;
            }
        }

        return false;
    }

    private bool CheckScreenOut()
    {
        Vector2 pos = GetPosition();
        float halfScale = m_Sprite.scale.x * 0.5f;

        if (pos.x < 0 || pos.x > ConstValue.WIDTH)
        {
            return true;
        }

        if (pos.y < 0 || pos.y > ConstValue.HEIGHT)
        {
            return true;
        }

        return false;
    }
}
