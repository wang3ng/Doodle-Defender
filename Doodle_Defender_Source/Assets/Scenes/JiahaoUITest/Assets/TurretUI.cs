using UnityEngine;
using UnityEngine.EventSystems;


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
    public GameObject scrollGroup; //The group of UI turrets 

    private Vector2 startPos;
    
    private void Start()
    {
        
        rectTransform = GetComponent<RectTransform>();
        turretSelect = turretSelectBase.GetComponent<TurretSelect>();
        selectedType = turretSelect.turretPrefab;

        canvas = GameObject.FindGameObjectWithTag("Canvas");
        scrollGroup = GameObject.Find("TurretContent");

        startPos = this.transform.localPosition;

    }

    
    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Ondrag");
        this.transform.SetParent(canvas.transform);

        this.transform.position = eventData.position;
        
    }


    
    public void OnEndDrag(PointerEventData eventData)
    {
        TurretPlacement();
        this.transform.SetParent(turretSelectBase.transform);
        this.transform.localPosition = startPos;
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
