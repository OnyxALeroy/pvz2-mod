using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour
{
    private bool isFree = true;
    public bool IsFree => isFree;
    
    private GameObject content;

    public void Plant(GameObject plant){
        isFree = false;
        content = Instantiate(plant, transform.position, transform.rotation);
        StartCoroutine(AdjustAfterLayout());
    }

    private IEnumerator AdjustAfterLayout()
    {
        yield return new WaitForEndOfFrame();

        content.GetComponent<RectTransform>().anchoredPosition += new Vector2(0, -0.1f);
    }
}
