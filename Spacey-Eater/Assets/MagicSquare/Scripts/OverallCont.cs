using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OverallCont : MonoBehaviour
{

    int[] squarevalues = new int[9];
    int[] solution = new int[9];

    Dropdown[] canvasComponents;
    // Start is called before the first frame update
    void Start()
    {
        int random = Random.Range(0, 5);


        squarevalues = getRandomValues(random);
        solution = getSolution(random);

        canvasComponents = GetComponentsInChildren<Dropdown>();
        for(int i=0; i<9; i++)
        {
            //Debug.Log(canvasComponents[i].value);
            canvasComponents[i].value = squarevalues[i];
            if(squarevalues[i] != 0)
            {
                canvasComponents[i].interactable = false;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    int[] getRandomValues(int index)
    {
        //squares go left to right up to down
        int[] list1 = new int[9] { 0, 0, 8, 9, 0, 1, 0, 7, 0 };
        int[] list2 = new int[9] { 0, 9, 0, 3, 0, 0, 8, 0, 6 };
        int[] list3 = new int[9] { 0, 0, 6, 3, 0, 7, 0, 0, 2 };
        int[] list4 = new int[9] { 0, 0, 4, 0, 0, 3, 6, 0, 8 };
        int[] list5 = new int[9] { 0, 7, 0, 9, 0, 1, 4, 0, 0 };

        int[][] lists = new int[][] { list1, list2, list3, list4, list5 };
        return lists[index];
    }

    int[] getSolution(int index)
    {
        //squares go left to right up to down
        int[] list1 = new int[9] { 4, 3, 8, 9, 5, 1, 2, 7, 6 };
        int[] list2 = new int[9] { 4, 9, 2, 3, 5, 7, 8, 1, 6 };
        int[] list3 = new int[9] { 8, 1, 6, 3, 5, 7, 4, 8, 2 };
        int[] list4 = new int[9] { 2, 9, 4, 7, 5, 3, 6, 1, 8 };
        int[] list5 = new int[9] { 2, 7, 6, 9, 5, 1, 4, 3, 8 };

        int[][] lists = new int[][] { list1, list2, list3, list4, list5};
        return lists[index];
    }

    public void checkAnswer()
    {
        Debug.Log("Within checkAnswer");
        bool flag = true;

        for(int i=0; i<9; i++)
        {
            if (canvasComponents[i].value != solution[i])
            {
                flag = false;
            }
        }

        if(flag)
        {
            Debug.Log("CORRECT");
        }
    }
}
