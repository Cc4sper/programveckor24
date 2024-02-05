using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class JustPressW : AchievementObj
{

    public override void Check()
    {
        isUpgradeable = false;
        base.Check();

        if (Input.GetKeyDown(KeyCode.W))
        {
            achGoal += 1;
        }
    }
}
