using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public Camera cam;
    [SerializeField] float focusScalar;
    public bool sideScrollar;
    public float defSize = 7;

    private void Start()
    {
        ActivateSideScrollar();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Trigger") || collision.CompareTag("damage") || collision.CompareTag("CheckPoint"))
        {
            
        }
        else if (sideScrollar == false)
        {
            print(collision.name);
            cam.GetComponent<Camerafollow>().Focus(true, defSize * focusScalar);
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Trigger") || collision.CompareTag("damage") || collision.CompareTag("CheckPoint"))
        {
           
        }
        else
        {
            cam.GetComponent<Camerafollow>().Focus(false, defSize);
        }
    }
    public void ActivateSideScrollar()
    {
        sideScrollar = true;
        cam.GetComponent<Camerafollow>().height = 5;
        defSize = 10;
        cam.GetComponent<Camerafollow>().SetCamera(defSize);
        GetComponent<PlayerHealth>().safe = true;
        GetComponent<PlayerMove>().sideScrollar = true;
    }
    public void InactivateSideScrollar()
    {

        sideScrollar = false;
        cam.GetComponent<Camerafollow>().height = 0;
        defSize = 7;
        cam.GetComponent<Camerafollow>().SetCamera(defSize);
        GetComponent<PlayerMove>().sideScrollar = false;
        GetComponent<PlayerHealth>().safe = false;
    }

    public void cameraDeath()
    {
        cam.GetComponent<Camerafollow>().deathEffect();
    }
}
