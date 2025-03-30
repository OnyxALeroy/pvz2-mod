using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    // Needed Prefabs for populating
    [SerializeField] GameObject zombieObject;
    [SerializeField] Lawn lawn;

    [SerializeField] List<Zombie> zombiePool;        // These are zombies who will be shown at the right
    [SerializeField] List<ZombieWave> zombieWaves;   // These are the waves of zombies (in order)

    private int currentWave = 0;

    private void Start(){
        lawn.SetupLawn();
        LaunchNextWave();
    }

    private void Update(){
        float tileWidth = lawn.GetTileSize()[0];
        foreach (var zombieObject in lawn.Zombies){
            zombieObject.GetComponent<ZombieObject>().ZombieUpdate(tileWidth);

            // TODO: check if zombie is dead and remove it from the level
        }
    }

    // --------------------------------------------------------------------------------------------

    private void LaunchNextWave(){
        if(currentWave < zombieWaves.Count){
            Debug.Log("Launched wave " + currentWave);
            zombieWaves[currentWave].SpawnZombies(lawn, zombieObject);
            currentWave++;
        }
        
        Debug.Log("No wave left to launch!");
    }
}
