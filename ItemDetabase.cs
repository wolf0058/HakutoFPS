using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDetabase : MonoBehaviour
{
    public List<Item> items = new List<Item>();
    private void Awake()
    {
        BuildDatabase();
        Debug.Log("BuildDatadese");
    }
    public Item GetItem(int id)
    {
        Debug.Log("GetItem呼ばれたよ!!int");
        return this.items.Find(item => item.id == id);
    }
    public Item GetItem(string itemName)
    {
        Debug.Log("GetItem呼ばれたよ!!string");
        return items.Find(item => item.title == itemName);
    }
    void BuildDatabase()
    {
        items = new List<Item>()
        {
            new Item (0,"key1",false),
            new Item (1,"iron1",false),
            new Item (2,"key2",false),
            new Item (3,"saw1",false),
            new Item (4,"key3",craftable:true,
            requiredItems:new List<Item>
            {
                new Item (1,"iron1",false),
                new Item (1,"iron1",false),
                new Item (1,"iron1",false)
            }
            ),
        };
    }
}
