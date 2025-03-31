using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Level", menuName = "PVZ 2/Create new Level")]
public class Level : ScriptableObject
{
    [Header("Level Infos")]
    [SerializeField] string levelName;
    [Tooltip("in seconds")]
    [SerializeField] float timeLimit;
    [SerializeField, Range(1, 100)] int transitionDamagePercentage;

    [Space(10)]
    [Header("Waves")]
    [SerializeField] List<ZombieWave> waves = new List<ZombieWave>();

    [Space(10)]
    [Header("Zombie Pool")] // These are zombies who will be shown at the right
    [SerializeField] List<Zombie> zombiePool;

    public string LevelName => levelName;
    public float TimeLimit { get { return Mathf.Max(0f, timeLimit); } }
    public float TransitionDamagePercentage => transitionDamagePercentage;
    public List<ZombieWave> Waves => waves;
    public List<Zombie> ZombiePool => zombiePool;
}
