using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Capsule : MonoBehaviour
{
    void Awake()
    {
        y = gameObject.transform.position.y;
        z = gameObject.transform.position.z;
    }

    private float y;
    private float z;
    private Vector3 screenPoint;
    private Vector3 offset;       

    void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        curPosition.z = z;
        curPosition.y = y;
        transform.position = curPosition;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
