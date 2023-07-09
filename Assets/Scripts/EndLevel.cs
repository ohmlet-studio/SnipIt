using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevel : MonoBehaviour
{
    public float movementSpeed;
    public Snippable LastSnippedLayer;
    public Transform bkg;
    public Transform target;
    private bool isMoving; // Flag to check if background is already moving

    // Start is called before the first frame update
    void Start()
    {
        isMoving = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (LastSnippedLayer.isSnipped())
        {
            if (!isMoving)
            {
                StartCoroutine(MoveBackground());
            }
        }
    }

    IEnumerator MoveBackground()
    {
        isMoving = true;
        float elapsedTime = 0;

        while (elapsedTime < movementSpeed)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / movementSpeed);
            bkg.transform.position = Vector3.Lerp(bkg.position, target.position, t);
            yield return null;
        }

        isMoving = false;
    }
}