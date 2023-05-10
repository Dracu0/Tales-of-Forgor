using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class BackgroundParalax : MonoBehaviour
{
    private float startPos;
    private GameObject cam;
    [SerializeField]private float parallaxEffect;

    private void Start()
    {
        cam = GameObject.Find("MainCamera");
        startPos = transform.position.x;
    }

    private void Update()
    {
        float distance = cam.transform.position.x * parallaxEffect;
        transform.position = new Vector3(startPos + distance, transform.position.y, transform.position.z);
    }
}
