using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZoneScript : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") || other.CompareTag("NPC"))
        {
            DoorScript door = GetComponentInParent<DoorScript>();
            door.Open();
        }
        
    }

    // Update is called once per frame
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") || other.CompareTag("NPC"))
        {
            DoorScript door = GetComponentInParent<DoorScript>();
            door.Close();
        }
    }
}
