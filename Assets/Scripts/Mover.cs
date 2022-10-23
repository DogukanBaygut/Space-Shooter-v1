using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    Rigidbody fizik;
    public int speed;

    void Start()
    {
        fizik = GetComponent<Rigidbody>();
        fizik.velocity = transform.forward * speed;
    }

    
}
