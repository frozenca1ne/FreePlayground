using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class Spikes : MonoBehaviour
{
    [SerializeField] float maxYValue = 0.2f;
    [SerializeField] float moveTime = 1f;
    [SerializeField] float waitTime = 1f;

   
    private void Start()
    {
        //StartCoroutine("MoveSpikes");
        /* Sequence movementSequence = DOTween.Sequence();
         movementSequence.AppendInterval(waitTime);
         movementSequence.Append(transform.DOMoveY(maxYValue, moveTime));
         movementSequence.AppendInterval(waitTime);
         movementSequence.Append(transform.DOMoveY(0, moveTime));
         movementSequence.SetLoops(-1);
        */
        Sequence movementSequence = DOTween.Sequence();
        movementSequence.AppendInterval(waitTime/2)
            .Append(transform.DOMoveY(maxYValue, moveTime).SetEase(Ease.OutElastic))
            .AppendInterval(waitTime/2)
            .SetLoops(-1,LoopType.Yoyo);
    }

    private void OnTriggerEnter(Collider other)
    {
        CubeMovement cube = other.GetComponent<CubeMovement>();
        cube.Die();
    }
}
