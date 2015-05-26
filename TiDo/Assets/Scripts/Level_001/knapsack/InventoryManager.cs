using UnityEngine;
using System.Collections;
using System.Collections.Generic;
/// <summary>
/// 完成物品信息的读取，读取后存放在list里面
/// </summary>
public class InventoryManager : MonoBehaviour
{
    //当前类的单例
    public static InventoryManager instance;
    //物品信息的文本文件
    public TextAsset listinfo;
    //存放所有物品Inventory，key为ID
    public Dictionary<int, Inventory> inventoryDict = new Dictionary<int, Inventory>();
    //使用list替代dictionary的是因为：key此处有可能重复。
    public List<InventoryItem> inventoryItemList = new List<InventoryItem>();
    //委托当背包物品改变了，更新显示
    public delegate void OnInventoryChangeEvent();
    public event OnInventoryChangeEvent OnInventoryChange;

    void Awake()
    {
        instance = this;
        ReadInventoryInfo();
    }
    void Start()
    {
        ReadInventoryItemInfo();
    }
    /// <summary>
    /// 读取文本文件，获取装备信息
    /// ps.练手项目，就不连接数据库操作了
    /// </summary>
    private void ReadInventoryInfo()
    {
        string str = listinfo.ToString();
        //根据换行符拆分
        string[] itemStrArray = str.Split('\n');
        foreach (string itemStr in itemStrArray)
        {
            //ID 名称 图标 类型（Equip，Drug） 装备类型(Helm,Cloth,Weapon,Shoes,Necklace,Bracelet,Ring,Wing) 售价 星级 品质 伤害 生命 战斗力 作用类型 作用值 描述
            string[] proArray = itemStr.Split('|');
            Inventory inventory = new Inventory();
            inventory.ID = int.Parse(proArray[0]);
            inventory.Name = proArray[1];
            inventory.ICON = proArray[2];
            switch (proArray[3])
            {
                case "Equip":
                    inventory.InventoryTYPE = InventoryType.Equip;
                    break;
                case "Drug":
                    inventory.InventoryTYPE = InventoryType.Drug;
                    break;
                case "Box":
                    inventory.InventoryTYPE = InventoryType.Box;
                    break;
            }
            if (inventory.InventoryTYPE == InventoryType.Equip)
            {
                switch (proArray[4])
                {
                    case "Helm":
                        inventory.EquipTYPE = EquipType.Helm;
                        break;
                    case "Cloth":
                        inventory.EquipTYPE = EquipType.Cloth;
                        break;
                    case "Weapon":
                        inventory.EquipTYPE = EquipType.Weapon;
                        break;
                    case "Shoes":
                        inventory.EquipTYPE = EquipType.Shoes;
                        break;
                    case "Necklace":
                        inventory.EquipTYPE = EquipType.Necklace;
                        break;
                    case "Bracelet":
                        inventory.EquipTYPE = EquipType.Bracelet;
                        break;
                    case "Ring":
                        inventory.EquipTYPE = EquipType.Ring;
                        break;
                    case "Wing":
                        inventory.EquipTYPE = EquipType.Wing;
                        break;
                }

            }
            //print(itemStr);
            //售价 星级 品质 伤害 生命 战斗力 作用类型 作用值 描述
            inventory.Price = int.Parse(proArray[5]);
            if (inventory.InventoryTYPE == InventoryType.Equip)
            {
                inventory.StarLevel = int.Parse(proArray[6]);
                inventory.Quality = int.Parse(proArray[7]);
                inventory.Damage = int.Parse(proArray[8]);
                inventory.HP = int.Parse(proArray[9]);
                inventory.Power = int.Parse(proArray[10]);
            }
            if (inventory.InventoryTYPE == InventoryType.Drug)
            {
                inventory.ApplyValue = int.Parse(proArray[12]);
            }
            inventory.Des = proArray[13];
            inventoryDict.Add(inventory.ID, inventory);
        }
    }
    /// <summary>
    /// 完成角色背包信息的初始化，获得拥有的物品
    /// </summary>
    private void ReadInventoryItemInfo()
    {
        //TODO 需要链接服务器 取得当前角色拥有的物品信息
        //随机生成主角拥有的物品
        for (int j = 0; j < 15; j++)
        {
            int id = Random.Range(1010, 1020);
            Inventory i = null;
            inventoryDict.TryGetValue(id, out i);
            //如果是装备
            if (i.InventoryTYPE == InventoryType.Equip)
            {
                InventoryItem it = new InventoryItem();
                it.Inventory = i;
                it.Level = Random.Range(1, 10);
                it.Count = 1;
                inventoryItemList.Add(it);
            }
            //如果非装备，比如药品
            else
            {
                //先判断背包里面是否已经存在
                InventoryItem it = null;
                bool isExit = false;
                foreach (InventoryItem temp in inventoryItemList)
                {
                    if (temp.Inventory.ID == id)
                    {
                        isExit = true;
                        it = temp;
                        break;
                    }
                }
                if (isExit)
                {
                    it.Count++;
                }
                else
                {
                    it = new InventoryItem();
                    it.Inventory = i;
                    it.Count = 1;
                    inventoryItemList.Add(it);
                }
            }
        }
        //初始化显示（InventoryUI注册了此事件，用于显示）
        OnInventoryChange();
    }
    /// <summary>
    /// 删除物品
    /// </summary>
    /// <param name="it"></param>
    public void RemoveInventoryItem(InventoryItem it)
    {
        this.inventoryItemList.Remove(it);
    }
    /// <summary>
    /// 添加物品
    /// </summary>
    /// <param name="it"></param>
    public void AddInventoryItem(InventoryItem it)
    {
        this.inventoryItemList.Add(it);
        //OnInventoryChange();
    }
    /// <summary>
    /// 背包物品点击处理事件，根据物品类交给对象类处理
    /// </summary>
    /// <param name="obj"></param>
    public void RecMsgFromInventoryItemUI(InventoryItemUI itemUi)
    {
        //装备
        if (itemUi.iItem.Inventory.InventoryTYPE == InventoryType.Equip)
        {
            GameObject.Find("EquipPopupLeft").SendMessage("RecMsgFromInventoryManagerLeft", itemUi);
        }
        //物品
        else if (itemUi.iItem.Inventory.InventoryTYPE == InventoryType.Box || itemUi.iItem.Inventory.InventoryTYPE == InventoryType.Drug)
        {
            GameObject.Find("InventoryPopup").SendMessage("RecMsgFromInventoryManager", itemUi);
        }
    }
    /// <summary>
    /// 人物栏装备点击处理事件
    /// </summary>
    /// <param name="obj"></param>
    public void RecMsgFromRoleEquipItemUI(RoleEquipItemUI itemRoleUI)
    {
        GameObject.Find("EquipPopupRight").SendMessage("RecMsgFromInventoryManagerRight", itemRoleUI);
    }
}
