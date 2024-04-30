using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField, Min(0f)]
    float
        extents = 4f,
        speed = 10f;

    public void Move(float target, float arenaExtents)
    {
        Vector3 p = transform.localPosition;
        float limit = arenaExtents - extents;
        p.x = Mathf.Clamp(p.x, -limit, limit);
        transform.localPosition = p;
    }
}
