using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroSceneHandler : MonoBehaviour
{
    // public GameObjects
    public GameObject selectionCanvas;
    public GameObject soloCanvas;
    // public GameObject multiplayerCanvas;
    public GameObject tutorialCanvas;

    public void Start()
    {
        MoveToSelectionCanvas();
    }

    // Switch Canvases
    public void MoveToSelectionCanvas()
    {
        soloCanvas.SetActive(false); tutorialCanvas.SetActive(false);
        selectionCanvas.SetActive(true);
    }
    public void MoveToSoloCanvas()
    {
        selectionCanvas.SetActive(false); tutorialCanvas.SetActive(false);
        soloCanvas.SetActive(true);
    }
    // public void MoveToMultiplayerCanvas() { }
    public void MoveToTutorialCanvas()
    {
        selectionCanvas.SetActive(false); soloCanvas.SetActive(false);
        tutorialCanvas.SetActive(true);
    }

    // Move to difference scenes
    public void MoveToJewelerScene()
    {
        SceneManager.LoadScene("JewelerScene");
    }
    public void MoveToInspectorScene()
    {
        SceneManager.LoadScene("InspectorScene");
    }
}
