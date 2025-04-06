using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum RangeType {
    Straight
}

[CreateAssetMenu(fileName = "Plant", menuName = "PVZ 2/Create new Plant")]
public class Plant : ScriptableObject
{
    [Space(10)]
    [Header("Plant Infos")]
    [SerializeField] string plantName;
    [TextArea]
    [SerializeField] string description;
    [SerializeField] int sunCost;
    [Tooltip("in seconds")]
    [SerializeField] float seedRecharge;
    [SerializeField] int maxHealth;
    [SerializeField] int attackDamage;
    [SerializeField] RangeType range;
    [SerializeField] bool doShoot;
    [SerializeField] Vector2 fireRate = new Vector2(1.35f, 1.5f);
    [SerializeField] float projectileVelocity;

    [Space(10)]
    [Header("Plant Components")]
    [SerializeField] GameObject plantObject;
    [SerializeField] GameObject projectileObject;

    [Space(10)]
    [Header("Seed Slot Components")]
    [SerializeField] Sprite slotBackground;
    [SerializeField] Sprite plantSeed;

    // Getters
    public string PlantName => plantName;
    public string Description => description;
    public int SunCost => sunCost;
    public float SeedRecharge => seedRecharge;
    public int MaxHealth => maxHealth;
    public int AttackDamage => attackDamage;
    public RangeType Range => range;
    public bool DoShoot => doShoot;
    public Vector2 FireRate => fireRate;
    public float ProjectileVelocity => projectileVelocity;
    public GameObject PlantObject => plantObject;
    public GameObject ProjectileObject => projectileObject;
    public Sprite SlotBackground => slotBackground;
    public Sprite PlantSeed => plantSeed;
}
