using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBounce : MonoBehaviour
{
    public GameObject hitSFX;

    public BallMoveMent ballMovement;
    public ScoreManager scoreManager;
    private Animator anim;
    private Animator anim1;

    private void Start()
    {
        // Lấy Animator của "Left Border"
        anim = GameObject.Find("Left Border").GetComponent<Animator>();
        anim1 = GameObject.Find("Right Border").GetComponent<Animator>();
    }

    private void Bounce(Collision2D collision)
    {
        Vector3 ballPosition = transform.position;
        Vector3 racketPosition = collision.transform.position;
        float racketHeight = collision.collider.bounds.size.y;

        float positionX;
        if (collision.gameObject.name == "player1")
        {
            positionX = 1; 
        }
        else
        {
            positionX = -1;
        }

        float positionY = (ballPosition.y - racketPosition.y)/racketHeight;

        ballMovement.IncreaseHitCounter();
        ballMovement.MoveBall(new Vector2(positionX, positionY));

        


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player1" || collision.gameObject.name == "Player2")
        {
            Bounce(collision);
        }


        else if (collision.gameObject.name == "Right Border")
        {
            anim1.SetTrigger("color2");
            scoreManager.Player1Goal();
            ballMovement.playerStart = false;
            StartCoroutine(ballMovement.Launch());

        }

        else if (collision.gameObject.name == "Left Border")
        {

            anim.SetTrigger("Bounce");
            scoreManager.Player2Goal();
            ballMovement.playerStart = true;
            StartCoroutine(ballMovement.Launch());
           

        }

        Instantiate(hitSFX,transform.position,transform.rotation);

    }

}
