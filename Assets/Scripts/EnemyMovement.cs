using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    //public GameObject obj;
    public float speed = 20.0f;
    private float ForwardBackward = 1.0f;
    // Update is called once per frame
    void Update()
    {
        transform.position += ForwardBackward*transform.forward * speed * Time.deltaTime;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Wall" || other.gameObject.tag == "Stair")
        {
            ForwardBackward = -ForwardBackward;
        }
    }

}
