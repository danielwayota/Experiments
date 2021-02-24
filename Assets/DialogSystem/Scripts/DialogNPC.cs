using UnityEngine;

public class DialogNPC : MonoBehaviour, IInteractive
{
    public string[] lines;

    public void Interact(DialogPlayer player)
    {
        player.GetComponent<DialogSystem>().PushDialog(this.lines);
    }
}