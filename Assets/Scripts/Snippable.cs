using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snippable : MonoBehaviour
{

    public float relative_position;

    public GameObject item_needed;

    private GameObject _player;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("_player");

        if(relative_position == 0)
            relative_position = transform.localPosition.z * 1000;
    }

    public bool isConditionMet() {
        if(item_needed) {
            return _player.GetComponent<Inventory>().inventory_items.Contains(item_needed);
        }

        return true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
