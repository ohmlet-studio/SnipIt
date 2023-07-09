using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<GameObject> inventory_items;

    public bool delItem(GameObject item_needed)
    {
        inventory_items.Remove(item_needed);
        GameObject.Find("_UI").GetComponentInChildren<ItemListUI>().UpdateUI(inventory_items);
        return true;
    }

    public bool checkItem(GameObject item_needed)
    {
        if(inventory_items.Contains(item_needed)) {
            if(item_needed.GetComponent<ItemScript>().is_consumable) {
                GameObject.Find("_UI").GetComponentInChildren<ItemListUI>().UpdateUI(inventory_items);
            }
            return true;
        }

        return false;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
