using UnityEngine;
using System.Collections;

public class DestroyedOnExit : MonoBehaviour
{

    // Called when thporte object leaves the view
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
