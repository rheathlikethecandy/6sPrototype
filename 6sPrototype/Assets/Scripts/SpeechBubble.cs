using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SpeechBubble : MonoBehaviour
{
    [SerializeField] TMP_Text bubbleText;
    [SerializeField] Button nextButton;
    private string text1 = "Time to stamp! You can read all about the current donor on the paper                                     -------->";
    private string text2 = "After reading the info about the donor, choose which stamp you believe applies to the donor and drag it over to the donor.";
    private string text3 = "If you choose the 'Interest' stamp, you will then have to stamp again with a more specific label.";
    private string text4 = "After a donor is stamped, drag it into the processing folder. After it is processed, you will be able to see if your stamp was correct or not.";
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
    }

    public void ChangeToText3()
    {
        bubbleText.text = text3;
    }

    public void ChangeToText4()
    {
        bubbleText.text = text4;
        nextButton.gameObject.SetActive(false);
       // this.gameObject.SetActive(false);
    }


}
