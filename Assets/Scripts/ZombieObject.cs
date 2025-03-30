using UnityEngine;
using UnityEngine.UI;

public class ZombieObject : MonoBehaviour
{
    public Zombie zombie;
    public GameObject zombiePrefabTemplate;

    void Start(){}

    void Update(){}

    // --------------------------------------------------------------------------------------------

    // Utils for the SetSprite method
   GameObject FindChildByName(Transform parent, string childName)
    {
        foreach (Transform child in parent)
        {
            if (child.name == childName)
            {
                return child.gameObject;
            }

            GameObject found = FindChildByName(child, childName);
            if (found != null) 
            {
                return found;
            }
        }
        return null;
    }

    // --------------------------------------------------------------------------------------------

    public void SetSprite(){
        zombiePrefabTemplate = Instantiate(zombie.ZombiePrefabTemplate, transform.position, transform.rotation);
        zombiePrefabTemplate.transform.SetParent(transform);

        if (zombie.BodyChange != null) { FindChildByName(zombiePrefabTemplate.transform, "Body").GetComponent<SpriteRenderer>().sprite = zombie.BodyChange; }
        if (zombie.HeadTopPartChange != null) { FindChildByName(zombiePrefabTemplate.transform, "HeadTopPart").GetComponent<SpriteRenderer>().sprite = zombie.HeadTopPartChange; }
        if (zombie.HeadBottomPartChange != null) { FindChildByName(zombiePrefabTemplate.transform, "HeadBottomPart").GetComponent<SpriteRenderer>().sprite = zombie.HeadBottomPartChange; }
        if (zombie.HeadAccessoryChange != null) { FindChildByName(zombiePrefabTemplate.transform, "HeadAccessory").GetComponent<SpriteRenderer>().sprite = zombie.HeadAccessoryChange; }
        if (zombie.LeftArmChange != null) { FindChildByName(zombiePrefabTemplate.transform, "LeftArm").GetComponent<SpriteRenderer>().sprite = zombie.LeftArmChange; }
        if (zombie.LeftForearmChange != null) { FindChildByName(zombiePrefabTemplate.transform, "LeftForearm").GetComponent<SpriteRenderer>().sprite = zombie.LeftForearmChange; }
        if (zombie.LeftHandChange != null) { FindChildByName(zombiePrefabTemplate.transform, "LeftHand").GetComponent<SpriteRenderer>().sprite = zombie.LeftHandChange; }
        if (zombie.RightArmChange != null) { FindChildByName(zombiePrefabTemplate.transform, "RightArm").GetComponent<SpriteRenderer>().sprite = zombie.RightArmChange; }
        if (zombie.RightForearmChange != null) { FindChildByName(zombiePrefabTemplate.transform, "RightForearm").GetComponent<SpriteRenderer>().sprite = zombie.RightForearmChange; }
        if (zombie.RightHandChange != null) { FindChildByName(zombiePrefabTemplate.transform, "RightHand").GetComponent<SpriteRenderer>().sprite = zombie.RightHandChange; }
        if (zombie.BottomChange != null) { FindChildByName(zombiePrefabTemplate.transform, "Bottom").GetComponent<SpriteRenderer>().sprite = zombie.BottomChange; }
        if (zombie.LeftThighChange != null) { FindChildByName(zombiePrefabTemplate.transform, "LeftThigh").GetComponent<SpriteRenderer>().sprite = zombie.LeftThighChange; }
        if (zombie.LeftLegChange != null) { FindChildByName(zombiePrefabTemplate.transform, "LeftLeg").GetComponent<SpriteRenderer>().sprite = zombie.LeftLegChange; }
        if (zombie.LeftFootBackChange != null) { FindChildByName(zombiePrefabTemplate.transform, "LeftFootBack").GetComponent<SpriteRenderer>().sprite = zombie.LeftFootBackChange; }
        if (zombie.LeftFootFrontChange != null) { FindChildByName(zombiePrefabTemplate.transform, "LeftFootFront").GetComponent<SpriteRenderer>().sprite = zombie.LeftFootFrontChange; }
        if (zombie.RightThighChange != null) { FindChildByName(zombiePrefabTemplate.transform, "RightThigh").GetComponent<SpriteRenderer>().sprite = zombie.RightThighChange; }
        if (zombie.RightLegChange != null) { FindChildByName(zombiePrefabTemplate.transform, "RightLeg").GetComponent<SpriteRenderer>().sprite = zombie.RightLegChange; }
        if (zombie.RightFootBackChange != null) { FindChildByName(zombiePrefabTemplate.transform, "RightFootBack").GetComponent<SpriteRenderer>().sprite = zombie.RightFootBackChange; }
        if (zombie.RightFootFrontChange != null) { FindChildByName(zombiePrefabTemplate.transform, "RightFootFront").GetComponent<SpriteRenderer>().sprite = zombie.RightFootFrontChange; }
    }
}
