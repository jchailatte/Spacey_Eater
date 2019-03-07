using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInput : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        bool supportsMultiTouch = Input.multiTouchEnabled;
        if (supportsMultiTouch)
        {
            Debug.Log("MultiTouchSupport enabled");
        }
        else
        {
            Debug.Log("MultiTouchSupport not enabled");
        }
    }

    // Update is called once per frame
    void Update()
    {
        int nbTouches = Input.touchCount;

        if (nbTouches > 0)
        {
            Debug.Log("Touch input registered");
            for (int i = 0; i < nbTouches; i++)
            {
                Touch touch = Input.GetTouch(i);

                if (touch.phase == TouchPhase.Began)
                {
                    Ray screenRay = Camera.main.ScreenPointToRay(touch.position);
                    RaycastHit hit;
                    if (Physics.Raycast(screenRay, out hit))
                    {
                        Debug.Log("User tapped on game object " + hit.collider.gameObject);
                        Vector3 temp = hit.collider.gameObject.transform.localScale;
                        hit.collider.gameObject.transform.localScale -= new Vector3(3f, 3f, 0);
                    }
                }
            }
        }
        else if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Mouse Input Registered");
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (hit.collider != null)
            {
                Debug.Log("User tapped on game object " + hit.collider.gameObject);
                Vector3 temp = hit.collider.gameObject.transform.localScale;
                Debug.Log(temp);
                hit.collider.gameObject.transform.localScale -= new Vector3(3f,3f,0);
            }
        }
    }
}
