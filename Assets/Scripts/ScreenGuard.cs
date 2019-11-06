using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenGuard : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        Object.Destroy(other.gameObject);
    }
    
}
