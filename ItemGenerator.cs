using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{

    public GameObject applePrefab, bombPrefab;

    float span = 1f, delta;

    bool InstOver = false;

    void Update()
    {
        GameManager gm = GameObject.Find("GameManager").GetComponent<GameManager>();

        if (InstOver) return;

        if (gm.GameStart)
        {
            delta += Time.deltaTime;

            if (delta > span)
            {
                delta = 0;
                int r = Random.Range(0, 101);

                if (r <= 80) Instantiate(applePrefab);
                else Instantiate(bombPrefab);
            }
        }
    }

    public void InstOut()
    {
        InstOver = true;
    }
}
