using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class ActionFactroy
{
    public static IAction CreateAction(ActionType type)
    {
        switch (type)
        {
            case ActionType.Enemy_Normal:
                return new EnemyNormalAction();
            case ActionType.Enemy_Bullet_Normal:
            case ActionType.Player_Bullet_Normal:
                return new BulletNormalAction();
        }

        return null;
    }
}

[Serializable]
public enum ActionType
{
    Enemy_Normal,
    Enemy_Bullet_Normal,
    

    Player_Bullet_Normal,
}