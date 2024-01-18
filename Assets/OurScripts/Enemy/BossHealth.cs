using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : EnemyHealth
{
    public bool phase;
    public override void Update()
    {
        base.Update();
        if (enemyhp <= 60 && phase == false)
        {
            phase = true;
            GetComponent<DefensiveSummon>().Summon(3);
            GetComponent<StraightChase>().speed = 2;
        }
    }

    public void Return()
    {
        GetComponent<EnemyHealth>().enabled = true;
        GetComponent<StraightChase>().nextPhase();
    }
}
