using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RisingWater : MonoBehaviour
{
    [SerializeField] private Rigidbody2D myRigidbody2D;
    [SerializeField] private float risingSpeed = 1f;

    private void FixedUpdate()
    {
        myRigidbody2D.velocity = Vector2.up * risingSpeed;
    }
}
