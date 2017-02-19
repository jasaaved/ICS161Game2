using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    // Components
    Vector3 movement;                   // The vector to store the direction of the player's movement.
    Animator anim;                      // Reference to the animator component.
    Rigidbody playerRigidbody;          // Reference to the player's rigidbody.
    private PlayerController playerController;


    // Movement
    public float speed = 6f;            // The speed that the player will move at.
    public float xVelAdj;
    public float yVelAdj;
    private float xFire;
    private float yFire;
    private GameObject shotgun;
    private GameObject handgun;
    private GameObject melee;


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

        shotgun.SetActive(false);
        handgun.SetActive(false);
        melee.SetActive(false);
    }

    void Update()
    {

        xVelAdj = Input.GetAxis("xMove");
        yVelAdj = Input.GetAxis("yMove");
        xFire = Input.GetAxis("xShoot");
        yFire = Input.GetAxis("yShoot");

        Move(xVelAdj, yVelAdj, xFire, yFire);
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

    void WalkingAnimation()
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


}
