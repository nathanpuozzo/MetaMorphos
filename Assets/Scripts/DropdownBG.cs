using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropdownBG : MonoBehaviour
{

    Dropdown dropdown;
    Color color;
    Material material;
    GameObject panel;
    int dropdown_value;
    public Material mainText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        panel = GameObject.Find("Panel");
        color = panel.GetComponent<Graphic>().color;
        material = panel.GetComponent<Image>().material;
        dropdown = GetComponent<Dropdown>();
        dropdown_value = dropdown.value;

        switch (dropdown.value)
        {
            case 0 :
                
                panel.GetComponent<Image>().material = new Material(mainText);
                 break;
            case 1:
                panel.GetComponent<Image>().material = null;
                panel.GetComponent<Image>().color = new Color(0.1371485f, 0.4339623f, 0.3975606f); 
               
                break;
            case 2:
                panel.GetComponent<Image>().material = null;
                panel.GetComponent<Image>().color = new Color(0.2641509f, 0.2641509f, 0.2641509f);
                
                break;
            default:
                break;
        }
    }
}
