using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericAttack : MonoBehaviour
{
    public int damage;
    public float holdTime;

    private void Start()
    {
        Destroy(gameObject, holdTime);
    }
}
