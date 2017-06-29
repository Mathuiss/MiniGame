using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScene : MonoBehaviour {

    public void Awake()
    {
        OnClick();
    }

    public void OnClick()
    {
        SceneManager.LoadScene("Avalanche");
    }
}
