using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] float focusScalar;
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        cam.GetComponent<Camerafollow>().Focus(true, focusScalar);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        cam.GetComponent<Camerafollow>().Focus(false, focusScalar);
    }

    public void cameraDeath()
    {
        cam.GetComponent<Camerafollow>().deathEffect();
    }
}
