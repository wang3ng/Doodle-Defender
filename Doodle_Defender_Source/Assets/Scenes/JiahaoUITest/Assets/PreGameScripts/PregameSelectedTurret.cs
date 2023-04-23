using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using UnityEngine;
using UnityEngine.UI;

public class PregameSelectedTurret : MonoBehaviour
{
    public Sprite turretType;
    public Image turretImage;

    //public Sprite TurretType
    //{
    //    get { return turretType; }
    //    set
    //    {
    //        if (turretImage != null)
    //        {
    //            turretImage.enabled = true;
    //            // Perform action when value changes
    //            turretImage.sprite = turretType;

    //            // Set the new value
    //            turretType = value;
    //        }
    //        else
    //        {
    //            turretImage.enabled = false;
    //        }
    //    }
    //}


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(turretType != null)
        {
            turretImage.enabled = true;
            turretImage.sprite = turretType;
            turretImage.rectTransform.sizeDelta = new UnityEngine.Vector2(turretImage.sprite.rect.width, turretImage.sprite.rect.height);

        }
        else
        {
            turretImage.enabled = false;
            turretImage.sprite = null;
        }
    }
}
