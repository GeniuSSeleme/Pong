using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallScript : MonoBehaviour
{
    public Text scorerightText;
    public Text scoreleftText;
    int scoreRight;
    int scoreLeft;
    float gravity = 0f;
    public Vector2 speed;
    // Start is called before the first frame update
     void Start()
    {
        Vector2 speed = new Vector2(10, 10);
        GetComponent<Rigidbody2D>().velocity = speed;
    }
    void Update()
    {

        gravity = Input.GetAxis("Vertical");

    }
    public float HitFactor(Vector2 ballPos, Vector2 racketPos,
                float racketHeight)
    {
        // ascii art:
        // ||  1 <- at the top of the racket
        // ||
        // ||  0 <- at the middle of the racket
        // ||
        // || -1 <- at the bottom of the racket
        return (ballPos.y - racketPos.y)/racketHeight;
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        // Note: 'col' holds the collision information. If the
        // Ball collided with a racket, then:
        //   col.gameObject is the racket
        //   col.transform.position is the racket's position
        //   col.collider is the racket's collider
        
        // Hit the left Racket?
        if (col.gameObject.name == "RacketLeft")
        {
            // Calculate hit Factor
            float y = HitFactor(transform.position,
                                col.transform.position,
                                col.collider.bounds.size.y);

            // Calculate direction, make length=1 via .normalized
            Vector2 dir = new Vector2(1, y).normalized;

            // Set Velocity with dir * speed
            GetComponent<Rigidbody2D>().velocity = dir * speed;

        }
        // Hit the right Racket?
        if (col.gameObject.name == "RacketRight")
        {
            
            // Calculate hit Factor
            float y = HitFactor(transform.position,
                                col.transform.position,
                                col.collider.bounds.size.y);

            // Calculate direction, make length=1 via .normalized
            Vector2 dir = new Vector2(-1, y).normalized;
            
            // Set Velocity with dir * speed
            GetComponent<Rigidbody2D>().velocity = dir * speed;
            
        }
        //this is our condition (if the ball collides with an object with the name Wallright)
        if (col.gameObject.name == "Wallright")
        {
            //this line will just add 1 point to the score
            scoreLeft++;
            //this line will convert the int score variable to a string variable
            scoreleftText.text = scoreLeft.ToString();
        }
        if (col.gameObject.name == "Wallleft")
        {
            scoreRight++;
            scorerightText.text = scoreRight.ToString();
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        GetComponent<Rigidbody2D>().gravityScale = gravity;
    }
}
