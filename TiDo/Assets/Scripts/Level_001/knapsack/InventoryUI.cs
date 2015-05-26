using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
/// <summary>
/// 背包整理和初始化显示
/// </summary>
public class InventoryUI : MonoBehaviour
{
    //所有的物品格子
    public List<InventoryItemUI> itemUIList = new List<InventoryItemUI>();
    public Button buttonCleanUp;
    
    void Awake()
    {
        InventoryManager.instance.OnInventoryChange += this.UpdateShow;
    }

    void OnDestroy()
    {
        InventoryManager.instance.OnInventoryChange -= this.UpdateShow;
    }
    /// <summary>
    /// 背包显示
    /// </summary>
    void UpdateShow()
    {
        //格子赋值
        for (int i = 0; i < InventoryManager.instance.inventoryItemList.Count; i++)
        {
            InventoryItem it = InventoryManager.instance.inventoryItemList[i];
            itemUIList[i].SetInventoryItem(it);
        }
        //剩余格子清空
        for (int i = InventoryManager.instance.inventoryItemList.Count; i < itemUIList.Count; i++)
        {
            itemUIList[i].Clear();
        }
    }
    /// <summary>
    /// 添加物品到背包
    /// </summary>
    /// <param name="it"></param>
    public void AddInventoryItem(InventoryItem it)
    {
        foreach (InventoryItemUI itUI in itemUIList)
        {
            if (itUI.iItem == null)
            {
                itUI.SetInventoryItem(it);
                break;
            }
        }
    }
    /// <summary>
    /// 删除物品
    /// </summary>
    /// <param name="it"></param>
    public void RemoveInventoryItem(InventoryItem it)
    {
        foreach (InventoryItemUI itUI in itemUIList)
        {
            if (itUI.iItem.Inventory.ID == it.Inventory.ID)
            {
                itUI.Clear();
            }
        }
    }
    /// <summary>
    /// 整理
    /// </summary>
    public void OnCleanup()
    {
        UpdateShow();
    }
}
