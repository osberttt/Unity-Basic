using UnityEngine;
using DG.Tweening;

public class RotatingObject : MonoBehaviour 
{
    public float duration = 10f;
    void Start()
    {
        // Rotate 360 degrees over 2 seconds
        transform.DORotate(new Vector3(0, 0, -360), duration, RotateMode.FastBeyond360)
            .SetEase(Ease.Linear)
            .SetLoops(-1, LoopType.Restart); // Infinite loop
    }
}


