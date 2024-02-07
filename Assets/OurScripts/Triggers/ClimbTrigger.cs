using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbTrigger : MonoBehaviour
{
    [SerializeField] float slowScalar;
    [SerializeField] bool steepClimb;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.parent.GetComponent<PlayerMove>().moveSpeed /= slowScalar;
            if (steepClimb)
            {
                collision.transform.parent.GetComponent<PlayerMove>().animator.SetBool("climbing", true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.parent.GetComponent<PlayerMove>().moveSpeed *= slowScalar;
            if (steepClimb)
            {
                collision.transform.parent.GetComponent<PlayerMove>().animator.SetBool("climbing", false);
            }
        }
    }
}
