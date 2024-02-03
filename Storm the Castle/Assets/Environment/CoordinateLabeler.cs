using UnityEngine;
using TMPro;

// ! PLACE THIS SCRIPT IN EDITOR FOLDER IF TRY TO BUILD OTHERWISE BUILD WILL FAIL !
[ExecuteAlways]
[RequireComponent(typeof(TextMeshPro))]
public class CoordinateLabeler : MonoBehaviour
{
    [SerializeField] Color defaultColor = Color.white;
    [SerializeField] Color blockedColor = Color.gray;
    [SerializeField] Color exploredColor = Color.yellow;
    [SerializeField] Color pathColor = new Color(1f, 0.5f, 0f);

    TextMeshPro label;
    Vector2Int coordinates = new Vector2Int();
    // All waypoint referances are use for the original path method
    // Waypoint waypoint;
    GridManager gridManager;

    void Awake()
    {
        label = GetComponentInChildren<TextMeshPro>();
        label.enabled = false;
        // waypoint = GetComponentInParent<Waypoint>();
        gridManager = FindObjectOfType<GridManager>();
        DisplayCoordinates();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Application.isPlaying)
        {
            DisplayCoordinates();
            UpdateObjectName();
            label.enabled = true;
        }

        SetLabelColor();
        ToggleLabels();
    }

    void SetLabelColor()
    {
        if (gridManager == null) { return; }

        Node node = gridManager.GetNode(coordinates);

        if (node == null) { return; }

        // if (waypoint.IsPlaceable)
        // {
        //     label.color = defaultColor;
        // }
        // else
        // {
        //     label.color = blockedColor;
        // }

        if (!node.isWalkable)
        {
            label.color = blockedColor;
        }
        else if (node.isPath)
        {
            label.color = pathColor;
        }
        else if (node.isExplored)
        {
            label.color = exploredColor;
        }
        else
        {
            label.color = defaultColor;
        }
    }

    void DisplayCoordinates()
    {
        // This needs to be done because of the wonky thing that happened as mentioned below
        var gridSize = 0.25f;

        if (gridManager == null) { return; }
        // ! Following two row divided by 40 because of the scale of the grid somehow grew when I reopened project...
        coordinates.x = Mathf.RoundToInt(transform.position.x / gridSize) / 40;
        coordinates.y = Mathf.RoundToInt(transform.position.z / gridSize) / 40;

        label.text = coordinates.x + "," + coordinates.y;
    }

    void ToggleLabels()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            label.enabled = !label.IsActive();
        }
    }

    void UpdateObjectName()
    {
        transform.parent.name = coordinates.ToString();
    }

}
