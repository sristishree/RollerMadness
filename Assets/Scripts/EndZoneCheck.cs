using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndZoneCheck : MonoBehaviour
{
    public bool gameCompleted = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "EndZone")
        {
            Debug.Log("Reached");
            gameCompleted = true;

        }
    }
}
