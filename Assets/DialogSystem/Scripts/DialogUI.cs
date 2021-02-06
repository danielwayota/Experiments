using UnityEngine;
using UnityEngine.UI;

public class DialogUI : MonoBehaviour
{
    public Text dialogLabel;

    public void Show(string text)
    {
        this.gameObject.SetActive(true);
        this.dialogLabel.text = text;
    }

    public void Hide()
    {
        this.gameObject.SetActive(false);
    }
}