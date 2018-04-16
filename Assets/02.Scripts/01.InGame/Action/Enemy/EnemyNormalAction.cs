using UnityEngine;
using System.Collections;

public class EnemyNormalAction : UnitBaseAction
{
    public override void Action()
    {
        m_Unit.Move(Vector2.down * m_Unit.GetData().moveSpeed * Time.deltaTime);
    }
}
