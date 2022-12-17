using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public int min = 5;
    public float sec = 0;
    public bool papersTapedDown;
    [SerializeField] GameObject fan;
    [SerializeField] GameObject phone;
    [SerializeField] GameObject coffee;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("DoRandom", 5.0f, 4.5f);
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
        if (!papersTapedDown && fan.activeInHierarchy)
        {
            fan.GetComponent<FanScript>().Blow();
        }    
    }

    public void DoPhone()
    {
        if (!papersTapedDown && phone.activeInHierarchy)
        {
            phone.GetComponent<PhoneScript>().Call();
        }
    }

    public void DoCoffee()
    {
       
        if (coffee.activeInHierarchy)
        {
            coffee.GetComponent<CoffeeScript>().Fill();
        }
        
    }
}
