using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoAttack : EnemyAttack
{
    private void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            Attack();
        }
    }
}
