using UnityEngine;
using System.Collections;

public class GoalScript : MonoBehaviour {

    [SerializeField]
    bool isPlayer;
    [SerializeField]
    GameManager gameMan;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.name == "Ball")
        {
            gameMan.GoalScored(isPlayer);
        }
    }
}
