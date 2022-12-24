using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Unity.VisualScripting;
using System;
using UnityEngine.PlayerLoop;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System.Linq;
using TMPro.EditorUtilities;
using Unity.VisualScripting.Antlr3.Runtime.Tree;

public partial class Player : MonoBehaviour, ICameraEvent
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
        Vector2[] diff_vec = new Vector2[4];
        Rigidbody.velocity = new();

        if (Input.anyKey == true)
        {
            if (Input.GetKey(KeyCode.A))
                diff_vec[0] = new() { x = -5.0f, y = 0.0f };
            if (Input.GetKey(KeyCode.D))
                diff_vec[1] = new() { x = 5.0f, y = 0.0f };
            if (Input.GetKey(KeyCode.W))
                diff_vec[2] = new() { x = 0.0f, y = 5.0f };
            if (Input.GetKey(KeyCode.S))
                diff_vec[3] = new() { x = 0.0f, y = -5.0f };
            // Space‚Å’eŠÛ”­ŽË
            if (Input.GetKey(KeyCode.Space))
            {
                Bullet.SetActive(true);
                LaunchBullet();
            }

            Rigidbody.velocity += Sum_Diff(diff_vec);
        }
        else
            Rigidbody.velocity = new() { x = 0f, y = 0f };
    }

    private Vector2 Sum_Diff(Vector2[] pvDiffvec)
    {
        Vector2 result = new();
        foreach (var i in pvDiffvec)
            result += i;

        return result;
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
