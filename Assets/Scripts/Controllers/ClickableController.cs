using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ClickableController : MonoBehaviour
{
    // static list of all clickable controllers
    private static List<ClickableController> listOfClickables = new List<ClickableController>();

    // public variables
    public float sizeReduction = 1.0f;
    public UnityEvent eventWhenClicked;

    // private variables
    private Transform spriteChild;

    // helper variables
    private bool clickEnabled = true;
    private bool clicked = false;
    private bool mousedOver = false;
    private Vector3 reducedSizeVector;

    void Awake()
    {
        spriteChild = transform.Find("Sprite");
        reducedSizeVector = new Vector3(sizeReduction, sizeReduction, 1.0f);
    }
    void Start()
    {
        listOfClickables.Add(this);
    }
    void Update()
    {
        // Reset clicked if mouse button ever goes up
        if (Input.GetMouseButtonUp(0)) { clicked = false; }

        // Set size of sprite based on conditions
        if ( clicked && mousedOver ) { spriteChild.localScale = reducedSizeVector; }
        else { spriteChild.localScale = Vector3.one; }
    }
    void OnDestroy()
    {
        listOfClickables.Remove(this);
    }

    // Public methods
    public void Enable() { clickEnabled = true; }
    public void Disable() { clickEnabled = false; clicked = false; mousedOver = false; }
    public static void EnableAll() { foreach (ClickableController clickable in listOfClickables) { clickable.Enable(); } }
    public static void DisableAll() { foreach (ClickableController clickable in listOfClickables) { clickable.Disable(); } }

    // Helper methods
    void ClickedAsButton()
    {
        eventWhenClicked.Invoke();
    }

    // Unity methods
    /*
    void OnMouseUpAsButton() { }
    */
    void OnMouseDown() { if(!clickEnabled){return;} clicked = true; }
    void OnMouseUp() { if (clicked) { ClickedAsButton(); } }
    void OnMouseEnter() { if(!clickEnabled){return;} mousedOver = true; }
    void OnMouseExit() { mousedOver = false; }


}
