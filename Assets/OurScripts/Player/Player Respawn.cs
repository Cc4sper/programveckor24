using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    
    public Vector2 savedPos;
    public KeyCode InteractKey;

    bool Interact;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("CheckPoint"))
        {
            Interact = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("CheckPoint"))
        {
            Interact = false;
        }
    }
    private void Update()
    {
        if (Interact && Input.GetKeyDown(InteractKey))
        {
            setSpawn();
        }
    }
    private void setSpawn()
    {
        savedPos = transform.position;
    }
}
