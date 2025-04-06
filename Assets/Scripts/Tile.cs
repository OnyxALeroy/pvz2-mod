using UnityEngine;

public class Tile : MonoBehaviour
{
    private bool isFree = true;
    public bool IsFree => isFree;

    public void Plant(GameObject plant){
        isFree = false;
        Instantiate(plant, transform.position, transform.rotation);
    }
}
