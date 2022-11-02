using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Filler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger triggered");
        if (other.GetComponent<Donor>() != null)
        {
            Debug.Log("collided with filler");
            other.GetComponent<Donor>().Spill();
            this.transform.parent.GetComponent<CoffeeScript>().Spill();
        }
    }
}
