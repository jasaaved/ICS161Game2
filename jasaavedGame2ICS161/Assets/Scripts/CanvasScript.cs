using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasScript : MonoBehaviour {
    public GameObject during;
    public GameObject after;

	// Use this for initialization
	void Start () {
        during = gameObject.transform.FindChild("GameRunning").gameObject;
        after = gameObject.transform.FindChild("OverScreen").gameObject;
        after.SetActive(false);

    }
	
	// Update is called once per frame
	void Update () {

		
	}

    public void GameOver()
    {
        during.SetActive(false);
        after.SetActive(true);
    }

    public void Winner()
    {
        during.SetActive(false);
    }
}
