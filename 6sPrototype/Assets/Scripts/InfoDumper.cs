using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class InfoDumper : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetText(GenInfo info)
    {
        string bigBlock = "Gender : " + info.GetGender() + 
                          "\nRace : " + info.GetRace() +
                          "\nAge : " + info.GetAge().ToString() +
                          "\nClothing : " + info.GetClothing() +
                          "\nPersonality : " + info.GetPersonality() +
                          "\nLikes : " + info.GetLike() +
                          "\nDislikes : " + info.GetDislike() +
                          "\nPlace of Birth : " + info.GetPob() +
                          "\nEducation : " + info.GetEducation() +
                          "\nProfession : " + info.GetProfession() +
                          "\nMarital Status : " + info.GetMarital() +
                          "\nInterest : " + info.GetInterest().ToString() +
                          "\nHistory : " + info.GetHistory();
        this.transform.GetComponent<TextMeshProUGUI>().SetText(bigBlock);

    }
}
