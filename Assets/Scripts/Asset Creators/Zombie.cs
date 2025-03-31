using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum SpeedType {
    Basic,
    Creeper,
    Stiff,
    Hungry,
    Speedy,
    Flighty
}

public enum ToughnessType {
    Average,
    Fragile,
    Solid,
    Protected,
    Dense,
    Hardened,
    Machined,
    Great,
    Undying,
    UltraUndying
}

[CreateAssetMenu(fileName = "Zombie", menuName = "PVZ 2/Create new Zombie")]
public class Zombie : ScriptableObject
{
    [Header("Zombie Infos")]
    [SerializeField] GameObject zombiePrefabTemplate;
    [SerializeField] string zombieName;

    [TextArea]
    [SerializeField] string description;

    [SerializeField] SpeedType zombieSpeedType;
    
    [System.Serializable]
    public class ZombieHealthComponent
    {
        [SerializeField] string componentName;
        [SerializeField] int maxHealth;
        public string ComponentName => componentName;
        public int MaxHealth => maxHealth;

        private int health = -1;
        public int Health { get => health; set { health = value; } }
    }
    [SerializeField] List<ZombieHealthComponent> heathComponents = new List<ZombieHealthComponent>(){};
    
    // Sprite Changes
    [Space(10)]
    [Header("Sprite Changes")]
    [SerializeField] Sprite bodyChange = null;
    [SerializeField] Sprite headTopPartChange = null;
    [SerializeField] Sprite headBottomPartChange = null;
    [SerializeField] Sprite headAccessoryChange = null;
    [SerializeField] Sprite leftArmChange = null;
    [SerializeField] Sprite leftForearmChange = null;
    [SerializeField] Sprite leftHandChange = null;
    [SerializeField] Sprite rightArmChange = null;
    [SerializeField] Sprite rightForearmChange = null;
    [SerializeField] Sprite rightHandChange = null;
    [SerializeField] Sprite bottomChange = null;
    [SerializeField] Sprite leftThighChange = null;
    [SerializeField] Sprite leftLegChange = null;
    [SerializeField] Sprite leftFootBackChange = null;
    [SerializeField] Sprite leftFootFrontChange = null;
    [SerializeField] Sprite rightThighChange = null;
    [SerializeField] Sprite rightLegChange = null;
    [SerializeField] Sprite rightFootBackChange = null;
    [SerializeField] Sprite rightFootFrontChange = null;

    // Getters
    public string ZombieName => zombieName;
    public string Description => description;
    public GameObject ZombiePrefabTemplate => zombiePrefabTemplate;

    public SpeedType ZombieSpeedType => zombieSpeedType;
    
    public int Health
    {
        get
        {
            int H = 0;

            foreach (var component in heathComponents)
            {
                int h = component.Health;

                if (h == -1){
                    h = component.MaxHealth;
                    component.Health = h;
                }

                H += h;
            }

            return H;
        }
    } 
    public int MaxHealth
    {
        get
        {
            int health = 0;

            foreach (var component in heathComponents)
            {
                health += component.MaxHealth;
            }

            return health;
        }
    }

    public List<ZombieHealthComponent> HealthComponents => heathComponents;

    public ToughnessType Toughness
    {
        get
        {
            int health = MaxHealth;
            if (health <= 0) { 
                Debug.LogError("Health cannot be negative");
                return ToughnessType.UltraUndying; 
            }
            if (health >= 1 && health <= 100) { return ToughnessType.Fragile; }
            if (health >= 101 && health <= 200) { return ToughnessType.Average; }
            if (health >= 201 && health <= 320) { return ToughnessType.Solid; }
            if (health >= 321 && health <= 600) { return ToughnessType.Protected; }
            if (health >= 301 && health <= 1000) { return ToughnessType.Dense; }
            if (health >= 1001 && health <= 1700) { return ToughnessType.Hardened; }
            if (health >= 1701 && health <= 2500) { return ToughnessType.Machined; }
            if (health >= 2501 && health <= 8000) { return ToughnessType.Great; }
            if (health >= 8001 && health <= 29500) { return ToughnessType.Undying; }
            return ToughnessType.UltraUndying;
        }
    }
    public float Speed { get { return SpeedDictionary[ZombieSpeedType]; } }

    public Sprite BodyChange => bodyChange;
    public Sprite HeadTopPartChange => headTopPartChange;
    public Sprite HeadBottomPartChange => headBottomPartChange;
    public Sprite HeadAccessoryChange => headAccessoryChange;
    public Sprite LeftArmChange => leftArmChange;
    public Sprite LeftForearmChange => leftForearmChange;
    public Sprite LeftHandChange => leftHandChange;
    public Sprite RightArmChange => rightArmChange;
    public Sprite RightForearmChange => rightForearmChange;
    public Sprite RightHandChange => rightHandChange;
    public Sprite BottomChange => bottomChange;
    public Sprite LeftThighChange => leftThighChange;
    public Sprite LeftLegChange => leftLegChange;
    public Sprite LeftFootBackChange => leftFootBackChange;
    public Sprite LeftFootFrontChange => leftFootFrontChange;
    public Sprite RightThighChange => rightThighChange;
    public Sprite RightLegChange => rightLegChange;
    public Sprite RightFootBackChange => rightFootBackChange;
    public Sprite RightFootFrontChange => rightFootFrontChange;

    // Stats Dictionaries
    public static readonly Dictionary<SpeedType, float> SpeedDictionary = new Dictionary<SpeedType, float>(){
        { SpeedType.Basic, 5f },
        { SpeedType.Creeper, 7.5f },
        { SpeedType.Stiff, 6.75f },
        { SpeedType.Hungry, 3.75f },
        { SpeedType.Speedy, 2.5f },
        { SpeedType.Flighty, 0.5f }
    };
}
