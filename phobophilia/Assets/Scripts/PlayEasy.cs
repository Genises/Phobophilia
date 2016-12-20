using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

// Button for starting the game on easy difficulty
public class PlayEasy : GameButton
{
	// When button is pressed, set difficulty to easy and load first scene
    public override void Press ()
    {
        Data.difficulty = Data.EASY;

		StartCoroutine(SetSnapshot()); // Take snapshot of screen for fade-in
        StartCoroutine(Pause());
    }

	// Take snapshot of screen for fade-in
    IEnumerator SetSnapshot ()
    {
		// Ensure frame has finished being drawn
        yield return new WaitForEndOfFrame();

		Texture2D texture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, true);

		texture.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0); // Take snapshot
        texture.Apply();

		Data.snapshot = texture; // Store snapshot so it can retrieved in the next scene
    }

	// Load next scene after brief delay
    IEnumerator Pause ()
    {
        yield return new WaitForSeconds(0.3F);
        SceneManager.LoadScene("SpiderRoom");
    }

}
