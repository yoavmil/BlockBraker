using UnityEngine;

public class ScreenGuard : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        Object.Destroy(other.gameObject);
    }
    
}
