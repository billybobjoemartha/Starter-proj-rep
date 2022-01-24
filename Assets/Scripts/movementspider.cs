using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class movementspider : MonoBehaviour
{
    public float mspeed = 5f;
    public GameObject lossUI;
    public GameObject winUI;
    public Rigidbody2D rb;
    Vector2 movement;
    float clock = 12f;
    float soundtime = 2f;
    int throo = 0;
    int booo = 0;
    public AudioClip winner;
    public AudioClip backgroundm;
    public AudioClip dmuse;
    public AudioSource musicsource;
    int plhd = 1;
    soundScript callback;
    private SpriteRenderer character;
    private Color col;
    public ParticleSystem slime; 

    void Start()
    {
        ParticleSystem slime = GetComponentInChildren<ParticleSystem>();
        //slime.Stop();
        //slime.Play();
        character = GetComponent<SpriteRenderer>();
        col = character.color;
        musicsource.clip = backgroundm;
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        clock -= 1 * Time.deltaTime;
        soundtime -= 1 * Time.deltaTime;
        
        if(clock <= 10)
        {
        while(plhd <= 2)
        {
            musicsource.Play();
            plhd++;
        }
        }


        if(clock <=0)
        {
            winUI.SetActive(true);
            while(plhd <= 3){
            musicsource.clip = winner;
            musicsource.Play();
            plhd++;
            }
            booo = 3;
        }
        if(throo == 3)
        {
            clock += 1 * Time.deltaTime;
        }
    }

    public void Lose ()
    {
        if(booo == 0)
        {
        while(plhd <= 3){    
        col.a = 0;
        character.color = col;
        musicsource.clip = dmuse;
        musicsource.Play();
        //slime.Play();
        plhd++;
        }
        //Destroy(gameObject);
        lossUI.SetActive(true);
        throo = 3; 
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * mspeed * Time.fixedDeltaTime);
    }
}
