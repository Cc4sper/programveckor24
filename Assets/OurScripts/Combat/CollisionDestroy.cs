using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDestroy : MonoBehaviour
{
    [SerializeField] string ignoreTag;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag(ignoreTag))
        {
            Destroy(gameObject);
        }

    }
}
