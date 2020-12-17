using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyOtter : MonoBehaviour
{

    /*private Rigidbody2D rb;
    private float turnTime;
    private Vector2 moveForce = new Vector2(1f, 1f);
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        turnTime = Time.time + 1f;
        rb = this.GetComponent<Rigidbody2D>();
        animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        //if it's time to turn
        if (Time.time > turnTime)
        {
            //swap in a new direction
            moveForce = moveForce * Random.Range(-1.3f, -1.25f);

            //store a new turn time
            turnTime = Time.time + 1f;
        }

        rb.AddForce(moveForce);
    }*/

    private float latestDirectionChangeTime;
    private readonly float directionChangeTime = 3f;
    private float characterVelocity = 6f;
    private Vector2 movementDirection;
    private Vector2 movementPerSecond;


    void Start()
    {
        latestDirectionChangeTime = 0f;
        calcuateNewMovementVector();
    }

    void calcuateNewMovementVector()
    {
        //create a random direction vector with the magnitude of 1, later multiply it with the velocity of the enemy
        movementDirection = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f)).normalized;
        movementPerSecond = movementDirection * characterVelocity;
    }

    void Update()
    {
        //if the changeTime was reached, calculate a new movement vector
        if (Time.time - latestDirectionChangeTime > directionChangeTime)
        {
            latestDirectionChangeTime = Time.time;
            calcuateNewMovementVector();
        }

        //move enemy: 
        transform.position = new Vector2(transform.position.x + (movementPerSecond.x * Time.deltaTime),
        transform.position.y + (movementPerSecond.y * Time.deltaTime));

    }
}
