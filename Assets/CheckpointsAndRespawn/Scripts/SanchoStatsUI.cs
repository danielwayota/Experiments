using UnityEngine;
using UnityEngine.UI;

public class SanchoStatsUI : MonoBehaviour
{
    public Image[] heartContainers;
    public Text bonesLabel;

    public void SetStats(int health, int bones)
    {
        foreach (var cont in this.heartContainers)
        {
            cont.gameObject.SetActive(false);
        }

        for (int i = 0; i < health; i++)
        {
            this.heartContainers[i].gameObject.SetActive(true);
        }

        this.bonesLabel.text = bones.ToString();
    }
}