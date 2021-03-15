using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    public float time = 1f;

    void Start()
    {
        Destroy(this.gameObject, this.time);
    }
}