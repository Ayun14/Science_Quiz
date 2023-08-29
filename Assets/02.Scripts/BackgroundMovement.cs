using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{
    [SerializeField] private float backgroundSpeed;

    private void Update()
    {
        MoveDown();
    }

    private void MoveDown()
    {
        transform.position += Vector3.up * backgroundSpeed * Time.deltaTime;

        if (transform.position.y >= 10)
            transform.position = new Vector3(0, -10, 0);
    }

}
