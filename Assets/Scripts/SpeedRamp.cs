using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedRamp : MonoBehaviour
{
    [SerializeField] float speedBoost = 10f;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Rigidbody ballRigidbody = other.gameObject.GetComponent<Rigidbody>();

            Vector3 currentVelocity = ballRigidbody.linearVelocity;

            if (currentVelocity.magnitude > 0.1f)
            {
                Vector3 boostDirection = currentVelocity.normalized;

                Vector3 force = boostDirection * speedBoost;
                ballRigidbody.AddForce(force, ForceMode.VelocityChange);
            }

        }
    }
}
