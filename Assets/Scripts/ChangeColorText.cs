using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;

public class ChangeColorText : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{

    public Text t;
    private bool b = false;
   

    public void ChangeColor() {

        t.color = Color.black;
        b = true;
        Debug.Log("color changed");
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        t.color = Color.black;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (b == true)
        {
            t.color = Color.black;
            
        }
        else
        {
            t.color = Color.white;
        }
        
    }
}
