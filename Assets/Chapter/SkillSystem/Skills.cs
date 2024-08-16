using System;
using Cysharp.Threading.Tasks;
using UnityEngine;


public class Telekinesis : BaseSkill
{
    public override void Execute()
    {
        // Telekinesis logic here
        Debug.Log("Telekinesis");
    }
}

public class Projectile : BaseSkill
{
    public override void Execute()
    {
        Debug.Log("Telekinesis");
    }
}

public class Fireball : BaseSkill
{
    public override void Execute()
    {
        Debug.Log("Fireball");
    }
}

public class IceBlast : BaseSkill
{
    public override void Execute()
    {
        Debug.Log("IceBlast");
    }
}

public class Heal : BaseSkill
{
    public override void Execute()
    {
        Debug.Log("Heal");
    }
}

public class Buff : BaseSkill
{
    public override void Execute()
    {
        Debug.Log("Buff");
    }
}

public class Debuff : BaseSkill
{
    public override void Execute()
    {
        Debug.Log("Debuff");
    }
}

public class Delay : BaseSkill
{
    public override async void Execute()
    {
        Debug.Log("Delay started");
        await UniTask.Delay(TimeSpan.FromSeconds(1), ignoreTimeScale: false);
        Debug.Log("Delay finished");
    }
}

public class Wall : BaseSkill
{
    public override void Execute()
    {
        Debug.Log("Wall");
    }
}

public class Bind : BaseSkill
{

}