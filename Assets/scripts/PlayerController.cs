using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Boundary
{
    public float xMin, xMax, yMin, yMax;
}

public class PlayerController : MonoBehaviour
{
    [Header("Movimiento")]
    public float speed;
    public Boundary boundary;
    private Rigidbody2D rig;
    float moveHorizontal;
    float moveVertical;
    
    [Header("Disparos")]
    public GameObject shot;
    public Transform shotSpawn;
    public float shotRate;
    private float nextShot;
    public int shotType;

    // Start is called before the first frame update
    void Awake()
    {
        rig = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        if(Input.GetKey("p") && Time.time > nextShot)
        {
            nextShot= Time.time + shotRate;

            shot = PoolingController.instance.GetPoolObject(shotType);
            shot.transform.position = shotSpawn.position;
            shot.SetActive(true); 
            Debug.Log("has tocado la p");
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rig.velocity = movement * speed;
        rig.position = new Vector2(Mathf.Clamp(rig.position.x, boundary.xMin, boundary.xMax), Mathf.Clamp(rig.position.y, boundary.yMin, boundary.yMax));
    }
}
