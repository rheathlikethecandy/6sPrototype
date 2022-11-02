using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PhoneScript : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] List<GameObject> callable;
    [SerializeField] float speed = 5.0f;
    [SerializeField] float scale = 5.0f;
    private bool ringing = false;
    private IEnumerator ringer;
    // Start is called before the first frame update
    void Start()
    {
        ringer = Jitter();
        Debug.Log("ringer set");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Call()
    {
        StartCoroutine(ringer);
    }
    public void EndCall()
    {
        Debug.Log("STOP");
        if (ringing == true)
        {
            StopCoroutine(ringer);
            ringer = Jitter();
            ringing = false;
        }
        ResetJit();
    }

    IEnumerator Jitter()
    {
        ringing = true;
        float timePassed = 0;
        while (timePassed < 15)
        {
            CallJit();
            timePassed += Time.deltaTime;

            yield return null;
        }
        ringing = false;
    }
    public void CallJit()
    {
        foreach (GameObject element in callable)
        {
            element.transform.localPosition = (20 * (new Vector3(
                Mathf.PerlinNoise(speed * Time.time, Random.Range(0.0f,80.0f)),
                Mathf.PerlinNoise(speed * Time.time, Random.Range(0.0f, 80.0f)),
                Mathf.PerlinNoise(speed * Time.time, Random.Range(0.0f, 80.0f)))));
        }
    }
    public void ResetJit()
    {
        foreach (GameObject element in callable)
        {
            element.transform.localPosition = new Vector3(0,0,0);
        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("End CALL");
        EndCall();
    }
}
