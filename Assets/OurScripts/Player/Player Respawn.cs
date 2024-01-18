using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    
    public Vector2 savedPos;
    
    bool Interact;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("CheckPoint"))
        {
            setSpawn();
        }
    }
    
    private void setSpawn()
    {
        savedPos = transform.position;
    }
}
