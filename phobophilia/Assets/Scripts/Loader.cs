using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

// Transitions from one scene to the next
public class Loader : MonoBehaviour
{
	public GameObject player;
	private Vector3 playerPos; // Position of the player
	private Vector3 tilePos; // Position of object warping player to next scene

    void Start ()
    {
        playerPos = player.transform.position;
        tilePos = GetComponent<Transform> ().position;
    }

    void Update ()
    {
        playerPos = player.transform.position;

		// Once player's position is below that of warp tile, load next scene
        if (playerPos.y <= tilePos.y)
        {
			StartCoroutine(SetSnapshot()); // Take snapshot of screen for fade-in
            StartCoroutine(Pause());
        }

    }

	// Take snapshot of screen for fade-in
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
        SceneManager.LoadScene("Room1");
    }

}
