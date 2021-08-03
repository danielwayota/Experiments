using UnityEngine;

public class SanchoData
{
    public int health;
    public int bones;

    public Vector2 checkPointposition;

    public SanchoData(int health, int bones)
    {
        this.health = health;
        this.bones = bones;
    }

    public SanchoData(int health, int bones, Vector2 checkPointposition) : this(health, bones)
    {
        this.checkPointposition = checkPointposition;
    }
}