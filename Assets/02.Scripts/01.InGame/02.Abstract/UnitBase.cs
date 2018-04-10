using UnityEngine;
using System.Collections;

public abstract class UnitBase : MonoBehaviour, Itk2dSprite , IUnit
{
    protected UnitData m_UnitData;
    protected GameObject m_GameObject;
    protected Transform m_Trans;
    protected tk2dSprite m_Sprite;

    
    protected virtual void GetScripts()
    {
        m_Trans = GetComponent<Transform>();
        m_GameObject = m_Trans.gameObject;
        m_Sprite = GetComponent<tk2dSprite>();
    }

    public UnitData GetData()
    {
        return m_UnitData;
    }
    public void SetData(UnitData data)
    {
        m_UnitData = data;
    }

    public Vector2 GetPosition()
    {
        return m_Trans.position;
    }
    public void SetPosition(Vector2 pos)
    {
        m_Trans.position = pos;
    }

    public string GetSpriteName()
    {
        return m_Sprite.name;
    }
    public void SetSpriteName(string name)
    {
        m_Sprite.SetSprite(name);
    }

    public void MovePosition(Vector2 position)
    {
        SetPosition(GetPosition() + position);
    }

    public abstract void Shoot();
    public abstract void Hit(uint damage);
    public abstract void Dead();

    
}
