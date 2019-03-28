using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropdownEvent : MonoBehaviour
{
    Dropdown mDropdown;
    
    // Start is called before the first frame update
    void Start()
    {
        mDropdown = GetComponent<Dropdown>();
        mDropdown.onValueChanged.AddListener(
            delegate { DropdownValueChanged(mDropdown); });

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DropdownValueChanged(Dropdown change)
    {
        Debug.Log("Change: " + change.value);
        transform.parent.gameObject.GetComponent<OverallCont>().checkAnswer();

    }
}
