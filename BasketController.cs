using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketController : MonoBehaviour
{
    public AudioClip appleSE, bombSE;
    AudioSource audio;

    bool playTime = false;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    public void PlayOut()
    {
        playTime = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        GameManager gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        
        if(other.tag == "Apple")
        {
            Debug.Log("사과");
            gm.GetApple();
            audio.PlayOneShot(appleSE);
        }
        else
        {
            Debug.Log("폭탄");
            gm.GetBomb();
            audio.PlayOneShot(bombSE);
            gm.DesertHP();
        }
        
        Destroy(other.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        GameManager gm = GameObject.Find("GameManager").GetComponent<GameManager>();

        if (playTime) return;

        if (gm.GameStart)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, Mathf.Infinity))
                {
                    float x = Mathf.RoundToInt(hit.point.x);
                    float z = Mathf.RoundToInt(hit.point.z);

                    transform.position = new Vector3(x, 0, z);
                }
            }
        }
    }
}
