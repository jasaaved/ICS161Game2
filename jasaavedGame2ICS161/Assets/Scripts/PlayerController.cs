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
    public bool running;



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
        current = 1;
        shotgun.SetActive(false);
        handgun.SetActive(false);
        melee.SetActive(false);
        move = true;
        canvas = GameObject.Find("Canvas").gameObject;
        health = canvas.transform.FindChild("Health").gameObject;
        SwapWeapons();
        running = false;
        speed = 6f;
    }

    void Update()
    {

        xVelAdj = Input.GetAxis("xMove");
        yVelAdj = Input.GetAxis("yMove");
        xFire = Input.GetAxis("xShoot");
        yFire = Input.GetAxis("yShoot");

        if (Input.GetButtonDown("Switch") && Input.GetAxisRaw("Fire3") == 0)
        {
            SwapWeapons();
        }

        if(Input.GetAxisRaw("Fire3") != 0 && !running)
        {
            anim.SetBool("Shotgun", false);
            anim.SetBool("Handgun", false);
            shotgun.SetActive(false);
            handgun.SetActive(false);
            running = true;
            speed = 8f;
        }

        if (Input.GetAxisRaw("Fire3") == 0 && running)
        {
            speed = 6f;
            running = false;

            if (current == 0)
            {
                anim.SetBool("Shotgun", true);
                anim.SetBool("Handgun", false);
                shotgun.SetActive(true);
                handgun.SetActive(false);
            }

            if (current == 1)
            {
                anim.SetBool("Shotgun", false);
                anim.SetBool("Handgun", true);
                shotgun.SetActive(false);
                handgun.SetActive(true);
            }
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

        if (current == 2)
        {
            current = 0;

        }

        if (current == 0)
        {
            anim.SetBool("Shotgun", true);
            anim.SetBool("Handgun", false);
            shotgun.SetActive(true);
            handgun.SetActive(false);
        }

        if (current == 1)
        {
            anim.SetBool("Shotgun", false);
            anim.SetBool("Handgun", true);
            shotgun.SetActive(false);
            handgun.SetActive(true);
        }


    }


}
