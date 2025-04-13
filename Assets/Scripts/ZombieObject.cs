using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ZombieObject : MonoBehaviour
{
    public Zombie zombie;
    public GameObject zombiePrefabTemplate;

    private Rigidbody2D rb;
    private float timeElapsed = 0f;  // Time passed since starting to move

    private void Start(){
        rb = GetComponent<Rigidbody2D>();
    }

    public void ZombieUpdate(float tileWidth){
        float waitBeforeMove = zombiePrefabTemplate.GetComponent<ZombiePrefab>().WaitBeforeMove;
        float beginningOffset = zombiePrefabTemplate.GetComponent<ZombiePrefab>().MovingBeginningOffset;
        float endingOffset = zombiePrefabTemplate.GetComponent<ZombiePrefab>().MovingEndingOffset;
        float stationaryMoveSpeed = (tileWidth / zombie.Speed) * Time.fixedDeltaTime;

        timeElapsed += Time.fixedDeltaTime;
        if (timeElapsed > waitBeforeMove && timeElapsed <= beginningOffset){
            // Beginning part of its movement (increasing exponential speed)
            float beginningSpeedCurvature = zombiePrefabTemplate.GetComponent<ZombiePrefab>().BeginningSpeedCurvature;
            float offset1 = Mathf.Log(stationaryMoveSpeed / (Mathf.Exp(beginningSpeedCurvature * beginningOffset) - 1));
            float offset2 = stationaryMoveSpeed / (1-Mathf.Exp(beginningSpeedCurvature * beginningOffset));

            float beginningSpeed = Mathf.Exp(beginningSpeedCurvature * timeElapsed + offset1) + offset2;
            rb.linearVelocity = new Vector2(-beginningSpeed, rb.linearVelocity.y);
        } else if (timeElapsed >= zombie.Speed - endingOffset && timeElapsed <= zombie.Speed){
            // Ending part of its movement (decreasing exponential speed)
            float endingSpeedCurvature = zombiePrefabTemplate.GetComponent<ZombiePrefab>().EndingSpeedCurvature;
            float offset1 = Mathf.Log(stationaryMoveSpeed / (Mathf.Exp(endingSpeedCurvature * zombie.Speed) - Mathf.Exp(endingSpeedCurvature * (zombie.Speed - endingOffset))));
            float offset2 = Mathf.Exp(endingSpeedCurvature * zombie.Speed + offset1);

            float endingSpeed = Mathf.Exp(endingSpeedCurvature * timeElapsed + offset1) + offset2;
            if (!float.IsNaN(endingSpeed) && !float.IsInfinity(endingSpeed))
            {
                rb.linearVelocity = new Vector2(-endingSpeed, rb.linearVelocity.y);
            }

        } else if (timeElapsed >= zombie.Speed){
            timeElapsed = 0f;
            rb.linearVelocity = Vector2.zero;
        } else if (timeElapsed <= waitBeforeMove){
            rb.linearVelocity = Vector2.zero;
        } else {
            // Middle part of its movement (constant speed)
            rb.linearVelocity = new Vector2(-stationaryMoveSpeed, rb.linearVelocity.y);
        }
    }

    // --------------------------------------------------------------------------------------------
    // --------------------------------------------------------------------------------------------
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

    public void SetSprite(int row){
        Vector3 offsets = new Vector3(zombie.ZombiePrefabTemplate.GetComponent<ZombiePrefab>().XOffset, zombie.ZombiePrefabTemplate.GetComponent<ZombiePrefab>().YOffset, zombie.ZombiePrefabTemplate.GetComponent<ZombiePrefab>().ZOffset);
        zombiePrefabTemplate = Instantiate(zombie.ZombiePrefabTemplate, transform.position + offsets, transform.rotation);
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

        int offset = 500 + row * 100;
        foreach (SpriteRenderer sr in zombiePrefabTemplate.GetComponentsInChildren<SpriteRenderer>())
        {
            sr.sortingOrder += offset;
        }
    }

    // --------------------------------------------------------------------------------------------
    // --------------------------------------------------------------------------------------------
    // --------------------------------------------------------------------------------------------
    
    // Unity's built-in method to detect collisions
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Zombie entered trigger with: " + other.gameObject.name);
        if (other.gameObject.name == "Tile(Clone)")
        {
            other.gameObject.transform.parent.transform.parent.GetComponent<Lawn>().HasZombieCrossed = true;
            Debug.Log("Zombie collided with a tile!");
        }
    }

    // --------------------------------------------------------------------------------------------
}
