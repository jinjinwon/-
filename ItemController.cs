using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    public float dropSpeed;
    const float y =-0.003f;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(Random.Range(-1, 2), 3, Random.Range(-1, 2));
    }

    // Update is called once per frame
    void Update()
    {
        GameManager gm = GameObject.Find("GameManager").GetComponent<GameManager>();
       
            if (gm.tbn_bool)
            {
                if (gm.time > 40f && gm.time <= 60f) dropSpeed = y + -0.002f;
                else if (gm.time > 20f && gm.time <= 40f) dropSpeed = y + -0.01f;
                else if (gm.time > 0f && gm.time <= 20f) dropSpeed = y + -0.004f;
            }
            if (gm.pbn_bool)
            {
                if (gm.point == 0) dropSpeed = y + -0.005f;
                else if (gm.point >= 1000f) dropSpeed = y + -0.01f;
                else if (gm.point >= 2000f) dropSpeed = y + -0.02f;
            }

            transform.Translate(0, dropSpeed, 0);


            if (transform.position.y < -1f)
            {
                gm.DesertHP();
                Destroy(gameObject);
            }
        
    }

    
}
