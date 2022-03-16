using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Enemy : MonoBehaviour
{
    public float speed;

    public int score = 0;

    public string scoreString="Score";

    public Text textScore;

    private Rigidbody2D rig;


    void Awake()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rig.velocity= transform.right*speed;

        Vector2 pos =transform.position;
        
        float sin = Mathf.Sin(pos.x);
        pos.y = sin;

        transform.position = pos; 
        
        if(textScore != null)
       {
           textScore.text = scoreString + score.ToString();
       }
    }

    //para que el enemigo muera al entrar con una colision
    void OnCollisionEnter2D(Collision2D collision)
    {
       this.gameObject.SetActive(false);

       score++;
      
    }
}

