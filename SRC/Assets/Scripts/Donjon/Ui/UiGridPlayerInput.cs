using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Donjon
{
    public static class UiGridPlayerInput
    {
        public static float DepthCam { get { return 10f; } }
        public static float DepthCam { get { return 10f; } }
        public static float DepthCam { get { return 10f; } }
        public static Point ConvertInputUIIntoPoint(Vector3 screenPosition)
        {
            screenPosition.z = detpthCam;
            var mainCamera = CameraManager.Cam;
            var worldPos = mainCamera.ScreenToWorldPoint(screenPosition);
            var worldPosVec2 = new Vector2(worldPos.x, worldPos.y);
            var cellPixelSize = new Vector2();
            var originPosition = new Vector2();

            var screenPosFromOrigin = worldPosVec2 - originPosition;
            var posX = Mathf.FloorToInt(screenPosFromOrigin.x / cellPixelSize.x);
            var posY = Mathf.FloorToInt(screenPosFromOrigin.y / cellPixelSize.y);
            return new Point(posX, posY);
        }
    }
}
