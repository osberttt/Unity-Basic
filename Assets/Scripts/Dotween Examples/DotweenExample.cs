using DG.Tweening;
using UnityEngine;

public class DotweenExample : MonoBehaviour
{
    public Vector3 endPosition = new Vector3(3, 0, 0);
   
    public float moveDuration = 1.5f;

    void Start()
    {
        transform
            .DOMove(endPosition, moveDuration)
            .OnComplete(() =>
            {
                Debug.Log("Compelete");
                Debug.Log("Lambda function");
            }); // lambda function
    }

    void CompeleteFunction()
    {
        Debug.Log("Compelete");
    }
}
