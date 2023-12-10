using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public float speed = 100f;
    private Transform _target;

    void Start()
    {
        _target = FindObjectOfType<Charachter>().GetComponent<Transform>();    
    }

    void Update()
    {

        if (transform.position.y < _target.position.y)
        {
            Vector3 newPos = new Vector3(transform.position.x, _target.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, newPos, speed);
        }
    }
}
