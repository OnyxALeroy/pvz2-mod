using UnityEngine;
using UnityEngine.UI;

public class ZombiePrefab : MonoBehaviour
{
    [SerializeField] float xOffset = 0f;
    [SerializeField] float yOffset = 0f;
    [SerializeField] float zOffset = 0f;
    [SerializeField] float waitBeforeMove = 0f;
    [SerializeField] float movingBeginningOffset = 0f;
    [SerializeField] float movingEndingOffset = 0f;
    [SerializeField] float beginningSpeedCurvature = 0f;
    [SerializeField] float endingSpeedCurvature = 0f;

    public float XOffset => xOffset;
    public float YOffset => yOffset;
    public float ZOffset => zOffset;
    public float WaitBeforeMove => waitBeforeMove;
    public float MovingBeginningOffset => movingBeginningOffset;
    public float MovingEndingOffset => movingEndingOffset;
    public float BeginningSpeedCurvature => beginningSpeedCurvature;
    public float EndingSpeedCurvature => endingSpeedCurvature;
}
