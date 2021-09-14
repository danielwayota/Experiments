using UnityEngine;

public class PauseBullet : MonoBehaviour
{
    public float speed = 4;

    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = this.transform.up * this.speed;
        Destroy(this.gameObject, 2f);
    }
}