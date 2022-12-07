using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float moveForce;
    public float maxVel;

    Rigidbody2D _rb;
    bool _isTriggered;
}
