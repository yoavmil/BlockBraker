using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPhisicsFilters : MonoBehaviour
{
    [SerializeField]
    List<KeyValuePair<GameObject, GameObject>> doesntCollide = new List<KeyValuePair<GameObject, GameObject>>();

    private void Awake()
    {
        var bounds = GameObject.FindGameObjectsWithTag("Bound");
        foreach (var pair in doesntCollide)
            Physics.IgnoreCollision(pair.Key.GetComponent<Collider>(), pair.Value.GetComponent<Collider>());
    }
}
