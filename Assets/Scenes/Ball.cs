using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField, Min(0f)]
    float
        constantXSpeed = 8f,
        constantYSpeed = 10f,
        extents = 0.5f;

    public float Extents => extents;

    public Vector2 Position => position;

    Vector2 position, velocity;

    System.Random random = new();

    public void UpdateVisualization() =>
        transform.localPosition = new Vector3(position.x, 0f, position.y);

    public void Move() => position += velocity * Time.deltaTime;

    public void StartNewGame()
    {
        position = Vector2.zero;
        UpdateVisualization();
        velocity = new Vector2(constantXSpeed, -constantYSpeed);
    }

    public void BounceX(float boundary)
    {
        position.x = 2f * boundary - position.x;
        velocity.x *= -1;
    }

    public void BounceY(float boundary)
    {
        position.y = 2f * boundary - position.y;
        velocity.y *= -1;
    }
}