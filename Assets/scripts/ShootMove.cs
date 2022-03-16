using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootMove : MonoBehaviour
{
    public float speed;


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
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
       this.gameObject.SetActive(false);
    }
}
