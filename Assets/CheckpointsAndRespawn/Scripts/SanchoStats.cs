using UnityEngine;

public class SanchoStats : MonoBehaviour
{
    private SanchoStatsUI ui;

    public int health = 2;
    public int bones = 0;

    void Start()
    {
        this.ui = GameObject.FindObjectOfType<SanchoStatsUI>();

        this.ui.SetStats(this.health, this.bones);
    }

    public void RestoreHealthStat(int health)
    {
        this.health = health;

        this.ui.SetStats(this.health, this.bones);
    }

    public void RestoreStats(int health, int bones)
    {
        this.health = health;
        this.bones = bones;

        this.ui.SetStats(this.health, this.bones);
    }

    public void Damage()
    {
        this.health --;

        this.ui.SetStats(this.health, this.bones);

        if (this.health <= 0)
        {
            if (Case1_GameManager.s_current != null)
            {
                Case1_GameManager.s_current.OnProtagonistDeath(this.gameObject);
            }
            else if (Case2_GameManager.s_current != null)
            {
                Case2_GameManager.s_current.OnProtagonistDeath(this.gameObject);
            }
        }
    }

    public void AddBone()
    {
        this.bones++;
        this.ui.SetStats(this.health, this.bones);
    }
}
