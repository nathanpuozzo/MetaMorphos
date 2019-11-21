using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ChangeNameModelText : MonoBehaviour
{

    private Text nameModel;
    private GameObject modelGO;
    private string nameGO;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        modelGO = GameObject.Find("MoucheTextured");
        if (!modelGO) {  Debug.Log("No model"); }
        else {
            nameGO = modelGO.name;
            nameModel = GetComponent<Text>();
            nameModel.text = nameGO;
        }
        
    }
}
