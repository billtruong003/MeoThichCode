using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

public class ControllerMagic : SerializedMonoBehaviour
{
    public static ControllerMagic Instance;
    [SerializeField] private GameObject UISkillSet;
    [SerializeField] private Queue<MagicSet> QueueMagic;

    [HideInInspector] public UnityAction OnSetSkill;
    [HideInInspector] public UnityAction OnFinishSkillSet;
    [HideInInspector] public UnityAction OnExecute;
    private bool settingSkill;

    private void Awake()
    {
        OnSetSkill += SettingSkill;
        OnFinishSkillSet += DoneSkillSet;
    }
    private void Start()
    {
        Instance = this;
        QueueMagic = new Queue<MagicSet>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
        {
            OnSetSkill?.Invoke();
        }

        if (Input.GetMouseButtonDown(0))
        {
            OnExecute?.Invoke();
        }
    }

    private void OnDestroy()
    {
        Instance = null;
        OnSetSkill -= SettingSkill;
    }

    public void SettingSkill()
    {
        if (settingSkill)
        {
            UISkillSet.SetActive(false);
            settingSkill = false;
            OnFinishSkillSet?.Invoke();
        }
        else
        {
            UISkillSet.SetActive(true);
            settingSkill = true;
        }
    }

    public void DoneSkillSet()
    {
        Execute();
    }
    public void AddMagic(MagicSet magic)
    {
        QueueMagic.Enqueue(magic);
    }
    public void Execute()
    {
        foreach (MagicSet magicSlot in QueueMagic)
        {
            magicSlot.TriggerSkill();
        }
    }
    public void RemoveMagic(int slot)
    {
        if (slot == QueueMagic.Count)
        {
            QueueMagic.Dequeue();
        }
    }
}

public enum MagicType
{
    Active,
    Effect,
    Timing,
    Passive,
}

// Projectile
// Băng
// Telekinesis
// Wall
// Delay và Bind