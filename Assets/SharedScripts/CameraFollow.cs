using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    void Update()
    {
        if (target == null)
            return;

        this.transform.position = Vector3.Lerp(
            this.transform.position,
            target.position - Vector3.forward * 10,
            Time.deltaTime * 5f
        );
    }
}