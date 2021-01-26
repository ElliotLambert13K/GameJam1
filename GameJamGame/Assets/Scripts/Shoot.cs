using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Shoot : MonoBehaviour
{
    public float fireRate = 0f;
    public float damage = 10f;
    public LayerMask whatToHit;
    private float timeToFireGun = 0f;
    public Transform firePoint;
    public bool motherDeath = false;
    public bool harambeDeath = false;
    public bool sonDeath = false;
    private float timeLeft = 10f;
    public GameObject timeRemainingUI;
    public AudioClip bulletSound;
    // Start is called before the first frame update
    void Start()
    {
        if (firePoint == null)
        {
            Debug.LogError("No Fire Point");
            timeRemainingUI = GameObject.Find("Timer");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (fireRate == 0)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                shootGun2();
                var audio = GetComponent<AudioSource>();
                audio.PlayOneShot(bulletSound);
            }
        }
        else if (Input.GetButton("Fire1") && Time.time > timeToFireGun)
        {
            timeToFireGun = Time.time + 1 / fireRate;
            shootGun2();
        }
        registerKills();


//        if (Input.GetButton("Fire2"))
//        {
//            Time.timeScale = 0.6f;
//            Debug.Log("Slowed TIme");
//        }
    }
    
    //void shootGun()
    //{
    //    Vector3 mousePosition = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, Camera.main.ScreenToWorldPoint(Input.mousePosition).z);
    //    Vector3 firePointPosition = new Vector3(firePoint.position.x, firePoint.position.y, firePoint.position.z);
    //    RaycastHit2D hit = Physics2D.Raycast(firePointPosition, mousePosition - firePointPosition, 100, whatToHit);
    //    
    //    if (hit.collider != null)
    //    {
    //        Debug.DrawLine(firePointPosition, hit.point, Color.red);
    //        Debug.Log("We hit " + hit.collider.name + " and did " + damage + " damage");
    //    }
    //}

    void shootGun2()
    {
        RaycastHit hit2;
        Physics.Raycast(firePoint.position, Camera.main.transform.TransformDirection(Vector3.forward), out hit2, Mathf.Infinity, whatToHit);

        if (hit2.collider != null)
        {
            Debug.DrawLine(firePoint.position, hit2.point, Color.red);
            Debug.Log("We hit " + hit2.collider.name + " and did " + damage + " damage");
            if (hit2.collider.tag == "Mother")
            {
                Debug.Log("Mother shot and killed");
                motherDeath = true;
            }
            else if (hit2.collider.tag == "Child")
            {
                Debug.Log("Son shot and killed");
                sonDeath = true;
            }
            else if (hit2.collider.tag == "Harambe")
            {
                Debug.Log("Harambe shot and killed");
                harambeDeath = true;
            }
        }
    }
    void registerKills()
    {
        timeLeft -= Time.deltaTime;
        //timeRemainingUI.gameObject.GetComponent<Text>().text = ("Time Left : " + (int)timeLeft);
        if (timeLeft < 0.1f)
        {
            if (harambeDeath == true && motherDeath == true && sonDeath == true)
            {
                SceneManager.LoadScene("AllDeath");
            }
            else if (harambeDeath == true && motherDeath == true && sonDeath == false)
            {
                SceneManager.LoadScene("MandHDeath");
            }
            else if (harambeDeath == true && motherDeath == false && sonDeath == true)
            {
                SceneManager.LoadScene("SandHDeath");
            }
            else if (harambeDeath == false && motherDeath == true && sonDeath == true)
            {
                SceneManager.LoadScene("MandSDeath");
            }
            else if (harambeDeath == true && motherDeath == false && sonDeath == false)
            {
                SceneManager.LoadScene("HarambeDeath");
            }
            else if (harambeDeath == false && motherDeath == true && sonDeath == false)
            {
                SceneManager.LoadScene("MotherDeath");
            }
            else if (harambeDeath == false && motherDeath == false && sonDeath == true)
            {
                SceneManager.LoadScene("SonDeath");
            }
            else
            {
                SceneManager.LoadScene("Passive");
            }

        }
    }
}
