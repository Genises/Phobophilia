using UnityEngine;
using UnityEngine.UI;
using System.Collections;

// Super-class for all game buttons
public abstract class GameButton : MonoBehaviour
{
	// All game buttons must have a method to be called when pressed
    public abstract void Press();
}
