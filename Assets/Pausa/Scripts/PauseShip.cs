using UnityEngine;

public class PauseShip : MonoBehaviour
{
    public float speed = 2f;
    public GameObject bulletPrfb;

    public Transform shootPoint;

    private Rigidbody2D body;

    void Start()
    {
        this.body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Pausetron.current.isPaused)
            return;

        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector2 mov = new Vector2(h, v);

        this.body.velocity = mov.normalized * this.speed;

        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(this.bulletPrfb, this.shootPoint.position, this.shootPoint.rotation);
        }
    }
}