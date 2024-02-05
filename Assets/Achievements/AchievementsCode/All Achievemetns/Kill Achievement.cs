using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class KillAchievement : AchievementObj
{
    public override void Check()
    {
        isUpgradeable = true;
        base.Check();
    }
}
