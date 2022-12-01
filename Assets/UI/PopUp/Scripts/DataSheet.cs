using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataSheet : MonoBehaviour
{
    //Declare variables
    public GameObject imagePopup;
    public RawImage IMG_Datasheet1;


    // Start is called before the first frame update
    void Start()
    {
        IMG_Datasheet1.enabled = false;
    }

    //Show image
    void OnTriggerEnter(Collider other)
    {
        IMG_Datasheet1.enabled = true;
    }

    //Hide image
    void OnTriggerExit(Collider other)
    {
        IMG_Datasheet1.enabled = false;
    }

    // Update is called once per frame
    //void Update()
    //{
        
    //}
}
