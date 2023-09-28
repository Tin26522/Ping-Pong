using System.Collections;

using UnityEngine;

public class BallMoveMent : MonoBehaviour
{
    public float startSpeed;
    public float extraSpeed;
    public float maxExtraSpeed;

    public bool playerStart = true;


    private int hitCounter = 0;

    private Rigidbody2D rb;



    void Start()
    {
        rb=GetComponent<Rigidbody2D>();

        StartCoroutine(Launch());
    }


    private void RestartBall()
    {
        rb.velocity = new Vector2(0,0);
        transform.position = new Vector2(0,0);
    }
    
    public IEnumerator Launch()
    {
        RestartBall();
        hitCounter = 0;
        yield return new WaitForSeconds(1); //Khi play game se cho 1s de ball di chuyen

        if (playerStart == true )
        {
            MoveBall(new Vector2(-1,0));
        }
        else
        {
            MoveBall(new Vector2( 1, 0));
        }
        MoveBall(new Vector2(-1, 0)); //Huong bay cua ball (bay ve ben trai)

    }

    public void MoveBall(Vector2 direction)
    {
        direction = direction.normalized;
        
        float Ballspeed = startSpeed + hitCounter * extraSpeed;

        rb.velocity = direction * Ballspeed;
    }

    public void IncreaseHitCounter()
    {
        if (hitCounter * extraSpeed < maxExtraSpeed)
        {
            hitCounter++;

        }
    }
}
