using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Coin : MonoBehaviour
{
    [SerializeField] int point = 10;
    
    private void Start()
    {
        Rotate();
    }
    private void Rotate()
    {
        Vector3 startRotation = new Vector3(90, 180, 0);
        Sequence RotateSequance = DOTween.Sequence();
        RotateSequance.Append(transform.DOLocalRotate(startRotation,2f).SetEase(Ease.Flash))
            .SetLoops(-1);
            
    }
    private void OnTriggerEnter(Collider other)
    {
        LevelManager.Instance.ScoreUp += point;
        LevelManager.Instance.ChangeCoinsCount();
        Destroy(gameObject);
    }
}
