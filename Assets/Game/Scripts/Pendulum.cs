using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Pendulum : MonoBehaviour
{
    [SerializeField] float moveTime = 1f;
    [SerializeField] float waitTime = 1f;
    [SerializeField] AnimationCurve movementEase;

    private void OnTriggerEnter(Collider other)
    {
        CubeMovement cube = other.GetComponent<CubeMovement>();
        if (cube != null)
        {
            cube.Die();
        }

    }
    private void Start()
    {
        Vector3 rotateVector = new Vector3(-70, 0, 0);
        Sequence moveSequence = DOTween.Sequence();
        moveSequence.Append(transform.DORotate(rotateVector, moveTime)).SetEase(movementEase)
            .AppendInterval(waitTime)
            .Append(transform.DORotate(-rotateVector, moveTime)).SetEase(movementEase)
            .AppendInterval(waitTime)
            .SetLoops(-1);

    }
}
