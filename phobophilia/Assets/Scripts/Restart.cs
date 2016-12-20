using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

// Button to restar the current scene in the event the player dies
public class Restart : GameButton
{
    private string scene; // The name of the current scene

    void Start()
    {
        scene = SceneManager.GetActiveScene ().name;   
    }

	// When button is pressed, reload scene
    public override void Press()
    {
		StartCoroutine(SetSnapshot()); // Take snapshot of screen for fade-in
        StartCoroutine(Pause());
    }

    IEnumerator SetSnapshot()
    {
		// Ensure frame has finished being drawn
        yield return new WaitForEndOfFrame();

        Texture2D texture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, true);

		texture.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0); // Take snapshot
        texture.Apply();

		Data.snapshot = texture; // Store snapshot so it can retrieved in the next scene
    }

	// Load next scene after brief delay
    IEnumerator Pause()
    {
        yield return new WaitForSeconds(0.3F);
        SceneManager.LoadScene(scene);
    }
}
