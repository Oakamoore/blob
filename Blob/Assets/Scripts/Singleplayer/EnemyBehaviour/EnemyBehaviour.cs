using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyBehaviour : MonoBehaviour
{

    public float fireRate = 0.75f;
    public GameObject bulletPrefab;
    public Transform bulletPosition;
    float nextFire;

    public AudioClip playerShootingAudio;

    public Transform target;

    public NavMeshAgent enemy;
    public float aggroDistance = 10;

    [HideInInspector]
    public int health = 3;
    public Slider healthBar;

    public delegate void EnemyKilled();
    public static event EnemyKilled OnEnemyKilled;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            transform.LookAt(other.transform);
            Fire();
        }
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
            EnemyDied();
    }

    void EnemyDied()
    {
        gameObject.SetActive(false);

        if (OnEnemyKilled != null)
            OnEnemyKilled.Invoke();
    }

    void Fire()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;

            GameObject bullet = Instantiate(bulletPrefab, bulletPosition.position, Quaternion.identity);

            bullet.GetComponent<BulletController>()?.InitialiseBullet(transform.rotation * Vector3.forward);

            AudioManager.Instance.Play3D(playerShootingAudio, transform.position);
        }
    }

    private void Update()
    {
        MoveToTarget();
    }

    private void MoveToTarget()
    {
        enemy.SetDestination(target.position);

        enemy.isStopped = false;

        float distanceToTarget = Vector3.Distance(transform.position, target.position);

        //Enemy stops moving when they get too close to the player
        if(distanceToTarget <= enemy.stoppingDistance)
        {
            enemy.isStopped = true;
        }

        //Enemy stops moving when they get too far away from the player
        else if(!((distanceToTarget > enemy.stoppingDistance) && (distanceToTarget <= enemy.stoppingDistance + aggroDistance))){
            enemy.isStopped = true;
        }
    }

}
