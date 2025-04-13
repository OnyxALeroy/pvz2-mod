using UnityEngine;

public class PlantObject : MonoBehaviour
{
    public Plant plant;
    public GameObject plantPrefabInstance;

    private Rigidbody2D rb;

    private void Start(){
        rb = GetComponent<Rigidbody2D>();
    }

    public void PlantUpdate(Lawn lawn){}

    // --------------------------------------------------------------------------------------------
    // --------------------------------------------------------------------------------------------
    // --------------------------------------------------------------------------------------------

    private void AdjustColliderSize()
    {
        BoxCollider2D collider = GetComponent<BoxCollider2D>();
        if (collider == null)
        {
            collider = gameObject.AddComponent<BoxCollider2D>();
        }

        SpriteRenderer spriteRenderer = plantPrefabInstance.GetComponentInChildren<SpriteRenderer>();
        if (spriteRenderer != null && spriteRenderer.sprite != null)
        {
            Vector2 size = spriteRenderer.sprite.rect.size / spriteRenderer.sprite.pixelsPerUnit;
            collider.size = size;
            collider.offset = spriteRenderer.transform.localPosition;
        }
    }

    // --------------------------------------------------------------------------------------------

    public void SetSprite(int row){
        plantPrefabInstance = Instantiate(plant.PlantObject, transform.position, transform.rotation);
        plantPrefabInstance.transform.SetParent(transform);
        AdjustColliderSize();

        int offset = row * 100;
        foreach (SpriteRenderer sr in plantPrefabInstance.GetComponentsInChildren<SpriteRenderer>())
        {
            sr.sortingOrder += offset;
        }
    }

    // --------------------------------------------------------------------------------------------
    // --------------------------------------------------------------------------------------------
    // --------------------------------------------------------------------------------------------
    
    // Unity's built-in method to detect collisions
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Plant entered trigger with: " + other.gameObject.name);
    }

    // --------------------------------------------------------------------------------------------
}
