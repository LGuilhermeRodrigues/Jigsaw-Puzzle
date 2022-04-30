using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;
public class mouseDrag : MonoBehaviour
{
    static int topOrder = 1;
    private Vector2 positionOnDragStartObject;
    private Vector2 positionOnDragStartCursor;
    
    public void OnMouseDrag(){
        Debug.Log("OnMouseDrag");
        Vector2 screenPosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(screenPosition);
        var mouseMovePath = mousePosition - positionOnDragStartCursor;
        transform.position = positionOnDragStartObject + mouseMovePath;
    }

    private void OnMouseDown()
    {
        positionOnDragStartCursor = Camera.main.ScreenToWorldPoint(
            new Vector2(Input.mousePosition.x, Input.mousePosition.y));
        positionOnDragStartObject = transform.position;
        Debug.Log("OnMouseDown");
        //GetComponent<SortingGroup>().sortingOrder = ++topOrder;
        GetComponent<Canvas>().sortingOrder = ++topOrder;
    }

    private void OnMouseUp()
    {
        Debug.Log("OnMouseUp");
        var respawn = GetComponent<Respawn>();
        if (isCloseToInitialPosition())
        {
            respawn.ReturnToInitialPosition();
        }
    }
    
    bool isCloseToInitialPosition()
    {
        var respawn = GetComponent<Respawn>();
        var distance = Vector2.Distance(transform.position, respawn.GetInitialPosition());   
        Debug.Log(distance);
        return distance < 0.4f;
    }
}
