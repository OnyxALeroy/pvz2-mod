using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SeedSlot : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerClickHandler
{
    public SeedManager seedManager;
    public int id;
    public bool isClickSelected = false;
    public Plant plant;

    private GameObject previewPlant;
    private bool isAvailable = true;
    private float internalCooldown;

    // Displaying parameters
    private Image cooldownOverlay;
    private Vector3 targetScale;
    private Vector3 originalScale;
    private bool hasStoredOriginalScale = false;
    private Image[] images;
    private Color[] originalColors;
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

        // Grab the overlay by name or tag
        cooldownOverlay = transform.Find("CooldownOverlay").GetComponent<Image>();
        cooldownOverlay.fillAmount = 0f;
    }

    private void Update(){
        HandleScaleTransition();
        HandleAvailability();

        // Cooldown ticking down
        if (internalCooldown > 0f){
            internalCooldown -= Time.deltaTime;
        }

        // Cooldown overlay manager
        float cooldownProgress = Mathf.Clamp01(internalCooldown / plant.SeedRecharge);
        cooldownOverlay.fillAmount = cooldownProgress;

        // Manage "Click & Click" plantation
        if (isClickSelected && Input.GetMouseButtonDown(0)){
            Vector3 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            worldPoint.z = 0;
            if (seedManager.PlantSeed(worldPoint, plant)){
                internalCooldown = plant.SeedRecharge;
            }
            isClickSelected = false;
        }
    }

    // --------------------------------------------------------------------------------------------

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (internalCooldown <= 0f){
            if (plant.PlantObject && seedManager.CheckIfCanPlant(plant.SunCost, true))
            {
                seedManager.ChangeSelection(id);
                previewPlant = Instantiate(plant.PlantObject);
                
                // Making the plant semi-transparent
                foreach (var sr in previewPlant.GetComponentsInChildren<SpriteRenderer>())
                {
                    Color c = sr.color;
                    c.a = 0.5f;
                    sr.color = c;
                }
            }
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (internalCooldown <= 0f){
            if (previewPlant)
            {
                Vector3 worldPoint = Camera.main.ScreenToWorldPoint(eventData.position);
                worldPoint.z = 0;
                previewPlant.transform.position = worldPoint;
            }
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (internalCooldown <= 0f){
            if (previewPlant)
            {
                seedManager.ChangeSelection(id);
                Vector3 plantPosition = previewPlant.transform.position;
                Destroy(previewPlant);
                previewPlant = null;
                if (seedManager.PlantSeed(plantPosition, plant)){
                    internalCooldown = plant.SeedRecharge;
                }
            }
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (internalCooldown <= 0f && seedManager.CheckIfCanPlant(plant.SunCost, true)){
            seedManager.ChangeSelection(id);
        }
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
        isAvailable = seedManager.CheckIfCanPlant(plant.SunCost, false) && internalCooldown <= 0f;
        bool hasEnoughSun = seedManager.CheckIfCanPlant(plant.SunCost, false);
        for (int i = 0; i < images.Length; i++)
        {
            Color original = originalColors[i];
            Color targetColor = hasEnoughSun
                ? original
                : new Color(original.r * darkenFactor, original.g * darkenFactor, original.b * darkenFactor, original.a);

            images[i].color = Color.Lerp(images[i].color, targetColor, Time.deltaTime * colorLerpSpeed);
        }
    }
}
