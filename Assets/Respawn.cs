using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    Vector3 initialPosition;
    
    void Start()
    {
        initialPosition = transform.position;
    }

    public void ReturnToInitialPosition()
    {
        transform.position = initialPosition;
    }
    
    public Vector3 GetInitialPosition()
    {
        return initialPosition;
    }

    public void SetInitialPosition()
    {
        initialPosition = transform.position;
    }
}
