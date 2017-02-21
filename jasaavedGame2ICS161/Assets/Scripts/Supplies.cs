using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Supplies : MonoBehaviour {
    private GameObject gamemanager;

	// Use this for initialization
	void Start () {
        gamemanager = GameObject.Find("GameManager").gameObject;
	}


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            gamemanager.GetComponent<GameManager>().GotSupply();
            Destroy(this.gameObject);
        }
            
    }

}
