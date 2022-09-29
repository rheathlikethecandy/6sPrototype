using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SpeechBubble : MonoBehaviour
{
    [SerializeField] TMP_Text bubbleText;
    [SerializeField] Button nextButton;
    [SerializeField] StampSystem stampSystem;
    private string text2 = "After reading the info about the donor, choose which stamp you believe applies to the donor and drag it over to the donor.";
    private string text3 = "If you choose the 'Interest' stamp, you will then have to stamp again with a more specific label.";
    private string text4 = "After a donor is stamped, drag it into the processing folder. Then you will be able to see if your stamp was correct or not.";

    public bool doneWithTutorial = false;
    // Start is called before the first frame update
    void Start()
    {
       nextButton.GetComponent<Button>().onClick.AddListener(delegate { ChangeToText2(); });

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeToText2()
    {
        bubbleText.text = text2;
        nextButton.GetComponent<Button>().onClick.AddListener(delegate { ChangeToText4(); });
        foreach (Button button in stampSystem.buttons)
        {
            button.gameObject.GetComponent<Draggable>().draggable = true;
        }
        nextButton.gameObject.SetActive(false);

    }

    public void ChangeToText3()
    {
        bubbleText.text = text3;
    }

    public void ChangeToText4()
    {
        bubbleText.text = text4;


    }

    private void DoneButton()
    {
        this.gameObject.SetActive(false);
    }


}
