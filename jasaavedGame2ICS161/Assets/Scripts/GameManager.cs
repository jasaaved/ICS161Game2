﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public int score;
    public Text cscore;
    public Text endscore;
    public Text ammo;
    public Text supply;
    public Text zombiew;
    private string t = "Score: ";
    private string t2 = "Ammo: ";
    private string t3 = "Supply Drop: ";
    private string t4 = "Zombies Incoming: ";
    public GameObject canvas;
    private GameObject player;
    private GameObject health;
    public bool gameover;
    public int handgun_ammo;
    public float shotgun_ammo;
    public float supply_time;
    public float zombie_time;
    public GameObject medkit;
    public GameObject s0;
    public GameObject s1;
    public GameObject s2;
    public GameObject s3;
    public GameObject s4;
    public GameObject z0;
    public GameObject z1;
    private GameObject zombf;
    public GameObject ar;
    public GameObject zm;
    private bool spawnmore;
    private int current_wave;
    private float ztime;
    private float stime;
    public bool time_up;
    public GameObject success;

    // Use this for initialization
    void Start () {
        canvas = GameObject.Find("Canvas").gameObject;
        zombf = GameObject.Find("Zombies").gameObject;
        health = canvas.transform.FindChild("Health").gameObject;
        gameover = false;
        player = GameObject.Find("Player").gameObject;
        handgun_ammo = 50;
        shotgun_ammo = 25;
        supply_time = 45f;
        zombie_time = 15f;
        spawnmore = true;
        current_wave = 1;
        ar.SetActive(false);
        zm.SetActive(false);
        ztime = 0f;
        stime = 0f;
        time_up = false;
}
	
	void Update () {
        supply_time -= Time.deltaTime;
        zombie_time -= Time.deltaTime;
        ztime += Time.deltaTime;
        stime += Time.deltaTime;
        if (health.GetComponent<BeatingHealthBar>().currentValue <= 0)
        {
            gameover = true;
        }

        if (ztime >= 4)
        {
            zm.SetActive(false);
        }

        if (stime >= 4)
        {
            ar.SetActive(false);
        }

        if (!gameover && !time_up)
        {
            cscore.text = t + score.ToString();
            supply.text = t3 + (Mathf.Round(supply_time * 100f) / 100f).ToString();
            zombiew.text = t4 + (Mathf.Round(zombie_time * 100f) / 100f).ToString();

            if (zombie_time <= 0)
            {
                zm.SetActive(true);
                zombie_time = 15f;
                zombf.GetComponent<ZombieFolder>().Wave(current_wave);
                current_wave++;
                ztime = 0f;
            }

            if (supply_time <= 0)
            {
                supply.text = "Supplies Arrived!";
                if (spawnmore)
                {
                    SpawnSupply();
                    spawnmore = false;
                    ar.SetActive(true);
                    stime = 0f;
                }
            }


            if (player.GetComponent<PlayerController>().current == 0)
            {
                ammo.text = t2 + shotgun_ammo.ToString();
            }

            if (player.GetComponent<PlayerController>().current == 1)
            {
                ammo.text = t2 + handgun_ammo.ToString();
            }

            if (player.GetComponent<PlayerController>().running)
            {
                ammo.text = t2;
            }

            if (zombf.transform.childCount <= 50)
            {
                for (int i = 50 - zombf.transform.childCount; i >= 0; i--)
                {

                    int s = Random.Range(0, 2);
                    if (s == 0)
                    {
                        Instantiate(z0, zombf.transform);
                    }

                    if (s == 1)
                    {
                        Instantiate(z1, zombf.transform);
                    }
                }
            }
        }

        if (gameover && !time_up)
        {
            player.GetComponent<PlayerController>().move = false;
            canvas.GetComponent<CanvasScript>().GameOver();
            endscore.text = t + score.ToString();
 
        }

        if (time_up)
        {
            player.GetComponent<PlayerController>().move = false;
            success.SetActive(true);
            canvas.GetComponent<CanvasScript>().Winner();
        }


    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Quit()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

    public void GotSupply()
    {
        handgun_ammo += Random.Range(0, 75);
        shotgun_ammo += Random.Range(0, 50);
        health.GetComponent<BeatingHealthBar>().currentValue += Random.Range(0, 5);
        
        if (health.GetComponent<BeatingHealthBar>().currentValue > 5)
        {
            health.GetComponent<BeatingHealthBar>().currentValue = 5;
        }

        supply_time = 45f;
        spawnmore = true;

    }

    private void SpawnSupply()
    {
        int s = Random.Range(0, 5);

        if (s == 0)
        {
            GameObject temp = Instantiate(medkit);
            temp.transform.position = s0.transform.position;
        }

        if (s == 1)
        {
            GameObject temp = Instantiate(medkit);
            temp.transform.position = s1.transform.position;
        }

        if (s == 2)
        {
            GameObject temp = Instantiate(medkit);
            temp.transform.position = s2.transform.position;
        }

        if (s == 3)
        {
            GameObject temp = Instantiate(medkit);
            temp.transform.position = s3.transform.position;
        }

        if (s == 4)
        {
            GameObject temp = Instantiate(medkit);
            temp.transform.position = s4.transform.position;
        }
    }
}
