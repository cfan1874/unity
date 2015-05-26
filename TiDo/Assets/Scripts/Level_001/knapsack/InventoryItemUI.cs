using UnityEngine;
using UnityEngine.UI;
using System.Collections;
/// <summary>
/// 附加在每个物品格子上面
/// </summary>
public class InventoryItemUI : MonoBehaviour
{
    //图片
    private Sprite sprite;
    //数量
    private Text label;
    //临时Text,保存当前物品的数量，最后赋值给物品的Text
    private Text tempText;
    public InventoryItem iItem;

    private Sprite Sprite
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
    private Text Label
    {
        get
        {
            if (label == null)
            {
                label = gameObject.GetComponentsInChildren<Text>()[0];
            }
            return label;
        }
        set { gameObject.GetComponentsInChildren<Text>()[0] = value; }
    }
    /// <summary>
    /// 物品Item赋值
    /// </summary>
    /// <param name="it"></param>
    public void SetInventoryItem(InventoryItem it)
    {
        //临时Text,保存当前物品的数量，最后赋值给物品的Text
        tempText = Label;
        this.iItem = it;
        //如果没有此图集的装备，中断
        if (!SpriteManger.spriteDic.ContainsKey(it.Inventory.ICON.Trim()))
        {
            return;
        }
        Sprite = SpriteManger.spriteDic[it.Inventory.ICON.Trim()];  
        //数量小于1就不显示
        if (it.Count <= 1)
        {
            tempText.text = "";
        }
        else
        {
            tempText.text = it.Count.ToString();
        }
        //赋值
        Label = tempText;
        tempText = null;
    }
    /// <summary>
    /// 清除物品
    /// </summary>
    public void Clear()
    {
        InventoryManager.instance.RemoveInventoryItem(iItem);
        Sprite = SpriteManger.spriteDic["bg_道具"] ;
    }
    /// <summary>
    /// 物品点击
    /// </summary>
    public void OnClick()
    {
        if (iItem != null)
        {
            GameObject.Find("InventoryManager").SendMessage("RecMsgFromInventoryItemUI", this);
        }
    }
    /// <summary>
    /// 物品使用
    /// </summary>
    /// <param name="count">使用的数量</param>
    public void ChangeCount(int count)
    {
        iItem.Count -= count;
        if (iItem.Count <= 0)
        {
            Clear();
        }
        else if (iItem.Count == 1)
        {
            tempText = Label;
            tempText.text = "";
            Label = tempText;
        }
        else
        {
            tempText = Label;
            tempText.text = (iItem.Count).ToString();
            Label = tempText;
        }
    }
}
