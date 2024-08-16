using UnityEngine;

public class MagicSet : MonoBehaviour
{
    public string skillName;
    public string description;
    public Sprite sprite;
    public MagicType magicType;
    public BaseSkill baseSkill;

    public void TriggerSkill()
    {
        switch (magicType)
        {
            case MagicType.Active:
                Execute.TriggerSkill(this);
                break;
            case MagicType.Effect:
                Execute.TriggerSkill(this);
                break;
            case MagicType.Timing:
                Execute.TriggerSkill(this);
                break;
            case MagicType.Passive:
                Execute.TriggerSkill(this);
                break;
        }
    }
}

