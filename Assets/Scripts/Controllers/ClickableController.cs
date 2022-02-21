using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableController : MonoBehaviour
{
    // public variables
    public float sizeReduction = 1.0f;

    // private variables
    private Transform spriteChild;

    // helper variables
    private bool clicked = false;
    private bool mousedOver = false;
    private Vector3 reducedSizeVector;

    void Start()
    {
        spriteChild = transform.Find("Sprite");
        reducedSizeVector = new Vector3(sizeReduction, sizeReduction, 1.0f);
    }

    void Update()
    {
        // Reset clicked if mouse button ever goes up
        if (Input.GetMouseButtonUp(0)) { clicked = false; }

        // Set size of sprite based on conditions
        if ( clicked && mousedOver ) { spriteChild.localScale = reducedSizeVector; }
        else { spriteChild.localScale = Vector3.one; }
    }

    // Helper methods
    void ClickedAsButton()
    {

    }

    // Unity methods
    /*
    void OnMouseUpAsButton() { }
    */
    void OnMouseDown() { clicked = true; }
    void OnMouseUp() { if (clicked) { ClickedAsButton(); } }
    void OnMouseEnter() { mousedOver = true; }
    void OnMouseExit() { mousedOver = false; }


}
