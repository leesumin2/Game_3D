using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackController : MonoBehaviour
{   public void Shoot(Vector3 dir) {
        GetComponent<Rigidbody>().AddForce(dir);
    }

    void OnCollisionEnter(Collision other) {
        GetComponent<Rigidbody>().isKinematic = true;
        if (other.gameObject.tag == "tree")
        {
            GetComponent<ParticleSystem>().Play();
            Destroy(other.gameObject);
            Destroy(gameObject, 1.0f);
        }
        else
        {
            Destroy(gameObject, 1.0f);
        }
    }
  

    // Start is called before the first frame update
    void Start()
    {
      //  Shoot(new Vector3(0, 200, 2000));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
