using UnityEngine;
using System.Collections;

public class NormalBulletAction : UnitBaseAction
{
    public override void Action()
    {
        if(m_Unit.GetData().type == UnitType.PlayerBullet)
        {
            m_Unit.Move(Vector2.up * m_Unit.GetData().speed * Time.deltaTime);
        }
        else if(m_Unit.GetData().type == UnitType.EnemyBullet)
        {
            m_Unit.Move(Vector2.down * m_Unit.GetData().speed * Time.deltaTime);
        }
    }
}
