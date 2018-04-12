using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoShootButton : MonoBehaviour {

    private bool m_IsAutoShoot;
    private CustomTimer m_Timer;
    private UnitData m_PlayerData;
    private void Awake()
    {
        m_PlayerData = PlayerManager.Instance.GetPlayer().GetData();
        m_Timer = new CustomTimer(m_PlayerData.shootSpeed);
        m_IsAutoShoot = true;
    }

    public void OnClick()
    {
        m_IsAutoShoot = !m_IsAutoShoot;
    }

    private void Update()
    {
        if (m_IsAutoShoot)
        {
            if (!m_Timer.Playing(m_PlayerData.shootSpeed))
            {
                PlayerManager.Instance.Shoot();
                m_Timer.ResetTimer();
            }
        }
    }
}
