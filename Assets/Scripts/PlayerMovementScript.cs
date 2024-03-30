using UnityEngine;
using System.Collections;

public class PlayerMovementScript : MonoBehaviour
{
    /* SerializeField exposes this value to the Editor, but not to other Scripts!
    It is "pseudo public"
    HorizontalPlayerAcceleration indicates how fast we accelerate Horizontally */

    [SerializeField]
    private float speed = 5000f;

    private Rigidbody2D OURRigidbody;

    // Use this for initialization
    void Start()
    {
        /* Get OurRigidbodyComponent once at the start of the game and store a reference to it
        This means that we don't need to call GetComponent more than once!
        This makes our game faster. (GetComponent is SLOW) */
        OURRigidbody = GetComponent<Rigidbody2D>();
    }

    public void HorizontalMovement(float HorizontalInput)
    {
        Vector2 ForceToAdd = Vector2.right * HorizontalInput * speed * Time.deltaTime;
        OURRigidbody.AddForce(ForceToAdd);
    }
}
