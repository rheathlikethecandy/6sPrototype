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
        min = 5;
        sec = 1;
    }

    // Update is called once per frame
    void Update()
    {
        sec -= Time.deltaTime;
        if (sec<=0)
        {
            sec = 60f;
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
