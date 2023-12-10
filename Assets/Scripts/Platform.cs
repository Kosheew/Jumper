using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public float jumpForce = 10f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.relativeVelocity.y <= 0f)
        {
            Rigidbody2D rb2d = collision.gameObject.GetComponent<Rigidbody2D>();
            if(rb2d != null)
            {
                rb2d.velocity = Vector2.up * jumpForce;
            }
        }
    }
}
