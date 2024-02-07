using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followbody : MonoBehaviour
{
    public Transform target;

    void Update()
    {

        if (target != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, 1000000000);
        }



    }
}
