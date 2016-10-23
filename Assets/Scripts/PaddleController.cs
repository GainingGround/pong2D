using UnityEngine;
using System.Collections;

public class PaddleController : MonoBehaviour {
    //Fields editable within Unity
    [SerializeField]
    bool isAI;
    [SerializeField]
    float speed = 0.2f;

    //Create a variable that allows modification of the paddle positions
    Transform paddleTransform;
    Transform opponent;

    //Create variables to control ball direction on impact
    int direction = 0;
    float previousPositionY;
    float previousOpponentY;

	// Use this for initialization
	void Start () {
        //gain control of player paddle
        paddleTransform = transform;
        previousPositionY = paddleTransform.position.y;
        //gain control of ai paddle, and find ball to use it's position to govern ai actions
        opponent = GameObject.Find("Ball").transform;
        previousOpponentY = opponent.position.y;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        //check for player or AI
        if (isAI)
        {
            //if ball is higher than previous ai paddle position, move paddle up
            if (previousOpponentY < opponent.position.y)
            {
                MoveUp();
            }
            //if ball is lower than previous ai paddle position, move paddle down
            else if (previousOpponentY > opponent.position.y)
            {
                MoveDown();
            }
        }
        else
        {
            if (Input.GetKey("up") || Input.GetKey("w"))
            {
                MoveUp();
            }
            else if (Input.GetKey("down") || Input.GetKey("s"))
            {
                MoveDown();
            }
        }

        if (previousPositionY > paddleTransform.position.y)
        {
            //set ball to go down if the paddle moved down to meet it
            direction = -1;
        }
        else if (previousPositionY < paddleTransform.position.y)
        {
            //get ball to go up if paddle moved up to meet it
            direction = 1;
        }
        else
        {
            //guess what happens here
            direction = 0;
        }
    }

    void LateUpdate () {
        previousPositionY = paddleTransform.position.y;
    }

    //this function adds a small amount of speed with every hit
    void OnCollisionExit2D(Collision2D contact)
    {
        float adjust = 5 * direction;
        contact.rigidbody.velocity = new Vector2(contact.rigidbody.velocity.x, contact.rigidbody.velocity.y + adjust);
    }

    //moves paddles according to input
    void MoveUp()
    {
        paddleTransform.position = new Vector2(paddleTransform.position.x, paddleTransform.position.y + speed);
    }

    void MoveDown()
    {
        paddleTransform.position = new Vector2(paddleTransform.position.x, paddleTransform.position.y - speed);
    }
}
