using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public Vector3 openPosition;
    public Vector3 closedPosition;
    public float openSpeed = 2.0f;
    private bool isOpen = false;

    private void Start()
    {
        transform.position = closedPosition;
    }
   

    public void Open()
    {
        if (!isOpen)
        {
            transform.position = Vector3.Lerp(transform.position, openPosition, Time.deltaTime * openSpeed);
            isOpen = true;
        }
    }

    // Update is called once per frame
    public void Close()
    {
        if (isOpen)
        {
            transform.position = Vector3.Lerp(transform.position, closedPosition, Time.deltaTime * openSpeed);
            isOpen = false;
        }
       

    }
}
