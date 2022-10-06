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
    List<SkillType> playerSkills = new List<SkillType>();
    public int skillPoints = 0;

    [SerializeField] GameObject deskText;
    [SerializeField] GameObject tapeText;
    [SerializeField] GameObject noFanText;
    [SerializeField] GameObject smallerStampText;
    [SerializeField] GameObject multiStampText;
    [SerializeField] GameObject highlighterText;
    [SerializeField] GameObject compressText;
    [SerializeField] GameObject staplerText;

    public TMP_Text skillPointsText;

    // Start is called before the first frame update
    void Start()
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
        skillTexts.Add (SkillType.SmallerStamp, smallerStampText);

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
   
    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowText(SkillType skill)
    {
        skillTexts[skill].SetActive(true);
    }

    public void HideText(SkillType skill)
    {
        skillTexts[skill].SetActive(false);
    }

    public void UpdatePointsText()
    {
        skillPointsText.text = "Skill Points: " + skillPoints.ToString();
    }

    void BuyASkill(SkillType skill)
    {
        if (CanBuySkill(skill))
        {
            playerSkills.Add(skill);
            skillPoints -= skillCosts[skill];
            skillFunctions[skill]();
            UnlockNewSkills(skill);
        }
        else
        {
            Debug.Log("Can't buy skill");
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
            unlockedSkills.Add(SkillType.MultiStamp);
            unlockedSkills.Add(SkillType.Highlighter);
            unlockedSkills.Add(SkillType.Compress);
            unlockedSkills.Add(SkillType.Stapler);
        }
    }

    void BiggerDeskFunction()
    {

    }

    void TapeFunction()
    {

    }

    void NoFanFunction()
    {

    }

    void SmallerStampFunction()
    {

    }

    void MultiStampFunction()
    {

    }

    void HighlighterFunction()
    {

    }

    void CompressFunction()
    {

    }

    void StaplerFunction()
    {

    }
}
