using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Paralax : MonoBehaviour
{
    private Vector2 _startPos;
    public float parallaxSpeed = 0.1f;

    void Start()
    {
        _startPos = new Vector2(transform.position.x, transform.position.y);
    }

    void Update()
    {
        float parallaxY = (Camera.main.transform.position.y - _startPos.y) * parallaxSpeed;

        Vector2 newPosition = new Vector2(_startPos.x, _startPos.y + parallaxY);
        transform.position = newPosition;
    }
}
