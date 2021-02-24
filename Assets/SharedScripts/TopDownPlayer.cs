using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class TopDownPlayer : MonoBehaviour
{
    public float speed;
    private Rigidbody2D body;

    void Start()
    {
        this.body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        var move = new Vector2(h, v);

        this.body.velocity = move.normalized * this.speed;
    }
}