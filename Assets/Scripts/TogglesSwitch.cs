using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TogglesSwitch : MonoBehaviour
{
    Boolean boolExt; 
    Toggle toggleExt;
    Toggle toggleInt;
    Toggle toggleDig;
    Toggle toggleExc;
    Toggle toggleRes;
    Toggle toggleNer;
    Toggle toggleRep;
    Toggle toggleCir;
    Toggle toggleGla;
    Toggle togglePoi;
    
    // Start is called before the first frame update
    void Start()
    {
        //Fetch the Toggle GameObject
        toggleExt = GameObject.Find("TogglePrefab").GetComponent<Toggle>();
        toggleInt = GameObject.Find("ToggleInt").GetComponent<Toggle>();
        toggleDig = GameObject.Find("ToggleDig").GetComponent<Toggle>();
        if (GameObject.Find("ToggleExc") != null)
        {
            toggleExc = GameObject.Find("ToggleExc").GetComponent<Toggle>();
        }
        if (GameObject.Find("ToggleRes") != null)
        {
            toggleRes = GameObject.Find("ToggleRes").GetComponent<Toggle>();
        }
        toggleNer = GameObject.Find("ToggleNer").GetComponent<Toggle>();
        toggleRep = GameObject.Find("ToggleRep").GetComponent<Toggle>();
        if (GameObject.Find("ToggleCir") != null)
        {
            toggleCir = GameObject.Find("ToggleCir").GetComponent<Toggle>();
        }
        if (GameObject.Find("ToggleGla") != null)
        {
            toggleGla = GameObject.Find("ToggleGla").GetComponent<Toggle>();
        }
        if (GameObject.Find("TogglePoi") != null)
        {
            togglePoi = GameObject.Find("TogglePoi").GetComponent<Toggle>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        toggleExt.onValueChanged.AddListener((bool value) => ToggleExtFunction(toggleExt.isOn));
        toggleInt.onValueChanged.AddListener((bool value) => ToggleIntFunction(toggleInt.isOn));
        toggleDig.onValueChanged.AddListener((bool value) => ToggleDigFunction(toggleDig.isOn));
        if (toggleExc!=null) { toggleExc.onValueChanged.AddListener((bool value) => ToggleExcFunction(toggleExc.isOn)); }
        if (toggleRes != null) { toggleRes.onValueChanged.AddListener((bool value) => ToggleResFunction(toggleRes.isOn)); }
        toggleNer.onValueChanged.AddListener((bool value) => ToggleNerFunction(toggleNer.isOn));
        toggleRep.onValueChanged.AddListener((bool value) => ToggleRepFunction(toggleRep.isOn));
        if (toggleCir != null) { toggleCir.onValueChanged.AddListener((bool value) => ToggleCirFunction(toggleCir.isOn)); }
        if (toggleGla != null) { toggleGla.onValueChanged.AddListener((bool value) => ToggleGlaFunction(toggleGla.isOn)); }
        if (togglePoi != null) { togglePoi.onValueChanged.AddListener((bool value) => TogglePoiFunction(togglePoi.isOn)); }

    }

    

    private void ToggleExtFunction(bool isOn)
    {
        
        toggleInt.isOn = false;
        toggleDig.isOn = false;
        if (toggleExc != null) { toggleExc.isOn = false;}
        if (toggleRes != null) { toggleRes.isOn = false; }
        toggleNer.isOn = false;
        toggleRep.isOn = false;
        if (toggleCir != null) { toggleCir.isOn = false; }
        if (toggleGla != null) { toggleGla.isOn = false; }
        if (togglePoi != null) { togglePoi.isOn = false; }
      
    }

    private void ToggleIntFunction(bool isOn)
    {
        
        toggleExt.isOn = false;
    }

    private void TogglePoiFunction(bool isOn)
        {
            toggleExt.isOn = false;
        }

    private void ToggleCirFunction(bool isOn)
    {
        toggleExt.isOn = false;

    }

    private void ToggleGlaFunction(bool isOn)
    {
        toggleExt.isOn = false;
    }


    private void ToggleRepFunction(bool isOn)
    {
        toggleExt.isOn = false;
    }

    private void ToggleNerFunction(bool isOn)
    {
        toggleExt.isOn = false;
    }

    private void ToggleResFunction(bool isOn)
    {
        toggleExt.isOn = false;
    }

    private void ToggleExcFunction(bool isOn)
    {
        toggleExt.isOn = false;
    }

    private void ToggleDigFunction(bool isOn)
    {
        toggleExt.isOn = false;
    }
}
