using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Donor : MonoBehaviour
{
    public StampSystem.StampType correctStamp;
    List<Color> colors = new List<Color>();
    public bool isStamped = false;
    public bool draggedOverFolder = false;
    [SerializeField] StampSystem stampSystem;
    [SerializeField] GameObject stampImage;
    [SerializeField] GameObject coloredSquare;
    [SerializeField] GameObject speechBubble;
    //holds generated info to be displayed
    private GenInfo info;


    // Start is called before the first frame update
    void Start()
    {
        colors.Add(Color.blue);
        colors.Add(Color.red);
        colors.Add(Color.black);
        colors.Add(Color.green);
        colors.Add(Color.yellow);

        SetCorrectStamp(info);

    }

    // Update is called once per frame
    void Update()
    {

    }

    public GenInfo GetInfo()
    {
        return info;
    }

    public void SetInfo(GenInfo infoIn)
    {
        info = infoIn;
    }

    public void SetCorrectStamp()
    {
        int randomNum = Random.Range(0, 5);
        if (randomNum == 0)
        {
            correctStamp = StampSystem.StampType.Identify;
        }
        else if (randomNum == 1)
        {
            correctStamp = StampSystem.StampType.Introduce;
        }
        else if (randomNum == 2)
        {
            correctStamp = StampSystem.StampType.Invest;
        }
        else if (randomNum == 3)
        {
            correctStamp = StampSystem.StampType.Inform;
        }
        else if (randomNum == 4)
        {
            correctStamp = StampSystem.StampType.ReInvest;
        }


        int randomColorInt = Random.Range(0, 5);
        coloredSquare.GetComponent<Image>().color = colors[randomColorInt];

    }

    public void SetCorrectStamp(GenInfo infoIn)
    {
        if (infoIn.GetGender() == "" || infoIn.GetRace() == "" || infoIn.GetAge() == 0)
        {
            correctStamp = StampSystem.StampType.Identify;
        }
        else if (infoIn.GetHistory() == "")
        {
            correctStamp = StampSystem.StampType.Introduce;
        }
        else if (infoIn.GetInterest() == 0)
        {
            correctStamp = StampSystem.StampType.Interest;
        }
        else if (infoIn.GetInterest() > 3 && infoIn.GetHistory() == "")
        {
            correctStamp = StampSystem.StampType.Invest;
        }
        else if (infoIn.GetInterest() <= 3 && infoIn.GetHistory() != "")
        {
            correctStamp = StampSystem.StampType.Inform;
        }
        else if (infoIn.GetInterest() > 3 && infoIn.GetHistory() != "")
        {
            correctStamp = StampSystem.StampType.ReInvest;
        }
        /*
         * What's the fallback case for say a <3 interest no history donor? do they proceed to 2nd stage?
         */
        coloredSquare.GetComponent<Image>().color = colors[(int)Random.Range(0, 4)];

    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Processing Folder" && isStamped)
        {
            draggedOverFolder = true;
            stampSystem.CheckStamp();
            if (stampSystem.interestButtonTutorialDone)
            {
                speechBubble.SetActive(false);
            }
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Processing Folder")
        {
            draggedOverFolder = false;
        }
    }
}




//============================================================================================================================================
public class GenInfo
{
    private string gender;
    private string race;
    private int age;
    private string clothing;
    private string personality;
    private string likes;
    private string dislikes;
    private string pob;
    private string education;
    private string profession;
    private int maritalStatus;
    private int interest;
    private string history;
    public string GetGender()
    {
        return this.gender;
    }
    public void SetGender(string inStr)
    {
        gender = inStr;
    }
    public string GetRace()
    {
        return race;
    }
    public void SetRace(string inStr)
    {
        race = inStr;
    }
    public int GetAge()
    {
        return age;
    }
    public void SetAge(int inInt)
    {
        age = inInt;
    }
    public string GetClothing()
    {
        return clothing;
    }
    public void SetClothing(string inStr)
    {
        clothing = inStr;
    }
    public string GetPersonality()
    {
        return personality;
    }
    public void SetPersonality(string inStr)
    {
        personality = inStr;
    }
    public string GetLike()
    {
        return likes;
    }
    public void SetLike(string inStr)
    {
        likes = inStr;
    }
    public string GetDislike()
    {
        return dislikes;
    }
    public void SetDislike(string inStr)
    {
        dislikes = inStr;
    }
    public string GetPob()
    {
        return pob;
    }
    public void SetPob(string inStr)
    {
        pob = inStr;
    }
    public string GetEducation()
    {
        return education;
    }
    public void SetEducation(string inStr)
    {
        education = inStr;
    }
    public string GetProfession()
    {
        return profession;
    }
    public void SetProfession(string inStr)
    {
        profession = inStr;
    }
    public int GetMarital()
    {
        return maritalStatus;
    }
    public void SetMarital(string inStr)
    {
        maritalStatus = int.Parse("inInt");
    }

    public int GetInterest()
    {
        return interest;
    }
    public void SetInterest(int inInt)
    {
        interest = inInt;
    }

    public string GetHistory()
    {
        return history;
    }
    public void SetHistory(string inStr)
    {
        history = inStr;
    }

    public GenInfo()
    {
        gender = (RandParseFile("/text/gentext.txt"));
        race = (RandParseFile("/text/racetext.txt"));
        int fiftyFifty = (int)Random.Range(0, 2);
        if (fiftyFifty < 1)
        {
            age = 0;
        }
        else
        {
            age = ((int)(Random.Range(2.5f, 8.0f) * 10));
        }
        clothing = (RandParseFile("/text/clothtext.txt"));
        personality = (RandParseFile("/text/pertext.txt"));
        likes = (RandParseFile("/text/liketext.txt"));
        dislikes = (RandParseFile("/text/distext.txt"));
        pob = (RandParseFile("/text/pobtext.txt"));
        education = (RandParseFile("/text/edtext.txt"));
        profession = (RandParseFile("/text/protext.txt"));
        history = (RandParseFile("/text/histext.txt"));
        maritalStatus = (int)(Random.Range(0.0f, 5.99f));
        interest = (int)(Random.Range(0.0f, 5.99f));
    }
    public string RandParseFile(string filePath)
    {
        string path = Application.persistentDataPath + filePath;
        StreamReader reader = new StreamReader(path);
        string text = "";
        int rand = (int)(Random.Range(0.0f, 1.0f) * 10f);
        for (int i = 0; i < rand; i++)
        {
            text = reader.ReadLine();
        }
        reader.Close();
        return text;
    }
    public string ParseFile(string filePath, int offSet)
    {
        string path = Application.persistentDataPath + filePath;
        StreamReader reader = new StreamReader(path);
        string text = "";
        for (int i = 0; i < offSet; i++)
        {
            text = reader.ReadLine();
        }
        reader.Close();
        return text;
    }
}