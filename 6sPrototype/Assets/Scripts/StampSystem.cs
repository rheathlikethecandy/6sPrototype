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

    List<Button> buttons = new List<Button>();

    [SerializeField] Donor donor;
    [SerializeField] TMP_Text resultText;
    [SerializeField] TMP_Text points;
    [SerializeField] Button nextButton;

    public int playerPoints = 0;

    // Start is called before the first frame update
    void Start()
    {
        PopulateButtonText();
        PopulateButtonClicked();
        correctStamp = donor.correctStamp;

        nextButton.GetComponent<Button>().onClick.AddListener(delegate { PressNextButton(); });

        ShowInitButtons();

    }

    // Update is called once per frame
    void Update()
    {
     
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

    void CheckStamp()
    {
        if (currentStamp == correctStamp)
        {
            if (currentStamp != StampType.Interest)
            {
                playerPoints += 200;
                resultText.text = "Correct!";
                ShowNextButton();
            }
            else
            {
                ShowInterestButtons();
                donor.SetSecondCorrectStamp();
                correctStamp = donor.correctStamp;
            }
        }
        else
        {
            playerPoints -= 100;
            resultText.text = "Incorrect :(";
            ShowNextButton();
        }
        points.text = "Points: " + playerPoints.ToString();
    }
    
    void ShowNextButton()
    {
        nextButton.gameObject.SetActive(true);
        HideAllButtons();
    }

    void PressNextButton()
    {
        resultText.text = "";
        nextButton.gameObject.SetActive(false);
        donor.SetInitCorrectStamp();
        ShowInitButtons();
        correctStamp = donor.correctStamp;
        foreach (Button button in buttons)
        {
            button.gameObject.GetComponent<DraggableUI>().ResetPosition();
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

    void ShowInitButtons()
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

    void SetCurrentStamp(Button button)
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
            currentStamp = StampType.Invest;
        }
        else if (button == informButton.GetComponentInChildren<Button>())
        {
            currentStamp = StampType.Inform;
        }
        else if (button == reInvestButton.GetComponentInChildren<Button>())
        {
            currentStamp = StampType.ReInvest;
        }
        CheckStamp();
    }

}