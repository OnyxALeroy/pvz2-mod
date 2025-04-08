using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour
{
    private bool isFree = true;
    public bool IsFree => isFree;
    
    private GameObject content;

    public void Plant(GameObject plantObject, GameObject plant){
        isFree = false;
        content = Instantiate(plantObject, transform.position, transform.rotation);
        Instantiate(plant, content.transform, false);
        StartCoroutine(AdjustAfterLayout());
    }

    private IEnumerator AdjustAfterLayout()
    {
        yield return new WaitForEndOfFrame();

        content.GetComponent<RectTransform>().anchoredPosition += new Vector2(0, -0.1f);
    }
}
