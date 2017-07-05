using UnityEngine.SceneManagement;
using UnityEngine;

public class SwitchScene : MonoBehaviour {
    
    /// <summary>
    /// Switches the scene to avalanche in this case
    /// </summary>
    /// <param name="scene"></param>
    public void SwitchTo(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
