using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public GameObject gameOverPanel;
    float count = 0;
    public Slider healthbar;
    public float health = 200;
    // Start is called before the first frame update
    void Start()
    {
        healthbar.maxValue = health;
    }

    // Update is called once per frame
    void Update()
    {
        count += Time.deltaTime;
        healthbar.value = health;
        if (health <= 0)
        {
            gameOverPanel.SetActive(true);
            healthbar.gameObject.SetActive(false);
            GameObject.Destroy(gameObject);
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (count >= 0.5f && collision.transform.tag == "Enemy")
        {
            health -= collision.transform.GetComponent<Health>().damage;
            count = 0;
        }

    }
}
