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

    /// <summary>
    /// Initiates the coroutine and then updates the score
    /// </summary>
    void Start()
    {
        StartCoroutine(Count());
        UpdateScore();
    }

    /// <summary>
    /// The IEnumerator is a coroutine to add points to score and save them to the playerprefs every given time
    /// Next the score will be updated
    /// Score will be saved to the playerprefs as a string
    /// </summary>
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

    /// <summary>
    /// Updates the score throughout the process and converts it to a string
    /// </summary>
    void UpdateScore()
    {
        score = "Score: " + points;
    }
}
