using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Counter : MonoBehaviour
{
    string score;

    //Interval for the counter to go up
    [SerializeField]
    float waitTime = 0.25f;
    int points = 0;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(Count());
        UpdateScore();
    }

    IEnumerator Count()
    {
        while (SceneManager.GetActiveScene().name == "Avalanche")
        {
            points++;
            UpdateScore();
            PlayerPrefs.SetString("KEY_SCORE", score);
            yield return new WaitForSeconds(waitTime);
        }
    }

    void UpdateScore()
    {
        score = "Score: " + points;
    }
}
