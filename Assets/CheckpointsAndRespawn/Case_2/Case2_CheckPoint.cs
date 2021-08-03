using UnityEngine;

public class Case2_CheckPoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        var stats = other.GetComponent<SanchoStats>();

        if (stats != null)
        {
            Case2_GameManager.s_current.OnProtagonistCheckpoint(stats);
        }
    }
}
