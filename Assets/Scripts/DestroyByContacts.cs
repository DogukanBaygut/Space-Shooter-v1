using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContacts : MonoBehaviour
{
    public GameObject explosion;
    public GameObject pshipexp;
    private GameController gameController;
    
    private void Start()
    {
        gameController = GameObject.FindWithTag("GameController").GetComponent<GameController>();


    }
    
     void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Boundary") {
            return;

        }
        Instantiate(explosion,transform.position,transform.rotation);
        if(other.tag == "Player")
        {
            Instantiate(pshipexp,other.transform.position,other.transform.rotation);
            gameController.GameOver();


        }
        Destroy(other.gameObject);
        Destroy(gameObject);
        gameController.UpdateScore();  

    }

    
}
