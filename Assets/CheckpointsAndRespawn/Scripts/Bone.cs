using UnityEngine;

public class Bone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        var stats = other.GetComponent<SanchoStats>();

        if (stats != null)
        {
            stats.AddBone();

            Destroy(this.gameObject);
        }
    }
}
