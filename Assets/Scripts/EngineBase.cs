using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineBase : MonoBehaviour
{
    // acceleration indicates how fast the enemy accelerates
    [SerializeField]
    private float acceleration = 5000f;

    // local references
    private Rigidbody2D ourRigidbody;

    // enemyAcceleration indicates how fast the enemy accelerates
    [SerializeField]
    private float enemyAcceleration = 5000f;

    // horizontalPlayerSpeed indicates how fast we accelerate Horizontally
    [SerializeField]
    private float horizontalPlayerAcceleration = 5000f;

    void Start()
    {
        // populate ourRigidbody
        ourRigidbody = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// Accelerate takes a direction as a parameter, and applies a force in this provided direction
    /// to ourRigidbody, based on the acceleration variables and the delta time.
    /// </summary>
    /// <param name="horizontalInput">A direction vector, expected to be a unit vector (magnitude of 1).</param>
    public void Accelerate(Vector2 direction)
    {
        //calculate our force to add
        Vector2 forceToAdd = direction * acceleration * Time.deltaTime;
        // apply forceToAdd to ourRigidbody
        ourRigidbody.AddForce(forceToAdd);
    }

    public void MoveEnemy(Vector2 direction)
    {
        //calculate our force to add
        Vector2 forceToAdd = direction * enemyAcceleration * Time.deltaTime;
        // apply forceToAdd to ourRigidbody
        ourRigidbody.AddForce(forceToAdd);
    }

    public void MovePlayer(float horizontalInput)
    {
        // a horizontalInput of 0 has no effect, as we want our ship to drift
        if (horizontalInput != 0)
        {
            //calculate our force to add
            Vector2 forceToAdd = Vector2.right * horizontalInput * horizontalPlayerAcceleration * Time.deltaTime;
            // apply forceToAdd to ourRigidbody
            ourRigidbody.AddForce(forceToAdd);
        }
    }
    public void MovePlayer(Vector2 direction)
    {
        // a horizontalInput of 0 has no effect, as we want our ship to drift
        if (direction.magnitude != 0)
        {
            //calculate our force to add
            Vector2 forceToAdd = direction * horizontalPlayerAcceleration * Time.deltaTime;
            // apply forceToAdd to ourRigidbody
            ourRigidbody.AddForce(forceToAdd);
        }
    }
}
