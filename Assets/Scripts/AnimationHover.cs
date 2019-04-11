using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AnimationHover : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler {

    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void OnPointerExit()
    {
        animator.SetBool("OnHover", false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {

        animator.SetBool("OnHover", true);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        //TODO : Load Assets Bundle in other Scene
        Debug.Log("Clicked");
    }
}
