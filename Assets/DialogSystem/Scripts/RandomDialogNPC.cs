using UnityEngine;

public class RandomDialogNPC : MonoBehaviour, IInteractive
{
    public string[] lines;

    public void Interact(DialogPlayer player)
    {
        int index = Random.Range(0, this.lines.Length);

        string line = this.lines[index];
        player.GetComponent<DialogSystem>().PushDialogLine(line);
    }
}