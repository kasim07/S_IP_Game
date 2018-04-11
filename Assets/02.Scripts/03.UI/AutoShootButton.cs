using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoShootButton : MonoBehaviour {

    private bool m_IsAutoShoot;
    private WaitForSeconds m_ShootSpeed;

    private void Awake()
    {
        m_IsAutoShoot = true;
        m_ShootSpeed = new WaitForSeconds(0.5f);        
        StartCoroutine(ShootingCoroutine());
    }

    public void OnClick()
    {
        m_IsAutoShoot = !m_IsAutoShoot;
    }

    private IEnumerator ShootingCoroutine()
    {
        while (true)
        {
            if (m_IsAutoShoot)
            {
                PlayerManager.Instance.Shoot();
            }
            yield return m_ShootSpeed;
        }
    }
}
