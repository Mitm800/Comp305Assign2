using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncingPlatform : MonoBehaviour
{
    public float bounce = 20.0f;


    private void OnCollisionEnter2D(Collision2D collider)
    {
        if(collider.gameObject.CompareTag("Player")) {
            Rigidbody2D rb = collider.gameObject.GetComponent<Rigidbody2D>();
            rb.AddForce(Vector2.up * bounce, ForceMode2D.Impulse);
        }
    }
}
