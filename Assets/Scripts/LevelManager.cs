using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    // Needed Prefabs for populating
    [SerializeField] GameObject zombieObject;
    [SerializeField] Lawn lawn;
    [SerializeField] Level level;
    [SerializeField] SeedManager seedManager;
    [SerializeField] SunDisplay sunDisplay;

    // FIXME: Should be filled when plants are chosen
    [SerializeField] List<Plant> plants = new List<Plant>();

    // FIXME: Will have to be defaulted to 0
    private int sunAmount = 250;

    private List<ZombieWave> zombieWaves;   // These are the waves of zombies (in order)
    private int currentWave = -1;
    private float internalLevelTimer = 0f;

    private void Start(){
        zombieWaves = level.Waves;
        if (zombieWaves == null || zombieWaves.Count == 0){
            Debug.LogError("No waves found! Ensure Level has waves assigned.");
            return;
        }

        lawn.SetupLawn();
        seedManager.SetupSeeds(plants);
        LaunchNextWave(true);
    }

    private void Update(){
        internalLevelTimer += Time.fixedDeltaTime;

        // Managing Zombies
        float tileWidth = lawn.GetTileSize()[0];
        foreach (var zombieObject in lawn.Zombies){
            zombieObject.GetComponent<ZombieObject>().ZombieUpdate(tileWidth);
            // TODO: check if zombie is dead and remove it from the level
        }

        // Updating the sun amount
        sunDisplay.SetSunAmount(sunAmount);

        // Checking if Game Over
        if (!IsGameOver()){
            LaunchNextWave(false);
        } else {
            // TODO: manage game over
            Debug.Log("Game Over!");
        }
    }

    // --------------------------------------------------------------------------------------------

    private void LaunchWave(){
        currentWave++;
        ZombieWave wave = zombieWaves[currentWave];
        if (currentWave >= zombieWaves.Count){
            Debug.LogError($"currentWave {currentWave} index is out of range! No more waves to launch.");
            return;
        }

        wave.Setup();
        Debug.Log("Launched wave " + currentWave);
        foreach(var entry in wave.Zombies){
            int column;
            if (entry.spawnColumn == 0){
                column = 11;
            } else {
                column = entry.spawnColumn + 1; // '+1' : the first column triggers Game Over
            }
            Vector3 spawnPosition = lawn.GetTileCenter(entry.spawnLane, column);
            GameObject newZombie = Instantiate(zombieObject, spawnPosition, Quaternion.identity, lawn.ZombiesContainer.transform);
            newZombie.GetComponent<ZombieObject>().zombie = entry.zombie;
            newZombie.GetComponent<ZombieObject>().SetSprite();
            lawn.AddZombie(newZombie);
        }
    }

    private void LaunchNextWave(bool doForceSpawning){
        if(currentWave < zombieWaves.Count){
            if (doForceSpawning){
                LaunchWave();
            } else if (internalLevelTimer >= level.TimeLimit || zombieWaves[currentWave].GetHealthPercentage() <= (100f - level.TransitionDamagePercentage)) {
                internalLevelTimer = 0f;
                LaunchWave();
            }
        } else {
            // TODO: manage end (by a win) of level
            Debug.Log("No wave left to launch!");
        }
    }

    // --------------------------------------------------------------------------------------------

    public bool CheckIfCanPlant(int plantingCost, bool showAnimation){
        if (plantingCost <= sunAmount){
            return true;
        } else {
            if (showAnimation){
                sunDisplay.ShowNotEnoughSun();
            }
            return false;
        }
    }

    public void PlantSeed(GameObject plantPrefab, Vector2 plantPosition, int plantingCost){
        if (CheckIfCanPlant(plantingCost, true)){
            if (lawn.PlantSeed(plantPrefab, plantPosition)){
                sunAmount -= plantingCost;
            }
        }
    }

    // --------------------------------------------------------------------------------------------

    private bool IsGameOver(){
        return lawn.HasZombieCrossed;
    }
}
