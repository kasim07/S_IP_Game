using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageButton : MonoBehaviour {

    private UISprite m_Sprite;
    private UILabel m_Label;
    private UIGrid m_Grid;

	private void Awake () {
        m_Sprite = GetComponent<UISprite>();
        m_Label = transform.GetChild(0).GetComponent<UILabel>();
        m_Grid = transform.parent.GetComponent<UIGrid>();

    }
	
    public void OnClick()
    {
        Debug.Log("Click");
        m_Sprite.height = 600;
        m_Grid.cellHeight = 300;
        m_Grid.repositionNow = true;
    }
}
