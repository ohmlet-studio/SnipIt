using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snippable : MonoBehaviour
{

    private bool snipped = false;

    public float relative_position;

    public GameObject item_needed;
    public GameObject item_needed2;

    private GameObject _painting;
    private GameObject _player;

    // Start is called before the first frame update
    void Start()
    {
        _painting = GameObject.Find("_painting");
        _player = GameObject.Find("_player");

        if(relative_position == 0)
            relative_position = transform.localPosition.z * 100;
    }

    public bool isConditionMet() {
        bool snip_ok = true;

        Inventory inventory = _player.GetComponent<Inventory>();

        Snippable parent_snip = transform.parent.GetComponent<Snippable>();
        if (parent_snip) {
            bool isParentSnipped = parent_snip.isSnipped();
            if(!isParentSnipped) {
                parent_snip.snip();
            }
            snip_ok &= isParentSnipped;            
        }

        if(item_needed) {
            snip_ok &= inventory.checkItem(item_needed);
            if(item_needed2) {
                snip_ok &= inventory.checkItem(item_needed2);
            }
        }

        if(snip_ok) {
            if(item_needed) {
                inventory.delItem(item_needed);
            }

            if (item_needed2)
            {
                inventory.delItem(item_needed2);
            }
        }

        return snip_ok;
    }

    public bool isSnipped() {
        return snipped;
    }

    public bool snip()
    {
        if (isConditionMet())
        {
            Vector3 new_pos = transform.localPosition;
            new_pos.z = relative_position;
            transform.localPosition = new_pos;
            transform.parent = _painting.transform;

            this.snipped = true;

            return true;
        } else {
            return false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
