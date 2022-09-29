using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public int min = 5;
    public float sec = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        sec -= Time.deltaTime;
        if (sec<=0)
        {
            sec = 59f;
            min -= 1;
        }
        if (sec>9)
        {
            gameObject.GetComponent<TMP_Text>().text = min + ":" + (int)sec;
        }
        else
        {
            gameObject.GetComponent<TMP_Text>().text = min + ":0" + (int)sec;
        }

        

    }
}
