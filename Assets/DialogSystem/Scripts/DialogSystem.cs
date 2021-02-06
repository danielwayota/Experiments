using UnityEngine;

using System.Collections.Generic;

public class DialogSystem : MonoBehaviour
{
    public bool hasDialog { get; protected set; }

    private DialogUI dialogUI;
    private Queue<string> dialogLines;

    void Start()
    {
        this.dialogUI = FindObjectOfType<DialogUI>();
        this.dialogUI.Hide();

        this.dialogLines = new Queue<string>();

        this.hasDialog = false;
    }

    public void PushDialog(string[] lines)
    {
        foreach (var line in lines)
        {
            this.dialogLines.Enqueue(line);
        }

        this.NextLine();
    }

    public void PushDialogLine(string line)
    {
        this.dialogLines.Enqueue(line);

        this.NextLine();
    }

    public void NextLine()
    {
        if (this.dialogLines.Count != 0)
        {
            var line = this.dialogLines.Dequeue();
            this.dialogUI.Show(line);
            this.hasDialog = true;
        }
        else
        {
            this.dialogUI.Hide();
            this.hasDialog = false;
        }
    }
}