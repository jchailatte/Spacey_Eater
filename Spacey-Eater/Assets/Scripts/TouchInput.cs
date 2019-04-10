using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInput : MonoBehaviour
{
    public float changePerClick = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        bool supportsMultiTouch = Input.multiTouchEnabled;
        TimerController.didWin = false;
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
                Vector2 pos = touch.position;

                float width = (float)Screen.width / 2.0f;
                float height = (float)Screen.height / 2.0f;

                pos.x = (pos.x - width) / width;
                pos.y = (pos.y - height) / height;

                RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);

                if (touch.phase == TouchPhase.Began)
                {
                    Ray screenRay = Camera.main.ScreenPointToRay(touch.position);

                    if (hit.collider.gameObject.tag == "Enemy")
                    {
                        Debug.Log("User tapped on game object " + hit.collider.gameObject);
                        Vector3 temp = hit.collider.gameObject.transform.localScale;
                        if (hit.collider.gameObject.transform.localScale.x < changePerClick || hit.collider.gameObject.transform.localScale.y < changePerClick)
                        {
                            //if user destroys object before time runs out didWin is true
                            TimerController.didWin = true;
                            Debug.Log("didWin is True");
                        }
                        else
                        {
                            hit.collider.gameObject.transform.localScale -= new Vector3(changePerClick, changePerClick, 0f);
                            //hit.collider.gameObject.GetComponent<CircleCollider2D>().transform.localScale -= new Vector3(changePerClick, changePerClick, 0f);
                            //Debug.Log(hit.collider.GetComponent<CircleCollider2D>().transform.localScale);
                        }
                    }
                }
            }
        }
        else if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (hit.collider.gameObject.tag == "Enemy")
            {
                Debug.Log("User tapped on game object " + hit.collider.gameObject);
                Vector3 temp = hit.collider.gameObject.transform.localScale;
                if (hit.collider.gameObject.transform.localScale.x < changePerClick || hit.collider.gameObject.transform.localScale.y < changePerClick)
                {
                    TimerController.didWin = true;
                    Debug.Log("didWin is True");
                }
                else
                {
                    hit.collider.gameObject.transform.localScale -= new Vector3(changePerClick, changePerClick, 0f);
                    //hit.collider.gameObject.GetComponent<CircleCollider2D>().transform.localScale -= new Vector3(changePerClick, changePerClick, 0f);
                    //Debug.Log(hit.collider.GetComponent<CircleCollider2D>().transform.localScale);
                }
            }
        }
    }
}
