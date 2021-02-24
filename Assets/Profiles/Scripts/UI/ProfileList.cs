using UnityEngine;
using UnityEngine.SceneManagement;

public class ProfileList : MonoBehaviour
{
    public Transform profilesHolder;

    public GameObject profileUIBoxPrefab;

    void Start()
    {
        var index = ProfileStorage.GetProfileIndex();

        foreach (var profileName in index.profileFileNames)
        {
            var go = Instantiate(this.profileUIBoxPrefab);
            var uibox = go.GetComponent<ProfileBoxUI>();

            uibox.nameLabel.text = profileName;

            // Click load button
            uibox.loadBtn.onClick.AddListener(() => {
                ProfileStorage.LoadProfile(profileName);

                SceneManager.LoadScene("P_Game");
            });

            // Click delete button
            uibox.deleteBtn.onClick.AddListener(() => {
                ProfileStorage.DeleteProfile(profileName);
                Destroy(go);
            });

            go.transform.SetParent(this.profilesHolder, false);
        }
    }
}
