using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedFlash : MonoBehaviour
{
    public GameObject selectedObject;
    public int redCol;
    public int greenCol;
    public int blueCol;
    public bool lookingAtObject = false;
    public bool falshingIn = true;
    public bool startedFlashing = false;


    void Update()
    {
        if (lookingAtObject == true)
        {
             selectedObject.GetComponent<Renderer>().material.color = new Color32((byte)redCol, (byte)greenCol, (byte)blueCol, 255);
        }
    }

    private void OnMouseOver()
    {
        selectedObject = GameObject.Find(CastingToObject.selectedObject);
        lookingAtObject = true;
        if (startedFlashing == false)
        {
            startedFlashing = true;
            StartCoroutine(FlashObject());
        }
    }

    private void OnMouseExit()
    {
        startedFlashing = false;
        lookingAtObject = false;
        StopCoroutine(FlashObject());
        selectedObject.GetComponent<Renderer>().material.color = new Color32(255, 255, 255, 255);
    }

    IEnumerator FlashObject()
    {
        while (lookingAtObject == true)
        {
            yield return new WaitForSeconds(0.05f);
            if (falshingIn == true)
            {
                if (blueCol <= 30)
                {
                    falshingIn = false;

                }
                else
                {
                    blueCol -= 25;
                    greenCol -= 1;

                }
            }

            if (falshingIn == false)
            {
                if (blueCol >= 250)
                {
                    falshingIn = true;
                }
                else
                {
                    blueCol += 25;
                    greenCol += 1;
                }
            }
        }
    }
}
