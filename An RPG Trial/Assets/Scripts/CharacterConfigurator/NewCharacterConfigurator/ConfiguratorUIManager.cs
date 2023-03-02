using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ConfiguratorUIManager : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerMoveHandler
{
    [SerializeField] private GameObject ModularCharacter;

    private bool isCharRotating;
    private Vector3 mouseInitialPos;
    private Vector3 mouseOffset;
    private float mouseDragSensitivity;
    private Vector3 charRotation;

    private void Start()
    {
        isCharRotating = false;
        mouseDragSensitivity = 0.4f;
    }

    private void Update()
    {
        if (isCharRotating)
        {
            mouseOffset = (Input.mousePosition - mouseInitialPos);
            charRotation.y = (mouseOffset.x + mouseOffset.y) * 0.5f;
            ModularCharacter.transform.Rotate(charRotation);
            mouseInitialPos = Input.mousePosition;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
        mouseInitialPos = Input.mousePosition;
        isCharRotating = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("OnPointerUp");

        isCharRotating = false;
    }

    public void OnPointerMove(PointerEventData eventData)
    {
        Debug.Log("OnPointerMove !isCharRotating");

        if (isCharRotating)
        {
            Debug.Log("OnPointerMove isCharRotating");
            mouseOffset = (Input.mousePosition - mouseInitialPos);
            charRotation.y = (mouseOffset.x + mouseOffset.y) * -mouseDragSensitivity;
            ModularCharacter.transform.Rotate(charRotation);
            mouseInitialPos = Input.mousePosition;
        }
    }

}
