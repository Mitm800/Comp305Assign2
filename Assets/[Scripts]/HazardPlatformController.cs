using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardPlatformController : MonoBehaviour
{
    private float rotateZ;
    private float rotateSpeed = 1.0f;
    private bool isRotating = false;
    public float haltTime = 5.0f;

    private void Start()
    {
        InvokeRepeating("Rotate", 0.0f, haltTime);
    }

    private void Update()
    {
        if (isRotating)
        {
            rotateZ += Mathf.LerpAngle(0, 180, rotateSpeed * Time.deltaTime);
            //rotateZ += rotateSpeed * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, 0, rotateZ);
        }
        else
        {
            fixZAxis();
        }

    }

    private void Rotate()
    {
        StartCoroutine(Rotate180());
    }

    private IEnumerator Rotate180()
    {
        if (!isRotating)
        {
            isRotating = true;
        }
        yield return new WaitForSeconds(1.0f);
        isRotating = false;

    }

    private void fixZAxis()
    {
        if(transform.rotation.z < 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            rotateZ = 0;
        }

        if (transform.rotation.z > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 180);
        }
        //if (rotateZ < 190 && rotateZ > 170)
        //{
        //    rotateZ = 180;
        //}
    }
}
