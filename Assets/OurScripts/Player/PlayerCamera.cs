using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public Camera cam;
    [SerializeField] float focusScalar;
    bool sideScrollar;
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Trigger") || collision.CompareTag("damage") || collision.CompareTag("CheckPoint"))
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
        if (collision.CompareTag("Trigger") || collision.CompareTag("damage") || collision.CompareTag("CheckPoint"))
        {
           
        }
        else
        {
            int defSize = 7;
            if (sideScrollar)
            {
                defSize = 10;
            }
            cam.GetComponent<Camerafollow>().Focus(false, defSize);
        }
    }
    public void ActivateSideScrollar()
    {
        sideScrollar = true;
        cam.GetComponent<Camerafollow>().height = 6;
        GetComponent<PlayerHealth>().safe = true;
        GetComponent<PlayerMove>().sideScrollar = true;
    }
    public void InactivateSideScrollar()
    {
        sideScrollar = false;
        cam.GetComponent<Camerafollow>().height = 0;
        GetComponent<PlayerMove>().sideScrollar = false;
        GetComponent<PlayerHealth>().safe = false;
    }

    public void cameraDeath()
    {
        cam.GetComponent<Camerafollow>().deathEffect();
    }
}
