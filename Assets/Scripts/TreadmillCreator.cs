using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TreadmillCreator : MonoBehaviour
{

    [SerializeField]
    float length = 10;
    [SerializeField]
    float tileWidth = 0.1f;
    [SerializeField]
    float speed = -1;
    float currSpeed = 0;
    float acceleration = 0.1f;
    [SerializeField]
    public GameObject tile;

    private List<GameObject> tiles = new List<GameObject>();
    GameObject lastTile = null;

    private GameObject CreateTile(Vector3 pos)
    {
        var inst = Instantiate(tile, pos, Quaternion.identity) as GameObject;
        var scale = inst.transform.localScale;
        inst.transform.localScale = new Vector3(length, scale.y, tileWidth);
        return inst;
    }

    void Awake()
    {
        for (float z = 0; z < length; z += tileWidth)
        {
            var pos = new Vector3(0, 0, z);
            tiles.Add(CreateTile(pos));
            
        }
        lastTile = tiles.Last();
    }

    private void LateUpdate()
    {
        currSpeed = Mathf.Min(Mathf.Abs(speed), currSpeed + acceleration * Time.deltaTime);        
        foreach (var t in tiles)
        {
            t.GetComponent<Rigidbody>().velocity = Vector3.forward * currSpeed * Mathf.Sign(speed);
        }
        var inst = tiles.FirstOrDefault(_i => _i.transform.position.z < 0);
        if (inst != null)
        {
            inst.transform.Translate(lastTile.transform.position - inst.transform.position + Vector3.forward * tileWidth);
            lastTile = inst;
        }
    }
    
}
