using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowPlayer : MonoBehaviour
{
    [SerializeField] float slowScalar;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            print("slowing");
            collision.transform.parent.GetComponent<PlayerMove>().moveSpeed /= slowScalar;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            print("stop slowing");
            collision.transform.parent.GetComponent<PlayerMove>().moveSpeed *= slowScalar;
        }
    }
}
