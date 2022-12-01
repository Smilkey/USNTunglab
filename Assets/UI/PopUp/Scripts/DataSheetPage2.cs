using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataSheetPage2 : MonoBehaviour
{
    //Declare variables
    public GameObject imagePopup2;
    public RawImage IMG_Datasheet2;


    // Start is called before the first frame update
    void Start()
    {
        IMG_Datasheet2.enabled = false;
    }

    //Show image
    void OnTriggerEnter(Collider other)
    {
        IMG_Datasheet2.enabled = true;
    }

    //Hide image
    void OnTriggerExit(Collider other)
    {
        IMG_Datasheet2.enabled = false;
    }
}
