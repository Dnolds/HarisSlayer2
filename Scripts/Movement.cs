using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    public GameObject[] Weapons;
   
  
    
  
    public Camera cam;
   public Rigidbody2D rg;
    public AudioSource audioWall;
    public AudioSource audioTable;
    public Slider TeleportTimer;
    public float speed = 3f;
    public float teleportTime = 10f;
    public float teleportTimer = 0f;
    float moveX;
    float moveY;
    public GameObject PauseMenu;
    bool isMac;
    // Start is called before the first frame update
    void Start()
    {
        teleportTimer = teleportTime;
        TeleportTimer.minValue = 0;
        TeleportTimer.maxValue = teleportTime;
    }

    // Update is called once per frame
    void Update()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");
        
        TeleportTimer.value = teleportTimer;
        Vector2 dir = transform.position - cam.ScreenToWorldPoint(Input.mousePosition);
        
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg +90f;
        rg.rotation = angle;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            PauseMenu.SetActive(true);
            
            
        }
        transform.position = transform.position + new Vector3(moveX*Time.deltaTime*speed, moveY*Time.deltaTime*speed, 0);
     //if (Input.GetKey("w"))
     //   {
     //       transform.position = transform.position + new Vector3(0, speed*Time.deltaTime, 0);
     //   }
     //   if (Input.GetKey("s"))
     //   {
     //       transform.position = transform.position + new Vector3(0, -speed * Time.deltaTime, 0);
     //   }
     //   if (Input.GetKey("a"))
     //   {
     //       transform.position = transform.position + new Vector3(-speed * Time.deltaTime, 0, 0);
     //   }
     //   if (Input.GetKey("d"))
     //   {
     //       transform.position = transform.position + new Vector3(speed * Time.deltaTime, 0, 0);
     //   }
        if (Input.GetKeyDown(KeyCode.Space) && teleportTimer <= 0)
        {
            Vector3 dir2 = (cam.ScreenToWorldPoint(Input.mousePosition) - transform.position);
            GameObject a = Instantiate(new GameObject(), transform.position, Quaternion.identity);
            a.transform.Translate(dir2);
            if(Physics2D.OverlapCircleAll(a.transform.position,0.1f).Length <= 0 )
            {
                Debug.Log("AAAHHH");
                transform.position = new Vector3(cam.ScreenToWorldPoint(Input.mousePosition).x,cam.ScreenToWorldPoint(Input.mousePosition).y);

                teleportTimer = teleportTime;
            }
            Destroy(a.gameObject);
            
        }
        teleportTimer -= Time.deltaTime * 4;
        GameObject activeWeapon = Weapons.FirstOrDefault(w => w.activeInHierarchy == true);
     
       
       
       
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        
       

    }
    private void OnCollisionExit2D(Collision2D collision)
    {
       
    }
    
   
    public void ChooseWeapon(int n)
    {
        int i = 0;
        foreach(var w in Weapons)
        {
            if(i == n)
            {
                w.SetActive(true);
             
            }
            else 
            { 
            w.SetActive(false);
            }
            i++;
        }
    }
}
