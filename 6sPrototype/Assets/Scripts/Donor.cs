using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Donor : MonoBehaviour
{
    public StampSystem.StampType correctStamp;
    List<Color> colors = new List<Color>();
    public bool isStamped = false;
    public bool draggedOverFolder = false;
    [SerializeField] StampSystem stampSystem;
    [SerializeField] GameObject stampImage;
    [SerializeField] GameObject coloredSquare;

    
    // Start is called before the first frame update
    void Start()
    {
        colors.Add(Color.blue);
        colors.Add(Color.red);
        colors.Add(Color.black);
        colors.Add(Color.green);
        colors.Add(Color.yellow);

        SetCorrectStamp();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetCorrectStamp()
    {
        int randomNum = Random.Range(0, 5);
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

  


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Processing Folder" && isStamped)
        {
            draggedOverFolder = true;
            stampSystem.CheckStamp();
        }

    }

    void onTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Processing Folder")
        {
            draggedOverFolder = false;
        }
    }
}
