using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class EnableText : MonoBehaviour
{

    private Text text;
    private GameObject textGO;
    Vector3 colliderPointion;
    RectTransform rectTransform;
    Vector3 pos;
    LineRenderer line;
    public Material mat1;
    bool lineCond = false;
    bool txtStay = false;
    GameObject cloneLabel;
    InterestPoint moveText;
    Button bilbo;
    int clickCount = 0;
    public Camera camera;
    float m_fieldOfView = 60.0f;

    // Start is called before the first frame update
    void Start()
    {
        camera = GameObject.Find("UICamera").GetComponent<Camera>();
        cloneLabel = GameObject.Find(gameObject.name);
        text = cloneLabel.GetComponent<Text>();
        bilbo = cloneLabel.AddComponent<Button>();
        bilbo.onClick.AddListener(() => DisableTxt());
        text.enabled = false;
       
    }

    // Update is called once per frame
    void Update()
    {


        if (GetComponent<LineRenderer>() != null)
        {
            line = GetComponent<LineRenderer>();
            line.material = mat1;
            if (lineCond == false)
            {
                line.enabled = false;
            }
        }

        if (camera.fieldOfView < 50.0f)
        {
            Debug.Log("I'm here");
            DisableTxt();
            clickCount = 0;
        }
    }
    /*
    private void OnMouseEnter()
    {

        
        text.enabled = true;
        lineCond = true;
        if (GetComponent<LineRenderer>() != null)
        {
            if(lineCond == true) { line.enabled = true; }
            
            
        }
    }
    */
    private void OnMouseDown()
    {
   
            txtStay = true;
            text.enabled = true;
            lineCond = true;

            if (GetComponent<LineRenderer>() != null)
            {
                if (lineCond == true) { line.enabled = true; }


            }
            clickCount++;
            Debug.Log(clickCount);

            if (clickCount == 2)
            {
                Debug.Log(clickCount);
                clickCount = 0;
                DisableTxt();
            }
        
        

    }
  
    private void DisableTxt()
    {
        Debug.Log("im'here");
        txtStay = false;
        text.enabled = false;
        lineCond = false;
        if (GetComponent<LineRenderer>() != null)
        {
            if (lineCond == false) { line.enabled = false; }

        }
    }
    /*
    private void OnMouseExit()
    {
        if (txtStay == false)
        {
            text.enabled = false;
            lineCond = false;
            if (GetComponent<LineRenderer>() != null)
            {
                if (lineCond == false) { line.enabled = false; }

            }
        }
    }
    */
   
}
