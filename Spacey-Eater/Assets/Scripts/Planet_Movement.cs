using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Planet_Movement : MonoBehaviour
{


    public float moveSpeed;
    public float growthRate;
    public float minigameGrowthRate;
    private Vector3 moveDirection;
    private Vector3 currentSize;

    public  GameObject gPlanet;

    private int random;

    // Start is called before the first frame update
    void Start()
    {
        //Setting current size using prefs
        if (PlayerPrefs.HasKey("currentX") && PlayerPrefs.HasKey("currentY"))
        {
            currentSize = new Vector3(PlayerPrefs.GetFloat("currentX"), PlayerPrefs.GetFloat("currentY"), 1f);
            Debug.Log("current Size is " + currentSize);

            //Checking if player won the minigame
            if (PlayerPrefs.HasKey("didWin"))
            {

                Debug.Log(PlayerPrefs.GetInt("didWin"));

                //If player did win 
                if (PlayerPrefs.GetInt("didWin") == 1)
                {
                    currentSize += new Vector3(minigameGrowthRate, minigameGrowthRate, 1f);

                    CheckScoreForWin(currentSize);

                }

                //If player lost
                else if (PlayerPrefs.GetInt("didWin") == 0)
                {
                    currentSize -= new Vector3(minigameGrowthRate, minigameGrowthRate, 1f);

                    CheckScoreForWin(currentSize);
                }

                //If no decision/tie
                else if (PlayerPrefs.GetInt("didWin") == -1)
                {
                    //Do nothing
                }
            }
            Debug.Log("Current Size is now " + currentSize);

            //If a previous size has already been set, use that size, otherwise stay at original size
            if (currentSize != new Vector3(0f, 0f, 0f))
            {
                transform.localScale = currentSize;
                currentSize = new Vector3(0f, 0f, 0f);
            }
        }

        Debug.Log("New scale is " + transform.localScale);
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
            //if hitting growth planet, increase size of main planet
            Debug.Log(transform.localScale);
            transform.localScale += new Vector3(growthRate, growthRate, 0f);
           // gPlanet.GetComponent<>

            Debug.Log(transform.localScale);
            Destroy(other.gameObject);

            CheckScoreForWin(transform.localScale);
        }

        else if (other.gameObject.tag == "Enemy")
        {
            //Saving player progress before skill check
            Debug.Log("Local scale x is " + transform.localScale.x);
            Debug.Log("Local scale y is " + transform.localScale.y);
            PlayerPrefs.SetFloat("currentX", transform.localScale.x);
            PlayerPrefs.SetFloat("currentY", transform.localScale.y);

            Debug.Log("Start minigame");
            Invoke("LoadRandomMinigame", 0.1f);
        }

    }

    //Loading Random Minigame
    private void LoadRandomMinigame()
    {
        //Commenting to discard randomness during testing
        //int random = Random.Range(0, 3);
        random = PlayerPrefs.GetInt("random");
        Debug.Log("Random number is:" + random);

        if (random == 0)
        {
            PlayerPrefs.SetInt("random", random + 1);
            SceneManager.LoadScene("Minigame2Scene");
        }
        else if (random == 1)
        {
            PlayerPrefs.SetInt("random", random + 1);
            SceneManager.LoadScene("MagicSquareMini");
        }
        else if (random ==2)
        {
            PlayerPrefs.SetInt("random", random + 1);
            SceneManager.LoadScene("MatchFace");
        }
        else if (random == 3)
        {
            PlayerPrefs.SetInt("random", 0);
            SceneManager.LoadScene("Minigame1Scene");
        }
        else
        {
            Debug.Log("ERROR LOADING MINIGAME");
        }
    }

    //Check score for win
    private void CheckScoreForWin(Vector3 vector3)
    {
        if (currentSize.x > .21f)
        {
            SceneManager.LoadScene("Win");
        }
        else if (currentSize.x < 0.00f)
        {
            SceneManager.LoadScene("Lose");
        }
    }
}
