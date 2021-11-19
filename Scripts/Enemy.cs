using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public float health;
    public float speed;

    public GameObject bullet;
    public Transform shotPoint;

    private float TimeBtwShots;
    public float StartTimeBtwShots;

    Player player;

    private void Start()
    {
        player = FindObjectOfType<Player>();
    }

    private void Update()
    {
        if (health <= 0) 
        {
            Score.PlayerScore++;
            Destroy(gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (player.transform.position.x < transform.position.x)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }

        if (TimeBtwShots <= 0)
        {
            Instantiate(bullet, shotPoint.position, transform.rotation);
            TimeBtwShots = StartTimeBtwShots;
        }
        else
        {
            TimeBtwShots -= Time.deltaTime;
        }

        //transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }
}
