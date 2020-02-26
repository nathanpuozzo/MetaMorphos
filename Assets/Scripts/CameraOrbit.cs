using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOrbit : MonoBehaviour
{

    protected Transform _Xform_Camera;
    protected Transform _XForm_Parent;

    protected Vector3 _LocalRotation;
    protected float _CameraDistance = 2f;

    public float MouseSensitivity = 4f;
    public float ScrollSensitivity = 2f;
    public float OrbitSpeed = 10f;
    public float ScrollSpeed = 6f;

    public bool CameraDisabled = false;

    // Start is called before the first frame update
    void Start()
    {
        this._Xform_Camera = this.transform;
        this._XForm_Parent = this.transform.parent;

    }

    void LateUpdate()
    {

        if (Input.GetKeyDown(KeyCode.LeftShift))
            CameraDisabled = !CameraDisabled;

        if (!CameraDisabled)
        {

            //Rotation of the Camera based on Mouse Coordinates
            if (Input.GetMouseButton(0))
            {
               
                _LocalRotation.x += Input.GetAxis("Mouse X") * MouseSensitivity;
                _LocalRotation.y -= Input.GetAxis("Mouse Y") * MouseSensitivity;

                
            }
            
           
            //Zooming INput from our Mouse Scroll Wheel
            if (Input.GetAxis("Mouse ScrollWheel") != 0f)
            {
                float ScrollAmount = Input.GetAxis("Mouse ScrollWheel") * ScrollSensitivity;

                //Makes camera zoom faster the further away it is from the target
                ScrollAmount *= (this._CameraDistance * 0.5f);

                this._CameraDistance += ScrollAmount * -1f;

                //This makes camera go no closer than 1.5 meters from target, and no further than 100 meters
                this._CameraDistance = Mathf.Clamp(this._CameraDistance, 0.5f, 3f);


            }
        }

        //Actual Camera Rig Transformations
        Quaternion QT = Quaternion.Euler(_LocalRotation.y, _LocalRotation.x, 0);
        this._XForm_Parent.rotation = Quaternion.Lerp(this._XForm_Parent.rotation, QT, Time.deltaTime * OrbitSpeed);

        if (this._Xform_Camera.localPosition.z != this._CameraDistance * -1f)
        {
            this._Xform_Camera.localPosition = new Vector3(0f, 0f, Mathf.Lerp(this._Xform_Camera.localPosition.z, this._CameraDistance * -1f, Time.deltaTime * ScrollSpeed));
        }

    }
}
