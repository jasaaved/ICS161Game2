using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandgunShoot : MonoBehaviour {
    public GameObject bullets;
    private GameObject gamemanager;
    private bool RTinuse;

	// Use this for initialization
	void Start () {
        RTinuse = false;
        gamemanager = GameObject.Find("GameManager").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
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
        if (transform.parent.name == "shotgun" && gamemanager.GetComponent<GameManager>().shotgun_ammo <= 0)
        {
            return;
        }

        if (transform.parent.name == "gun" && gamemanager.GetComponent<GameManager>().handgun_ammo <= 0)
        {
            return;
        }
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

        if (transform.parent.name == "shotgun")
        {
            gamemanager.GetComponent<GameManager>().shotgun_ammo -= 0.25f;
        }

        if (transform.parent.name == "gun")
        {
            gamemanager.GetComponent<GameManager>().handgun_ammo--;
        }
    }
}
