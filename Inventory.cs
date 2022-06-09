using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Item> charactorItems = new List<Item>();
    public ItemDetabase itemDatabaseGiveItem;
    public UIInventory inventoryUI;
    private bool isView = false;
    private float Menuon;
    public static Inventory instance;
    [SerializeField] private GameObject inventryonoff;
    private void Start()
    {
        bool a;
        a = inventryonoff.activeSelf;
        if (a == false)
        {
            Debug.Log("<color=green>" + "InventoryPanelを表示させろ(GiveItemの動作がしなくなる)" + "</color>");
        }
        //動作確認用
        //GiveItem("key2");
        inventoryUI.gameObject.SetActive(false);
    }

    //アイテムをインベントリに追加する
    public void GiveItem(int id)
    {
        Debug.Log("GiveItemが呼ばれました");
        Item itemToAdd = itemDatabaseGiveItem.GetItem(id);
        charactorItems.Add(itemToAdd);
        inventoryUI.AddNewItem(itemToAdd);
        Debug.Log("Added item: " + itemToAdd.title);
    }

    public void GiveItem(string title)
    {
        Item itemToAdd;
        Debug.Log("GiveItemが呼ばれました");
        Debug.Log(title);
        itemToAdd = itemDatabaseGiveItem.GetItem(title);
        Debug.Log("itemToAdd:" + itemToAdd.name);
        inventoryUI.AddNewItem(itemToAdd);
        charactorItems.Add(itemToAdd);
    }

    public Item CheckForItem(int id)
    {
        //Check for itemは説明文（意味ない）
        //{0}: {1}の中に値を入れそれを出力することができる
        //Debug.Log(string.Format("Check for item {0}: {1}", id, charactorItems.Find(item => item.id == id) != null));
        //Findは一番最初にある物を返す
        return charactorItems.Find(item => item.id == id);
    }

    public Item CheckForItem(Item item)
    {
        Debug.Log(string.Format("Check for item {0}: {1}", item.id, charactorItems.Find(i => i.id == item.id) != null));
        return charactorItems.Find(i => i.id == item.id);
    }

    public void RemoveItem(int id)
    {
        Item item = CheckForItem(id);
        if (item != null)
        {
            charactorItems.Remove(item);
            inventoryUI.RemoveItem(item);
            Debug.Log("Item Removed: " + item.title);
        }
    }

    public void RemoveItems(List<Item> items)
    {
        foreach (var item in items)
        {
            Item item1 = CheckForItem(item);
            if (item1 != null)
            {
                charactorItems.Remove(item1);
                inventoryUI.RemoveItem(item1);
            }
        }
    }

    private void Update()
    {
        //Debug.Log("0" + CheckForItem(0));
        //Debug.Log("1" + CheckForItem(1));
        //インベントリ  十字キー 上は0以上 下は0以下
        float inventryon = Input.GetAxis("Axis 8");
        if (inventryon > 0 && Menuon == 0.0f)
        {
            inventoryUI.gameObject.SetActive(isView);
            isView = !isView;
        }
        Menuon = inventryon;
    }
}
