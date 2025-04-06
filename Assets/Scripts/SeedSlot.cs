using UnityEngine;
using UnityEngine.EventSystems;

public class SeedSlot : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerClickHandler
{
    public GameObject plantPrefab;
    public SeedManager seedManager;
    private GameObject previewPlant;
    private bool isClickSelected = false;

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (plantPrefab)
        {
            previewPlant = Instantiate(plantPrefab);
            
            // Making the plant semi-transparent
            foreach (var sr in previewPlant.GetComponentsInChildren<SpriteRenderer>())
            {
                Color c = sr.color;
                c.a = 0.5f;
                sr.color = c;
            }

            Debug.Log("Dragging " + plantPrefab.name);
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (previewPlant)
        {
            Vector3 worldPoint = Camera.main.ScreenToWorldPoint(eventData.position);
            worldPoint.z = 0;
            previewPlant.transform.position = worldPoint;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (previewPlant)
        {
            Vector3 plantPosition = previewPlant.transform.position;
            Destroy(previewPlant); // Destroy the preview when drag ends
            previewPlant = null;

            seedManager.PlantSeed(plantPrefab, plantPosition);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!isClickSelected)
        {
            isClickSelected = true;
            Debug.Log("Seed selected: " + plantPrefab.name);
        }
        else
        {
            // Get the clicked position
            Vector3 worldPoint = Camera.main.ScreenToWorldPoint(eventData.position);
            worldPoint.z = 0;
            
            // Place the plant
            Instantiate(plantPrefab, worldPoint, Quaternion.identity);
            Debug.Log("Planted " + plantPrefab.name + " at " + worldPoint);

            isClickSelected = false; // Reset selection
        }
    }
}
