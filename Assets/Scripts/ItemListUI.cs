using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemListUI : MonoBehaviour
{
    void Start()
    {
        foreach (Transform child in this.transform)
        {
            Destroy(child.gameObject);
        }
    }

    // Call this method to update the UI with the item sprites
    public void UpdateUI(List<GameObject> inventory)
    {
        // Clear the existing items in the container
        foreach (Transform child in this.transform)
        {
            Destroy(child.gameObject);
        }

        // Iterate through the list of items
        foreach (GameObject item in inventory)
        {
            ItemScript itemScript = item.GetComponent<ItemScript>();

            GameObject newItemUI = new GameObject(itemScript.item_name);
            Image itemImage = newItemUI.AddComponent<Image>();

            itemImage.sprite = itemScript.item_icon;

            newItemUI.transform.SetParent(this.transform);

            // Position the new Image UI element from left to right in the UI element
            // You can adjust the positioning based on your UI layout and preferences
            // You might want to consider using the itemContainer's cellSize and spacing properties
        }
    }
}
