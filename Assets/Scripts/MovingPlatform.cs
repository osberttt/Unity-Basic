using UnityEngine;
using DG.Tweening;

public class MovingPlatform : MonoBehaviour
{
    [Header("Movement Settings")]
    public Transform pointA;
    public Transform pointB;
    public float moveDuration = 2f;
    public bool startAtPointA = true; // has to be true

    private void Start()
    {
        // Set starting position
        transform.position = startAtPointA ? pointA.position : pointB.position; // ternary operator

        // Start moving between the two points
        MovePlatform();
    }

    void MovePlatform()
    {
        // Create looped movement sequence
        if (startAtPointA)
        {
            transform
                .DOMove(pointB.position, moveDuration)
                .SetEase(Ease.InOutSine)
                .SetLoops(-1, LoopType.Yoyo);
        }
        else
        {
            transform
                .DOMove(pointA.position, moveDuration)
                .SetEase(Ease.InOutSine)
                .SetLoops(-1, LoopType.Yoyo);
        }
    }

   
}