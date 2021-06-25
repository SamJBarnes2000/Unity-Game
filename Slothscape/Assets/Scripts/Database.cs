using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class Database : MonoBehaviour
{
    private ItemDatabase items;
    private static Database instance;

    private void Awake() {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }else
        {
            Destroy(gameObject);
        }
    }

    public static Item GetItemByID(string ID)
    {
        return instance.items.allItems.FirstOrDefault(i => i.itemID == ID);

        //or can use
        // foreach (Item item in instance.items.allItems)
        // {
        //     if(item.itemID == ID)
        //     {
        //         return item;
        //     }
        // }

        // return null;

    }

    public static Item GetRandomItem()
    {
        return instance.items.allItems[Random.Range(0, instance.items.allItems.Count())];
    }
}
