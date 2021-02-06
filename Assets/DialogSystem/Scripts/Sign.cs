using UnityEngine;

public class Sign : MonoBehaviour, IInteractive
{
    public string text;

    public void Interact(TopDownPlayer player)
    {
        player.GetComponent<DialogSystem>().PushDialogLine(this.text);
    }
}