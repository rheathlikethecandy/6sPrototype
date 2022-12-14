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
        if (Input.GetMouseButtonUp(0) && isActive && gameObject.GetComponent<Draggable>().dragging)
        {
            stampSystem.SetCurrentStamp(gameObject.GetComponent<Button>());
            isActive = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.transform.parent.gameObject.tag == "Donor")
        {
            stampSystem.currentDonor = other.gameObject.transform.parent.gameObject.GetComponent<Donor>();
            gameObject.GetComponent<Button>().interactable = true;
            isActive = true;
        }  
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.transform.parent.gameObject.tag == "Donor")
        {
            gameObject.GetComponent<Button>().interactable = false;
            isActive = false;
        } 
    }
}
