using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class CameraArea : MonoBehaviour
{
    private GameObject Camera { get; set; }
    private Vector3 RightTop { get; set; }
    private Vector3 LeftBottom { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        Camera = transform.parent.gameObject;
        Vector3 initVec = Camera.transform.position;
        initVec.z = 0;
        transform.position = new()
        {
            x = initVec.x,
            y = initVec.y,
            z = 0
        };
        var spriteRenderer = transform.GetComponent<SpriteRenderer>();
        RightTop = spriteRenderer.bounds.max;
        LeftBottom = spriteRenderer.bounds.min;
        gameObject.GetComponent<Collider2D>().isTrigger = true;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerExit2D(Collider2D pvCollision)
    {
        ExecuteEvents.Execute<ICameraEvent>(
            target: pvCollision.gameObject,
            eventData: null,
            functor: (cameraEvent, data) => cameraEvent.CameraOut(RightTop, LeftBottom));
    }

    private void OnTriggerEnter2D(Collider2D pvCollision)
    {
        ExecuteEvents.Execute<ICameraEvent>(
            target: pvCollision.gameObject,
            eventData: null,
            functor: (cameraEvent, data) => cameraEvent.CameraIn(RightTop, LeftBottom));
    }
}
