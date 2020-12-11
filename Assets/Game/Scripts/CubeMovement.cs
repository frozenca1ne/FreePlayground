using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CubeMovement : MonoBehaviour
{
    [Header("Move")]
    [SerializeField] float moveTime;
    [SerializeField] float jumpPower;
    [SerializeField] float reloadDelay = 1f;

    [Header("Die")]
    [SerializeField] GameObject dieAnimation;
    [SerializeField] AudioClip dieAudio;



    private bool allowInput;

    public void SetKinemtaic()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.isKinematic = false;
    }
    public void Die()
    {
        MeshRenderer mesh = gameObject.GetComponent<MeshRenderer>();
        mesh.enabled = false;
        PlayDiePartical();
        AudioManager.Instance.PlaySound(dieAudio);
        Destroy(gameObject, 0.5f);
        SceneLoader.Instance.LoadActiveScene(reloadDelay);
    }
    public void MoveFromTeleport(Vector3 finalPoint,float moveTime,float teleportHeight)
    {
        float transfomY = transform.position.y;
        Sequence teleportSequence = DOTween.Sequence();
        teleportSequence.Append(transform.DOMoveY(teleportHeight, moveTime))
            .Append(transform.DOMove(finalPoint, moveTime))
            .Append(transform.DOMoveY(transfomY, moveTime));
    }
    private void PlayDiePartical()
    {
        Vector3 particalPosition = transform.position;

        GameObject dieAn = Instantiate(dieAnimation, particalPosition, Quaternion.identity);
        Destroy(dieAn, 1f);
    }
    private void Start()
    {
        allowInput = true;
        
    }
    private void Update()
    {
        MoveCube();
    }

    private void MoveCube()
    {
        if(!allowInput) {  return;  }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            MoveForward();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            MoveBack();
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MoveLeft();
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            MoveRight();
        }
    }

    public void MoveRight()
    {
        if (!allowInput) { return; }
        Vector3 newPosition = transform.position + Vector3.right;
        DoMove(newPosition);
    }

    public void MoveLeft()
    {
        if (!allowInput) { return; }
        Vector3 newPosition = transform.position + Vector3.left;
        DoMove(newPosition);
    }

    public void MoveBack()
    {
        if (!allowInput) { return; }
        Vector3 newPosition = transform.position + Vector3.back;
        DoMove(newPosition);
    }

    public void MoveForward()
    {
        if (!allowInput) { return; }
        Vector3 newPosition = transform.position + Vector3.forward;
        DoMove(newPosition);
    }

    private void DoMove(Vector3 position)
    {
        //Debug.DrawRay(position, Vector3.down, Color.green, 2f);
        if(Physics.Raycast(position,Vector3.down,1f))
        {
            transform.DOJump(position, jumpPower, 1, moveTime).OnComplete(ResetInput);
            allowInput = false;
        }
        
    }
    private void ResetInput()
    {
        allowInput = true;
    }
}
