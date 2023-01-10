using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playerController : MonoBehaviour
{
    public float speed;
    float hAxis;
    float vAxis;
    bool jDown;
    bool isJump;

    Vector3 moveVec;

    Rigidbody rigid;
    Animator ani;

    GameObject director;
    GameObject pointText;
    int coinPoint = 0;
    public AudioClip appleSE;
    public AudioClip bombSE;
    public AudioClip coinSE;
    public AudioClip jumpSE;
    AudioSource aud;

    void OnTriggerEnter(Collider col) {

        if (col.gameObject.tag == "bomb") {
            this.aud.PlayOneShot(this.bombSE);
            Destroy(col.gameObject);
            director = GameObject.Find("GameDirector");
            director.GetComponent<GameDirector>().DecreaseHp();
        }

        if (col.gameObject.tag == "apple")
        {
            this.aud.PlayOneShot(this.appleSE);
            Destroy(col.gameObject);
            director = GameObject.Find("GameDirector");
            director.GetComponent<GameDirector>().IncreaseHp();

        }

        if (col.gameObject.tag == "coin")
        {
            this.coinPoint++;
            Debug.Log(coinPoint);
            this.aud.PlayOneShot(this.coinSE);
            GetComponent<ParticleSystem>().Play();
            director = GameObject.Find("GameDirector");
       //     this.director.GetComponent<GameDirector>().GetCoin();
            Destroy(col.gameObject);
            this.pointText.GetComponent<Text>().text = this.coinPoint.ToString("D") + " /28 Coin";
        }
        if (col.gameObject.tag == "goal" && this.coinPoint >= 20)
        {
            SceneManager.LoadScene("ClearScene");

        }

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            ani.SetBool("isJump", false);
            isJump = false;
        }

        if (collision.gameObject.tag == "tree")
        {
            director = GameObject.Find("GameDirector");
            director.GetComponent<GameDirector>().tree();
        }
        if (collision.gameObject.tag == "terrain")
        {
            SceneManager.LoadScene("FailScene");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        ani = GetComponentInChildren<Animator>();
        this.director = GameObject.Find("GameDirector");
        GetComponent<AudioSource>().Play();
        this.aud = GetComponent<AudioSource>();
        this.pointText = GameObject.Find("Coin");

    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        Move();
        Jump();
        transform.LookAt(transform.position + moveVec);

    }

    void GetInput() {
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");   //GetAxisRaw => axis값 정수로 반환
        jDown = Input.GetButtonDown("Jump");
    }

    void Move() {

        moveVec = new Vector3(hAxis, 0, vAxis).normalized; //normalized 방향 값 1로 보정 
        transform.position += moveVec * speed * Time.deltaTime;
        ani.SetBool("isRun", moveVec != Vector3.zero);
    }

    void Jump() {

        if (jDown && !isJump)
        {
            rigid.AddForce(Vector3.up * 15, ForceMode.Impulse);
            ani.SetBool("isJump", true);
            ani.SetTrigger("doJump");
            isJump = true;
            this.aud.PlayOneShot(this.jumpSE);
        }
    }


}
