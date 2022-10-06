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
    public Button buySkillButton;

    public void OnPointerEnter(PointerEventData eventData)
    {
        skillTree.ShowText(skillType);
        StartCoroutine(HideSkillText());
        skillTree.currentText = skillTree.skillTexts[skillType];
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        //skillTree.HideText(skillType);
    }

    // Start is called before the first frame update
    void Start()
    {
        skillTree = GameObject.FindWithTag("Skill Tree System").GetComponent<SkillTree>();
        buySkillButton = skillTree.skillTexts[skillType].GetComponentInChildren(typeof(Button)) as Button;
        buySkillButton.GetComponent<Button>().onClick.AddListener(delegate { skillTree.BuyASkill(skillType); });
    }

    IEnumerator HideSkillText()
    {
        yield return new WaitForSeconds(3f);
        skillTree.HideText(skillType);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
