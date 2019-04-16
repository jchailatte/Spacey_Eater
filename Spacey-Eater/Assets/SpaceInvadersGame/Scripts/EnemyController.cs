using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    private Transform enemyHolder;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        TimerController.didWin = false;
        enemyHolder = GetComponent<Transform>();
        InvokeRepeating("MoveEnemy", 0.01f, 0.03f);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void MoveEnemy()
    {
        enemyHolder.position += Vector3.right * speed * Time.deltaTime;
        foreach (Transform enemy in enemyHolder)
        {
            if (enemy.position.x < -10.5 || enemy.position.x > 10.5)
            {
                speed = -speed;
                return;
            }
        }
        Debug.Log(enemyHolder.childCount);
        if (enemyHolder.childCount == 0)
        {
            TimerController.didWin = true;
            PlayerPrefs.SetInt("didWin", 1);
            //win game return to main game
            Debug.Log("Win Game");
            SceneManager.LoadScene("Game"); 

        }
    }
}
