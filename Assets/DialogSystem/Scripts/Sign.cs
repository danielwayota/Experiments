using UnityEngine;

public class Sign : MonoBehaviour, IInteractive
{
    public string text;

    public void Interact(DialogPlayer player)
    {
        player.GetComponent<DialogSystem>().PushDialogLine(this.text);
    }
}