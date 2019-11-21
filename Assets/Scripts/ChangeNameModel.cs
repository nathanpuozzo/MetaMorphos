using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.AddressableAssets;
using System.Collections.Generic;

public class ChangeNameModel : MonoBehaviour
{

    private GameObject go;
    private GameObject phylumGO;
    private string nameModel;
    private Text nameModelText;
    private Text namePhylumText;
    

    public void Update()
    {
        phylumGO = GameObject.Find("NamePhyText");
        namePhylumText = phylumGO.GetComponent<Text>();
        nameModelText = GetComponent<Text>();
        nameModel = nameModelText.text;
        go = GameObject.FindGameObjectWithTag("Respawn");
        if (go != null)
        {

            nameModelText.text = go.name;
            nameModelText.text = nameModelText.text.Substring(0, nameModelText.text.Length - 7);
            getPhyText();
        }
        else { nameModelText.text = ""; }
       
    }
    
    private void getPhyText()
    {
        switch (nameModelText.text)
        {
            case "Arthropoda":
                namePhylumText.text="Hexapoda";
                break;
            case "Arachnida":
                namePhylumText.text = "Arthropoda";
                break;
            case "Anthozoa":
                namePhylumText.text = "Cnidaria";
                break;
            case "Schyphozoa":
                namePhylumText.text = "Cnidaria";
                break;
            case "Ctenophora":
                namePhylumText.text = "";
                break;
            case "Turbellaria":
                namePhylumText.text = "Platyhelminthes";
                break;
            case "Polychaeta":
                namePhylumText.text = "Panannelida";
                break;
            case "Myzostomida":
                namePhylumText.text = "Panannelida";
                break;
            case "Gastropoda":
                namePhylumText.text = "Mollusca";
                break;
            case "Nematoda":
                namePhylumText.text = "";
                break;
            case "Crustacea":
                namePhylumText.text = "Arthropoda";
                break;
            case "Holothuroidea":
                namePhylumText.text = "Echinodermata";
                break;
            case "Ascidiacea":
                namePhylumText.text = "Urochordata";
                break;
            case "Tardigrada":
                namePhylumText.text = "Ecdysozoa";
                break;
            case "Sea Star":
                namePhylumText.text = "Echinodermata";
                break;

            case null:
                namePhylumText.text = "";
                break;
            default:
                break;
        }
    }

}
