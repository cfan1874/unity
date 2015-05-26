using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RoleEquipItemUI : MonoBehaviour
{
    //图片
    private Sprite sprite;
    //装备属性
    public InventoryItem iItem;
    //是否已装备
    private bool isDressOn;

    public bool IsDressOn
    {
        get { return isDressOn; }
        set { isDressOn = value; }
    }
    public Sprite Sprite
    {
        get
        {
            if (sprite == null)
            {
                sprite = gameObject.GetComponentsInChildren<Image>()[1].sprite;
            }
            return sprite;
        }
        set { gameObject.GetComponentsInChildren<Image>()[1].sprite = value; }
    }
    /// <summary>
    /// 穿上
    /// </summary>
    /// <param name="it"></param>
    public void SetInventoryItem(InventoryItem iItem)
    {
        if (iItem == null) return;
        this.iItem = iItem;
        Sprite = SpriteManger.spriteDic[iItem.Inventory.ICON.Trim()];
        IsDressOn = true;
        InventoryManager.instance.RemoveInventoryItem(iItem);
    }
    /// <summary>
    /// 装备点击,弹出框
    /// </summary>
    public void OnClick()
    {
        if (iItem != null)
        {
            GameObject.Find("InventoryManager").SendMessage("RecMsgFromRoleEquipItemUI", this);
        }
    }
    /// <summary>
    /// 清空,并把装备放回到背包
    /// </summary>
    public void Clear()
    {
        IsDressOn = false;
        InventoryManager.instance.AddInventoryItem(iItem);
        Sprite =SpriteManger.spriteDic["bg_道具"] ;
        iItem = null;
    }

}