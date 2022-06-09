using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public GameObject[] itemchilled;
    public int id;
    public string title;
    public string description;
    public Sprite icon;
    public bool craftable;
    public List<Item> requiredItems = new List<Item>();

    public Inventory InventoryGiveItem;
    public string giveItemletter;

    public Item(int id, string title, bool craftable = false, List<Item> requiredItems = null)
    {
        this.id = id;
        this.title = title;
        this.craftable = craftable;
        this.requiredItems = requiredItems;
        this.icon = Resources.Load<Sprite>("Sprites/items/" + title);
    }
    // 別のItemから新しいItemを作るメソッド
    public Item(Item item)
    {
        this.id = item.id;
        this.title = item.title;
        this.description = item.description;
        this.craftable = item.craftable;
        this.requiredItems = item.requiredItems;
        this.icon = Resources.Load<Sprite>("Sprites/Items/" + title);
    }

    //取ったように見せるために消す
    public void OnTriggerStay(Collider collision)
    {
        bool off = false;
        if (off == false)
        {
            if (collision.gameObject.tag == "player")
            {
                if (Input.GetKey(KeyCode.JoystickButton0))
                {
                    giveItemletter = this.name;
                    this.GetComponent<BoxCollider>().enabled = false;

                    itemchilled[0].GetComponent<Renderer>().enabled = false;
                    itemchilled[1].GetComponent<Renderer>().enabled = false;
                    itemchilled[2].GetComponent<Renderer>().enabled = false;
                    itemchilled[3].GetComponent<Renderer>().enabled = false;
                    itemchilled[4].GetComponent<Renderer>().enabled = false;
                    InventoryGiveItem.GiveItem(giveItemletter);

                    off = true;
                }
            }
        }
    }
}
