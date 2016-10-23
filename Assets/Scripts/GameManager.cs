using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    //set scores for each paddle
    int playerScore, aiScore = 0;
    [SerializeField]
    BallController gameBall;
    [SerializeField]
    Text scoreText;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame to update the score
	void Update ()
    {

    }

    //what to do when a goal is scored
    public void GoalScored (bool isPlayer)
    {
        if (isPlayer)
        { playerScore++; }
        else if (!isPlayer)
        { aiScore++; }

        if (playerScore == 5)
            GameOver('p');
        else if (aiScore == 5)
            GameOver('a');
        UpdateScoreText();
        gameBall.Reset();
    }

    void GameOver(char winner)
    {
        playerScore = 0;
        aiScore = 0;
        gameBall.Reset();
    }

    void UpdateScoreText()
    {
        scoreText.text = "AI " + aiScore.ToString() + " - " + playerScore.ToString() + " Player";
    }

}
