using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeTail : MonoBehaviour
{
    public Transform SnakeHead;
    private Renderer rend;
    public float CircleDiameter;

    private List<Transform> snakeFragments = new List<Transform>();
    private List<Vector3> positions = new List<Vector3>();
    void Awake()
    {
        positions.Add(SnakeHead.position);
        AddCircle();
        AddCircle();
    }

    void Update()
    {
        float distance = ((Vector3)SnakeHead.position - positions[0]).magnitude;

        if(distance > CircleDiameter)
        {
            Vector3 direction = ((Vector3) SnakeHead.position - positions[0].normalized);

            positions.Insert(0, SnakeHead.position);
            positions.RemoveAt(positions.Count - 1);
            distance -= CircleDiameter;
        }
        for (int i = 0; i < snakeFragments.Count; i++)
        {
            snakeFragments[i].position = Vector3.Lerp(positions[i + 1], positions[i], distance / CircleDiameter);
        }
    }
    public void AddCircle()
    {
        Transform circle = Instantiate(SnakeHead, positions[positions.Count - 1], Quaternion.identity, transform);
        snakeFragments.Add(circle);
        positions.Add(circle.position);
    }
    public void ChangeColor(Color color)
    {
        var rendOfHead = SnakeHead.GetComponentInChildren<Renderer>();
        rendOfHead.material.color = color;
        for (int i = 0; i < snakeFragments.Count; i++)
        {
            rend = snakeFragments[i].GetComponentInChildren<Renderer>();
            rend.material.color = color;
        }
    }
}
