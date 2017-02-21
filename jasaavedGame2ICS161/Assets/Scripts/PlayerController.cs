using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    
    Vector3 movement;                   
    Animator anim;                     
    Rigidbody playerRigidbody;          
    private PlayerController playerController;



    public float speed = 6f;            
    public float xVelAdj;
    public float yVelAdj;
    private float xFire;
    private float yFire;
    private GameObject shotgun;
    private GameObject handgun;
    private GameObject melee;
    public int current;
    public bool move;
    public GameObject canvas;
    private GameObject health;



    void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        playerController = GetComponent<PlayerController>();
        anim = GetComponent<Animator>();

    }

    private void Start()
    {
        shotgun = transform.FindChild("shotgun").gameObject;
        handgun = transform.FindChild("gun").gameObject;
        melee = transform.FindChild("crowbar").gameObject;
        current = 0;
        shotgun.SetActive(false);
        handgun.SetActive(false);
        melee.SetActive(false);
        move = true;
        canvas = GameObject.Find("Canvas").gameObject;
        health = canvas.transform.FindChild("Health").gameObject;
    }

    void Update()
    {
        if (current == 0)
        {
            speed = 8f;
       }

        else
        {
            speed = 6f;
        }

        xVelAdj = Input.GetAxis("xMove");
        yVelAdj = Input.GetAxis("yMove");
        xFire = Input.GetAxis("xShoot");
        yFire = Input.GetAxis("yShoot");
        
        if (Input.GetButtonDown("Switch"))
        {
            SwapWeapons();
        }

        if (move)
        {
            Move(xVelAdj, yVelAdj, xFire, yFire);
        }
        WalkingAnimation();
    }



    void Move(float h, float v, float xs, float ys)
    {
        playerRigidbody.velocity = new Vector3(speed * h, playerRigidbody.velocity.y, speed * v);

        float heading = Mathf.Atan2(xs, ys);
        if (Mathf.Abs(xs) >= 0.2 && Mathf.Abs(ys) >= 0.2)
        {
            GetComponent<Rigidbody>().constraints = 
                RigidbodyConstraints.FreezeRotationX |
                RigidbodyConstraints.FreezeRotationZ;
            transform.rotation = Quaternion.EulerAngles(0, heading, 0);
        }
        else
        {
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX |
                RigidbodyConstraints.FreezeRotationY |
                RigidbodyConstraints.FreezeRotationZ;
        }
    }

    private void WalkingAnimation()
    {
        if (move)
        {
            if (xVelAdj != 0 || yVelAdj != 0)
            {
                anim.SetBool("Walking", true);
            }
            else
            {
                anim.SetBool("Walking", false);
                anim.SetBool("Running", false);
            }
        }

        else
        {
            anim.SetBool("Walking", false);
            anim.SetBool("Running", false);
        }

        if (health.GetComponent<BeatingHealthBar>().currentValue <= 0)
        {
            anim.SetBool("Dead", true);
        }
    }

    private void SwapWeapons()
    {
        current++;

        if (current == 3)
        {
            current = 0;
            anim.SetBool("Shotgun", false);
            anim.SetBool("Handgun", false);
            shotgun.SetActive(false);
            handgun.SetActive(false);
        }

        if (current == 1)
        {
            anim.SetBool("Shotgun", true);
            anim.SetBool("Handgun", false);
            shotgun.SetActive(true);
            handgun.SetActive(false);
        }

        if (current == 2)
        {
            anim.SetBool("Shotgun", false);
            anim.SetBool("Handgun", true);
            shotgun.SetActive(false);
            handgun.SetActive(true);
        }


    }


}
