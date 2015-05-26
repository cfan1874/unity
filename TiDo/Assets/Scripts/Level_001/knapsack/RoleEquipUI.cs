using UnityEngine;
using UnityEngine.UI;
using System.Collections;
/// <summary>
/// 管理装备的穿上或卸下等……
/// </summary>
public class RoleEquipUI : MonoBehaviour
{
    //八个装备栏
    public RoleEquipItemUI helmEquip;
    public RoleEquipItemUI clothEquip;
    public RoleEquipItemUI weaponEquip;
    public RoleEquipItemUI shoesEquip;
    public RoleEquipItemUI necklackEquip;
    public RoleEquipItemUI braceletEquip;
    public RoleEquipItemUI ringEquip;
    public RoleEquipItemUI wingEquip;
    private InventoryItem item;
    private InventoryItemUI itemUi;
    /// <summary>
    /// 穿上
    /// </summary>
    public void RecMsgFromEquipPopupUp(InventoryItemUI itemUi)
    {
            this.itemUi=itemUi;
            this.item = itemUi.iItem;
            switch (itemUi.iItem.Inventory.EquipTYPE)
            {                
                case EquipType.Helm:
                    DressUp(helmEquip);
                    break;
                case EquipType.Cloth:
                    DressUp(clothEquip);
                    break;
                case EquipType.Weapon:
                    DressUp(weaponEquip);
                    break;
                case EquipType.Shoes:
                    DressUp(shoesEquip);
                    break;
                case EquipType.Necklace:
                    DressUp(necklackEquip);
                    break;
                case EquipType.Bracelet:
                    DressUp(braceletEquip);
                    break;
                case EquipType.Ring:
                    DressUp(ringEquip);
                    break;
                case EquipType.Wing:
                    DressUp(wingEquip);
                    break;
            }
    }
    /// <summary>
    /// 装备（动词）
    /// </summary>
    /// <param name="roleUI">要装备的物品</param>
    private void DressUp(RoleEquipItemUI roleUI)
    {
        //当前已有装备，先把装备卸下
        if (roleUI.IsDressOn)
        {
            //RecMsgFromEquipPopupDown(roleUI);
            roleUI.SetInventoryItem(item);
        }
        //当前无装备，直接穿上
        else
        {
            roleUI.SetInventoryItem(item);
        }
    }
    /// <summary>
    /// 卸下(理解为：添加到背包)
    /// </summary>
    public void RecMsgFromEquipPopupDown(RoleEquipItemUI roleUI)
    {
        roleUI.Clear();
    }
}
