using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunBlast : MonoBehaviour {

    public GameObject bullets;
    private bool RTinuse;

    // Use this for initialization
    void Start()
    {
        RTinuse = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Fire2") != 0 && RTinuse == false)
        {
            Fire();
            RTinuse = true;
        }

        if (Input.GetAxisRaw("Fire2") == 0)
        {
            RTinuse = false;
        }


    }

    void Fire()
    {
        // Create the Bullet from the Bullet Prefab
        var bullet = (GameObject)Instantiate(
            bullets,
            transform.position,
            transform.rotation);

        // Add velocity to the bullet
        bullet.GetComponent<Rigidbody>().velocity = -bullet.transform.up * 20;
        bullet.transform.Rotate(90, 0, 0);


        // Destroy the bullet after 2 seconds
        Destroy(bullet, 2.0f);

    }
}
