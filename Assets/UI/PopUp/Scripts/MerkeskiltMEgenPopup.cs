using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MerkeskiltMEgenPopup : MonoBehaviour
{
    //Declare variables
    public GameObject merkeskiltMEgenPopup;
    public RawImage imgMerkeskiltMEgen;


    // Start is called before the first frame update
    void Start()
    {
        imgMerkeskiltMEgen.enabled = false;
    }

    //Show image
    void OnTriggerEnter(Collider other)
    {
        imgMerkeskiltMEgen.enabled = true;
    }

    //Hide image
    void OnTriggerExit(Collider other)
    {
        imgMerkeskiltMEgen.enabled = false;
    }
}
