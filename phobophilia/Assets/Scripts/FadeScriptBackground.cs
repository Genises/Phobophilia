using UnityEngine;
using System.Collections;

// Ensures fade-in effect at start of every scene covers whole screen (displays behind FadeScript)
public class FadeScriptBackground : MonoBehaviour
{
	public Texture2D fadeTexture; // Black background texture
	private GUITexture gText; // Image to print to screen
	private float fadeSpeed = 0.3f; // Speed of fade-in
	private int fadeDir = -1; // Fade direction; -1 is fade-in, 1 is fade-out
	private float alpha = 1.0f; // Transparency of fade

    void Awake()
    {
        gText = GetComponent<GUITexture> ();
        gText.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
		gText.texture = fadeTexture; // Initialize GUI texture to black background texture
    }

    void Update()
    {
		alpha += fadeDir * fadeSpeed * Time.deltaTime; // Increase transparency by fade speed
		alpha = Mathf.Clamp01(alpha); // Clamp transparency to accepted range

		gText.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha); // Update image with new transparency
    }
}
