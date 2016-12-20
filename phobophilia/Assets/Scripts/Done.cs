using UnityEngine;
using UnityEngine.UI;
using System.Collections;

// Functionality of the title screen's "done" button
public class Done : GameButton
{
    public GameButton playEasy;
    public GameButton playNormal;
    public GameButton playHard;
    public GameButton instructions;
    public GameObject instructionsText;
	public AudioClip click; // The noise that plays when the button is pressed
    private AudioSource source;

	// Set button invisible by default; button should only be visible on instructions screen
    void Start()
    {
        source = GetComponent<AudioSource>();
        GetComponent<Image>().enabled = false;
    }

	// When button is pressed, play click sound, make button invisible, and make all other buttons visible
    public override void Press()
    {
        source.PlayOneShot(click);
        playEasy.GetComponent<Image>().enabled = true;
        playNormal.GetComponent<Image>().enabled = true;
        playHard.GetComponent<Image>().enabled = true;
        instructions.GetComponent<Image>().enabled = true;
        GetComponent<Image>().enabled = false;
        instructionsText.SetActive(false);
    }

}
