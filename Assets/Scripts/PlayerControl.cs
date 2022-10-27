using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    private Animator _animator;
    public float speed = 5f;

    public GameObject Player;

    private SpriteRenderer _renderer;

    public bool isRight = true;

    public int range = 2;

    public Text txtScore;

    private int score = 0;

    private Rigidbody2D rb;

    private bool moveLeft, moveRight,moveJump;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _renderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        txtScore = GameObject.Find("TxtScore").GetComponent<Text>();
    }

    public void MoveLeft()
    {
        moveLeft = true;
    }
    public void MoveRight()
    {
        moveRight = true;
    }
    public void MoveJump()
    {
        moveJump = true;
    }
    public void MoveStop()
    {
        moveLeft = false;
        moveRight = false;
        moveJump = false;
        _animator.SetInteger("PlayerStats", 0);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Coin")
        {
            score++;
            txtScore.text = "Text Score: " + score.ToString();
            if (score >= 10)
            {
                SceneManager.LoadScene( 1 );
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        //_animator.SetInteger("status", 0);

        if (Input.GetKey(KeyCode.LeftArrow) || moveLeft == true)
        {
            isRight = false;
            range = -2;
            gameObject.transform.Translate(Vector3.left * speed * Time.deltaTime);
            _animator.SetInteger("PlayerStats", 1);
            _renderer.flipX = true;
        } else if (Input.GetKey(KeyCode.RightArrow) || moveRight == true)
        {
            range = 2;
            isRight = true;
            gameObject.transform.Translate(Vector3.right * speed * Time.deltaTime);
            _animator.SetInteger("PlayerStats", 1);
            _renderer.flipX = false;
        } else if (Input.GetKey(KeyCode.Space) || moveJump == true)
        {
            gameObject.transform.Translate(Vector3.up * 10f * Time.deltaTime);
            _animator.SetInteger("PlayerStats", 3);
        } else if (Input.GetKey(KeyCode.R) && Input.GetKeyDown(KeyCode.RightArrow)) 
        {
            gameObject.transform.Translate(Vector3.right * speed * 2 * Time.deltaTime);
            _animator.SetInteger("PlayerStats", 2);
        } else if (Input.GetKey(KeyCode.R) && Input.GetKeyDown(KeyCode.LeftArrow))
        {
            gameObject.transform.Translate(Vector3.left * speed * 2 * Time.deltaTime);
            _animator.SetInteger("PlayerStats", 2);
        }
        else 
        {
            _animator.SetInteger("PlayerStats", 0);
        }
    }

    public void Dead()
    {
        gameObject.SetActive( false );
        Invoke( "OnRetry", 2 );
    }
    private void OnRetry()
    {
        SceneManager.LoadScene( SceneManager.GetActiveScene().buildIndex );
    }
}
