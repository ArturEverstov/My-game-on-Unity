using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shoot : MonoBehaviour
{
    public TextMeshProUGUI TextUI;
    public int enemies = 2;
    public float force = 155f;
    public float fireRate = 5f;
    public float range = 1500f;
    public Transform bulletSpawn;
    public AudioClip shotSFX;
    public AudioSource audioSource;
    private float nextFire = 1f;

    public Camera _cam;

    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + 1f / fireRate;
            Shooting();
        }
    }

    void Shooting()
    {
        audioSource.PlayOneShot(shotSFX);
        RaycastHit hit;
        if (Physics.Raycast(_cam.transform.position,_cam.transform.forward,out hit,range))
        {
            if(hit.transform.gameObject.tag == "enemy")
            {
                Destroy(hit.transform.gameObject);
                enemies = enemies -1;
                TextUI.text = "Destroy all enemy forces (1/2)";
                if(enemies == 0)
                {
                    TextUI.text = "You Win!";
                }
            }           
        }
    }
}
