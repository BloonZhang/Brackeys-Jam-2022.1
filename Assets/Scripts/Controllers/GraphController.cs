using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//TODO: animate dots moving up and down
public class GraphController : MonoBehaviour
{

    // private GameObjects
    [SerializeField] private Sprite circleSprite;
    private RectTransform graphContainer;

    // public variables
    public int numberOfFacets = 10;

    // helper variables
    private List<GameObject> listOfGraphItems = new List<GameObject>();
    private GameObject verticalLine;

    void Awake()
    {
        graphContainer = transform.Find("GraphContainer").GetComponent<RectTransform>();
    }

    void Start()
    {
        CreateVerticalLine(5);
    }

    // public methods
    public void DrawEVGraph(float percentageSuccess)
    {
        ClearGraph();
        List<float> valueList = new List<float>();
        for (int i = 0; i <= numberOfFacets; i++)
        {
            valueList.Add(Stats.CalculateProbability(numberOfFacets, i, percentageSuccess));
        }
        ShowGraph(valueList);
    }

    // Methods for drawing graph
    private void ShowGraph(List<float> valueList) 
    {
        // distance between each point on x axis
        float xSize = graphContainer.sizeDelta.x / (valueList.Count + 1);
        //float yMaximum = System.Linq.Enumerable.Max(valueList) * 2f;
        float yMaximum = 0.75f;
        float graphHeight = graphContainer.sizeDelta.y;
        GameObject lastCircleGameObject = null;
        for (int i = 0; i < valueList.Count; i++)
        {
            float xPosition = xSize + (i * xSize);
            // Normalize y height
            float yPosition = (valueList[i] / yMaximum) * graphHeight;
            GameObject circleGameObject = CreateCircle(new Vector2(xPosition, yPosition));
            if (lastCircleGameObject != null)
            {
                CreateDotConnection(lastCircleGameObject.GetComponent<RectTransform>().anchoredPosition, circleGameObject.GetComponent<RectTransform>().anchoredPosition);
            }
            lastCircleGameObject = circleGameObject;
        }
    }
    private GameObject CreateCircle(Vector2 anchoredPosition)
    {
        GameObject gameObject = new GameObject("circle", typeof(Image));
        gameObject.transform.SetParent(graphContainer, false);
        gameObject.GetComponent<Image>().sprite = circleSprite;
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = anchoredPosition;
        rectTransform.sizeDelta = new Vector2(11, 11);
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);
        listOfGraphItems.Add(gameObject);
        return gameObject;
    }
    private void CreateDotConnection(Vector2 dotPositionA, Vector2 dotPositionB)
    {
        GameObject gameObject = new GameObject("dotConnect", typeof(Image));
        gameObject.transform.SetParent(graphContainer, false);
        gameObject.GetComponent<Image>().color = new Color(1,1,1,0.5f);
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        Vector2 direction = (dotPositionB - dotPositionA).normalized;
        float distance = Vector2.Distance(dotPositionA, dotPositionB);
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);
        rectTransform.sizeDelta = new Vector2(distance, 3f);
        rectTransform.anchoredPosition = dotPositionA + direction * distance * 0.5f;
        rectTransform.localEulerAngles = new Vector3(0, 0, (Mathf.Atan2(direction.y, direction.x)*180/Mathf.PI));
        listOfGraphItems.Add(gameObject);
    }
    private void CreateVerticalLine(int successes)
    {
        float ySize = graphContainer.sizeDelta.y * 0.5f;
        float xPosition = (graphContainer.sizeDelta.x / (numberOfFacets + 2)) * (successes + 1);
        GameObject gameObject = new GameObject("vertLine", typeof(Image));
        gameObject.transform.SetParent(graphContainer, false);
        gameObject.GetComponent<Image>().color = new Color(1,1,1,0.5f);
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);
        rectTransform.sizeDelta = new Vector2(3f, ySize);
        rectTransform.anchoredPosition = new Vector2(xPosition, ySize * 0.5f);
        verticalLine = gameObject;
    }
    private void ClearGraph()
    {
        foreach (GameObject gameObject in listOfGraphItems) { Destroy(gameObject); }
    }
}
