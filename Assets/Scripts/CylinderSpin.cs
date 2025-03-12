using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderSpin : MonoBehaviour
{

    public float speed = 3;

    void Update()
    {
        Vector3 dir = Vector3.up;
        Quaternion deltaRotation = Quaternion.Euler(dir * speed * Time.deltaTime);
        transform.rotation = transform.rotation * deltaRotation;
    }

}
