using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentHealth : MonoBehaviour {

    public int health;

	// Use this for initialization
	void Update () {
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Projectile")
        {
            if (other.transform.parent.name == "gun")
            {
                health -= 5;
            }

            if (other.transform.parent.name == "shotgun")
            {
                health -= 15;
            }
            
        }
    }
}
