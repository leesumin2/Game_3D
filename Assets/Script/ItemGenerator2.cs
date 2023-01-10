using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator2 : MonoBehaviour
{
    public GameObject applePrefab;
    public GameObject bombPrefab;

    float span = 2.0f;
    float delta = 0;
    int ratio = 2;

    float speed = -0.03f;

    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    public void SetParameter(float span, float speed, int ratio)
    {
        this.span = span;
        this.speed = speed;
        this.ratio = ratio;

    }

    // Update is called once per frame
    void Update()
    {

        this.delta += Time.deltaTime;
        if (this.delta > this.span)
        {
            this.delta = 0;
            GameObject item;
            int dice = Random.Range(1, 11); // 1~ 10±îÁö °ª ¹ÝÈ¯..
            if (dice <= this.ratio)
            {
                item = Instantiate(bombPrefab) as GameObject; //20% È®·ü
            }
            else
            {  //80% È®·ü
                item = Instantiate(applePrefab) as GameObject;
            }

            float x = Random.Range(-3, 3);

            item.transform.position = new Vector3(x, 13, 16);
            item.GetComponent<ItemController>().dropSpeed = this.speed;
        }

    }
}
