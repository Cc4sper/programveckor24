using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualFlip : MonoBehaviour
{
    [SerializeField] int rot;
    Transform player;
    void Update()
    {
        if (transform.parent.CompareTag("Player"))
        {
            if (player == null)
            {
                player = transform.parent;
            }
            if (player.transform.rotation.z < 0)
            {
                transform.localEulerAngles = new Vector3(0, 180, 0);
            }
            else 
            {
                transform.localEulerAngles = Vector3.zero;
            }
        }
    }
}
