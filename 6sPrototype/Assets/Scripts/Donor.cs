using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using TMPro;

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
    [SerializeField] GameObject text;
    [SerializeField] InfoDumper dumper;
    [SerializeField] GameObject splotch;

    public GameObject stampedImage;
    //holds generated info to be displayed
    private GenInfo info;

    private Vector2 initPos;

    public bool onDesk = true;

    // Start is called before the first frame update
    void Start()
    {
        initPos = transform.position;
        colors.Add(Color.blue);
        colors.Add(Color.red);
        colors.Add(Color.black);
        colors.Add(Color.green);
        colors.Add(Color.yellow);
        info = new GenInfo();
        dumper.SetText(info);
        SetCorrectStamp(info);
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<RectTransform>().localPosition.x < -300)
        {
            GetComponent<RectTransform>().localPosition = new Vector3(-300, GetComponent<RectTransform>().localPosition.y, GetComponent<RectTransform>().localPosition.z);
        }
        if (GetComponent<RectTransform>().localPosition.x > 367)
        {
            GetComponent<RectTransform>().localPosition = new Vector3(367, GetComponent<RectTransform>().localPosition.y, GetComponent<RectTransform>().localPosition.z);
            // transform.position.x = 367;
        }
        if (GetComponent<RectTransform>().localPosition.y < -114)
        {
            GetComponent<RectTransform>().localPosition = new Vector3(GetComponent<RectTransform>().localPosition.x, -114, GetComponent<RectTransform>().localPosition.z);
            // transform.position.y = -114;
        }
        if (GetComponent<RectTransform>().localPosition.y > 124)
        {
            GetComponent<RectTransform>().localPosition = new Vector3(GetComponent<RectTransform>().localPosition.x, 124, GetComponent<RectTransform>().localPosition.z);
            // transform.position.y = -114;
        }
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
        if (other.gameObject.tag == "Desk")
        {
            onDesk = true;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Processing Folder")
        {
            draggedOverFolder = false;
        }
        if (other.gameObject.tag == "Desk")
        {
            onDesk = false;
        }
    }

    public void ResetPos()
    {
        transform.position = initPos;
    }

    public void Spill()
    {
        StartCoroutine(Splotchy());
    }

    IEnumerator Splotchy()
    {
        float timePassed = 0;
        splotch.SetActive(true);
        while (timePassed < 8)
        {
            timePassed += Time.deltaTime;

            yield return null;
        }
        splotch.SetActive(false);
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
    private string maritalStatus;
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
    public string GetMarital()
    {
        return maritalStatus;
    }
    public void SetMarital(string inStr)
    {
        maritalStatus = inStr;
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
        gender = GetRandomLine(Resources.Load<TextAsset>("Text/gentext"));
        race = GetRandomLine(Resources.Load<TextAsset>("Text/racetext"));
        int fiftyFifty = (int)Random.Range(0, 2);
        if (fiftyFifty < 1)
        {
            age = 0;
        }
        else
        {
            age = ((int)(Random.Range(2.5f, 8.0f) * 10));
        }
        clothing = GetRandomLine(Resources.Load<TextAsset>("Text/clothtext"));
        personality = GetRandomLine(Resources.Load<TextAsset>("Text/pertext"));
        likes = GetRandomLine(Resources.Load<TextAsset>("Text/liketext"));
        dislikes = GetRandomLine(Resources.Load<TextAsset>("Text/distext"));
        pob = GetRandomLine(Resources.Load<TextAsset>("Text/pobtext"));
        education = GetRandomLine(Resources.Load<TextAsset>("Text/edtext"));
        profession = GetRandomLine(Resources.Load<TextAsset>("Text/protext"));
        history = GetRandomLine(Resources.Load<TextAsset>("Text/histext")); 
        int maritalStatusInt = (int)(Random.Range(0.0f, 10.0f));
        if (maritalStatusInt < 3)
        {
            maritalStatus = "Married";
        }
        else if (maritalStatusInt < 4)
        {
            maritalStatus = "Widowed";
        }
        else if (maritalStatusInt < 5)
        {
            maritalStatus = "Separated";
        }
        else if (maritalStatusInt < 7)
        {
            maritalStatus = "Divorced";
        }
        else
        {
            maritalStatus = "Single";
        }
        //Also need to see how this will be calculated, unsure at the moment
        interest = (int)(Random.Range(0.0f, 5.99f));
    }
    public string RandParseFile(string filePath)
    {
       // string path = Application.persistentDataPath + "\\" + filePath;
        StreamReader reader = new StreamReader(filePath);
        string text = "";
        int rand = (int)(Random.Range(0.0f, 1.0f) * 10f);
        for (int i = 0; i < rand; i++)
        {
            text = reader.ReadLine();
        }
        reader.Close();
        Debug.Log("Text: " + text);
        return text;
    }

    private string GetRandomLine(TextAsset file)
    {
        var lines = file.text.Split('\n');

        var randomIndex = Random.Range(0, lines.Length);

        return lines[randomIndex];
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