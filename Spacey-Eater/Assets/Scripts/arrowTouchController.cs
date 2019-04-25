using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowTouchController : MonoBehaviour
{
    public ArrowController arrowCon;
    private void OnMouseDown()
    {
        arrowCon.changeArrow();
    }
}
