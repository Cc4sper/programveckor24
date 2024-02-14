using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class KillAchievement : AchievementObj
{
    public override bool Check()
    {
        isUpgradeable = true;
       return base.Check();
    }
}
