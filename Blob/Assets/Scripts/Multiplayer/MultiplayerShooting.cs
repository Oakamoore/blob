using Photon.Pun;
using Photon.Pun.UtilityScripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;
using UnityEngine.UI;

public class MultiplayerShooting : MonoBehaviour, IPunObservable
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

    public GameObject parent;

    PhotonView photonView;

    public Camera cam;
    Collider planeCollider;
    RaycastHit hit;
    Ray ray;

    void Awake()
    {
        photonView = GetComponent<PhotonView>();
    }

    void Start()
    {
        planeCollider = GameObject.Find("Ground").GetComponent<Collider>();
    }

    private void FixedUpdate()
    {

        if (!photonView.IsMine)
            return;

        //Ray going from the camera through the mouse cursor
        ray = cam.ScreenPointToRay(Input.mousePosition);

        //Checks if the ray has intersected the plane
        //Updates the position of the game object this script is attached to, to match the point of intersection
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider == planeCollider)
            {
                //When the right mouse button is held down
                if (Input.GetMouseButton(1))
                {
                    transform.position = Vector3.MoveTowards(transform.position, hit.point, Time.deltaTime * 5);
                }

                transform.LookAt(new Vector3(hit.point.x, transform.position.y, hit.point.z));
            }
        }

        if (Input.GetMouseButton(0))
            photonView.RPC("Fire", RpcTarget.AllViaServer);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            MultiplayerBulletController bullet = collision.gameObject.GetComponent<MultiplayerBulletController>();
            TakeDamage(bullet);
        }
    }

    void TakeDamage(MultiplayerBulletController bullet)
    {

        print("I've been hit! " + bullet.damage);
        print("My health is " + health);
        health -= bullet.damage;
        print("My health is now " + health);
        healthBar.value = health;
        if (health <= 0)
        {
            bullet.owner.AddScore(1);
            PlayerDied();
        }
    }

    void PlayerDied()
    {
        //parent.SetActive(false);
        health = 3;
        healthBar.value = health;
    }

    [PunRPC]
    void Fire()
    {
        if(Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;

            GameObject bullet = Instantiate(bulletPrefab, bulletPosition.position, Quaternion.identity);

            bullet.GetComponent<MultiplayerBulletController>()?.InitialiseBullet(transform.rotation * Vector3.forward, photonView.Owner);

            AudioManager.Instance.Play3D(playerShootingAudio, transform.position);
        }
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(health);
        }
        else
        {
            health = (int)stream.ReceiveNext();
            healthBar.value = health;
        }
    }

}
