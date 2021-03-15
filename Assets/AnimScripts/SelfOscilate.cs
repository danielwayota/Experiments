using UnityEngine;

public class SelfOscilate : MonoBehaviour
{
    public Vector3 direction = Vector3.up;
    public float amplidude = 0.25f;
    public float speed = 1f;

    public float startingAngle = 0;

    public SelfOscilateType type;

    private float angle;
    private Vector3 pivot;

    void Start()
    {
        this.angle = this.startingAngle;

        if (this.type == SelfOscilateType.POSITION)
        {
            this.pivot = this.transform.localPosition;
        }
        else if (this.type == SelfOscilateType.SCALE)
        {
            this.pivot = this.transform.localScale;
        }
    }

    void Update()
    {
        Vector3 offset = this.direction * Mathf.Cos(this.angle) * this.amplidude;

        if (this.type == SelfOscilateType.POSITION)
        {
            this.transform.localPosition = this.pivot + offset;
        }
        else if (this.type == SelfOscilateType.SCALE)
        {
            this.transform.localScale = this.pivot + offset;
        }

        this.angle += Time.deltaTime * this.speed;
        if (this.angle > Mathf.PI * 2)
            this.angle -= Mathf.PI * 2;
    }
}

public enum SelfOscilateType
{
    POSITION, SCALE
}