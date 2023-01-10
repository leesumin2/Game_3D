using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackBallGenerator : MonoBehaviour
{
    public GameObject attackBallPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            GameObject ball = Instantiate(attackBallPrefab) as GameObject;
            //ball.GetComponent<attackController>().Shoot(new Vector3(0, 200, 2000));
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 worldDir = ray.direction;
            ball.GetComponent<attackController>().Shoot(worldDir.normalized * 5000);
        
        }   
    }
}
