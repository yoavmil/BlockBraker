using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    Plane movingPlane;


    // Start is called before the first frame update
    void Start()
    {
        movingPlane = new Plane(Vector3.forward, transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        //var mousePos = Input.mousePosition;
        //mousePos.x = Mathf.Clamp(mousePos.x, 0, Screen.width);
        //var pos = Camera.main.ScreenToWorldPoint(mousePos);
        //Vector2 setPos = new Vector2(pos.x, transform.position.y);

        //transform.position = setPos;

        // create a ray from the mousePosition
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        // plane.Raycast returns the distance from the ray start to the hit point
        float distance;
        if (movingPlane.Raycast(ray, out distance))
        {
            
            // some point of the plane was hit - get its coordinates
            var hitPoint = ray.GetPoint(distance);
            // use the hitPoint to aim your cannon
            
            var pos = new Vector3(hitPoint.x, transform.position.y, transform.position.z);
            //Debug.Log(distance + " hitPoint=" + hitPoint + " pos=" + pos);
            transform.position = pos; 
        }

    }


}
