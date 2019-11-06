using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Brick : MonoBehaviour
{
    [SerializeField]
    float damagePerHit = 0.4f;

    [SerializeField]
    bool splitAftedDeath = true;

    [SerializeField]
    float health = 1f; //100%

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            health -= damagePerHit;
            if (health <= 0)
            {
                if (splitAftedDeath) spawnSplits();
                explode();
            }
        }
    }

    private void spawnSplits()
    {
        for (int i = 0; i < 4; i++)
        {
            var clone = Object.Instantiate(gameObject);
            clone.transform.localScale = gameObject.transform.localScale * 0.5f;
            Vector3 offset = Vector3.zero;
            switch (i)
            {
                case 0: offset.x = -0.5f; offset.y = -0.5f; break;
                case 1: offset.x = -0.5f; offset.y = +0.5f; break;
                case 2: offset.x = +0.5f; offset.y = -0.5f; break;
                case 3: offset.x = +0.5f; offset.y = +0.5f; break;
            }
            clone.transform.position = clone.transform.position + offset;
            var brickScript = clone.GetComponent<Brick>();
            brickScript.splitAftedDeath = false;
            brickScript.health = 1f;
            brickScript.damagePerHit = 1f;

            clone.GetComponent<Rigidbody>().mass = 1f;
        }
    }

    private void explode()
    {
        Object.Destroy(gameObject);
    }

    private void OnDestroy()
    {
        var allBricks = GameObject.FindGameObjectsWithTag("Brick");
        var allBrickScripts = allBricks.Select(b => b.GetComponent<Brick>());
        if (allBrickScripts.Count(bs => bs.splitAftedDeath) == 0)
        {
            SceneManager.LoadScene("LandingPageScene");
        }
    }
}
