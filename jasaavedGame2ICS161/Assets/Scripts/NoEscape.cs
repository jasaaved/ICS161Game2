using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoEscape : MonoBehaviour {
    private GameObject zombiefolder;
    private GameObject player;

    void Start()
    {
        zombiefolder = GameObject.Find("Zombies").gameObject;
        player = GameObject.Find("Player").gameObject;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            player.GetComponent<PlayerController>().move = false;
            zombiefolder.GetComponent<ZombieFolder>().AllKill();
        }
    }
}
