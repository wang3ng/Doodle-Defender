using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class turretButton : MonoBehaviour
{
    public int turretType;
    private bool selected = false;
    [SerializeField] GameObject _turret2;
    [SerializeField] GameObject _turret3;
    [SerializeField] GameObject _turret5;
    [SerializeField] Sprite buttonDefault;
    [SerializeField] Sprite buttonFinished;
    [SerializeField] TextMeshProUGUI amountTxt;
    [SerializeField] TextMeshProUGUI amountTxtShadow;

    private GameObject turret;
    public int amount = 0;

    // Start is called before the first frame update
    void Start()
    {
        _turret2.SetActive(false);
        _turret3.SetActive(false);
        _turret5.SetActive(false);

        if (turretType == 2)
        {
            _turret2.SetActive(true);
            turret = CursorManager.Instance.turret2;
        }else if (turretType == 3)
        {
            _turret3.SetActive(true);
            turret = CursorManager.Instance.turret3;
        } else if (turretType == 5)
        {
            _turret5.SetActive(true);
            turret = CursorManager.Instance.turret5;
        }

        if (amount <= 0)
        {
            this.GetComponent<Image>().sprite = buttonFinished;
            this.GetComponent<Toggle>().interactable = false;
        }


    }

    private void Update()
    {
        amountTxt.text = "x" + amount;
        amountTxtShadow.text = amountTxt.text;
    }


    public void onSelected()
    {
        if (amount > 0)
        {
            if (selected)
            {
                //this.GetComponent<Image>().sprite = buttonDefault; 
                selected = false;
                CursorManager.Instance.selectedType = null;
                
            }
            else
            {
                //this.GetComponent<Image>().sprite = buttonSelected;

                selected = true;
                CursorManager.Instance.selectedTurretButton = this.gameObject;
                
                CursorManager.Instance.selectedType = turret;
                
            }
        }
        else
        {
            selected = false;
            this.GetComponent<Image>().sprite = buttonFinished;
            //this.GetComponent<Toggle>().interactable = false;
        }

    }



}
