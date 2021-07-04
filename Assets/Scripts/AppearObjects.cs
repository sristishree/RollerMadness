using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearObjects : MonoBehaviour
{
    public GameObject target;

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (!target)
                return;
            target.SetActive(true);

        }
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            //Destroy(gameObject);
        }
    }
}
