using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.UI;

public class Shooting : MonoBehaviour
{

    Rigidbody rb;

    public float fireRate = 0.75f;
    public GameObject bulletPrefab;
    public Transform bulletPosition;
    float nextFire;

    public AudioClip playerShootingAudio;

    [HideInInspector]
    public int health = 3;
    public Slider healthBar;

    private void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
            Fire();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            BulletController bullet = collision.gameObject.GetComponent<BulletController>();
            TakeDamage(bullet.damage);
        }
    }

    void TakeDamage(int damage)
    {
        health -= damage;
        healthBar.value = health;
        if (health <= 0)
            PlayerDied();
    }

    void PlayerDied()
    {
        gameObject.SetActive(false);
    }

    void Fire()
    {
        if(Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;

            GameObject bullet = Instantiate(bulletPrefab, bulletPosition.position, Quaternion.identity);

            bullet.GetComponent<BulletController>()?.InitialiseBullet(transform.rotation * Vector3.forward);

            AudioManager.Instance.Play3D(playerShootingAudio, transform.position);
        }
    }

}
