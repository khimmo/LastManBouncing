using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollision : MonoBehaviour
{
    //private float playerbounceForce;
    public float wallbounceForce;
    public float bounceForceMultiplier;
    public Rigidbody rb;

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collision involves another ball
        if (collision.gameObject.CompareTag("Player"))
        {
            // Get the Rigidbody of the other ball
            Rigidbody otherBallRigidbody = collision.gameObject.GetComponent<Rigidbody>();

            float totalVelocity = rb.velocity.magnitude + otherBallRigidbody.velocity.magnitude;

            float playerbounceForce = totalVelocity * bounceForceMultiplier;

            // Calculate the bounce force direction (away from the collision point)
            Vector3 bounceDirection = (transform.position - collision.contacts[0].point).normalized;

            // Apply a bounce force to both balls
            rb.AddForce(bounceDirection * playerbounceForce, ForceMode.Impulse);
            otherBallRigidbody.AddForce(-bounceDirection * playerbounceForce, ForceMode.Impulse);
        }

        if (collision.gameObject.CompareTag("Wall"))
        {
            // Get the Rigidbody of the other ball
            //Rigidbody otherBallRigidbody = collision.gameObject.GetComponent<Rigidbody>();

            // Calculate the bounce force direction (away from the collision point)
            Vector3 bounceDirection = (transform.position - collision.contacts[0].point).normalized;

            // Apply a bounce force to both balls
            rb.AddForce(bounceDirection * wallbounceForce, ForceMode.Impulse);
            //otherBallRigidbody.AddForce(-bounceDirection * wallbounceForce, ForceMode.Impulse);
        }
    }
}
