using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartGameScript : MonoBehaviour {

	// Load the game when clickeds
	public void OnClicked()
    {
        SceneManager.LoadScene("pong");
    }
}
