using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    bool InteractSpawn;
    public Vector2 savedPos;
    [SerializeField] KeyCode InteractKey;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("CheckPoint"))
        {
            InteractSpawn = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("CheckPoint"))
        {
            InteractSpawn = false;
        }
    }
    private void Update()
    {
        if (InteractSpawn && Input.GetKeyDown(InteractKey))
        {
            setSpawn();
        }
    }
    private void setSpawn()
    {
        savedPos = transform.position;
    }
}
