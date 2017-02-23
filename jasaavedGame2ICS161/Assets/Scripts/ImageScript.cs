using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageScript : MonoBehaviour {
    public GameObject canvas;

	// Use this for initialization
	void Start () {
        RectTransform crt = canvas.GetComponent<RectTransform>();
        this.GetComponent<RectTransform>().sizeDelta = new Vector2(crt.sizeDelta.x, crt.sizeDelta.y);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
