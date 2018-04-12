using UnityEngine;
using System.Collections;

public class NormalBulletAction : UnitBaseAction
{
    public override void Action()
    {
        if(m_Unit.GetData().type == UnitType.Player_Bullet)
        {
            m_Unit.Move(Vector2.up * m_Unit.GetData().moveSpeed * Time.deltaTime);
        }
        else if(m_Unit.GetData().type == UnitType.Enemy_Bullet)
        {
            m_Unit.Move(Vector2.down * m_Unit.GetData().moveSpeed * Time.deltaTime);
        }
    }
}
