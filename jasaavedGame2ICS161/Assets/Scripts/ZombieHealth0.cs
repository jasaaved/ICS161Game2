using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieHealth0 : MonoBehaviour {
    public int health;
    private GameObject h_ui;

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        if (health <= 0)
        {
            Destroy(this.transform.parent.gameObject);
        }
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Handgun")
        {
            health -= 40;

        }


        if (other.tag == "Shotgun")
        {
            health -= 25;
        }

    }

}
