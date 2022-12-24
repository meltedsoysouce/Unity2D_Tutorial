using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public partial class Bullet : MonoBehaviour, IControlEvent
{
    private Rigidbody2D Rigidbody { get; set; }
    private Renderer Renderer { get; set; }    
    private GameObject Player { get; set; }

    private bool IsLaunched { get; set; } = false;

    // Start is called before the first frame update
    public void Start()
    {
        transform.position = new() { x = 0.0f, y = 2.0f };
        Rigidbody = transform.GetComponent<Rigidbody2D>();
        Renderer = GetComponent<Renderer>();
        Player = transform.parent.gameObject;
        Rigidbody.gravityScale = 0.0f;

        gameObject.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        if (IsLaunched == true &&
            Renderer.isVisible == false)
        {
            gameObject.SetActive(false);
            IsLaunched = false;
        }

        return;
    }

    public void LaunchBullet()
    {
        // 弾はとりあず一つ発射
        if (IsLaunched == false)
        {
            IsLaunched = true;
            transform.position = Player.transform.position;
            Rigidbody.velocity = new() { x = 0.0f, y = 7.0f };
        }

        return;
    }
}
