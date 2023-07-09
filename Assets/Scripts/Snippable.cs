using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snippable : MonoBehaviour
{

    private float snipTreshold = 0.0001f;

    public float relative_position;

    public GameObject item_needed;

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
    
        Snippable parent_snip = transform.parent.GetComponent<Snippable>();
        if (parent_snip) {
            bool isParentSnipped = parent_snip.isSnipped();
            if(!isParentSnipped) {
                parent_snip.snip();
            }
            snip_ok &= isParentSnipped;            
        }

        if(item_needed) {
            snip_ok &= _player.GetComponent<Inventory>().checkItem(item_needed);
        }

        return snip_ok;
    }

    public bool isSnipped() {
        return ! (Mathf.Abs(transform.localPosition.z) < snipTreshold);
    }

    public bool snip()
    {
        if (isConditionMet())
        {
            Vector3 new_pos = transform.localPosition;
            new_pos.z = relative_position;
            transform.localPosition = new_pos;
            transform.parent = _painting.transform;

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
