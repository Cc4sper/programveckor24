using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnClick : MonoBehaviour
{
    
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            Destroy(gameObject);
        }
    }
}
