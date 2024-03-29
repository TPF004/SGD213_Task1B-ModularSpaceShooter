using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    private float acceleration = 50f;

    [SerializeField]
    private float initialVelocity = 5f;

    private Rigidbody2D ourRigidbody;

    public void Move(Vector2 move)
    {
        Vector2 ForceToAdd = Vector2.up * acceleration * Time.deltaTime;

        ourRigidbody.AddForce(ForceToAdd);
    }

    // Start is called before the first frame update
    void Start()
    {
        ourRigidbody = GetComponent<Rigidbody2D>();

        ourRigidbody.velocity = Vector2.up * initialVelocity;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
