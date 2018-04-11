using UnityEngine;

public class PlayerManager : SingletonManager<PlayerManager>
{
    [Header("Init Data")]
    [SerializeField]
    private UnitData m_DefualtData;

    protected PlayerManager() { }

    [SerializeField]
    private PlayerScript m_Player;
    public PlayerScript GetPlayer()
    {
        return m_Player;
    }

    private void Awake()
    {
        m_Player.SetData(m_DefualtData);
    }

    public void Shoot()
    {
        m_Player.Shoot();
    }
}
