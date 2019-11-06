using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundFX : MonoBehaviour
{
    [SerializeField]
    Color idleColor = Color.grey;
    [SerializeField]
    Color hitColor = Color.red;
    [SerializeField]
    float colorToIdleSeconds = 0.5f;


    private void Awake()
    {
        lastHit = DateTime.Now;
        lastHit = lastHit.AddSeconds(-colorToIdleSeconds * 2);
    }


    DateTime lastHit;
    private void OnCollisionEnter(Collision collision)
    {
        lastHit = DateTime.Now;
    }

    private void Update()
    {
        Color c = Color.Lerp(hitColor, idleColor, (float)(DateTime.Now - lastHit).TotalMilliseconds / 1000.0f / colorToIdleSeconds);
        GetComponent<MeshRenderer>().material.color = c;
    }
}
