using UnityEngine;
using System.Collections;

public class BulletScript : UnitBase
{
    private BulletActionController m_BulletActionCtrl;

    private void Awake()
    {
        m_BulletActionCtrl = new BulletActionController();
    }

    public void ChangeAction(IAction action)
    {
        m_BulletActionCtrl.ChangeAction(action);
    }

    public override void Hit(uint damage)
    {
        throw new System.NotImplementedException();
    }

    public override void Dead()
    {
        throw new System.NotImplementedException();
    }

    public override void Action()
    {
        m_BulletActionCtrl.Action();
    }
}
