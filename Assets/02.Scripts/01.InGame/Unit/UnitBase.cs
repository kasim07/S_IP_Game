using UnityEngine;
using System.Collections;

public abstract class UnitBase : MonoBehaviour, Itk2dSprite , IUnit, IPoolObject
{
    protected UnitData m_UnitData;
    protected GameObject m_GameObject;
    protected Transform m_Trans;
    protected tk2dSprite m_Sprite;

    public void InitCreate()
    {
        GetScripts();
        SetActive(false);
    }
    protected virtual void GetScripts()
    {
        m_Trans = GetComponent<Transform>();
        m_GameObject = m_Trans.gameObject;
        m_Sprite = GetComponent<tk2dSprite>();
    }

    public Transform GetTransfrom()
    {
        return m_Trans;
    }
    public GameObject GetGameObject()
    {
        return m_GameObject;
    }

    public bool GetActive()
    {
        return m_GameObject.activeSelf;
    }
    public void SetActive(bool isAwake)
    {
        if (GetActive() != isAwake)
            m_GameObject.SetActive(isAwake);
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

    public string GetTag()
    {
        return m_GameObject.tag;
    }

    public void SetTag(string str)
    {
        m_GameObject.tag = str;
    }

    /// <summary>
    /// mul 100 (pixel per meter)
    /// </summary>
    /// <param name="position"></param>
    public virtual void Move(Vector2 position)
    {
        SetPosition(GetPosition() + (position * 100));
        PushObjectBackView();
    }
    protected virtual void PushObjectBackView()
    {
        Vector2 pos = GetPosition();
        float halfScale = m_Sprite.scale.x * 0.5f;

        if (pos.x < halfScale)
        {
            pos.x = halfScale;
        }
        else if(pos.x > ConstValue.WIDTH - halfScale)
        {
            pos.x = ConstValue.WIDTH - halfScale;
        }
        else
        {
            return;
        }

        SetPosition(pos);
    }

    public virtual void Action() { }
    public virtual void Shoot() { }   
    public virtual void Hit(uint damage)
    {
        GetData().Hit(damage);
        if(GetData().life == false)
        {
            Dead();
        }
    }
    public abstract void Dead();
}
