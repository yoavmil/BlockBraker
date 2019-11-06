using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball2 : MonoBehaviour
{

    [SerializeField]
    float velocity = 1.0f;

    [SerializeField]
    Vector2 initialDirection = new Vector2(0, -1.0f);


    Rigidbody rigid;
    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        rigid.velocity = new Vector3(initialDirection.x, 0, initialDirection.y).normalized * velocity;
    }

    private void FixedUpdate()
    {
        rigid.velocity = rigid.velocity.normalized * velocity;
    }

}
