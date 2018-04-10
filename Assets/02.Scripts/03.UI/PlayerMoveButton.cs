using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveButton : MonoBehaviour {

    private Vector2 m_PivotPosition;
    private PlayerScript m_Player;
    private bool m_IsPress;

    private void Awake()
    {
        m_Player = PlayerManager.Instance.GetPlayer();
        m_PivotPosition = UICamera.mainCamera.WorldToScreenPoint(transform.position);

        StartCoroutine(MoveCoroutine());
    }

    public void OnPress(bool isPress)
    {
        if (m_IsPress != isPress)
        {
            m_IsPress = isPress;
        }
    }

    private IEnumerator MoveCoroutine()
    {
        while (true)
        {
            if (m_IsPress)
            {
                m_Player.MovePosition(GetDirection() * m_Player.GetData().speed);
            }
            yield return cTime.m_WFS;
        }
    }

    private Vector2 GetDirection()
    {
        Vector2 dir = Vector2.zero;
        Vector2 pos = UICamera.lastEventPosition;

        CDebug.Log(pos.y + " " + m_PivotPosition.y);

        if (pos.y > m_PivotPosition.y) return dir;
        if(pos.x < m_PivotPosition.x)
        {
            dir = Vector2.left;
        }
        else
        {
            dir = Vector2.right;
        }
        return dir;
    }
}
