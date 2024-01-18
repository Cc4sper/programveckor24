using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WantDestroy : WantReward
{
    public GameObject[] destroyObj;
    public override void Saticified()
    {
        base.Saticified();
        for (int i = 0; i < destroyObj.Length; i++)
        {
            Destroy(destroyObj[i]);
        }
    }
}
