using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BulletManager : SingletonManager<BulletManager>
{
    [Header("Prefab")]
    [SerializeField]
    private BulletScript m_BulletPrefab;
    [Header("Parent")]
    [SerializeField]
    private Transform m_BulletParent;
    private UnitPooling<BulletScript> m_BulletPool;

    protected BulletManager() { }
    // Use this for initialization
    private void Awake()
    {
        m_BulletPool = new UnitPooling<BulletScript>();
        m_BulletPool.InitPoolingData(m_BulletPrefab,m_BulletParent, 30);
    }

    public BulletScript GetNewActiveBullet(
        UnitData data, Vector2 pos, string spriteName, IAction action)
    {
        BulletScript bullet = m_BulletPool.GetDisableObject();

        bullet.SetData(data);
        if (data.type == UnitType.Player_Bullet)
        {
            bullet.SetTag(Tags.Player_Bullet);
        }
        else if (data.type == UnitType.Enemy_Bullet)
        {
            bullet.SetTag(Tags.Enemy_Bullet);
        }

        bullet.SetPosition(pos);
        bullet.SetSpriteName(spriteName);
        SetEnableBullet(bullet);

        action.InitData(bullet);
        bullet.ChangeAction(action);       

        return bullet;
    }

    private void SetEnableBullet(BulletScript bullet)
    {
        bullet.SetActive(true);
        m_BulletPool.SetEnableObject(bullet);
    }
    public void SetDisableBullet(BulletScript bullet)
    {
        bullet.SetActive(false);
        m_BulletPool.SetDisableObject(bullet);
    }

    private void Update()
    {
        m_BulletPool.AllEnableAction();
    }    
}
