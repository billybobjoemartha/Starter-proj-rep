using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class shoot : MonoBehaviour
{
    public Transform fp;
    public GameObject cannonB;
    public int testn = 2;
    public int num;
    float currentTime = 0f;
    float startingTime = 1f;
    float begin = 2f;
    float finale = 12f;
    public AudioClip boom;
    public AudioSource musicsource;

    void Start()
    {
        currentTime = startingTime;
    }


    void Update()
    {   
        finale -= 1 * Time.deltaTime;
        if(finale <= 0)
        {
            testn = 6;
        }
        begin -= 1 * Time.deltaTime;
        if(begin <= 0)
        {
        currentTime -= 1 * Time.deltaTime;
        if(currentTime <= 0)
        {
            RandomGenerate ();
            if(num == testn)
            {
            Shoot();
            }
            currentTime =startingTime;
        }
        }

        if(Input.GetKeyDown("r"))
        {
            SceneManager.LoadScene("SampleScene");
        }
    }

    public void RandomGenerate () {
        num = Random.Range(1, 4);
    }

    void Shoot ()
    {
        Instantiate(cannonB, fp.position, fp.rotation);
        musicsource.clip = boom;
        musicsource.Play();
    }
}
