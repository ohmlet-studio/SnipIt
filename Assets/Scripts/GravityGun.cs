using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GravityGun : MonoBehaviour
{

    public Camera cam;
    public float maxGrabDist = 100f;
    public float snipMaxDist = 10f;

    public Image crosshair;

    public LayerMask layerMask;

    public GameObject grabbed;

    public Sprite spriteHandOpen;
    public Sprite spriteHandClosed;
    public Sprite spriteDot;
    public Sprite spriteCisors;
    public Sprite spritePick;

    public SoundEffectsPlayer soundPlayer;

    // Start is called before the first frame update
    void Start()
    {
        soundPlayer = GetComponent<SoundEffectsPlayer>();
    }
    public void ChangeOriginTo(GameObject target, Vector3 position)
    {
        GameObject emptyGameObject = new GameObject("tmp_movable");
        emptyGameObject.transform.parent = target.transform.parent;

        target.transform.parent = emptyGameObject.transform;

        Vector3 offset = emptyGameObject.transform.position - position;
        foreach (Transform child in emptyGameObject.transform)
            child.transform.position += offset;
        emptyGameObject.transform.position = position;
    }

    void updateCrosshair(bool canGrab, bool grabbed, bool cansnip, bool isItem) {
        if(!grabbed && isItem) {
            crosshair.sprite = spritePick;
        }
        else if(!grabbed && cansnip) {
            crosshair.sprite = spriteCisors;
        }
        else if (!grabbed && canGrab)
        {
            crosshair.sprite = spriteHandOpen;
        }
        else if (grabbed)
        {
            crosshair.sprite = spriteHandClosed;
        }
        else
        {
            crosshair.sprite = spriteDot;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f));
        bool canGrab = false;
        bool canSnip = false;
        ItemScript isItem = null;

        if (grabbed)
        {
            Plane plane = new Plane(Vector3.forward, grabbed.transform.position);

            float raycastDistance;
            if (plane.Raycast(ray, out raycastDistance))
            {
                if(raycastDistance < maxGrabDist) {
                    Vector3 targetPosition = ray.GetPoint(raycastDistance);
                    grabbed.transform.position = targetPosition;

                    //Vector3 direction = (targetPosition - transform.position).normalized;
                    //Vector3 newPosition = transform.position + direction * mov_speed * Time.deltaTime;

                    if (Input.GetMouseButtonDown(0))
                    {
                        soundPlayer.dropS();
                        Transform new_parent = grabbed.transform.parent;
                        grabbed.transform.GetChild(0).parent = new_parent;
                        Destroy(grabbed);
                        grabbed = null;
                    }
                }
            }
        } 
        else
        {
            RaycastHit hit;
            canGrab = Physics.Raycast(ray, out hit, float.MaxValue, layerMask);

            if (canGrab) {                
                GameObject grabbed_candidate = hit.collider.gameObject;

                ItemScript itemScript = grabbed_candidate.GetComponent<ItemScript>();

                Snippable snipScript = grabbed_candidate.GetComponent<Snippable>();
                if (!isItem && hit.distance < snipMaxDist && snipScript) {
                        canSnip = !snipScript.isSnipped();
                }

                if (Input.GetMouseButtonDown(0)) {
                    if (itemScript)
                    {
                        soundPlayer.unlockS();
                        itemScript.pick();
                    }
                    else if (canSnip)
                    {
                        soundPlayer.snipS();
                        snipScript.snip();
                    }
                    else
                    {
                        //set new origin to hit pos
                        soundPlayer.grabS();
                        ChangeOriginTo(grabbed_candidate, hit.point);
                        grabbed = grabbed_candidate.transform.parent.gameObject;
                    }
                }
            }
        }

        updateCrosshair(canGrab, grabbed, canSnip, isItem);

    }
}
