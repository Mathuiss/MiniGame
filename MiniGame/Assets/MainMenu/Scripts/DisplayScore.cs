using UnityEngine;
using UnityEngine.UI;

public class DisplayScore : MonoBehaviour {

    /// <summary>
    /// Creates the variables used in the Text component
    /// </summary>
    private Text text;
    private string defaultScore = "Score: 0";

    /// <summary>
    /// Sets the Text.text to the stored score string in the playerprefs
    /// </summary>
	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
        text.text = PlayerPrefs.GetString("KEY_SCORE", defaultScore);
	}
}
