using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

// Functionality of the title screen's "instructions" button
public class Instructions : GameButton
{
    public GameButton playEasy;
    public GameButton playNormal;
    public GameButton playHard;
    public GameButton done;
    public GameObject instructionsText;
	public AudioClip click; // The noise that plays when the button is pressed
    private AudioSource source;

    void Start ()
    {
        source = GetComponent<AudioSource> ();
    }

	// When button is pressed, play click sound and go to instructions screen by making all buttons invisible, and making done button visible
    public override void Press()
    {
        source.PlayOneShot (click);
        playEasy.GetComponent<Image> ().enabled = false;
        playNormal.GetComponent<Image>().enabled = false;
        playHard.GetComponent<Image>().enabled = false;
        GetComponent<Image>().enabled = false;
        done.GetComponent<Image>().enabled = true;
        instructionsText.SetActive (true);
    }

}
