using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Unity.VisualScripting;
using System;
using UnityEngine.PlayerLoop;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Rigidbody2D Rigidbody { get; set; }
    private GameObject Bullet { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        this.transform.position = new() { x = 0.0f, y = 0.0f, z = 0.0f };
        Rigidbody = this.transform.GetComponent<Rigidbody2D>();
        Rigidbody.gravityScale = 0.0f;
        Bullet = transform.GetChild(0).gameObject;
    }


    // Update is called once per frame
    void Update()
    {
        MoveMySelf();
    }

    private void MoveMySelf()
    {
        if (Input.anyKey == true)
        {
            if (Input.GetKey(KeyCode.A))
                Rigidbody.velocity = new() { x = -5.0f, y = 0.0f };
            if (Input.GetKey(KeyCode.D))
                Rigidbody.velocity = new() { x = 5.0f, y = 0.0f };
            if (Input.GetKey(KeyCode.W))
                Rigidbody.velocity = new() { x = 0.0f, y = 5.0f };
            if (Input.GetKey(KeyCode.S))
                Rigidbody.velocity = new() { x = 0.0f, y = -5.0f };
            // Space‚Å’eŠÛ”­ŽË
            if (Input.GetKey(KeyCode.Space))
            {
                Bullet.SetActive(true);
                LaunchBullet();
            }

        }
        else
            Rigidbody.velocity = new() { x = 0f, y = 0f };
    }
    
    private void LaunchBullet()
    {
        Bullet.SetActive(true);
        ExecuteEvents.Execute<IControlEvent>(
            target: Bullet,
            eventData: null,
            functor: (controlEvent, data) => { controlEvent.LaunchBullet(); });
    }

    private enum EventType
    {
        None = -1,
        Launch,
    }

    private void OnTriggerEnter2D(Collider2D pvCollision)
    {
        switch (pvCollision.gameObject.tag)
        {
            case "Enemy":
                OnHitEnemy();
                return;
        }        
    }

    private void OnHitEnemy()
    {
        SceneManager.LoadScene("GameOver");
    }
}
