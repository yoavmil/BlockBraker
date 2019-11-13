using System.Collections.Generic;
using UnityEngine;

public class Pusher : MonoBehaviour
{
    [SerializeField]
    [Tooltip("in units of 1/sec")]
    Vector2 pushVelocity = new Vector2(0, 0);
    protected Vector3 pushVelocity3D { get { return Vector3.Scale(new Vector3(pushVelocity.x, 0, pushVelocity.y), gameObject.transform.localScale); } }
    
    protected new Renderer renderer;
    protected new BoxCollider collider;
    [SerializeField]
    List<GameObject> touchingGameObjects = new List<GameObject>();
    private void Awake()
    {
        renderer = GetComponent<Renderer>();
        renderer.material.mainTexture.wrapMode = TextureWrapMode.Repeat;

        collider = GetComponent<BoxCollider>();
    }

    void Update()
    {
        renderer.material.mainTextureOffset += pushVelocity * Time.fixedDeltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        touchingGameObjects.Add(other.gameObject);        
    }

    private void OnTriggerExit(Collider other)
    {
        touchingGameObjects.Remove(other.gameObject);
    }

    private void FixedUpdate()
    {
        touchingGameObjects.RemoveAll(_o => _o == null);
        foreach (var go in touchingGameObjects) 
            go.GetComponent<Rigidbody>().MovePosition(go.transform.position + pushVelocity3D * Time.deltaTime);
    }
}
