using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataSheet : MonoBehaviour
{
    //Declare variables
    [SerializeField] Image customImage;

    //Declare
    
    // Start is called before the first frame update
    void Start()
    {
        customImage.enabled = false;
    }

    //Activate picture
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            customImage.enabled = true;
        }
    }

    //Deactivate picture
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            customImage.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
