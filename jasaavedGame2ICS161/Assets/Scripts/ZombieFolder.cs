using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieFolder : MonoBehaviour {
    public GameObject gamemanager;
	// Use this for initialization
	void Start () {
        gamemanager = GameObject.Find("GameManager").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AllKill()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            GameObject Zomb = transform.GetChild(i).gameObject;
            Zomb.GetComponent<Zombie>().kill = true;
        }
    }

    void OnDestroy()
    {
        gamemanager.GetComponent<GameManager>().score += 100;
    }
}
