using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ZoomInAndOut : MonoBehaviour
{
    [SerializeField] private  Camera cameraFollow;
    private Vector3 cameraFollowPosition;
   // private float zoom = 80f;

    private void HandleZoom()
    {

        float zoomChangeAmount = 120f;

        if (Input.GetKey(KeyCode.KeypadPlus))
        {
            cameraFollow.fieldOfView -= zoomChangeAmount * Time.deltaTime; 
        }
        if (Input.GetKey(KeyCode.KeypadMinus))
        {
            cameraFollow.fieldOfView += zoomChangeAmount * Time.deltaTime;
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            cameraFollow.fieldOfView += zoomChangeAmount * Time.deltaTime;
        }
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            cameraFollow.fieldOfView -= zoomChangeAmount * Time.deltaTime;
        }

        cameraFollow.fieldOfView = Mathf.Clamp(cameraFollow.fieldOfView, 20, 60);

    }
    // Start is called before the first frame update
    void Start()
    {
        cameraFollow = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleZoom();
    }
}
