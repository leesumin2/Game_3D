using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{

    public float dropSpeed = -0.3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, this.dropSpeed);
        if (transform.position.z < -1.0f) {
            Destroy(gameObject);
        }
    }
}
