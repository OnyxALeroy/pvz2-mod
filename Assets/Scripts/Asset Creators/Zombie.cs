using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Zombie", menuName = "PVZ 2/Create new Zombie")]
public class Zombie : ScriptableObject
{
    [SerializeField] string zombieName;

    [TextArea]
    [SerializeField] string description;
    
    [SerializeField] GameObject zombiePrefabTemplate;

    // Sprite Changes
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
}
