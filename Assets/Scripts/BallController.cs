using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour {

    //makes field editable in Unity
    [SerializeField]
    float forceValue = 4.5f;

    //Creates a way to interact with the physical ball
    Rigidbody2D ballBody;

	// Use this for initialization
	void Start () {
        //Get the actual ball rigidbody
        ballBody = GetComponent<Rigidbody2D>();

        int rand = Random.Range(0,1);
        //Add an inital force to get the ball moving with a random value declared to set initial direction either right or left (not working for some reason)
        if (rand < 0.5)
        {
            ballBody.AddForce(new Vector2(forceValue * 5f, -5f));
        }
        else if (rand > 0.5)
        {
            ballBody.AddForce(new Vector2(forceValue * -5f, -5f));
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //public makes it visible to other classes, function resets ball after a goal
    public void Reset()
    {
        ballBody.velocity = Vector2.zero;
        transform.position = new Vector2(0, 0);
        Start();
    }
}
