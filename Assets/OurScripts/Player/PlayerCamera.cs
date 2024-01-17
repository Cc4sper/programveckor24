using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] float focusScalar;
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Trigger") || collision.CompareTag("damage"))
        {
            
        }
        else
        {
            print(collision.name);
            cam.GetComponent<Camerafollow>().Focus(true, 5);
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Trigger") || collision.CompareTag("damage"))
        {
           
        }
        else
        {
            cam.GetComponent<Camerafollow>().Focus(false, 7);
        }
    }

    public void cameraDeath()
    {
        cam.GetComponent<Camerafollow>().deathEffect();
    }
}
