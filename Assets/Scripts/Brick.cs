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

    bool destroyed = false;
    private void OnCollisionEnter(Collision collision)
    {    
        if (collision.gameObject.tag == "Ball")
        {
            health -= damagePerHit;
            
            if (health <= 0 && !destroyed)
            {
                destroyed = true; // for some reason OnCollisionEnter was called twice
                if (splitAftedDeath) spawnSplits();
                explode();
            }
        }
    }

    private void spawnSplits()
    {
        for (int i = 0; i < 8; i++)
        {
            var clone = Object.Instantiate(gameObject);
            
            clone.transform.localScale = gameObject.transform.localScale * 0.5f;
            int dirX = (i & 0x1) != 0 ? 1 : -1;
            int dirY = (i & 0x2) != 0 ? 1 : -1;
            int dirZ = (i & 0x4) != 0 ? 1 : -1;
            Vector3 offset = new Vector3(dirX, dirY, dirZ) * 0.25f; // 0.25 = 0.5^2

            clone.transform.position = gameObject.transform.position + offset;
            var brickScript = clone.GetComponent<Brick>();
            brickScript.splitAftedDeath = false;
            brickScript.health = 1f;
            brickScript.damagePerHit = 1f;

            clone.GetComponent<Rigidbody>().mass = 1f;
            clone.GetComponent<Rigidbody>().AddExplosionForce(300f, gameObject.transform.position - new Vector3(0, 0.25f, 0), 3f);
        }
    }

    private void explode()
    {
        Object.Destroy(gameObject);
    }

    private void OnDestroy()
    {
        var allBricks = GameObject.FindGameObjectsWithTag("Brick").ToList();
        if (allBricks.Count == 0)
        {
            SceneManager.LoadScene("LandingPageScene");
        }
    }
}
