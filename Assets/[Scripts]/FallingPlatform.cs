using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour
{
    Rigidbody2D rb;

    private bool shaking = false;
    public float shakeIntensity = 10f;
    public float fallTime = 2.0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();    
    }

    private void Update()
    {
        if (shaking)
        {
            Vector3 newPosition = Random.insideUnitSphere * (shakeIntensity * Time.deltaTime);
            newPosition.x += transform.position.x;
            newPosition.y += transform.position.y;
            //newPosition.y = transform.position.y;
            newPosition.z = transform.position.z;

            transform.position = newPosition;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine("shake");
            Invoke("DropPlatform", fallTime);
            Destroy(gameObject, fallTime + 0.5f);
        }
    }

    private IEnumerator shake()
    {
        Vector3 originalPosition = transform.position;

        if (!shaking)
        {
            shaking = true;
        }

        yield return new WaitForSeconds(2.0f);
        shaking = false;
        transform.position = originalPosition;

    }
    private void DropPlatform()
    {
        rb.isKinematic = false;
    }
}
