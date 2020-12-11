using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] Transform finalPoint;
    [SerializeField] float moveTime = 1f;
    [SerializeField] float teleportHeight = 5f;
    private void OnTriggerEnter(Collider other)
    {
        CubeMovement cube = other.GetComponent<CubeMovement>();
        if (cube != null)
        {
            
            cube.MoveFromTeleport(finalPoint.transform.position, moveTime, teleportHeight);
        }

    }
}
