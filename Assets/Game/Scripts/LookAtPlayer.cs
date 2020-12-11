using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    [SerializeField] Transform target;

    private void MoveWithPlayer()
    {
        if(target!= null)
        {
            float playerX = target.transform.position.x;
            float cameraY = transform.position.y;
            float playerZ = target.transform.position.z;
            Vector3 moveVector = new Vector3(playerX, cameraY, playerZ);
            transform.position = moveVector;
        }
       
    }
    private void FixedUpdate()
    {
        MoveWithPlayer();
    }
}
