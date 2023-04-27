using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
using UnityEngine.UI;

//Draggable Turret UI
[RequireComponent(typeof(RectTransform))]
public class TurretUI : MonoBehaviour, IDragHandler, IEndDragHandler
{
    

    [Header("The TurretUI is the UI element script in which \n the player will drag and drop to spawn an actual turret")]
    [Header("The TurretSelect controls the button in the turret \n inventory, in which the information of that turret type is stored.")]
    public GameObject turretSelectBase; //the turretSelect gameobejct that's paired with this turretUI

    //the turretSelect componenet that's paired with this turretUI
    [HideInInspector]public TurretSelect turretSelect;

    //this transform
    private RectTransform rectTransform;

    [HideInInspector]public GameObject selectedType;

    [HideInInspector]public GameObject canvas;
    [HideInInspector] public GameObject overlayCanvas;
    public GameObject scrollGroup; //The group of UI turrets 

    private Vector2 startPos;
    private Vector2 startScale;
    
    private void Start()
    {
        Debug.Log("this turret ui is working");
        rectTransform = GetComponent<RectTransform>();
        turretSelect = turretSelectBase.GetComponent<TurretSelect>();
        selectedType = turretSelect.turretPrefab;

        canvas = GameObject.Find("Canvas");
        overlayCanvas = GameObject.Find("OverlayCanvas");
        scrollGroup = GameObject.Find("TurretContent");

        startPos = this.transform.localPosition;
        startScale = this.transform.localScale;

    }

    
    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Ondrag");
        Vector3 pos = Camera.main.WorldToScreenPoint(this.transform.position);
        transform.SetParent(overlayCanvas.transform, false);
        transform.position = pos;

        transform.localScale = new Vector2(0.4f,0.4f);




        this.transform.position = eventData.position;

        
    }


    
    public void OnEndDrag(PointerEventData eventData)
    {
        TurretPlacement();
        this.transform.SetParent(turretSelectBase.transform,false);



        this.transform.localPosition = startPos;
        this.transform.localScale = startScale;
        
    }


    // Update is called once per frame
    void TurretPlacement()
    {
        //Placement of the turret
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //Cast raycast
        if (Physics.Raycast(ray, out hit, 500.0f))
        {
            //Check if hits turret Base
            if (hit.transform.CompareTag("turretBase"))
            {
                if (hit.transform.gameObject.GetComponent<turretBase>().occupied == false)
                {

                    //spawn a turret on the turret base
                    var a = Instantiate(selectedType, hit.transform.position, transform.rotation);
                    hit.transform.gameObject.GetComponent<turretBase>().occupied = true;

                    //Destroy the this UI element after a turret is placed down
                    //Destroy(this.gameObject);
                }
            }
        }

    }
}
