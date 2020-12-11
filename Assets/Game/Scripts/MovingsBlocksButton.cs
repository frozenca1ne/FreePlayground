using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MovingsBlocksButton : MonoBehaviour
{
    [SerializeField] float blockMoveTime = 1f;
    [SerializeField] float blockReturnTime = 1f;
    [SerializeField] float blockWaitTime = 1f;
    [SerializeField] float moveDistance = 2f;
    [SerializeField] float buttonDownValue = 0.1f;
    [SerializeField] float buttonDownTime = 0.5f;
    [SerializeField] GameObject blocks;
    [SerializeField] GameObject button;

    private Vector3 startPosition;
     
    private void Start()
    {
        startPosition = blocks.transform.position;

    }
    private void OnTriggerEnter(Collider other)
    {
        Sequence useButton = DOTween.Sequence();
        useButton.Append(button.transform.DOMoveY(-buttonDownValue, buttonDownTime))
            .Append(blocks.transform.DOMoveZ(moveDistance, blockMoveTime));

    }
    private void OnTriggerExit(Collider other)
    {
        Sequence unusedButton = DOTween.Sequence();
        unusedButton.AppendInterval(blockWaitTime)
            .Append(button.transform.DOMoveY(buttonDownValue, buttonDownTime))
           .Append(blocks.transform.DOMoveZ(startPosition.z, blockMoveTime));
    }
}
