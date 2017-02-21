using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieHealth0 : MonoBehaviour {
    public int health;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (health <= 0)
        {
            Destroy(this.transform.parent);
        }
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Projectile")
        {
            if (other.transform.parent.name == "gun")
            {
                health -= 17;
            }

            if (other.transform.parent.name == "shotgun")
            {
                health -= 25;
            }

        }
    }
}
