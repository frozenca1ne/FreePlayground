using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPlayerFall : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        CubeMovement cube = other.GetComponent<CubeMovement>();
        if(cube != null)
        {
            cube.Die();
        }    
    }
}
