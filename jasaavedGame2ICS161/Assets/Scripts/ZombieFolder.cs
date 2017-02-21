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

    public void Wave(int i)
    {
        if (i > 25)
        {
            i = 25;
        }
        for (int t = i*2; i >= 0; i--)
        {
            GameObject Zomb = transform.GetChild(t).gameObject;
            Zomb.GetComponent<Zombie>().kill = true;
            Zomb.transform.parent = null;
        }
    }


}
