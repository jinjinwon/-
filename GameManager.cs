using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    Text timeText, pointText, lastPointText;
    Image hp;

    public float time = 60f;
    public int point;

    public GameObject tbn, pbn,hp_bar;

    public bool tbn_bool = false;
    public bool pbn_bool = false;  
    public bool GameStart = false;
    bool Gameover = false;

    // Start is called before the first frame update
    void Start()
    {
        timeText= GameObject.Find("TimeText").GetComponent<Text>();
        pointText = GameObject.Find("PointText").GetComponent<Text>();
        lastPointText = GameObject.Find("LastPointText").GetComponent<Text>();
        hp = GameObject.Find("Hp").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Gameover) return;

        if (tbn_bool)
        {
            time -= Time.deltaTime;
            timeText.text = time.ToString("F2");
            pointText.text = point.ToString() + "POINT";
            GameStart = true;
            if (time <= 0f)
            {
                GameOver();             
            }
        }
        if(pbn_bool)
        {
            pointText.text = point.ToString() + "POINT";
            GameStart = true;
            if (hp.fillAmount == 0f)
            {
                GameOver();
            }
        }
    }

    public void GetApple()
    {
        point += 100;
    }
    
    public void GetBomb()
    {
        point /= 2;
    }

    public void LastPoint()
    {
        lastPointText.text = point.ToString() + "점 입니다.";
    }

    public void GameOver()
    {
        FindObjectOfType<ItemGenerator>().InstOut();
        FindObjectOfType<BasketController>().PlayOut();
        LastPoint();
        Gameover = true;       
    }

    public void OnClickTbn()
    {
        tbn.SetActive(false);
        pbn.SetActive(false);
        hp_bar.SetActive(false);
        tbn_bool = true;
    }
    public void OnClickPbn()
    {
        tbn.SetActive(false);
        pbn.SetActive(false);
        pbn_bool = true;
    }

    public void DesertHP()
    {
        hp.fillAmount -= 0.1f;           
    }
}
