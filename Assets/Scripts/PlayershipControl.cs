using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayershipControl : MonoBehaviour
{

    Rigidbody fizik;
    AudioSource audioPlayer;
    public int hiz;
    public float xMin, xMax, zMin, zMax;
    public float nextFire;
    public float fireRate;
    public GameObject shotspawn;
    public GameObject shot;
    
   
    void Start()
    {

        fizik = GetComponent<Rigidbody>();
        audioPlayer = GetComponent<AudioSource>();





    }
   void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal,0, moveVertical);
        fizik.velocity=movement*hiz;

        Vector3 position = new Vector3(
            Mathf.Clamp(fizik.position.x, xMin, xMax),
            0,
            Mathf.Clamp(fizik.position.z, zMin, zMax));

        fizik.position=position;   
        fizik.rotation = Quaternion.Euler(0, 0, fizik.velocity.x * -6);
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
          Instantiate(shot, shotspawn.transform.position, shotspawn.transform.rotation);
            audioPlayer.Play();
        }
        
    }
}
