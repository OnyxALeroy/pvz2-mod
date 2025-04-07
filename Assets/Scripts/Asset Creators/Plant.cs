using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// NOTE: to modify the Inspector, go to Editor/PlantEditor.cs

public enum PlantType {
    SunProducer,
    Attacker
}

public enum RangeType {
    None,
    Straight
}

[CreateAssetMenu(fileName = "Plant", menuName = "PVZ 2/Create new Plant")]
public class Plant : ScriptableObject
{
    // General Infos
    [SerializeField] string plantName;
    [TextArea] [SerializeField] string description;
    [SerializeField] int sunCost;
    [Tooltip("in seconds")] [SerializeField] float seedRecharge;
    [SerializeField] int maxHealth;
    [SerializeField] PlantType type;

    // Attackers only
    [SerializeField] int attackDamage = 0;
    [SerializeField] RangeType range = RangeType.None;
    [SerializeField] bool doShoot = false;
    [SerializeField] Vector2 fireRate = new Vector2(1.35f, 1.5f);
    [SerializeField] float projectileVelocity;

    // Sun-Producers only
    [SerializeField] int productionAmount = 0;
    [Tooltip("in seconds")] [SerializeField] float productionCooldown = 0f;

    // Display Infos
    [SerializeField] GameObject plantObject;
    [SerializeField] List<GameObject> auxiliaryObjects;
    [SerializeField] Sprite slotBackground;
    [SerializeField] Sprite plantSeed;

    // Getters ------------------------------------------------------------------------------------

    // General Infos
    public string PlantName => plantName;
    public string Description => description;
    public int SunCost => sunCost;
    public float SeedRecharge => seedRecharge;
    public int MaxHealth => maxHealth;
    public PlantType Type => type;

    // Attackers only
    public int AttackDamage => attackDamage;
    public RangeType Range => range;
    public bool DoShoot => doShoot;
    public Vector2 FireRate => fireRate;
    public float ProjectileVelocity => projectileVelocity;

    // Sun-Producers only
    public int ProductionAmount => productionAmount;
    public float ProductionCooldown => productionCooldown;

    // Display Infos
    public GameObject PlantObject => plantObject;
    public List<GameObject> AuxiliaryObjects => auxiliaryObjects;
    public Sprite SlotBackground => slotBackground;
    public Sprite PlantSeed => plantSeed;
}
