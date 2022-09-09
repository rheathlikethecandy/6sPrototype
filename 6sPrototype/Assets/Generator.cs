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
    public static string GetGender()
    {
        return gender;
    }
    public void SetGender(string inStr)
    {
        gender = inStr;
    }
    public static string GetRace()
    {
        return race;
    }
    public void SetRace(string inStr)
    {
        race = inStr;
    }
    public static int GetAge()
    {
        return age;
    }
    public void SetAge(string inStr)
    {
        age = int.Parse("inInt");
    }
    public static string GetPersonality()
    {
        return personality;
    }
    public void SetPersonality(string inStr)
    {
        personality = inStr;
    }
    public static string GetLike()
    {
        return likes;
    }
    public void SetLike(string inStr)
    {
        likes = inStr;
    }
    public static string GetDislike()
    {
        return dislikes;
    }
    public void SetDislike(string inStr)
    {
        dislikes = inStr;
    }
    public static string GetPob()
    {
        return pob;
    }
    public void SetPob(string inStr)
    {
        pob = inStr;
    }
    public static string GetEducation()
    {
        return education;
    }
    public void SetEducation(string inStr)
    {
        education = inStr;
    }
    public static string GetProfession()
    {
        return profession;
    }
    public void SetProfession(string inStr)
    {
        profession = inStr;
    }
    public static int GetMarital()
    {
        return maritalStatus;
    }
    public void SetMarital(string inStr)
    {
        maritalStatus = int.Parse("inInt");
    }

    public GenInfo NewDonor()
    {
        GenInfo gen = new GenInfo();
        gen.SetGender(RandParseFile("/text.txt"));
        gen.SetRace(RandParseFile("/text.txt"));
        gen.SetAge(RandParseFile("/text.txt"));
        gen.SetPersonality(RandParseFile("/text.txt"));
        gen.SetLike(RandParseFile("/text.txt"));
        gen.SetDislike(RandParseFile("/text.txt"));
        gen.SetPob(RandParseFile("/text.txt"));
        gen.SetEducation(RandParseFile("/text.txt"));
        gen.SetProfession(RandParseFile("/text.txt"));
        gen.SetMarital(RandParseFile("/text.txt"));
        return gen;
    }
    public string RandParseFile(string filePath)
    {
        string path = Application.persistentDataPath + filePath;
        StreamReader reader = new StreamReader(path);
        string text = "";
        int rand = (int)(Random.Range(0.0f, 1.0f) * 10f);
        for(int i = 0; i < rand; i++)
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