using UnityEngine;
using UnityEngine.UI;

public class DisplayScore : MonoBehaviour {

    private Text text;
    private string defaultScore = "Score: 0";

	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
        text.text = PlayerPrefs.GetString("KEY_SCORE", defaultScore);
	}
}
