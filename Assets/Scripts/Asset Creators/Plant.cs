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

    // Sprite Changes
    [Space(10)]
    [Header("Plant Components")]
    [SerializeField] GameObject plant;
    [SerializeField] GameObject projectile; 

    // Getters
}
