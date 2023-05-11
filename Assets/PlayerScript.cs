using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerScript : MonoBehaviour
{
    [SerializeField]float jumpForce = 10f;
    [SerializeField] SpriteRenderer[] circlePartColor;


    Rigidbody2D rb;
    SpriteRenderer sr;
    ScoreManager scoreManager;
    Color[] colors = new Color[4];
    bool jumped = false;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        scoreManager = FindObjectOfType<ScoreManager>();
        for(int i=0;i<circlePartColor.Length;i++)
        {
            colors[i] = circlePartColor[i].color;
        }

        RandomizeBallColor();
    }

    private void Update()
    {
        if(Input.GetButtonDown("Jump") || (Input.touchCount>0 && !jumped))
        {
            jumped = true;
            Jump();
        }
        if(Input.touchCount ==0 )
        {
            jumped = false;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<SpriteRenderer>()!=null)
        {
            if (sr.color != collision.GetComponent<SpriteRenderer>().color && collision.gameObject.tag == "CirclePart")
            {
                //Debug.Log("game over!!!");
                FindObjectOfType<ScoreManager>().ProcessGameOver();
                //Destroy(gameObject);
                gameObject.SetActive(false);
            }
            if (collision.gameObject.tag == "ColorChanger")
            {
                RandomizeBallColor();
                Destroy(collision.gameObject);
                scoreManager.AddScore(1);
            }
        }
        if(collision.gameObject.tag == "BallFallingDetector")
        {
            //Debug.Log("Ball fallen. game over!!!");
            FindObjectOfType<ScoreManager>().ProcessGameOver();
            //Destroy(gameObject);
            gameObject.SetActive(false);
        }
    }


    private void Jump()
    {
        rb.velocity = Vector2.up * jumpForce;
        GetComponent<AudioSource>().Play();
    }

    private void RandomizeBallColor()
    {
        int randIndx = Random.Range(0, colors.Length);
        sr.color = colors[randIndx];
    }

}
