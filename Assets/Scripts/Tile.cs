using System.Collections;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private bool isFree = true;
    public bool IsFree => isFree;
    
    private GameObject content;

    public void Plant(GameObject plantObject, Plant plant, int row){
        isFree = false;
        content = Instantiate(plantObject, transform);
        content.GetComponent<PlantObject>().plant = plant;
        content.GetComponent<PlantObject>().SetSprite(row);
        StartCoroutine(AdjustAfterLayout());
    }

    private IEnumerator AdjustAfterLayout()
    {
        yield return new WaitForEndOfFrame();

        content.GetComponent<RectTransform>().anchoredPosition += new Vector2(0, -0.1f);
    }
}
