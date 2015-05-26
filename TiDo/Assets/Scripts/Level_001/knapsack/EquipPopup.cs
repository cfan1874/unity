using UnityEngine;
using UnityEngine.UI;
using System.Collections;
/// <summary>
/// 装备的弹出框，如果为背包点击就弹出左边，人物装备点击就弹出右边
/// </summary>
public class EquipPopup : MonoBehaviour {

    //名称
    public Text nameLabel;
    //图
    public Image inventoryImage;
    //战斗力
    public Text powerLabel;
    //品质
    public Text qualityLabel;
    //生命
    public Text hpLabel;
    //伤害
    public Text damageLabel;
    //等级
    public Text levelLabel;
    //描述
    public Text desLabel;
    //使用Button
    public Button useButton;
    //物品弹出框
    public GameObject imageEquipPopup;
    //装备栏弹出装备
    private RoleEquipItemUI itemRoleUI;
    //背包弹出装备
    private InventoryItemUI itemUi;

    /// <summary>
    /// 背包弹出装备赋值
    /// </summary>
    /// <param name="itemUI"></param>
    public void RecMsgFromInventoryManagerLeft(InventoryItemUI itemUI)
    {
        imageEquipPopup.SetActive(true);
        this.itemUi = itemUI;
        nameLabel.text = itemUI.iItem.Inventory.Name;
        inventoryImage.sprite = SpriteManger.spriteDic[itemUI.iItem.Inventory.ICON.Trim()]; ;
        powerLabel.text = itemUI.iItem.Inventory.Power + "";
        qualityLabel.text = itemUI.iItem.Inventory.Quality + "";
        hpLabel.text = itemUI.iItem.Inventory.HP + "";
        damageLabel.text = itemUI.iItem.Inventory.Damage + "";
        levelLabel.text = itemUI.iItem.Inventory.StarLevel + "";
        desLabel.text = itemUI.iItem.Inventory.Des + "";
    }
    /// <summary>
    /// 人物栏弹出装备赋值
    /// </summary>
    /// <param name="itemUI"></param>
    public void RecMsgFromInventoryManagerRight(RoleEquipItemUI itemRoleUI)
    {

        imageEquipPopup.SetActive(true);
        this.itemRoleUI = itemRoleUI;
        nameLabel.text = itemRoleUI.iItem.Inventory.Name;
        inventoryImage.sprite = SpriteManger.spriteDic[itemRoleUI.iItem.Inventory.ICON.Trim()]; ;
        powerLabel.text = itemRoleUI.iItem.Inventory.Power + "";
        qualityLabel.text = itemRoleUI.iItem.Inventory.Quality + "";
        hpLabel.text = itemRoleUI.iItem.Inventory.HP + "";
        damageLabel.text = itemRoleUI.iItem.Inventory.Damage + "";
        levelLabel.text = itemRoleUI.iItem.Inventory.StarLevel + "";
        desLabel.text = itemRoleUI.iItem.Inventory.Des + "";
    }
    /// <summary>
    /// 装上或卸下按钮点击
    /// </summary>
    public void OnUseButtonClick()
    {
        if (gameObject.name == "EquipPopupLeft")
        {
            //装上
            GameObject.Find("RoleEquipUI").SendMessage("RecMsgFromEquipPopupUp", itemUi);
            //清空背包栏的格子
            itemUi.Clear();
            imageEquipPopup.SetActive(false);
        }
        if (gameObject.name == "EquipPopupRight")
        {
            //卸下
            GameObject.Find("RoleEquipUI").SendMessage("RecMsgFromEquipPopupDown", itemRoleUI);
            imageEquipPopup.SetActive(false);
        }
    }

}
