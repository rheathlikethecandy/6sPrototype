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
    private float min = 0f;
    private float max = 0f;
    void Start()
    {
        max = transform.rotation.eulerAngles.z + OsRange;
        min = max - (OsRange * 2);
    }

    // Update is called once per frame
    void Update()
    {
        //oscillate around z
        blowVec = Quaternion.Euler(0, 0, 180) * transform.up;
        this.transform.eulerAngles = new Vector3(this.transform.rotation.eulerAngles.x, this.transform.rotation.eulerAngles.y, (Mathf.PingPong(Time.time * 10, max - min) + min));
    }
    public void Blow()
    {
        //add force to gameobjects facing
        foreach (GameObject element in blowable)
        {
            element.GetComponent<Rigidbody2D>().AddForce(new Vector2(blowVec.x / 2, blowVec.y / 2));
        }
    }
}
