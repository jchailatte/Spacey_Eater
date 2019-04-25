using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.iOS;

//public class requestUserAccess : MonoBehaviour
//{
//    // Start is called before the first frame update
//    IEnumerator Start()
//    { 
//        findMicrophones();

//        yield return Application.RequestUserAuthorization(UserAuthorization.Microphone);
//        if (Application.HasUserAuthorization(UserAuthorization.Microphone))
//        {
//            Debug.Log("Microphone found");
//        }
//        else
//        {
//            Debug.Log("Microphone not found");
//        }
//    }

//    void findMicrophones()
//    {
//        foreach (var device in Microphone.devices)
//        {
//            Debug.Log("Name: " + device);
//        }
//    }

//}
