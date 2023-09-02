using UnityEngine;
using System.Collections;

public class SurikenMovement : MonoBehaviour
{
    [SerializeField] private float surikenSpeed;

    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
        transform.position += Vector3.up * surikenSpeed * Time.deltaTime;

        if (transform.position.y > 7)
            Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("AI"))
            Destroy(collision.gameObject, 4);

        if (collision.gameObject.CompareTag("Player"))
            Invoke("PlayerDieFeedback", 1f);
    }

    private void PlayerDieFeedback()
    {
        GameManager.Instance.isLive = false;
    }
}
