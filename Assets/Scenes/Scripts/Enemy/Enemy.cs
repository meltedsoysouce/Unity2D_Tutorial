using UnityEngine;

public partial class Enemy : MonoBehaviour, ICameraEvent
{
    private Rigidbody2D Rigidbody { get; set; }
    private Transform Transform { get; set; }
    private Vector3 RightTop { get; set; }
    private Vector3 LeftBottom { get; set; }

    private float Height { get; set; }
    private float Width { get; set; }

    private bool IsCameraOut { get; set; } = false;

    // Start is called before the first frame update
    void Start()
    {
        Transform = transform;
        Transform.position = new() { x = 0.0f, y = 4.0f };
        Rigidbody = transform.GetComponent<Rigidbody2D>();
        var spriteRenderer = gameObject
                .GetComponent<SpriteRenderer>();
        RightTop = spriteRenderer.bounds.max;
        LeftBottom = spriteRenderer.bounds.min;
        Height = spriteRenderer.size.y;
        Width = spriteRenderer.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody.velocity = Transform.up.normalized * 5.0f;
        return;
    }
}
