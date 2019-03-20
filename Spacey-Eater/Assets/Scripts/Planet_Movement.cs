using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet_Movement : MonoBehaviour
{


    public float moveSpeed;
    private Vector3 moveDirection; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentPosition = transform.position;
        if (Input.GetButton("Fire1"))
        {
            //Debug.Log("mouse fired");
            Vector3 moveToward = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            moveDirection = moveToward - currentPosition;
            moveDirection.z = 0;
            moveDirection.Normalize(); 
        }
        Vector3 target = moveDirection * moveSpeed + currentPosition;
        transform.position = Vector3.Lerp(currentPosition, target, Time.deltaTime); 
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Hit " + other.gameObject);
        if (other.gameObject.tag == "GrowthPlanet")
        {
            transform.localScale += new Vector3((float)0.25, (float)0.25, 0) * Time.deltaTime;  
            Destroy(other.gameObject); 
        }
    }
}
