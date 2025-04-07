using UnityEngine;
using UnityEngine.EventSystems;

public class SeedSlot : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerClickHandler
{
    public GameObject plantPrefab;
    public SeedManager seedManager;
    public int id;
    public bool isClickSelected = false;
    private GameObject previewPlant;

    // --------------------------------------------------------------------------------------------

    private void Update(){
        transform.Find("SelectionMark").gameObject.SetActive(isClickSelected);

        if (isClickSelected && Input.GetMouseButtonDown(0))
        {
            Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            worldPoint.z = 0;
            seedManager.PlantSeed(plantPrefab, worldPoint);
            isClickSelected = false;
        }
    }

    // --------------------------------------------------------------------------------------------

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
            Destroy(previewPlant);
            previewPlant = null;
            seedManager.PlantSeed(plantPrefab, plantPosition);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        seedManager.ChangeSelection(id);
    }
}
