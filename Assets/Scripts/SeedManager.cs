using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SeedManager : MonoBehaviour
{
    [SerializeField] LevelManager levelManager;
    [SerializeField] GameObject seedSlotPrefab;

    public void SetupSeeds(List<Plant> plants){
        int seedId = 0;
        foreach (var plant in plants)
        {
            Transform seedSlot = Instantiate(seedSlotPrefab, transform).transform;  
            seedSlot.GetComponent<SeedSlot>().plantPrefab = plant.PlantObject;
            seedSlot.GetComponent<SeedSlot>().seedManager = this;
            seedSlot.GetComponent<SeedSlot>().id = seedId;
            seedSlot.GetComponent<SeedSlot>().sunCost = plant.SunCost;
            seedId++;

            // Attributing the background sprite
            seedSlot.Find("Background").GetComponent<Image>().sprite = plant.SlotBackground;

            // Attributing the seed sprite (showing the plant)
            seedSlot.Find("Plant").GetComponent<Image>().sprite = plant.PlantSeed;

            // Showing the correct price
            seedSlot.Find("CostText").GetComponent<Text>().text = plant.SunCost.ToString();
        }
    }

    public void ChangeSelection(int index){
        Debug.Log($"Selecting {index}");
        transform.GetChild(index).GetComponent<SeedSlot>().isClickSelected = !transform.GetChild(index).GetComponent<SeedSlot>().isClickSelected;

        for (int i = 0; i < transform.childCount; i++){
            if (i != index){
                transform.GetChild(i).GetComponent<SeedSlot>().isClickSelected = false;
            }
        }
    }

    // --------------------------------------------------------------------------------------------

    public bool CheckIfCanPlant(int plantingCost, bool showAnimation){
        return levelManager.CheckIfCanPlant(plantingCost, showAnimation);
    }

    public void PlantSeed(GameObject plantPrefab, Vector3 plantPosition, int plantingCost){
        levelManager.PlantSeed(plantPrefab, plantPosition, plantingCost);
    }
}
