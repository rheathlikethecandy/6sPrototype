using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public int min = 5;
    public float sec = 0;
    [SerializeField] GameObject fan;
    [SerializeField] GameObject phone;
    [SerializeField] GameObject coffee;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("DoRandom", 5.0f, 4.5f);
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

    public void DoRandom()
    {
        int randHazard = (int)Random.Range(0f, 2.999f);
        if (randHazard == 0)
        {
            DoFan();
        }
        else if (randHazard == 1)
        {
            DoPhone();
        }
        else
        {
            DoCoffee();
        }
    }

    public void DoFan()
    {
        Debug.Log("fan\n");
        fan.GetComponent<FanScript>().Blow();
    }

    public void DoPhone()
    {
        Debug.Log("phone\n");
        phone.GetComponent<PhoneScript>().Call();
    }

    public void DoCoffee()
    {
        Debug.Log("coffee\n");
        coffee.GetComponent<CoffeeScript>().Fill();
    }
}
