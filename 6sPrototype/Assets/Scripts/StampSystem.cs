using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StampSystem : MonoBehaviour
{

    public enum StampType 
    {
        Identify,
        Introduce, 
        Interest, 
        Invest, 
        Inform, 
        ReInvest
    }

    private StampType currentStamp;
    public StampType correctStamp;

    [SerializeField] GameObject identifyButton;
    [SerializeField] GameObject introduceButton;
    [SerializeField] GameObject interestButton;
    [SerializeField] GameObject investButton;
    [SerializeField] GameObject informButton;
    [SerializeField] GameObject reInvestButton;

    public List<Button> buttons = new List<Button>();

    [SerializeField] Donor donor1;
    [SerializeField] Donor donor2;
    [SerializeField] Donor donor3;
    [SerializeField] Donor donor4;
    public Donor currentDonor;
    [SerializeField] TMP_Text resultText;
    [SerializeField] TMP_Text points;
    [SerializeField] Button nextButton;

    [SerializeField] Sprite emptyFolderImage;
    [SerializeField] Sprite folderImage;
    [SerializeField] GameObject processingFolder;
    [SerializeField] SpeechBubble speechBubble;
    private int numDonorsComplete = 0;
    public int numDonorsCorrect = 0;

    public int playerPoints = 0;

    public bool interestButtonTutorialDone = false;


    public Dictionary<int,Dictionary<StampType, StampType>> finishedProfiles = new Dictionary<int, Dictionary<StampType, StampType>>();

    [SerializeField] Timer timer;
    [SerializeField] GameObject stampingScreen;
    [SerializeField] GameObject roundReviewScreen;

    // Start is called before the first frame update
    void Start()
    {
        PopulateButtonText();
        PopulateButtonClicked();
        correctStamp = currentDonor.correctStamp;

        nextButton.GetComponent<Button>().onClick.AddListener(delegate { PressNextButton(); });

        ShowInitButtons();


    }

    // Update is called once per frame
    void Update()
    {
        if (timer.min == -1 || numDonorsComplete==4)
        {
            RoundOver();
        }
    }

    void PopulateButtonClicked()
    {
        foreach (Button button in buttons)
        {
            button.GetComponent<Button>().onClick.AddListener(delegate { SetCurrentStamp(button); });
        }
    }

    void PopulateButtonText()
    {
        identifyButton.GetComponentInChildren<TMP_Text>().text = "Identify";
        introduceButton.GetComponentInChildren<TMP_Text>().text = "Introduce";
        interestButton.GetComponentInChildren<TMP_Text>().text = "Interest";
        investButton.GetComponentInChildren<TMP_Text>().text = "Invest";
        informButton.GetComponentInChildren<TMP_Text>().text = "Inform";
        reInvestButton.GetComponentInChildren<TMP_Text>().text = "Re-Invest";

        buttons.Add(identifyButton.GetComponentInChildren<Button>());
        buttons.Add(introduceButton.GetComponentInChildren<Button>());
        buttons.Add(interestButton.GetComponentInChildren<Button>());
        buttons.Add(investButton.GetComponentInChildren<Button>());
        buttons.Add(informButton.GetComponentInChildren<Button>());
        buttons.Add(reInvestButton.GetComponentInChildren<Button>());
    }

    public void CheckStamp()
    {
        if (currentStamp == correctStamp)
        {
            if (currentStamp != StampType.Interest)
            {
                playerPoints += 200;
                //resultText.text = "Correct!";
                Dictionary<StampType, StampType> stampPair = new Dictionary<StampType, StampType>();
                stampPair.Add(correctStamp, currentStamp);
                finishedProfiles.Add(numDonorsComplete, stampPair);
                numDonorsCorrect++;
                PressNextButton();
                numDonorsComplete++;
                if (numDonorsComplete == 1)
                {
                    processingFolder.GetComponent<Image>().sprite = folderImage;
                }
            }
        }
        else
        {
            playerPoints -= 100;
            //resultText.text = "Incorrect :(";
            Dictionary<StampType, StampType> stampPair = new Dictionary<StampType, StampType>();
            stampPair.Add(correctStamp, currentStamp);
            finishedProfiles.Add(numDonorsComplete, stampPair);
            PressNextButton();
            numDonorsComplete++;
            if (numDonorsComplete == 1)
            {
                processingFolder.GetComponent<Image>().sprite = folderImage;
            }
        }
        //points.text = "Points: " + playerPoints.ToString();
        currentDonor.gameObject.SetActive(false);
    }
    
    void ShowNextButton()
    {
        nextButton.gameObject.SetActive(true);
        HideAllButtons();
    }

    void PressNextButton()
    {
        //currentDonor.gameObject.SetActive(true);
        //currentDonor.gameObject.GetComponent<Draggable>().ResetPosition();
        currentDonor.isStamped = false;
        currentDonor.stampedImage.gameObject.SetActive(false);
        currentDonor.gameObject.GetComponent<Draggable>().draggable = false;
        resultText.text = "";
        nextButton.gameObject.SetActive(false);
        //currentDonor.SetCorrectStamp();
        ShowInitButtons();
        correctStamp = currentDonor.correctStamp;
        foreach (Button button in buttons)
        {
            button.gameObject.GetComponent<Draggable>().ResetPosition();
            button.interactable = false;
        }
    }

    void ShowInterestButtons()
    {
        identifyButton.gameObject.SetActive(false);
        introduceButton.gameObject.SetActive(false);
        interestButton.gameObject.SetActive(false);

        investButton.gameObject.SetActive(true);
        informButton.gameObject.SetActive(true);
        reInvestButton.gameObject.SetActive(true);
    }

    public void ShowInitButtons()
    {
        investButton.gameObject.SetActive(false);
        informButton.gameObject.SetActive(false);
        reInvestButton.gameObject.SetActive(false);

        identifyButton.gameObject.SetActive(true);
        introduceButton.gameObject.SetActive(true);
        interestButton.gameObject.SetActive(true);
    }

    void HideAllButtons()
    {
        identifyButton.gameObject.SetActive(false);
        introduceButton.gameObject.SetActive(false);
        interestButton.gameObject.SetActive(false);

        investButton.gameObject.SetActive(false);
        informButton.gameObject.SetActive(false);
        reInvestButton.gameObject.SetActive(false);
    }

    public void SetCurrentStamp(Button button)
    {
        if (button == identifyButton.GetComponentInChildren<Button>())
        {
            currentStamp = StampType.Identify;
        }
        else if (button == introduceButton.GetComponentInChildren<Button>())
        {
            currentStamp = StampType.Introduce;
        }
        else if (button == interestButton.GetComponentInChildren<Button>())
        {
            currentStamp = StampType.Interest;
        }
        else if (button == investButton.GetComponentInChildren<Button>())
        {
            if (!interestButtonTutorialDone)
            {
                interestButtonTutorialDone = true;
                speechBubble.ChangeToText4();
            }
            currentStamp = StampType.Invest;
        }
        else if (button == informButton.GetComponentInChildren<Button>())
        {
            if (!interestButtonTutorialDone)
            {
                interestButtonTutorialDone = true;
                speechBubble.ChangeToText4();
            }
            currentStamp = StampType.Inform;
        }
        else if (button == reInvestButton.GetComponentInChildren<Button>())
        {
             if (!interestButtonTutorialDone)
            {
                interestButtonTutorialDone = true;
                speechBubble.ChangeToText4();
            }
            currentStamp = StampType.ReInvest;
        }
        if (button != interestButton.GetComponentInChildren<Button>())
        {
            currentDonor.isStamped = true;
            currentDonor.stampedImage.gameObject.SetActive(true);
            button.gameObject.GetComponent<Draggable>().ResetPosition();
            currentDonor.gameObject.GetComponent<Draggable>().draggable = true;
            //currentDonor.gameObject.GetComponent<Draggable>().ResetPosition();
            if (speechBubble.gameObject.activeInHierarchy)
            {
                speechBubble.ChangeToText4();
            }
        }
        else if (button == interestButton.GetComponentInChildren<Button>())
        {
            ShowInterestButtons();
            if (!interestButtonTutorialDone)
            {
                speechBubble.ChangeToText3();
            }
        }
    }

    void RoundOver()
    {
        stampingScreen.gameObject.SetActive(false);
        roundReviewScreen.gameObject.SetActive(true);
    }

}
