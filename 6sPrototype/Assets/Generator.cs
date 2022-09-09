using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Manager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public class GenInfo
{
    private string gender;
    private string race;
    private int age;
    private string personality;
    private string likes;
    private string dislikes;
    private string pob;
    private string education;
    private string profession;
    private int maritalStatus;
    public string GetGender()
    {
        return gender;
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
    public void SetMarital(int inInt)
    {
        maritalStatus = inInt;
    }


    static void ParseFile()
    {
        string path = "Assets/test.txt";
        StreamReader reader = new StreamReader(path);
        reader.Close();
    }
}