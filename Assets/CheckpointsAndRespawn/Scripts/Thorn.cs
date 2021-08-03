using UnityEngine;

public class Thorn : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        var data = other.GetComponent<SanchoStats>();
        if (data != null)
        {
            data.Damage();
        }
    }
}