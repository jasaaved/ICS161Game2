using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour {
    [HideInInspector]
    public NavMeshAgent nav;
    private GameObject player;
    private bool kill;
    private float timer;
    private Animator anim;

    // Use this for initialization
    void Start () {
        player = GameObject.Find("Player").gameObject;
        nav = GetComponent<NavMeshAgent>();
        kill = false;
        timer = 5f;
        anim = GetComponent<Animator>();

    }
	
	// Update is called once per frame
	void Update () {
        if (nav.isActiveAndEnabled && kill)
        {
            nav.SetDestination(player.transform.position);
        }

        else if (nav.isActiveAndEnabled && !kill && timer >= 5f)
        {
            nav.SetDestination(RandomDestination());
            timer = 0f;
        }

        timer += Time.deltaTime;
        WalkingAnimation();

    }

    public Vector3 RandomDestination()
    {
        return new Vector3(Random.Range(30, 53), 0, Random.Range(-4, 7));
    }

    private void WalkingAnimation()
    {
        if (nav.remainingDistance == 0)
        {
            anim.SetBool("Walking", false);
        }
        else
        {
            anim.SetBool("Walking", true);
        }
    }
}
