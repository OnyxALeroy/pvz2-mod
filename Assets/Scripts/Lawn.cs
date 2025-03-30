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

        for (int row = 0; row < rowAmount; row++)
        {
            for (int col = 0; col < columnAmount; col++)
            {
                Instantiate(tilePrefab, lawnGrid.transform);
            }
        }
    
        LayoutRebuilder.ForceRebuildLayoutImmediate(lawnGrid.GetComponent<RectTransform>());
    }

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
}
