using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SeedManager : MonoBehaviour
{
    [SerializeField] GameObject seedSlotPrefab;

    public void SetupSeeds(List<Plant> plants){
        foreach (var plant in plants)
        {
            Transform seedSlot = Instantiate(seedSlotPrefab, transform).transform;

            // Attributing the background sprite
            seedSlot.Find("Background").GetComponent<Image>().sprite = plant.SlotBackground;

            // Attributing the seed sprite (showing the plant)
            seedSlot.Find("Plant").GetComponent<Image>().sprite = plant.PlantSeed;

            // Showing the correct price
            seedSlot.Find("CostText").GetComponent<Text>().text = plant.SunCost.ToString();

            Debug.Log($"Planted {plant.PlantName} at {seedSlot.position}");
        }
    }
}
