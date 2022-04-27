using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public Vector3 initialPosition;
    
    void Start()
    {
        initialPosition = transform.position;
    }

    public void ReturnToInitialPosition()
    {
        transform.position = initialPosition;
    }
}
