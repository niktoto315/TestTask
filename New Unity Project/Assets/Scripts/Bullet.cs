using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float lifetime;
    public float distance;
    public int damage;
    public LayerMask WhatIsSolid;
    private Vector2 vector;

    private void Start()
    {
        Invoke("DestroyBullet", lifetime);
        vector = Vector2.right;
    }

    private void Update()
    {
        RaycastHit2D HitInfo = Physics2D.Raycast(transform.position, transform.right, distance, WhatIsSolid);
        if(HitInfo.collider != null)
        {
            if (HitInfo.collider.CompareTag("Enemy"))
            {
                HitInfo.collider.GetComponent<Enemy>().TakeDamage(damage);
                DestroyBullet();
            }
            if (HitInfo.collider.CompareTag("Player"))
            {
                HitInfo.collider.GetComponent<Player>().TakeDamage(damage);
                DestroyBullet();
            }
            if (HitInfo.collider.CompareTag("Barrier"))
            {
                vector = Vector2.left;
            }
        }
        transform.Translate(vector * speed * Time.deltaTime);
    }

    private void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
