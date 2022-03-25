using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardDanger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.position = new Vector3(-5f, -2.5f, 0f);
        }
    }
}
