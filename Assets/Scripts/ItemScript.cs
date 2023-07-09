using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{

    public string item_name;
    public Sprite item_icon;
    public bool is_consumable;

    public void pick() {
        List<GameObject> inventory = GameObject.Find("_player").GetComponent<Inventory>().inventory_items;
        inventory.Add(this.gameObject);
        this.gameObject.SetActive(false);
        GameObject.Find("_UI").GetComponentInChildren<ItemListUI>().UpdateUI(inventory);
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
