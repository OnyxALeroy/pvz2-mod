using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ZombieWave", menuName = "PVZ 2/Create new Wave")]
public class ZombieWave : ScriptableObject
{
    [SerializeField] string waveName;

    [System.Serializable]
    public class ZombieEntry
    {
        public Zombie zombie;
        [Range(1, 5)] public int spawnLane;
        public int spawnColumn = -1;
    }

    [SerializeField] List<ZombieEntry> zombies = new List<ZombieEntry>();

    public List<ZombieEntry> GetZombies() => zombies;

    // Spawning zombies at their specified lane
    public void SpawnZombies(Lawn lawn, GameObject zombieObject){
        foreach(var entry in zombies){
            int column;
            if (entry.spawnColumn == -1){
                column = 11;
            } else {
                column = entry.spawnColumn + 1; // '+1' : the first column triggers Game Over
            }
            Debug.Log($"Spawning {entry.zombie.name} at cell ({entry.spawnLane}, {column})");

            Vector3 spawnPosition = lawn.GetTileCenter(entry.spawnLane, column);
            GameObject newZombie = Instantiate(zombieObject, spawnPosition, Quaternion.identity, lawn.ZombiesContainer.transform);
            newZombie.GetComponent<ZombieObject>().zombie = entry.zombie;
            newZombie.GetComponent<ZombieObject>().SetSprite();
            lawn.AddZombie(newZombie);
        }
    }
}
