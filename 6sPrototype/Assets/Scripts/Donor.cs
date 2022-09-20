using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Donor : MonoBehaviour
{
    public StampSystem.StampType correctStamp;
    List<Color> colors = new List<Color>();
    // Start is called before the first frame update
    void Start()
    {
        colors.Add(Color.blue);
        colors.Add(Color.red);
        colors.Add(Color.black);
        colors.Add(Color.green);
        colors.Add(Color.yellow);

        SetInitCorrectStamp();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetInitCorrectStamp()
    {
        int randomNum = Random.Range(0, 3);
        if (randomNum ==  0)
        {
            correctStamp = StampSystem.StampType.Identify;
        }
        else if (randomNum == 1)
        {
            correctStamp = StampSystem.StampType.Introduce;
        }
        else if (randomNum == 2)
        {
            correctStamp = StampSystem.StampType.Interest;
        }
        int randomColorInt = Random.Range(0, 5);
        gameObject.GetComponent<Image>().color = colors[randomColorInt];
        
    }

    public void SetSecondCorrectStamp()
    {
        int randomNum = Random.Range(0, 3);
        if (randomNum == 0)
        {
            correctStamp = StampSystem.StampType.Invest;
        }
        else if (randomNum == 1)
        {
            correctStamp = StampSystem.StampType.Inform;
        }
        else if (randomNum == 2)
        {
            correctStamp = StampSystem.StampType.ReInvest;
        }
    }
}
