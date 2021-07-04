using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearObjects : MonoBehaviour
{
    public GameObject target;

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (!target)
                return;
            Debug.Log("Here");
            target.SetActive(false);

        }
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (!target)
                return;
            target.SetActive(true);

        }
    }
}
