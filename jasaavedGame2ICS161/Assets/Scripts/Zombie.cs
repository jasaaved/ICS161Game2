using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Zombie : MonoBehaviour {
    [HideInInspector]
    public NavMeshAgent nav;
    private GameObject player;
    private GameObject gamemanager;
    public bool kill;
    private float timer;
    private Animator anim;
    private GameObject Canvas;


    // Use this for initialization
    void Start () {
        player = GameObject.Find("Player").gameObject;
        nav = GetComponent<NavMeshAgent>();
        kill = false;
        timer = 5f;
        anim = this.gameObject.GetComponentInChildren<Animator>();
        Canvas = GameObject.Find("Canvas").gameObject;
        Canvas = Canvas.transform.FindChild("Health").gameObject;
        gamemanager = GameObject.Find("GameManager").gameObject;

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
        anim.SetBool("Attack", true);
        if (nav.remainingDistance <= nav.stoppingDistance)
        {
            anim.SetBool("Walking", false);
            if (kill)
            {
                Canvas.GetComponent<BeatingHealthBar>().currentValue -= 0.05f;
                if (Canvas.GetComponent<BeatingHealthBar>().currentValue <= 0)
                {
                    Canvas.GetComponent<BeatingHealthBar>().currentValue = 0;
                }
            }
            
        }
        else
        {
            anim.SetBool("Walking", true);
        }
    }

    private void OnDestroy()
    {
        gamemanager.GetComponent<GameManager>().score += 100;
    }
}
