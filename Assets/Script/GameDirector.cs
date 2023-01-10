using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour
{
    GameObject timerText;
    GameObject pointText;
    GameObject generator;
    GameObject hpGauge;
    float time = 50.0f;



    void Start()
    {
        this.generator = GameObject.Find("GameGenerator");
        this.timerText = GameObject.Find("Time");
        this.pointText = GameObject.Find("Coin");
        this.hpGauge = GameObject.Find("hpGauge");
    }


    public void DecreaseHp() {
        this.hpGauge.GetComponent<Image>().fillAmount -= 0.3f;
    }
    public void tree()
    {
        this.hpGauge.GetComponent<Image>().fillAmount -= 0.5f;
    }
    public void IncreaseHp()
    {
        this.hpGauge.GetComponent<Image>().fillAmount += 0.2f;
    }


    void Update()
    {
        this.time -= Time.deltaTime;

        if (this.time < 0)
        {
            this.time = 0;
            this.generator.GetComponent<ItemGenerator>().SetParameter(10000.0f, 0, 0);
            this.generator.GetComponent<ItemGenerator2>().SetParameter(10000.0f, 0, 0);
            SceneManager.LoadScene("FailScene");
        }
        else if (0 <= this.time && this.time < 5) { 
            this.generator.GetComponent<ItemGenerator>().SetParameter(0.5f, -0.06f, 6);
            this.generator.GetComponent<ItemGenerator2>().SetParameter(0.5f, -0.06f, 6);
        }
        else if (5 <= this.time && this.time < 15)
        {
            this.generator.GetComponent<ItemGenerator>().SetParameter(0.7f, -0.05f, 5);
            this.generator.GetComponent<ItemGenerator2>().SetParameter(0.7f, -0.05f, 5);
        }
        else if (15 <= this.time && this.time < 25)
        {
            this.generator.GetComponent <ItemGenerator> ().SetParameter(0.8f, -0.04f, 4);
            this.generator.GetComponent<ItemGenerator2>().SetParameter(0.8f, -0.04f, 4);
        }
        else if (25 <= this.time && this.time < 50)
        {
            this.generator.GetComponent<ItemGenerator>().SetParameter(1.0f, -0.03f, 3);
            this.generator.GetComponent<ItemGenerator2>().SetParameter(1.0f, -0.03f, 3);
        }

        this.timerText.GetComponent<Text>().text = this.time.ToString("F1");


        if (this.hpGauge.GetComponent<Image>().fillAmount == 0)
        {
            SceneManager.LoadScene("FailScene");
        }
        

    }
}
