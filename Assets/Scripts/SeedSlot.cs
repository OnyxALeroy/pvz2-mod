using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SeedSlot : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerClickHandler
{
    public GameObject plantPrefab;
    public SeedManager seedManager;
    public int id;
    public bool isClickSelected = false;
    public int sunCost;

    private GameObject previewPlant;
    private Vector3 targetScale;
    private Vector3 originalScale;
    private bool hasStoredOriginalScale = false;
    private Image[] images;
    private Color[] originalColors;
    private bool colorsInitialized = false;
    private float scaleSpeed = 5f;
    private float selectedScaleMultiplier = 1.2f;
    private float darkenFactor = 0.25f;
    private float colorLerpSpeed = 10f;

    // --------------------------------------------------------------------------------------------

    private void Start()
    {
        images = GetComponentsInChildren<Image>();
        originalColors = new Color[images.Length];

        for (int i = 0; i < images.Length; i++)
        {
            originalColors[i] = images[i].color;
        }

        colorsInitialized = true;
    }

    private void Update(){
        HandleScaleTransition();
        HandleAvailability();

        if (isClickSelected && Input.GetMouseButtonDown(0)){
            Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            worldPoint.z = 0;
            seedManager.PlantSeed(plantPrefab, worldPoint, sunCost);
            isClickSelected = false;
        }
    }

    // --------------------------------------------------------------------------------------------

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (plantPrefab && seedManager.CheckIfCanPlant(sunCost, true))
        {
            seedManager.ChangeSelection(id);
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
            seedManager.ChangeSelection(id);
            Vector3 plantPosition = previewPlant.transform.position;
            Destroy(previewPlant);
            previewPlant = null;
            seedManager.PlantSeed(plantPrefab, plantPosition, sunCost);
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        seedManager.ChangeSelection(id);
    }

    // --------------------------------------------------------------------------------------------
    
    private void HandleScaleTransition()
    {
        if (!hasStoredOriginalScale)
        {
            originalScale = transform.localScale;
            hasStoredOriginalScale = true;
        }

        Vector3 targetScale = isClickSelected ? originalScale * selectedScaleMultiplier : originalScale;
        transform.localScale = Vector3.Lerp(transform.localScale, targetScale, Time.deltaTime * scaleSpeed);
    }

    private void HandleAvailability()
    {
        if (!colorsInitialized) return;

        bool isAvailable = seedManager.CheckIfCanPlant(sunCost, false);

        for (int i = 0; i < images.Length; i++)
        {
            Color original = originalColors[i];
            Color targetColor = isAvailable
                ? original
                : new Color(original.r * darkenFactor, original.g * darkenFactor, original.b * darkenFactor, original.a);

            images[i].color = Color.Lerp(images[i].color, targetColor, Time.deltaTime * colorLerpSpeed);
        }
    }
}
