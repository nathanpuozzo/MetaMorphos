using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextAboveGO : MonoBehaviour
{
    private GameObject target;
    private GameObject MarkerGO;
    private Text Marker;
    private RectTransform canvasRect;
    // Start is called before the first frame update
    void Start()
    {
        canvasRect = GetComponent<RectTransform>();
        //Set the canvasRect to object with same name as UItext.text
        MarkerGO = GameObject.Find("Zone");
        
        
    }

    // Update is called once per frame
    void Update()
    {
        // Offset position above object bbox (in world space)
        float offsetPosY = canvasRect.transform.position.y + 1.5f;

        // Final position of marker above GO in world space
        Vector3 offsetPos = new Vector3(canvasRect.transform.position.x, offsetPosY, canvasRect.transform.position.z);

        // Calculate *screen* position (note, not a canvas/recttransform position)
        Vector2 canvasPos;
        Vector2 screenPoint = Camera.main.WorldToScreenPoint(offsetPos);

        // Convert screen position to Canvas / RectTransform space <- leave camera null if Screen Space Overlay
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRect, screenPoint, null, out canvasPos);

        // Set
        canvasRect.transform.localPosition = canvasPos;

    }

   
}
