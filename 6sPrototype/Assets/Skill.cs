using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Skill : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public SkillTree skillTree;
    [SerializeField] SkillTree.SkillType skillType;

    public void OnPointerEnter(PointerEventData eventData)
    {
        skillTree.ShowText(skillType);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        skillTree.HideText(skillType);
    }

    // Start is called before the first frame update
    void Start()
    {
        skillTree = GameObject.FindWithTag("Skill Tree System").GetComponent<SkillTree>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
