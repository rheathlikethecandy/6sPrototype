using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RoundReview : MonoBehaviour
{
    private int roundNum = 1;

    [SerializeField] TMP_Text roundCompleteText;
    [SerializeField] TMP_Text numCorrectText;
    [SerializeField] TMP_Text donor1Text;
    [SerializeField] TMP_Text donor2Text;
    [SerializeField] TMP_Text donor3Text;
    [SerializeField] TMP_Text donor4Text;
    [SerializeField] TMP_Text totalPoints;
    List<TMP_Text> donorTexts = new List<TMP_Text>();

    [SerializeField] StampSystem stampSystem;

    // Start is called before the first frame update
    void Start()
    {
        donorTexts.Add(donor1Text);
        donorTexts.Add(donor2Text);
        donorTexts.Add(donor3Text);
        donorTexts.Add(donor4Text);

        roundCompleteText.text = "Round " + roundNum + " Complete!";
        if (stampSystem.numDonorsCorrect != 1)
        {
            numCorrectText.text = "You got " + stampSystem.numDonorsCorrect + " profiles correct.";
        }
        else
        {
            numCorrectText.text = "You got " + stampSystem.numDonorsCorrect + " profile correct.";

        }
        totalPoints.text = "TOTAL POINTS: " + stampSystem.playerPoints;

        foreach (KeyValuePair<int, Dictionary<StampSystem.StampType, StampSystem.StampType>> finishedProfiles in stampSystem.finishedProfiles)
        {
            Dictionary<StampSystem.StampType, StampSystem.StampType> stampPairs = finishedProfiles.Value;
            foreach (KeyValuePair<StampSystem.StampType, StampSystem.StampType> stampPair in stampPairs)
            {
                int num = finishedProfiles.Key + 1;
                if (stampPair.Key == stampPair.Value)
                {
                    donorTexts[finishedProfiles.Key].text = "Donor " + num + " was correct.";
                }
                else
                {
                    donorTexts[finishedProfiles.Key].text = "Donor " + num + " was supposed to be " + stampPair.Key.ToString() + ".";
                }
            }
        }
    }

}
