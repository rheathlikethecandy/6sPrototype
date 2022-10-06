using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class Draggable : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
{
    public bool dragging;
    private Vector2 offset;

    public bool draggable = false;
    private Vector2 startingPos;

    [SerializeField] GameObject infoDisplay;
    [SerializeField] GameObject back;

    [SerializeField] StampSystem stampSystem;

    void Start()
    {
        stampSystem = GameObject.FindWithTag("Stamp System").GetComponent<StampSystem>();
        startingPos = transform.position;
        //stampSystem.ShowInitButtons();


    }

    public void Update()
    {
        if (dragging && draggable && Input.GetMouseButton(0))
        {
            if (gameObject.GetComponent<Donor>() != null)
            {
                if (gameObject.GetComponent<Donor>().onDesk == true)
                {
                    transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y) - offset;
                }
                else
                {
                    gameObject.GetComponent<Donor>().onDesk = true;
                    dragging = false;
                }
            
            }
            else
            {
                transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y) - offset;

            }
        }
        else if (draggable)
        {
            if (gameObject.GetComponent<Stamp>() != null)
            {
                if (!gameObject.GetComponent<Stamp>().isActive && Input.GetMouseButtonUp(0))
                {
                    ResetPosition();
                }
            }
            else if (gameObject.GetComponent<Donor>() != null)
            {
                if (!gameObject.GetComponent<Donor>().draggedOverFolder && Input.GetMouseButtonUp(0))
                {
                    //ResetPosition();
                }
            }
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        dragging = true;
        offset = eventData.position - new Vector2(transform.position.x, transform.position.y);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        dragging = false;
    }

    public void ResetPosition()
    {
        transform.position = startingPos;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        EnableInfo();
        Debug.Log("Mouse Over");
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        DisableInfo();
    }

    public void EnableInfo()
    {
        infoDisplay.SetActive(true);
        back.SetActive(true);
    }

    public void DisableInfo()
    {
        infoDisplay.SetActive(false);
        back.SetActive(false);
    }
}
