using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class DescendingCube : MonoBehaviour
{
    [Header("Object")]
    [SerializeField] GameObject cube;

    [Header ("Move")]
    [SerializeField] float waitTime = 2f;
    [SerializeField] float moveTime = 1f;
    [SerializeField] float cubeLiftingHeight = 2f;
    [SerializeField] float buttonDownValue = 0.1f;
    [SerializeField] float buttonDownTime = 0.5f;


    private void OnTriggerEnter(Collider other)
    {
        Sequence buttonOn = DOTween.Sequence();
        buttonOn.Append(transform.DOMoveY(-buttonDownValue, buttonDownTime))
            .Append(cube.transform.DOMoveY(cubeLiftingHeight, moveTime));
    }
    private void OnTriggerExit(Collider other)
    {
        Vector3 shakeVector = new Vector3(0.5f, 0, 0);
        Sequence buttonUp = DOTween.Sequence();
        buttonUp.Append(transform.DOMoveY(buttonDownValue, buttonDownTime))
            .AppendInterval(waitTime)
            .Append(cube.transform.DOShakePosition(waitTime, shakeVector))                      
            .Append(cube.transform.DOMoveY(0.5f, moveTime));
    }
    
}
