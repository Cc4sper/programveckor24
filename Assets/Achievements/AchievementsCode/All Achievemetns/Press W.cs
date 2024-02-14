using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class JustPressW : AchievementObj
{

    public override bool Check()
    {
        isUpgradeable = false;
        

        if (Input.GetKeyDown(KeyCode.W))
        {
            achGoal += 1;
        }

       return base.Check();
    }
}
