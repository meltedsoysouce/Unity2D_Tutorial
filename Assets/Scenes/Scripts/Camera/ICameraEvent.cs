using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public interface ICameraEvent : IEventSystemHandler
{
    /// <summary>
    /// カメラ範囲害からの進入時
    /// </summary>
    void CameraIn(Vector3 pvRightTop, Vector3 pvLeftBottom);

    /// <summary>
    /// カメラ範囲内からの離脱時
    /// </summary>
    void CameraOut(Vector3 pvRightTop, Vector3 pvLeftBottom);
}
