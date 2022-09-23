using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stamp : MonoBehaviour
{

    [SerializeField] StampSystem stampSystem;
    public bool isActive = false;
   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Donor")
        {
            gameObject.GetComponent<Button>().interactable = true;
            isActive = true;
        }  
    }

    void onTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "Donor")
        {
            gameObject.GetComponent<Button>().interactable = false;
            isActive = false;
        }
            
    }
}
