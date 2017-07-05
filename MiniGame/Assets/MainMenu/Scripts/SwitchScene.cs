using UnityEngine.SceneManagement;
using UnityEngine;

public class SwitchScene : MonoBehaviour {


    public void SwitchTo(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
