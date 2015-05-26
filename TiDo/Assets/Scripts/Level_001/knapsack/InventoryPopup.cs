using UnityEngine;
using UnityEngine.UI;
using System.Collections;
/// <summary>
/// 非装备的弹出框（药品等能使用的）
/// </summary>
public class InventoryPopup : MonoBehaviour {
    //名称
    public Text nameLabel;
    //图
    public Image inventoryImage;
    //描述
    public Text desLabel;
    //使用Button
    public Button useButton;
    //物品弹出框
    public GameObject imageInventoryPopup;
    //当前弹出物品
    private InventoryItemUI itemUI;
    /// <summary>
    /// 物品弹出
    /// </summary>
    /// <param name="itemUI"></param>
    public void RecMsgFromInventoryManager(InventoryItemUI itemUI)
    {
        this.itemUI = itemUI;
        imageInventoryPopup.SetActive(true);
        nameLabel.text = itemUI.iItem.Inventory.Name;
        inventoryImage.sprite = SpriteManger.spriteDic[itemUI.iItem.Inventory.ICON.Trim()]; ;
        desLabel.text = itemUI.iItem.Inventory.Des;
    }

    public void OnUseButtonClick()
    {
        itemUI.ChangeCount(1);
        imageInventoryPopup.SetActive(false);
    }

}
