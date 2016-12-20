using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// Handles input controls on title screen
public class Selector : MonoBehaviour
{
	public AudioClip select; // Audio which plays as player cycles through buttons
	private Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger; // ID of VIVE controller's trigger button
	private Valve.VR.EVRButtonId touchPad = Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad; // ID of VIVE controller's touchpad
	private SteamVR_Controller.Device controller { get { return SteamVR_Controller.Input((int)trackedObj.index); } } // VR controller
	private SteamVR_TrackedObject trackedObj; // Used to get reference to VR controller
    private AudioSource source;
    public GameButton easy;
	private Sprite playEasy; // Graphic for "Play Easy" button when not highlighted
	public Sprite playEasyHighlighted; // Graphic for "Play Easy" button when highlighted
    public GameButton normal;
	private Sprite playNormal; // Graphic for "Play Normal" button when not highlighted
	public Sprite playNormalHighlighted; // Graphic for "Play Normal" button when highlighted
    public GameButton hard;
	private Sprite playHard; // Graphic for "Play Hard" button when not highlighted
	public Sprite playHardHighlighted; // Graphic for "Play Hard" button when highlighted
    public GameButton instr;
	private Sprite instructions; // Graphic for "Instructions" button when not highlighted
	public Sprite instructionsHighlighted; // Graphic for "Instructions" button when highlighted
    public GameButton done;
	private GameButton[] buttons; // Collections of buttons
	private Sprite[] sprites; // Collection of unhighlighted button graphics
	private Sprite[] spritesHighlighted; // Collection of highlighted button graphics
	private int i; // Index of currently highlighted button
	private bool onInstr; // True when player is on instructions screen

	void Start ()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
        source = GetComponent<AudioSource>();
        playEasy = easy.GetComponent<Image> ().sprite;
        playNormal = normal.GetComponent<Image> ().sprite;
        playHard = hard.GetComponent<Image> ().sprite;
        instructions = instr.GetComponent<Image> ().sprite;
        buttons = new GameButton[] {easy, normal, hard, instr};
        sprites = new Sprite[] {playEasy, playNormal, playHard, instructions};
        spritesHighlighted = new Sprite[] { playEasyHighlighted, playNormalHighlighted, playHardHighlighted, instructionsHighlighted };
        i = 0;
        onInstr = false;

		easy.GetComponent<Image> ().sprite = playEasyHighlighted; // Initialize "Play Easy" button to highlighted
    }

    void Update ()
    {
		if (controller == null) // Debug message for if controller doesn't exist
        {
            Debug.Log("Controller not initialized");
            return;
        }

		if (!onInstr) // Ignore button inputs when on instructions screen
        {
            if (controller.GetPressDown(touchPad))
            {
                Vector2 press = controller.GetAxis();

				// If player presses up on controller, play sound effect and move selection up
                if (press.y >= 0)
                {
                    source.PlayOneShot(select);

					buttons[i].GetComponent<Image>().sprite = sprites[i]; // De-highlight current button

					i--; // Decrement button index

					if (i == -1) // If button index goes below zero, wrap-around to button 3
                        i = 3;

					buttons[i].GetComponent<Image>().sprite = spritesHighlighted[i]; // Highlight new button
                }
				else // If player presses down on controller, play sound effect and move selection down
                {
                    source.PlayOneShot(select);

					buttons[i].GetComponent<Image>().sprite = sprites[i]; // De-highlight current button

					i = (i + 1) % 4; // Increment button index; if button index goes above 3, wrap-around to button 0

					buttons[i].GetComponent<Image>().sprite = spritesHighlighted[i]; // Highlight current button
                }

            }
            
        }

        if (controller.GetPressDown(triggerButton))
        {
			if (!onInstr) // If player presses trigger when not on instructions screen, press highlighted button
            {
                buttons[i].Press();

				if (i == 3) // If highlighted button is instructions button, indicate player is on instructions screen
                    onInstr = true;

            }
			else // If player presses trigger when on instructions screen, press "Done" button
            {
                done.Press();

				onInstr = false; // Indicate player is no longer on instructions screen
            }

        }

    }

}