using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Donjon
{
    public static class UiGridPlayerInput
    {
        public static Point ConvertInputUIIntoPoint(Vector3 screenPosition)
        {
            screenPosition.z = CameraManager.DepthCam;
            var mainCamera = CameraManager.MainCam;
            var worldPos = mainCamera.ScreenToWorldPoint(screenPosition);
            var worldPosVec2 = new Vector2(worldPos.x, worldPos.y);
            var cellSize = FloorManager.CellSize;
            var originPosition = FloorManager.GridOrigin;

            var worldPosFromOrigin = worldPosVec2 - originPosition;
            var posX = Mathf.FloorToInt(worldPosFromOrigin.x / cellSize.x);
            var posY = Mathf.FloorToInt(worldPosFromOrigin.y / cellSize.y);
            return new Point(posX, posY);
        }
    }
}
