using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class SkillSlotController : MonoBehaviour
{
    [SerializeField] private MagicSet magic;
    [SerializeField] private Image skillBtn;
    [SerializeField] private Image backgroundSkillBtn;
    [SerializeField] private TextMeshProUGUI skillName;

    private void Awake()
    {
        if (magic != null)
        {
            InitSkill(magic);
            skillBtn.GetComponent<Button>().onClick.AddListener(OnClick);
        }
    }

    public void InitSkill(MagicSet magic)
    {
        skillBtn.sprite = magic.sprite;
        backgroundSkillBtn.sprite = magic.sprite;
        skillName.text = magic.skillName;
    }

    private void OnClick()
    {
        ControllerMagic.Instance.AddMagic(magic);
    }
}

