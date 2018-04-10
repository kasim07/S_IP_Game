using UnityEngine;

public class PlayerManager : SingletonManager<PlayerManager>
{
    protected PlayerManager() { }

    [SerializeField]
    private PlayerScript m_Player;

    public PlayerScript GetPlayer()
    {
        return m_Player;
    }
}
