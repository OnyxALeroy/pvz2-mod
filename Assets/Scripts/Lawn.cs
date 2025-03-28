using UnityEngine;
using UnityEngine.UI;

public class Lawn : MonoBehaviour
{
    [SerializeField] Image lawnBackground;
    [SerializeField] GameObject lawnGrid;
    [SerializeField] GameObject tilePrefab;

    private int tileAmount = 45 + 10;

    void Start()
    {
        for (int i = 0; i < tileAmount; i++){
            GameObject tile = Instantiate(tilePrefab, lawnGrid.transform);
        }
    }
}
