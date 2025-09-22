using UnityEngine;
using DG.Tweening; // Required for DOTween

public class DotweenRotate : MonoBehaviour
{
    [Header("Rotation")]
    public Vector3 rotationAmount = new Vector3(0, 0, 180); // How much to rotate
    public float duration = 2f; // How long the rotation takes

    void Start()
    {
        RotateObject();
    }

    void RotateObject()
    {
        // Create a rotation tween
        Tween rotationTween = transform
            .DORotate(rotationAmount, duration, RotateMode.FastBeyond360)
            .SetEase(Ease.Linear)
            .SetLoops(2, LoopType.Incremental);
    }
}