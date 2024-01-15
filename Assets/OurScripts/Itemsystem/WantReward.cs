using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WantReward : WantItem
{
    [SerializeField] Item[] reward;
    [SerializeField] Vector3 dropSpot;

    public override void Saticified()
    {
        base.Saticified();
        for (int i = 0; i < reward.Length; i++)
        {
            Item drop = Instantiate(reward[i], transform.position, Quaternion.identity);
            drop.transform.localPosition += new Vector3(dropSpot.x + Random.Range(-5,5)/10f, dropSpot.y + Random.Range(-5, 5) / 10f);
        }
    }
}
