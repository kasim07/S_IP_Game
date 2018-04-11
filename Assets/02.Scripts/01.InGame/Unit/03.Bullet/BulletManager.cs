using UnityEngine;
using System.Collections;

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
        StartCoroutine(BulletActionCoroutine());
    }

    public BulletScript GetNewActiveBullet(
        UnitData data, Vector2 pos, string spriteName, IAction action)
    {
        BulletScript bullet = m_BulletPool.GetDisableObject();
        InitBullet(data, pos, spriteName, bullet);

        action.InitData(bullet);
        bullet.ChangeAction(action);

        return bullet;
    }

    private void InitBullet(UnitData data, Vector2 pos, string spriteName, UnitBase unit)
    {
        unit.SetData(data);
        unit.SetPosition(pos);
        unit.SetSpriteName(spriteName);
        unit.SetActive(true);
    }

    private IEnumerator BulletActionCoroutine()
    {
        while (true)
        {
            m_BulletPool.AllEnableAction();
            yield return cTime.m_WaitDeltaTime;
        }
    }


    
}
