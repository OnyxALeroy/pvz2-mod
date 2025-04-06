using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lawn : MonoBehaviour
{
    [SerializeField] Sprite lawnImage;
    [SerializeField] Image lawnBackground;
    [SerializeField] GameObject lawnGrid;
    [SerializeField] GameObject tilePrefab;
    [SerializeField] GameObject zombiesContainer;

    private int rowAmount = 5;
    private int columnAmount = 11;   // 9 true columns + 2 false ones (zombie spawn & Game Over)
    private List<GameObject> zombies = new List<GameObject>();

    public Sprite LawnImage => lawnImage;
    public Image LawnBackground => lawnBackground;
    public GameObject LawnGrid => lawnGrid;
    public GameObject TilePrefab => tilePrefab;
    public GameObject ZombiesContainer => zombiesContainer;
    public List<GameObject> Zombies => zombies;

    public bool HasZombieCrossed { get; set; }

    // --------------------------------------------------------------------------------------------

    public void AddZombie(GameObject zombie)
    {
        zombies.Add(zombie);
    }
    public void RemoveZombie(GameObject zombie)
    {
        zombies.Remove(zombie);
    }

    // --------------------------------------------------------------------------------------------

    public void SetupLawn()
    {
        Vector3 lawnGridPos = lawnGrid.transform.position;
        lawnBackground.sprite = lawnImage;
        HasZombieCrossed = false;

        for (int row = 0; row < rowAmount; row++)
        {
            for (int col = 0; col < columnAmount; col++)
            {
                GameObject tile = Instantiate(tilePrefab, lawnGrid.transform);
                
                // Adding a collider to the first column of each row (for Game Over trigger)
                if (col == 0)
                {
                    BoxCollider2D collider = tile.GetComponent<BoxCollider2D>();
                    if (collider == null)
                    {
                        collider = tile.AddComponent<BoxCollider2D>();
                    }
                    collider.isTrigger = true;
                }
            }
        }
    
        LayoutRebuilder.ForceRebuildLayoutImmediate(lawnGrid.GetComponent<RectTransform>());
    }
    
    // --------------------------------------------------------------------------------------------

    public Vector2 GetTileSize(){
        GameObject tile = lawnGrid.transform.GetChild(0).gameObject;
        RectTransform rect = tile.GetComponent<RectTransform>();
        if (rect!= null)
        {
            return rect.sizeDelta;
        }
        return Vector2.zero;
    }

    public Vector3 GetTileCenter(int i, int j)
    {
        int index = (i - 1) * columnAmount + (j - 1);
        if (index < 0 || index >= lawnGrid.transform.childCount)
        {
            Debug.LogError($"Invalid index: {index} (i={i}, j={j})");
            return Vector3.zero;
        }

        GameObject tile = lawnGrid.transform.GetChild(index).gameObject;
        RectTransform rect = tile.GetComponent<RectTransform>();

        if (rect != null)
        {
            // Get world position of tile's center using anchors and pivot
            Vector3 worldPosition = rect.position;
            worldPosition.x += rect.rect.width * (0.5f - rect.pivot.x);
            worldPosition.y -= rect.rect.height * (0.5f - rect.pivot.y);
            return worldPosition;
        }

        Debug.LogError($"Tile ({i}, {j}) does not have a RectTransform!");
        return Vector3.zero;
    }

    public Vector2Int? GetTileFromPosition(Vector2 worldPosition)
    {
        RectTransform gridRect = lawnGrid.GetComponent<RectTransform>();
        Vector2 localPoint = gridRect.InverseTransformPoint(worldPosition);
        Vector2 tileSize = GetTileSize();
        float offsetX = localPoint.x;
        float offsetY = -localPoint.y;
        if (offsetX < 0 || offsetY < 0) { return null; }
        int col = Mathf.FloorToInt(offsetX / tileSize.x);
        int row = Mathf.FloorToInt(offsetY / tileSize.y);
        if (col < 1 || col >= columnAmount - 1 || row < 0 || row >= rowAmount) { return null; }
        return new Vector2Int(row + 1, col);
    }

    // --------------------------------------------------------------------------------------------

    public void PlantSeed(GameObject plantPrefab, Vector2 plantPosition){
        Vector2Int? tileCoords = GetTileFromPosition(plantPosition);
        if (tileCoords != null){
            int row = tileCoords.Value.x;
            int col = tileCoords.Value.y;
            int index = (row - 1) * columnAmount + col;

            Tile tile = lawnGrid.transform.GetChild(index).gameObject.GetComponent<Tile>();

            if (tile.IsFree){
                tile.Plant(plantPrefab);
                Debug.Log($"Trying to plant at ({row}, {col}), of index {index}");
            }
        }
    }

    // --------------------------------------------------------------------------------------------
}
