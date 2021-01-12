using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fernando : MonoBehaviour
{
    public float movementSpeed = 1f;

    Navigator navigator;

    void Start()
    {
        this.navigator = FindObjectOfType<Navigator>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            var screen = Input.mousePosition;
            var world = Camera.main.ScreenToWorldPoint(screen);
            world.z = 0;

            var path = this.navigator.GetPath(this.transform.position, world);

            StopAllCoroutines();
            StartCoroutine(this.RunPath(path));
        }
    }

    IEnumerator RunPath(List<Vector3> path)
    {
        foreach (var target in path)
        {
            var origin = this.transform.position;

            float percent = 0;
            while (percent < 1f)
            {
                this.transform.position = Vector3.Lerp(origin, target, percent);

                percent += Time.deltaTime * this.movementSpeed;
                yield return null;
            }
        }
    }
}
