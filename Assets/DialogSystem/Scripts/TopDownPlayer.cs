using UnityEngine;

public class TopDownPlayer : MonoBehaviour
{
    public float speed = 4f;

    public float interactRange;
    public LayerMask whatIsInteractuable;

    private Rigidbody2D body;
    private DialogSystem dialogSystem;

    void Start()
    {
        this.body = GetComponent<Rigidbody2D>();
        this.dialogSystem = GetComponent<DialogSystem>();
    }

    void Update()
    {
        var mov = Vector2.zero;

        if (this.dialogSystem.hasDialog)
        {
            // Dialog stuff
            if (Input.GetButtonDown("Jump"))
            {
                this.dialogSystem.NextLine();
            }
        }
        else
        {
            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");

            mov = (new Vector2(h, v)).normalized;

            // Interact
            if (Input.GetButtonDown("Jump"))
            {
                var collider = Physics2D.OverlapCircle(this.transform.position, this.interactRange, this.whatIsInteractuable);
                if (collider != null)
                {
                    var inter = collider.gameObject.GetComponent<IInteractive>();
                    if (inter != null)
                        inter.Interact(this);
                }
            }
        }

        this.body.velocity = mov * this.speed;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(this.transform.position, this.interactRange);
    }
}