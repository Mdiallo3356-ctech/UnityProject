using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Xml;
using UnityEngine.Networking;
public class ReadWeatherXML : MonoBehaviour
{
    string key = "08060df82cdd6790c6dff1349258c79e"; // key from openweathermap.org

    public string zip ="11237"; //

    string apiReturn = ""; //results for api stored

    public GameObject cloudEmitter; // for  clouds

    [Header("Values are written to")]
    public string cloudState;

    void Start()
    {
        StartCoroutine(GetWeather());
    }

    private void Update()
    {

       if ( apiReturn.Length <= 0)//nothing will show up until api return string is not empty
              return;
       else
       {
           if (apiReturn.IndexOf("clouds") !=-1)//Will return with info from string if api return is not empty 
           {
                  int pmStart=apiReturn.IndexOf("clouds");//pmStart and pmEnd is for storing and looking inside
                  int pmEnd=apiReturn.IndexOf("/clouds");//allows to select info from apireturn.index...

                  int theRightMode = apiReturn.IndexOf("mode", pmStart, pmEnd - pmStart);

                  int indexOfMode = theRightMode +6;

                  cloudState = apiReturn.Substring(indexOfMode, 1);
                  Debug.Log("returning a value");
           }

       }

       if(cloudState.Contains("c"))//if truethat the area has clouds, a "c" will appear
          cloudEmitter.SetActive(true);
    
    
    
    }
    IEnumerator GetWeather()
    {
        UnityWebRequest www = UnityWebRequest.
            Get("http://api.openweathermap.org/data/2.5/weather?zip=" + zip + "&mode=xml&APPID=" + key);
        yield return www.SendWebRequest();
         
        if (!www.isNetworkError && !www.isHttpError)
        {
            // Get text content like this:
            Debug.Log(www.downloadHandler.text);
            apiReturn = www.downloadHandler.text;
        }
        else
        {
            Debug.Log(www.error + " " + www);//shows if the is an error while requesting console log
        }
    }
}
