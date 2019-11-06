using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetGravity : MonoBehaviour
{
    [SerializeField]
    private Vector3 newGravity;

    private void Start()
    {
        Physics.gravity = newGravity;
    }
}
