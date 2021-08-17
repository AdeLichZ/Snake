using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeMovement : MonoBehaviour
{
    public float speed = 100f;

    void Update()
    {
        transform.Translate(transform.forward * speed * Time.deltaTime);
    }
}
