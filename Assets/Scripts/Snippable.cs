using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snippable : MonoBehaviour
{

    private float snipTreshold = 0.5f;

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
            return _player.GetComponent<Inventory>().checkItem(item_needed);
        }

        return true;
    }

    public bool isSnipped() {
        return ! (Mathf.Abs(transform.localPosition.z) < snipTreshold);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
