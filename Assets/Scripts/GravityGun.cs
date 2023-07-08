using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityGun : MonoBehaviour
{

    public Camera cam;
    public float maxGrabDist = 5f;
    public float mov_speed = 5f;
    public LayerMask layerMask;

    GameObject grabbed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (grabbed) {
            Plane plane = new Plane(Vector3.forward, grabbed.transform.position);
            Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f));

            float raycastDistance;
            if(plane.Raycast(ray, out raycastDistance)) {
                Vector3 targetPosition = ray.GetPoint(raycastDistance);
                grabbed.transform.position = targetPosition;

                //Vector3 direction = (targetPosition - transform.position).normalized;
                //Vector3 newPosition = transform.position + direction * mov_speed * Time.deltaTime;
            }
        
        }

        if (Input.GetMouseButtonDown(0))
        {
            if(grabbed) {
                Debug.Log("ungrabbed");
                grabbed = null;
            }
            else {
                RaycastHit hit;
                Ray ray = cam.ViewportPointToRay(new Vector3(0.5f, 0.5f));
                if (Physics.Raycast(ray, out hit, maxGrabDist)) {

                    Renderer renderer = hit.collider.GetComponent<Renderer>();
                    if (renderer && renderer.material)
                    {
                        Vector2 pixelUV = hit.textureCoord;
                        pixelUV.x *= renderer.material.mainTexture.width;
                        pixelUV.y *= renderer.material.mainTexture.height;

                        if (renderer.material.mainTexture is Texture2D texture)
                        {
                            Color pixelColor = texture.GetPixel((int)pixelUV.x, (int)pixelUV.y);
                            Debug.Log(pixelColor);

                            if (pixelColor.a == 0f)
                            {
                                return; // Ignore the hit if the alpha is 0
                            }
                        }
                    }

                    Debug.Log("grabbed");
                    grabbed = hit.collider.gameObject;
                }
            }

        }
    }
}
