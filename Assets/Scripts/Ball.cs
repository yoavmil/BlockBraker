using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    // param
    [SerializeField]
    Paddle paddle1 = null;
    [SerializeField]
    float releasingVelocity = 10;

    // properties
    Vector2 toPaddle;
    bool sticking = true;

    // Start is called before the first frame update
    void Start()
    {
        if (paddle1 != null) toPaddle = transform.position - paddle1.transform.position;
        this.tag = "Ball";
    }

    private void FixedUpdate()
    {
        if (!sticking)
        {
            var rigidBody = GetComponent<Rigidbody>();
            rigidBody.velocity = rigidBody.velocity.normalized * releasingVelocity;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        if (sticking)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                sticking = false;
                GetComponent<Rigidbody>().velocity = new Vector2(0, releasingVelocity);
            }
            else
            {
                transform.position = paddle1.transform.position + new Vector3(toPaddle.x, toPaddle.y);
            }
        }
    }

    private void OnDestroy()
    {
        var allBalls = GameObject.FindGameObjectsWithTag("Ball");
        if (allBalls.Length == 0)
        {
            SceneManager.LoadScene("LandingPageScene");
        }
    }

}
