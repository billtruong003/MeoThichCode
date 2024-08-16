using UnityEngine;

public class BaseSkill : MonoBehaviour
{
    public virtual void Execute()
    {
        Debug.Log("Executing base skill");
    }

}