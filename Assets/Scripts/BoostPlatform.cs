using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostPlatform : MonoBehaviour
{
    public float jumpForceMin = 15f;
    public float jumpForceMax = 20f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.GetComponent<Charachter>() != null)
        {
            if (collision.relativeVelocity.y <= 0f)
            {
                Rigidbody2D rb2d = collision.gameObject.GetComponent<Rigidbody2D>();
                float jumpRandomForce = Random.Range(jumpForceMin, jumpForceMax);
                rb2d.velocity = Vector2.up * jumpRandomForce;
            }
            
        }
    }
}
