using System;
using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using Unity.Collections;
using UnityEngine.UI;
using Unity.VisualScripting;
using static UnityEngine.GraphicsBuffer;
using System.Security.Cryptography;

public class CardVisual : MonoBehaviour
{
    private bool initalize = false;

    [Header("Card")]
    public Card parentCard;
    private Transform cardTransform;
    private Vector3 rotationDelta;
    private int savedIndex;
    Vector3 movementDelta;

    [Header("References")]
    public Transform visualShadow;
    [SerializeField] private Transform tiltParent;
    [SerializeField] private Image cardImage;

    [Header("Follow Parameters")]
    [SerializeField] private float followSpeed = 30;

    [Header("Rotation Parameters")]
    [SerializeField] private float rotationAmount = 20;
    [SerializeField] private float rotationSpeed = 20;
    [SerializeField] private float autoTiltAmount = 30;
    [SerializeField] private float manualTiltAmount = 20;
    [SerializeField] private float tiltSpeed = 20;

    private float curveYOffset;


    // Start is called before the first frame update
    void Start()
    {
        cardTransform = parentCard.transform;
    }

    // Update is called once per frame
    void Update()
    {
        SmoothFollow();
        FollowRotation();
        //CardTilt();
    }

    private void SmoothFollow()
    {
        Vector3 verticalOffset = (Vector3.up * (parentCard.isDragging ? 0 : curveYOffset));
        transform.position = Vector3.Lerp(transform.position, cardTransform.position + verticalOffset, followSpeed * Time.deltaTime);
    }

    private void FollowRotation()
    {
        Vector3 movement = (transform.position - cardTransform.position);
        movementDelta = Vector3.Lerp(movementDelta, movement, 5 * Time.deltaTime);
        Vector3 movementRotation = (parentCard.isDragging ? movementDelta : movement) * rotationAmount;
        rotationDelta = Vector3.Lerp(rotationDelta, movementRotation, rotationSpeed * Time.deltaTime);
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, Mathf.Clamp(rotationDelta.x, -60, 60));
    }
    private void CardTilt()
    {
        savedIndex = parentCard.isDragging ? savedIndex : parentCard.ParentIndex();
        float sine = Mathf.Sin(Time.time + savedIndex) * (1);
        float cosine = Mathf.Cos(Time.time + savedIndex) * (1);

        Vector3 offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float tiltX = 0;
        float tiltY = 0;
        float tiltZ = tiltParent.eulerAngles.z;

        float lerpX = Mathf.LerpAngle(tiltParent.eulerAngles.x, tiltX + (sine * autoTiltAmount), tiltSpeed * Time.deltaTime);
        float lerpY = Mathf.LerpAngle(tiltParent.eulerAngles.y, tiltY + (cosine * autoTiltAmount), tiltSpeed * Time.deltaTime);
        float lerpZ = Mathf.LerpAngle(tiltParent.eulerAngles.z, tiltZ, tiltSpeed / 2 * Time.deltaTime);

        transform.eulerAngles = new Vector3(lerpX, lerpY, lerpZ);
    }
}
