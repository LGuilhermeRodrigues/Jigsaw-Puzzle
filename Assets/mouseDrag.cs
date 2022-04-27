using System;
using UnityEngine;
using UnityEngine.Rendering;
public class mouseDrag : MonoBehaviour
{
    static int topOrder = 1;
    
    public void OnMouseDrag(){
        Vector2 screenPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(screenPosition);
        transform.position = mousePosition;
    }

    private void OnMouseDown()
    {
        GetComponent<SortingGroup>().sortingOrder = ++topOrder;
    }

    private void OnMouseUp()
    {
        var respawn = GetComponent<Respawn>();
        if (isCloseToInitialPosition())
        {
            respawn.ReturnToInitialPosition();
        }
    }
    
    bool isCloseToInitialPosition()
    {
        var respawn = GetComponent<Respawn>();
        var distance = Vector2.Distance(transform.position, respawn.initialPosition);   
        Debug.Log(distance);
        return distance < 0.3f;
    }
}
