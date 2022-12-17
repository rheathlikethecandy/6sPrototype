using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeScript : MonoBehaviour
{
    [SerializeField] GameObject filler;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Fill()
    {
        filler.SetActive(true);
    }
    public void Spill()
    {
        filler.SetActive(false);
    }
}
