using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
using UnityEngine.UI;

//Draggable Turret UI
[RequireComponent(typeof(RectTransform))]
public class PregameTurretUI : MonoBehaviour, IDragHandler, IEndDragHandler, IDropHandler
{
    

    [Header("The PreTurretUI is the UI element script in which \n the player will select the turrets for the game")]
    public GameObject turretSelectBase; //the turretSelect gameobejct that's paired with this turretUI

    //the turretSelect componenet that's paired with this turretUI
    //[HideInInspector]public TurretSelect turretSelect;

    //this transform
    private RectTransform rectTransform;

    public Sprite turretType;

    [HideInInspector]public GameObject canvas;
    public GameObject scrollGroup; //The group of UI turrets 

    private Vector2 startPos;
    private Vector2 startScale;
    private bool isDroppedAndSelected = false;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();

        canvas = GameObject.Find("PreLevelCanvas");
        scrollGroup = GameObject.Find("TurretInventoryContent");

        startPos = this.transform.localPosition;
        startScale = this.transform.localScale;

    }

    
    public void OnDrag(PointerEventData eventData)
    {
        transform.SetParent(canvas.transform, false);

        transform.localScale = new Vector2(0.2f,0.2f);




        this.transform.position = eventData.position;

        
    }


    
    public void OnEndDrag(PointerEventData eventData)
    {
        //if (!isDroppedAndSelected)
        //{
        //    this.transform.SetParent(turretSelectBase.transform, false);



        //    this.transform.localPosition = startPos;
        //    this.transform.localScale = startScale;
        //}

        GameObject[] baseObjects = GameObject.FindGameObjectsWithTag("TurretSelectedForThisLevel");
        float minDistance = Mathf.Infinity;
        GameObject closestBaseObject = null;

        foreach (GameObject baseObject in baseObjects)
        {
            float distance = Vector2.Distance(transform.position, baseObject.transform.position);
            if (distance < minDistance)
            {
                minDistance = distance;
                closestBaseObject = baseObject;
            }
        }

        if (closestBaseObject != null && minDistance < 50)
        {
            closestBaseObject.GetComponent<PregameSelectedTurret>().turretType = turretType;
        }

        this.transform.SetParent(turretSelectBase.transform, false);
        this.transform.localPosition = startPos;
        this.transform.localScale = startScale;

    }


    // Update is called once per frame
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("On drop ran");
        if (eventData.pointerDrag.CompareTag("TurretSelectedForThisLevel"))
        {
            Debug.Log("On drop success");
            this.gameObject.SetActive(false);
           //eventData.pointerDrag.GetComponent<PregameSelectedTurret>().TurretType = turretType;
            isDroppedAndSelected = true;
        }

    }
}
