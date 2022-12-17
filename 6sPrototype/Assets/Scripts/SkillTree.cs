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
        SpeedProcess,
        SixStamps
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
    [SerializeField] GameObject speedProcessText;
    [SerializeField] GameObject sixStampsText;

    public GameObject currentText;

    public TMP_Text skillPointsText;
    [SerializeField] TMP_Text cantBuyText;

    [SerializeField] StampSystem stampSystem;

    [SerializeField] Sprite deskGreen;
    [SerializeField] Sprite tapeGreen;
    [SerializeField] Sprite noFanGreen;
    [SerializeField] Sprite smallStampGreen;
    [SerializeField] Sprite speedProcessGreen;
    [SerializeField] Sprite sixStampsGreen;

    public Skill[] skillImages = new Skill[8];

    [SerializeField] Timer timer;
    [SerializeField] GameObject stopFanButton;


    // Start is called before the first frame update

    void Awake()
    {
        skillCosts.Add(SkillType.BiggerDesk, 2);
        skillFunctions.Add(SkillType.BiggerDesk, BiggerDeskFunction);
        skillTexts.Add(SkillType.BiggerDesk, deskText);

        skillCosts.Add(SkillType.Tape, 4);
        skillFunctions.Add(SkillType.Tape, TapeFunction);
        skillTexts.Add(SkillType.Tape, tapeText);

        skillCosts.Add(SkillType.NoFan, 3);
        skillFunctions.Add(SkillType.NoFan, NoFanFunction);
        skillTexts.Add(SkillType.NoFan, noFanText);

        skillCosts.Add(SkillType.SmallerStamp, 3);
        skillFunctions.Add(SkillType.SmallerStamp, SmallerStampFunction);
        skillTexts.Add(SkillType.SmallerStamp, smallerStampText);

        skillCosts.Add(SkillType.SpeedProcess, 4);
        skillFunctions.Add(SkillType.SpeedProcess, SpeedProcessFunction);
        skillTexts.Add(SkillType.SpeedProcess, speedProcessText);

        skillCosts.Add(SkillType.SixStamps, 4);
        skillFunctions.Add(SkillType.SixStamps, SixStampsFunction);
        skillTexts.Add(SkillType.SixStamps, sixStampsText);

        unlockedSkills.Add(SkillType.BiggerDesk);
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
            cantBuyText.text = "Skill acquired!";
            playerSkills.Add(skill);
            skillPoints -= skillCosts[skill];
            skillFunctions[skill]();
            UnlockNewSkills(skill);
            UpdatePointsText();
            skillImages = FindObjectsOfType<Skill>();
            foreach (Skill skillImage in skillImages)
            {
                if (skillImage.skillType == skill)
                {
                    if (skill == SkillType.BiggerDesk)
                    {
                        skillImage.gameObject.GetComponent<Image>().sprite = deskGreen;
                    }
                    else if (skill == SkillType.Tape)
                    {
                        skillImage.gameObject.GetComponent<Image>().sprite = tapeGreen;
                    }
                    else if (skill == SkillType.NoFan)
                    {
                        skillImage.gameObject.GetComponent<Image>().sprite = noFanGreen;
                    }
                    else if (skill == SkillType.SmallerStamp)
                    {
                        skillImage.gameObject.GetComponent<Image>().sprite = smallStampGreen;
                    }
                    else if (skill == SkillType.SpeedProcess)
                    {
                        skillImage.gameObject.GetComponent<Image>().sprite = speedProcessGreen;
                    }
                    else if (skill == SkillType.SixStamps)
                    {
                        skillImage.gameObject.GetComponent<Image>().sprite = sixStampsGreen;
                    }
                }
            }

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
        skillImages = FindObjectsOfType<Skill>();
        if (skill == SkillType.BiggerDesk)
        {
            unlockedSkills.Add(SkillType.NoFan);
            unlockedSkills.Add(SkillType.SmallerStamp);
            foreach (Skill skillImage in skillImages)
            {
                if (skillImage.skillType == SkillType.NoFan || skillImage.skillType == SkillType.SmallerStamp)
                {
                    Image image = skillImage.gameObject.GetComponent<Image>();
                    image.color = new Color(image.color.r, image.color.g, image.color.b, 1f);
                }
            }
        }
        else if (skill == SkillType.NoFan)
        {
            if (!unlockedSkills.Contains(SkillType.SpeedProcess))
            {
                unlockedSkills.Add(SkillType.SpeedProcess);
            }
            unlockedSkills.Add(SkillType.Tape);
            foreach (Skill skillImage in skillImages)
            {
                if (skillImage.skillType == SkillType.SpeedProcess || skillImage.skillType == SkillType.Tape)
                {
                    Image image = skillImage.gameObject.GetComponent<Image>();
                    image.color = new Color(image.color.r, image.color.g, image.color.b, 1f);
                }
            }
        }
        else if (skill == SkillType.SmallerStamp)
        {
            if (!unlockedSkills.Contains(SkillType.SpeedProcess))
            {
                unlockedSkills.Add(SkillType.SpeedProcess);
            }
            unlockedSkills.Add(SkillType.SixStamps);
            foreach (Skill skillImage in skillImages)
            {
                if (skillImage.skillType == SkillType.SpeedProcess || skillImage.skillType == SkillType.SixStamps)
                {
                    Image image = skillImage.gameObject.GetComponent<Image>();
                    image.color = new Color(image.color.r, image.color.g, image.color.b, 1f);
                }
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
        timer.papersTapedDown = true;
    }

    void NoFanFunction()
    {
        stopFanButton.SetActive(true);
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

    void SpeedProcessFunction()
    {
        stampSystem.speedProcessingOn = true;
    }

    void SixStampsFunction()
    {
        Vector3 newScale = new Vector3(.6f, .6f, .6f);
        stampSystem.identifyButton.transform.localScale = newScale;
        stampSystem.introduceButton.transform.localScale = newScale;
        stampSystem.interestButton.transform.localScale = newScale;
        stampSystem.investButton.transform.localScale = newScale;
        stampSystem.informButton.transform.localScale = newScale;
        stampSystem.reInvestButton.transform.localScale = newScale;

        stampSystem.identifyButton.transform.localPosition = new Vector3(-281, -86, 0);
        stampSystem.identifyButton.GetComponentInChildren<Button>().gameObject.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
        stampSystem.identifyButton.GetComponentInChildren<Button>().gameObject.GetComponent<Draggable>().startingPos = stampSystem.identifyButton.GetComponentInChildren<Button>().gameObject.GetComponent<Draggable>().transform.position;

        stampSystem.introduceButton.transform.localPosition = new Vector3(-168, -86, 0);
        stampSystem.introduceButton.GetComponentInChildren<Button>().gameObject.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
        stampSystem.introduceButton.GetComponentInChildren<Button>().gameObject.GetComponent<Draggable>().startingPos = stampSystem.introduceButton.GetComponentInChildren<Button>().gameObject.GetComponent<Draggable>().transform.position;

        stampSystem.interestButton.transform.localPosition = new Vector3(-52, -86, 0);
        stampSystem.interestButton.GetComponentInChildren<Button>().gameObject.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
        stampSystem.interestButton.GetComponentInChildren<Button>().gameObject.GetComponent<Draggable>().startingPos = stampSystem.interestButton.GetComponentInChildren<Button>().gameObject.GetComponent<Draggable>().transform.position;

        stampSystem.investButton.transform.localPosition = new Vector3(63, -86, 0);
        stampSystem.investButton.GetComponentInChildren<Button>().gameObject.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
        stampSystem.investButton.GetComponentInChildren<Button>().gameObject.GetComponent<Draggable>().startingPos = stampSystem.investButton.GetComponentInChildren<Button>().gameObject.GetComponent<Draggable>().transform.position;

        stampSystem.informButton.transform.localPosition = new Vector3(177, -86, 0);
        stampSystem.informButton.GetComponentInChildren<Button>().gameObject.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
        stampSystem.informButton.GetComponentInChildren<Button>().gameObject.GetComponent<Draggable>().startingPos = stampSystem.informButton.GetComponentInChildren<Button>().gameObject.GetComponent<Draggable>().transform.position;

        stampSystem.reInvestButton.transform.localPosition = new Vector3(290, -86, 0);
        stampSystem.reInvestButton.GetComponentInChildren<Button>().gameObject.GetComponent<RectTransform>().anchoredPosition = Vector3.zero;
        stampSystem.reInvestButton.GetComponentInChildren<Button>().gameObject.GetComponent<Draggable>().startingPos = stampSystem.reInvestButton.GetComponentInChildren<Button>().gameObject.GetComponent<Draggable>().transform.position;

        stampSystem.sixStamps = true;
    }
}
