using UnityEngine;
using UnityEngine.SceneManagement;

public class Case1_SceneLoader : MonoBehaviour
{
    public string sceneName = "";

    private void OnTriggerEnter2D(Collider2D other)
    {
        Case1_GameManager.s_current.SaveProtagonistData();

        SceneManager.LoadScene(this.sceneName);
    }
}
