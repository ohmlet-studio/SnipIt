using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnipInPosition : MonoBehaviour
{

    public float relative_position;    

    // Start is called before the first frame update
    void Start()
    {
        if(relative_position == 0)
            relative_position = transform.localPosition.z * 1000;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
