using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NewGame : MonoBehaviour
{
    public InputField profileInput;

    public void Generate()
    {
        string profileName = this.profileInput.text;
        ProfileStorage.CreateNewGame(profileName);

        SceneManager.LoadScene("P_Game");
    }
}
