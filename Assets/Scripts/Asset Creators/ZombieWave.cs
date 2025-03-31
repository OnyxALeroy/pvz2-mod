using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ZombieWave
{
    [SerializeField] bool isBigWave;

    [System.Serializable]
    public class ZombieEntry
    {
        public Zombie zombie;

        [Range(1, 5)] public int spawnLane = 1;
        [Range(0, 9)] public int spawnColumn = 0;
    }

    [SerializeField] private List<ZombieEntry> zombies = new List<ZombieEntry>();

    private int maxHealth;

    public bool IsBigWave => isBigWave;
    public List<ZombieEntry> Zombies => zombies;

    public void Setup(){
        maxHealth = 0;
        foreach( ZombieEntry entry in zombies){
            maxHealth += entry.zombie.MaxHealth;
        }
    }

    public float GetHealthPercentage(){
        int currentHealth = 0;
        foreach( ZombieEntry entry in zombies){
            currentHealth += entry.zombie.Health;
        }
        return (currentHealth / maxHealth)*100f;
    }
}
