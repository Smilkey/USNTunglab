using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Security.Policy;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopupMeasurement : MonoBehaviour
{
    //Declare variables
    public GameObject Popup;
    public GameObject TMP_Tagname;
    public GameObject TMP_Measurement;
    public string phpURL;

    //Declare TMP Text component
    TextMeshProUGUI TagnameText;
    TextMeshProUGUI MeasurementText;

    //Private variables
    private string url;
    private int measurementValue;
    private bool shouldPullData = false;
    private int internalCounter = 0;

    // Start is called before the first frame update
    void Start()
    {
        //url = "http://127.0.0.1"
        Popup.SetActive(false);

        //Assign Popup tagname text and measurement text
        TagnameText = TMP_Tagname.GetComponent<TextMeshProUGUI>();
        MeasurementText = TMP_Measurement.GetComponent<TextMeshProUGUI>();
    }

    //Activate popup
    void OnTriggerEnter(Collider other)
    {
        Popup.SetActive(true);
        shouldPullData = true;

        //Set the tagname text to the name of the instrument
        TagnameText.text = name;
        //Set the full url to php script
        url = phpURL + "?tagname=" + name + "&amount=1";
        //Collect latest instrument measurement based on the name of the instrument
        this.UpdateMeasurementText();
    }

    //deactivate Popup
    void OnTriggerExit(Collider other)
    {
        Popup.SetActive(false);
        shouldPullData = false;
    }


    // Update is called once per frame
    void Update()
    {
        if (!shouldPullData || String.IsNullOrEmpty(url) || TagnameText is null || MeasurementText is null)
        {
            return;
        }

        if (internalCounter <= 60*2)
        {
            internalCounter++;
            return;
        }
        else
        {
            this.UpdateMeasurementText();
            internalCounter = 0;
        }
    }

    // Set colors based on measurement alarm ranges
    private void UpdateMeasurementText()
    {
        measurementValue = Int32.Parse(GetMeasurementFromDatabase());
        MeasurementText.text = measurementValue + " °C";

        string tagName = TagnameText.text;

        if (tagName == "601-TE-106")
        {
            if (measurementValue > 75)
            {
                MeasurementText.color = new Color32(180, 37, 38, 255);
            }
            else if (measurementValue > 73 && measurementValue < 75)
            {
                MeasurementText.color = new Color32(231, 220, 10, 255);
            }
            else
            {
                MeasurementText.color = new Color32(58, 180, 37, 255);
            }
        }
        else
        {
            if (measurementValue > 100)
            {
                MeasurementText.color = new Color32(180, 37, 38, 255);
            }
            else if (measurementValue > 95 && measurementValue < 100)
            {
                MeasurementText.color = new Color32(231, 220, 10, 255);
            }
            else
            {
                MeasurementText.color = new Color32(58, 180, 37, 255);
            }
        }
            
    }

    private string GetMeasurementFromDatabase()
    {
        if (url is null)
        {
            return "0";
        }
        string response;
        using (WebClient client = new WebClient())
        {
            response = client.DownloadString(url);
        }
        string[] parts = response.Split(',');

        return parts[1];
    }
}
