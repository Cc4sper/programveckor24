using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : EnemyHealth
{
    public bool phase;
    [SerializeField] Healthmanagermadam health;
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

    public override void TakeDamage(int dmg, bool hit)
    {
        base.TakeDamage(dmg, hit);
        health.TakeDamage(dmg);

    }

}
