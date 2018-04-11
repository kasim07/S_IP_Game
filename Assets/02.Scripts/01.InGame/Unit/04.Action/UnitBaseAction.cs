using UnityEngine;
using System.Collections;

public abstract class UnitBaseAction : IAction
{
    protected IUnit m_Unit;

    public void InitData(IUnit unit)
    {
        m_Unit = unit;
    }

    public abstract void Action();
}
