using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] List<GameObject> blowable;
    [SerializeField] int blowForce;
    [SerializeField] float OsRange = 25f;
    [SerializeField] Vector3 blowVec;
    [SerializeField] AudioSource fanSFX;
    private float min = 0f;
    private float max = 0f;

    public bool isBlowing;
    private float blowTimer = 0f;

    void Start()
    {
        max = transform.rotation.eulerAngles.z + OsRange;
        min = max - (OsRange * 2);
    }

    // Update is called once per frame
    void Update()
    {   
        if (isBlowing)
        {
            //oscillate around z
            blowVec = Quaternion.Euler(0, 0, 180) * transform.up;
            this.transform.parent.eulerAngles = new Vector3(this.transform.rotation.eulerAngles.x, this.transform.rotation.eulerAngles.y, (Mathf.PingPong(Time.time * 10, max - min) + min));
            blowTimer += Time.deltaTime;
            if (blowTimer >= 5)
            {
                blowTimer = 0f;
                StopFan();
            }
        }
    }

    public void Blow()
    {
        fanSFX.Play();
        Debug.Log("BLOW");
        isBlowing = true;
        //add force to gameobjects facing
        blowVec.x = Random.Range(-2, 2);
        blowVec.y = Random.Range(-2, 2);
        foreach (GameObject element in blowable)
        {
            element.GetComponent<Rigidbody2D>().AddForce(new Vector2(blowVec.x / 2, blowVec.y / 2));
            
        }
    }

    public void StopFan()
    {
        fanSFX.Stop();
        foreach (GameObject element in blowable)
        {
            element.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            element.GetComponent<Rigidbody2D>().angularVelocity = 0;
        }
        isBlowing = false;
    }
}
