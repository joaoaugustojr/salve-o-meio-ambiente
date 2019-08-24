using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public Transform cameraParallax;
    public float parallaxSpeed = 0;

    private Vector3 previusposition;

    void Start()
    {
        previusposition = cameraParallax.position;
    }

    void Update()
    {
        transform.Translate((cameraParallax.position.x - previusposition.x) / parallaxSpeed, (cameraParallax.position.y - previusposition.y) / parallaxSpeed, 0);
        previusposition = cameraParallax.position;
    }
}
