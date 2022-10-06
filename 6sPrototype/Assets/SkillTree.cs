using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class SkillTree : MonoBehaviour
{

    public enum SkillType
    {
        BiggerDesk,
        Tape,
        NoFan,
        SmallerStamp,
        MultiStamp,
        Highlighter,
        Compress,
        Stapler
    }

    public Dictionary<SkillType, int> skillCosts = new Dictionary<SkillType, int>();
    public Dictionary<SkillType, System.Action> skillFunctions = new Dictionary<SkillType, System.Action>();
    public Dictionary<SkillType, GameObject> skillTexts = new Dictionary<SkillType, GameObject>();
    public List<SkillType> unlockedSkills = new List<SkillType>();
    public List<SkillType> playerSkills = new List<SkillType>();
    public int skillPoints = 0;

    [SerializeField] GameObject deskText;
    [SerializeField] GameObject tapeText;
    [SerializeField] GameObject noFanText;
    [SerializeField] GameObject smallerStampText;
    [SerializeField] GameObject multiStampText;
    [SerializeField] GameObject highlighterText;
    [SerializeField] GameObject compressText;
    [SerializeField] GameObject staplerText;

    public GameObject currentText;

    public TMP_Text skillPointsText;
    [SerializeField] TMP_Text cantBuyText;

    [SerializeField] StampSystem stampSystem;
    // Start is called before the first frame update

    void Awake()
    {
        skillCosts.Add(SkillType.BiggerDesk, 2);
        skillFunctions.Add(SkillType.BiggerDesk, BiggerDeskFunction);
        skillTexts.Add(SkillType.BiggerDesk, deskText);

        skillCosts.Add(SkillType.Tape, 3);
        skillFunctions.Add(SkillType.Tape, TapeFunction);
        skillTexts.Add(SkillType.Tape, tapeText);


        skillCosts.Add(SkillType.NoFan, 3);
        skillFunctions.Add(SkillType.NoFan, NoFanFunction);
        skillTexts.Add(SkillType.NoFan, noFanText);

        skillCosts.Add(SkillType.SmallerStamp, 3);
        skillFunctions.Add(SkillType.SmallerStamp, SmallerStampFunction);
        skillTexts.Add(SkillType.SmallerStamp, smallerStampText);

        skillCosts.Add(SkillType.MultiStamp, 4);
        skillFunctions.Add(SkillType.MultiStamp, MultiStampFunction);
        skillTexts.Add(SkillType.MultiStamp, multiStampText);

        skillCosts.Add(SkillType.Highlighter, 4);
        skillFunctions.Add(SkillType.Highlighter, HighlighterFunction);
        skillTexts.Add(SkillType.Highlighter, highlighterText);

        skillCosts.Add(SkillType.Compress, 4);
        skillFunctions.Add(SkillType.Compress, CompressFunction);
        skillTexts.Add(SkillType.Compress, compressText);

        skillCosts.Add(SkillType.Stapler, 4);
        skillFunctions.Add(SkillType.Stapler, StaplerFunction);
        skillTexts.Add(SkillType.Stapler, staplerText);

        unlockedSkills.Add(SkillType.BiggerDesk);
    }

    void Start()
    {
       
    }
   
    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowText(SkillType skill)
    {
        skillTexts[skill].SetActive(true);
        if (currentText != null)
        {
            if (skillTexts[skill] != currentText)
            {
                currentText.SetActive(false);
            }
        }
    }

    public void HideText(SkillType skill)
    {
        skillTexts[skill].SetActive(false);
    }

    public void UpdatePointsText()
    {
        skillPointsText.text = "Skill Points: " + skillPoints.ToString();
    }

    public void BuyASkill(SkillType skill)
    {

        cantBuyText.transform.parent.gameObject.SetActive(true);
        StartCoroutine(HideCantBuyText());
        if (CanBuySkill(skill))
        {
            playerSkills.Add(skill);
            skillPoints -= skillCosts[skill];
            skillFunctions[skill]();
            UnlockNewSkills(skill);
            UpdatePointsText();
            cantBuyText.text = "Skill acquired!";

        }
        else
        {
            if (!unlockedSkills.Contains(skill)) 
            {
                cantBuyText.text = "This skill isn't unlocked yet!";
            }
            else if (skillPoints < skillCosts[skill])
            {
                cantBuyText.text = "You can't afford this skill!";
            }
            else
            {
                cantBuyText.text = "You already have this skill!";
            }
        }

    }

    bool CanBuySkill(SkillType skill)
    {
        if (skillPoints >= skillCosts[skill] && unlockedSkills.Contains(skill) && !playerSkills.Contains(skill))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void UnlockNewSkills(SkillType skill)
    {
        if (skill == SkillType.BiggerDesk)
        {
            unlockedSkills.Add(SkillType.Tape);
            unlockedSkills.Add(SkillType.NoFan);
            unlockedSkills.Add(SkillType.SmallerStamp);
        }
        else if (skill == SkillType.Tape || skill == SkillType.NoFan || skill == SkillType.SmallerStamp)
        {
            if(unlockedSkills.Contains(SkillType.MultiStamp))
            {
                unlockedSkills.Add(SkillType.MultiStamp);
                unlockedSkills.Add(SkillType.Highlighter);
                unlockedSkills.Add(SkillType.Compress);
                unlockedSkills.Add(SkillType.Stapler);
            }
        }
    }

    IEnumerator HideCantBuyText()
    {
        yield return new WaitForSeconds(3f);
        cantBuyText.transform.parent.gameObject.SetActive(false); ;
    }

    void BiggerDeskFunction()
    {
        stampSystem.bigDesk.SetActive(true);
        stampSystem.upperChairsHigher.SetActive(true);
        stampSystem.lowerChairsLower.SetActive(true);
        stampSystem.normalDesk.SetActive(false);
        stampSystem.upperChairs.SetActive(false);
        stampSystem.lowerChairs.SetActive(false);
    }

    void TapeFunction()
    {
        // Make it so donor papers can't move when the fan turns on 
    }

    void NoFanFunction()
    {
        // Make "stop fan" button that stops the fan for up to 5 sec
    }

    void SmallerStampFunction()
    {
        Vector3 newScale = new Vector3(.6f, .6f, .6f);
        stampSystem.identifyButton.transform.localScale = newScale;
        stampSystem.introduceButton.transform.localScale = newScale;
        stampSystem.interestButton.transform.localScale = newScale;
        stampSystem.investButton.transform.localScale = newScale;
        stampSystem.informButton.transform.localScale = newScale;
        stampSystem.reInvestButton.transform.localScale = newScale;
    }

    void MultiStampFunction()
    {
        // Multiple stamps in one? 
        // Kinds confused what this means
    }

    void HighlighterFunction()
    {
        // Highlight specific, important info on donor sheets
    }

    void CompressFunction()
    {
        // Compress donor info so it fits on one page
    }

    void StaplerFunction()
    {
        // Staple profile papers together 
        // To do this, we first have to make it so there is more than one physical page per donor profile, instead of just a button to switch to a new page
    }
}
