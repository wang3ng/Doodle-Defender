
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(RectTransform))]
public class TurretUI : MonoBehaviour, IDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    bool selected = false;
    bool dragging = false;
    float dragReleaseTimer = 0;
    bool destroying = false;
    public GameObject selectedType;
    public GameObject canvas;
    public GameObject scrollGroup;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        this.transform.SetParent(canvas.transform);
        //rectTransform.anchoredPosition += eventData.delta;
        this.transform.position = eventData.position;
        selected = true;
        dragging = true;
        
    }

    void Update()
    {
        if (selected)
        {
            if (!dragging)
            {
                dragReleaseTimer += Time.deltaTime;
            }
            if (dragReleaseTimer >= 1f)
            {
                selected = false;
                dragReleaseTimer = 0;
            }
        }

        if (destroying)
        {
            var xScale = this.transform.localScale.x;
            var yScale = this.transform.localScale.y;
            xScale -= 0.006f;
            yScale -= 0.006f;
            this.transform.localScale = new Vector3(xScale, yScale, 1);

            var zR = this.rectTransform.localRotation.eulerAngles.z;
            zR += 1f;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, zR));



            if (xScale <= 0.05)
            {
                Destroy(this.gameObject);
            }


        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        dragging = false;
        TurretPlacement();
        this.transform.SetParent(scrollGroup.transform);
    }


    void OnTriggerStay2D(Collider2D collision)
    {
        //Debug.Log("dragging:" + dragging + "selected: " + selected);

        //if (collision.gameObject.tag != "Topic" && selected && !dragging && !destroying)
        //{

        //    destroying = true;
        //    SoundManager.Instance.source.PlayOneShot(SoundManager.Instance.trash);
        //}

        
    }

    // Update is called once per frame
    void TurretPlacement()
    {


        //Turret placement
        //if (Input.GetMouseButtonDown(0))
        //{ // << use GetMouseButton instead of GetMouseButtonDown
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 500.0f))
            {

                if (hit.transform.CompareTag("turretBase"))
                {
                    if (hit.transform.gameObject.GetComponent<turretBase>().occupied == false)
                    {

                        var a = Instantiate(selectedType, hit.transform.position, transform.rotation);
                        //Decrease the amount of the turret in the inventory by 1, if 0, trigger it so it disables
                        hit.transform.gameObject.GetComponent<turretBase>().occupied = true;
                    Destroy(this.gameObject);

                    }
                }

            }
        //}
    }
}
