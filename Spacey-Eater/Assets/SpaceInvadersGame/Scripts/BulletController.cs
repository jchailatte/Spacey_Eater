using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private Transform bullet;
    public GameObject explosion;
    public AudioSource _audioSource1;
    public AudioSource _audioSource2;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        bullet = GetComponent<Transform>();
        _audioSource1 = GetComponent<AudioSource>();
        _audioSource2 = GetComponent<AudioSource>();

        _audioSource1.Play();
        Debug.Log("Audio source played:");
    }

    // Update is called once per frame
    void Update()
    {
        bullet.position += Vector3.up * speed * Time.deltaTime;
        if (bullet.position.y >= 10)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collided with: " + other.gameObject);
        if (other.tag == "Enemy")
        {
            Instantiate(explosion, new Vector3(other.gameObject.transform.position.x, other.gameObject.transform.position.y, -7f), other.gameObject.transform.rotation);
            _audioSource2.Play();
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        else if (other.tag == "Base")
        {
            Destroy(gameObject);
        }
    }
}
