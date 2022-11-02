using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class Hover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] GameObject infoDisplay;
    [SerializeField] GameObject back;
    [SerializeField] GameObject ignored;
    // Start is called before the first frame update
    void Start()
    {
        Physics2D.IgnoreCollision(ignored.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        EnableInfo();
        Debug.Log("Enter");
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        DisableInfo();
        Debug.Log("Exit");
    }

    public void EnableInfo()
    {
        if (infoDisplay != null)
        {
            infoDisplay.SetActive(true);
            back.SetActive(true);
        }
    }

    public void DisableInfo()
    {
        if (infoDisplay != null)
        {
            infoDisplay.SetActive(false);
            back.SetActive(false);
        }
    }
}
