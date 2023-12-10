using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class Charachter : MonoBehaviour
{
    public GameObject gameOverPanel;
    public Text gameScore;

    private Camera _mainCamera;
    private float deadZone = 11.5f;

    public float moveSpeed = 10.0f;
    private float _directionMove;
    private Rigidbody2D _rb2d;

    private int score = 0;
    private Text jewelText;

    private Animator _animator; //***
    private int _state = 0;     //***

    public GameObject particalPrefab;

    void Start()
    {
        _mainCamera = FindObjectOfType<Camera>();
        gameOverPanel.SetActive(false); // <-------------------------
        _animator = GetComponent<Animator>(); 
        _rb2d = GetComponent<Rigidbody2D>();
        jewelText = GameObject.Find("TextJewel").GetComponent<Text>();
    }

    void Update()
    {
        _animator.SetInteger("state", _state); 
        _directionMove = Input.GetAxis("Horizontal") * moveSpeed;
        if(transform.position.y <_mainCamera.transform.position.y - deadZone)
        {
            gameOverPanel.SetActive(true);
            gameScore.text = score.ToString();
        }
    }
    private void FixedUpdate()
    {
        Vector2 velocity = _rb2d.velocity;
        velocity.x = _directionMove;
        _rb2d.velocity = velocity;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Jewel"))
        {
            score++;
            Destroy(collision.gameObject);
        }
    }

    private void LateUpdate()
    {
        jewelText.text = score.ToString();
    }
    //----------------------------------------------------------------------------/
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Platform")
        {
            if(collision.relativeVelocity.y >= 0)
            {
                _state = 1;
                Vector2 position = new Vector2(transform.position.x, transform.position.y - 0.5f);
                Instantiate(particalPrefab, position, Quaternion.identity);
            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Platform") _state = 0;
    }
    //---------------------------------------------------------------------------/
}
