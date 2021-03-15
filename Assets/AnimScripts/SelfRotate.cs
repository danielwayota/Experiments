using UnityEngine;

public class SelfRotate : MonoBehaviour
{
    public Vector3 direction = Vector3.up;
    public float speed = 20;

    void Update()
    {
        this.transform.Rotate(this.direction * this.speed * Time.deltaTime);
    }
}
