using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillTree : MonoBehaviour
{

    public enum Skill
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

    public Dictionary<Skill, int> skillCosts = new Dictionary<Skill, int>();
    public Dictionary<Skill, System.Action> skillFunctions = new Dictionary<Skill, System.Action>();
    public List<Skill> unlockedSkills = new List<Skill>();
    List<Skill> playerSkills = new List<Skill>();
    public int skillPoints = 0;

    // Start is called before the first frame update
    void Start()
    {
        skillCosts.Add(Skill.BiggerDesk, 2);
        skillFunctions.Add(Skill.BiggerDesk, BiggerDeskFunction);

        skillCosts.Add(Skill.Tape, 3);
        skillFunctions.Add(Skill.Tape, TapeFunction);

        skillCosts.Add(Skill.NoFan, 3);
        skillFunctions.Add(Skill.NoFan, NoFanFunction);

        skillCosts.Add(Skill.SmallerStamp, 3);
        skillFunctions.Add(Skill.SmallerStamp, SmallerStampFunction);

        skillCosts.Add(Skill.MultiStamp, 4);
        skillFunctions.Add(Skill.MultiStamp, MultiStampFunction);

        skillCosts.Add(Skill.Highlighter, 4);
        skillFunctions.Add(Skill.Highlighter, HighlighterFunction);

        skillCosts.Add(Skill.Compress, 4);
        skillFunctions.Add(Skill.Compress, CompressFunction);

        skillCosts.Add(Skill.Stapler, 4);
        skillFunctions.Add(Skill.Stapler, StaplerFunction);

        unlockedSkills.Add(Skill.BiggerDesk);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void BuyASkill(Skill skill)
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

    bool CanBuySkill(Skill skill)
    {
        if (skillPoints >= skillCosts[skill] && unlockedSkills.Contains(skill))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void UnlockNewSkills(Skill skill)
    {
        if (skill == Skill.BiggerDesk)
        {
            unlockedSkills.Add(Skill.Tape);
            unlockedSkills.Add(Skill.NoFan);
            unlockedSkills.Add(Skill.SmallerStamp);
        }
        else if (skill == Skill.Tape || skill == Skill.NoFan || skill == Skill.SmallerStamp)
        {
            unlockedSkills.Add(Skill.MultiStamp);
            unlockedSkills.Add(Skill.Highlighter);
            unlockedSkills.Add(Skill.Compress);
            unlockedSkills.Add(Skill.Stapler);
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
