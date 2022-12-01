using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MerkeskiltPopup : MonoBehaviour
{
    //Declare variables
    public GameObject merkeskiltPopup;
    public RawImage imgMerkeskilt;


    // Start is called before the first frame update
    void Start()
    {
        imgMerkeskilt.enabled = false;
    }

    //Show image
    void OnTriggerEnter(Collider other)
    {
        imgMerkeskilt.enabled = true;
    }

    //Hide image
    void OnTriggerExit(Collider other)
    {
        imgMerkeskilt.enabled = false;
    }
}
