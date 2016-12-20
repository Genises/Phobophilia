using UnityEngine;
using System.Collections;

//Stores data which should be save between scenes
public class Data : MonoBehaviour
{
    public const int EASY = 0;
    public const int NORMAL = 1;
    public const int HARD = 2;
	public const bool CROUCHED = true;
	public const bool UNCROUCHED = false;
	public static int difficulty; // The game's difficulty level
	public static bool crouched; // Used to keep track of when the player is crouched/uncrouched; Used so player can crouch/uncrouch with both controllers
	public static Texture2D snapshot; // Snapshot of the screen immediately before transitioning from one scene to the next
}
