using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FallBlock : MonoBehaviour
{
    [SerializeField] float fallDistance = 4f;
    [SerializeField] float fallTime = 1f;
    [SerializeField] float waitingBeforeFalling = 1f;
    [SerializeField] float waitingBeforeUp = 3f;

   
    private void DoFall()
    {
        Vector3 shakeVector = new Vector3(0, 0, 0.5f);
        Sequence fallSequence = DOTween.Sequence();
        fallSequence.Append(transform.DOShakePosition(waitingBeforeFalling, shakeVector))
            .Append(transform.DOMoveY(-fallDistance, fallTime))
            .AppendInterval(0.1f).AppendCallback(CheckPlayer)
            .AppendInterval(waitingBeforeUp)
            .Append(transform.DOMoveY(-0.1f, fallTime));
    }
    private void OnTriggerEnter(Collider other)
    {
        CubeMovement cube = other.GetComponent<CubeMovement>();
        if (cube != null)
        {
            DoFall();
        }       
    }

    private void CheckPlayer()
    {
        LayerMask layerMask = LayerMask.GetMask("Player");
        if (Physics.Raycast(transform.position,Vector3.up,5f,layerMask))
        {
            CubeMovement cube = FindObjectOfType<CubeMovement>();
            cube.SetKinemtaic();
        }
    }
}
