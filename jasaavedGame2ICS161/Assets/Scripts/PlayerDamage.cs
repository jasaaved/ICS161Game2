using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    private GameObject health;

    void Start()
    {
        health = GameObject.Find("Canvas").gameObject;
        health = health.transform.FindChild("Health").gameObject;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            health.GetComponent<BeatingHealthBar>().currentValue -= 0.01f;
            if (health.GetComponent<BeatingHealthBar>().currentValue <= 0)
            {
                health.GetComponent<BeatingHealthBar>().currentValue = 0;
            }
        }
    }

}
