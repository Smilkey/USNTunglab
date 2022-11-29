using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Security.Policy;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopupDescription : MonoBehaviour
{

    //Declare variables
    public GameObject Popup;
    public GameObject TMP_Tagname;
    public GameObject TMP_Description;
    public string phpURL;

    //Declare TMP Text components
    TextMeshProUGUI TagnameText;
    TextMeshProUGUI DescriptionText;

    //Private variables
    private string url;

    // Start is called before the first frame update
    void Start()
    {
        //url = "http://127.0.0.1"
        Popup.SetActive(false);

        //Assign Popup tagname text and measurement text
        TagnameText = TMP_Tagname.GetComponent<TextMeshProUGUI>();
        DescriptionText = TMP_Description.GetComponent<TextMeshProUGUI>();
    }

    //Activate popup
    void OnTriggerEnter(Collider other)
    {
        Popup.SetActive(true);

        //Set the tagname text to the name of the instrument
        TagnameText.text = name;
        //Set the full url to php script
        url = phpURL + "?tagname=" + name + "&amount=1";
        //Collect latest instrument measurement based on the name of the instrument
        DescriptionText.text = GetMeasurementFromDatabase();
    }

    //deactivate Popup
    void OnTriggerExit(Collider other)
    {
        Popup.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {

    }

    private string GetMeasurementFromDatabase()
    {
        string response;
        using (WebClient client = new WebClient())
        {
            response = client.DownloadString(url);
        }
        string[] parts = response.Split(',');

        return parts[0];
    }
}
