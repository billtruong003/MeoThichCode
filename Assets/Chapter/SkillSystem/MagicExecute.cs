using System.Collections.Generic;
using UnityEngine;

public static class Execute
{
    public static Dictionary<string, BaseSkill> skillActiveDicts = new();
    public static Dictionary<string, BaseSkill> skillEffectDicts = new();
    public static Dictionary<string, BaseSkill> skillTimingDicts = new();
    public static Dictionary<string, BaseSkill> skillPassiveDicts = new();


    public static void TriggerSkill(MagicSet magicSet)
    {
        BaseSkill skill = GetSkill(magicSet);
        if (skill != null)
        {
            skill.Execute();
        }
        else
        {
            Debug.LogError("Skill object is null.");
        }
    }

    public static BaseSkill GetSkill(MagicSet magicSet)
    {
        BaseSkill skill = new();
        switch (magicSet.magicType)
        {
            case MagicType.Active:
                return skillActiveDicts.TryGetValue(magicSet.skillName, out skill) ? skill : null;
            case MagicType.Effect:
                return skillEffectDicts.TryGetValue(magicSet.skillName, out skill) ? skill : null;
            case MagicType.Timing:
                return skillTimingDicts.TryGetValue(magicSet.skillName, out skill) ? skill : null;
            case MagicType.Passive:
                return skillPassiveDicts.TryGetValue(magicSet.skillName, out skill) ? skill : null;
            default:
                return null;
        }
    }
}
