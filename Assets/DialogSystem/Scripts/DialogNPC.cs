using UnityEngine;

public class DialogNPC : MonoBehaviour, IInteractive
{
    public string[] lines;

    public void Interact(TopDownPlayer player)
    {
        player.GetComponent<DialogSystem>().PushDialog(this.lines);
    }
}