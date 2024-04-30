using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField, Min(0f)]
    float
        constantXSpeed = 8f,
        constantYSpeed = 10f,
        randomXSpeed = 2f,
        randomYSpeed = 2f,
        extents = 0.5f;

    readonly float speed;

    Ball()
    {
        this.speed = System.MathF.Sqrt(constantXSpeed * constantXSpeed + constantYSpeed * constantYSpeed);
    }

    public float Extents => extents;

    public Vector2 Position => position;

    Vector2 position, velocity;

    System.Random random = new();

    public void UpdateVisualization() =>
        transform.localPosition = new Vector3(position.x, 0f, position.y);

    public void Move() => position += velocity / velocity.magnitude * speed * Time.deltaTime;

    public void StartNewGame()
    {
        position = Vector2.zero;
        UpdateVisualization();
        velocity = new Vector2(constantXSpeed, -constantYSpeed);
    }

    private float Random()
    {
        return (float)random.NextDouble() * 2.0f - 1.0f;
    }

    public void BounceX(float boundary)
    {
        position.x = 2f * boundary - position.x;
        float signX = velocity.x > 0 ? 1 : -1;
        float signY = velocity.y > 0 ? 1 : -1;
        velocity.x = -signX * constantXSpeed + Random() * randomXSpeed;
        velocity.y = signY * constantYSpeed + Random() * randomYSpeed;
    }

    public void BounceY(float boundary)
    {
        position.y = 2f * boundary - position.y;
        float signX = velocity.x > 0 ? 1 : -1;
        float signY = velocity.y > 0 ? 1 : -1;
        velocity.y = -signY * constantYSpeed + Random() * randomYSpeed;
        velocity.x = signX * constantXSpeed + Random() * randomXSpeed;
    }
}