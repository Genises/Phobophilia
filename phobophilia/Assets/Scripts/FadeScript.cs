using UnityEngine;
using System.Collections;

// Handles fade-in effect transitioning from previous scene to this one
public class FadeScript : MonoBehaviour
{
	public AudioClip link; // Sound-effect to play on fade-in
	private GUITexture gText; // Image to print to screen
	private Texture2D fadeTexture = Data.snapshot; // Snapshot of previous screen
	private float fadeSpeed = 0.3f; // Speed of fade-in
	private int fadeDir = -1; // Fade direction; -1 is fade-in, 1 is fade-out
	private float alpha = 1.0f; // Transparency of fade
    private AudioSource source;

    void Awake()
    {
        source = GetComponent<AudioSource>();
        source.PlayOneShot(link); // Play sound effect on startup
        gText = GetComponent<GUITexture> ();
        gText.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
		gText.texture = fadeTexture; // Initialize GUI texture to snapshot of previous screen
        gText.pixelInset = (new Rect(0, 0, -525, -850));
    }

    void Update()
    {
		alpha += fadeDir * fadeSpeed * Time.deltaTime; // Increase transparency by fade speed
		alpha = Mathf.Clamp01(alpha); // Clamp transparency to accepted range

		gText.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha); // Update image with new transparency
    }
}
