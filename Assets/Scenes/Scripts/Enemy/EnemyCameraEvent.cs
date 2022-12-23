using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public partial class Enemy
{
    public void CameraOut(Vector3 pvRightTop, Vector3 pvLeftBottom)
    {
        if (IsCameraOut == true)
            return;

        IsCameraOut = true;
        var delta_z = GetRoatetAngler();
        Transform.Rotate(new() { x = 0f, y = 0f, z = delta_z });
    }

    public void CameraIn(Vector3 pvRightTop, Vector3 pvLeftBottom)
    {
        IsCameraOut = false;
    }

    /// <summary>
    /// 画面端に行った時の回転角を取得する
    /// </summary>
    /// <returns> float: 回転各</returns>
    private float GetRoatetAngler()
    {
        var delta = 135f;
        if (-90 <= transform.eulerAngles.z ||
            transform.eulerAngles.z <= 90)
            return -delta;
        else
            return delta;
    }
}
