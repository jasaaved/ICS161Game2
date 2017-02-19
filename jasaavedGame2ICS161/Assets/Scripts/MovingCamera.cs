using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCamera : MonoBehaviour {

    private GameObject player;
    public float smoothing  = 5f;
    private Vector3 offset;
    private Vector3 targetCamPos;
    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Player").gameObject;
        smoothing = 5f;
        offset = transform.position - player.transform.position;
    }

    void FixedUpdate()
    {
        Vector3 targetCamPos = player.transform.position + offset;

        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
    }
}
