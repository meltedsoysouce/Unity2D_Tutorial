using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public partial class Player
{
    public void CameraIn(Vector3 pvRightTop, Vector3 pvLeftBottom)
    {

    }

    public void CameraOut(Vector3 pvRightTop, Vector3 pvLeftBottom)
    {
        if (pvRightTop.y <= transform.position.y)
            transform.Translate(new() { x = 0, y = -0.5f, z = 0 });
        else if (pvRightTop.x <= transform.position.x)
            transform.Translate(new() { x = -0.5f, y = 0, z = 0 });
        else if (transform.position.y <= pvLeftBottom.y)
            transform.Translate(new() { x = 0, y = 0.5f, z = 0});
        else if (transform.position.x <= pvLeftBottom.x)
            transform.Translate(new() { x = 0.5f, y = 0, z = 0});
    }
}
