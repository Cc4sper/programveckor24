using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] float focusScalar;
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        cam.GetComponent<Camerafollow>().Focus(true, 5);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        cam.GetComponent<Camerafollow>().Focus(false, 6);
    }

    public void cameraDeath()
    {
        cam.GetComponent<Camerafollow>().deathEffect();
    }
}
