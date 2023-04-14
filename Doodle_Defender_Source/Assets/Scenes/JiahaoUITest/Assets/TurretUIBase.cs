
using UnityEngine;
using UnityEngine.EventSystems;

//Draggable Turret UI
[RequireComponent(typeof(RectTransform))]
public class TurretUIBase : MonoBehaviour, IDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;

    public GameObject selectedType;
    public GameObject canvas;
    public GameObject scrollGroup; //The group of UI turrets 

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnDrag(PointerEventData eventData)
    {

        this.transform.SetParent(canvas.transform);

        this.transform.position = eventData.position;
        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!TurretPlacement())
        {
            this.transform.SetParent(scrollGroup.transform);
        }
    }


    // Update is called once per frame
    bool TurretPlacement()
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
                    Destroy(this.gameObject);
                    return true;
                }
                return false;
            }
            return false;
        }
        else
        {
            return false;
        }

    }
}
