using UnityEngine;
using System.Collections;

public class BulletActionController
{
    private IAction m_Action;

    public BulletActionController()
    {
    }
    public BulletActionController(IAction action)
    {
        ChangeAction(action);
    }

    public void ChangeAction(IAction action)
    {
        m_Action = action;
    }

    public void Action()
    {
        if (m_Action == null)
        {
            Debug.Log("Empty Action");
            return;
        }
        m_Action.Action();
    }
}
