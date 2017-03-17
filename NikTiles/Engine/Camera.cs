using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NikTiles.Engine {

    /// <summary>
    /// A class that handles how 3D is made into a 2D projection on the display. 
    /// </summary>
    public class Camera {

        #region Declarations
        private Vector3 target;
        private Vector3 position;

        private Matrix projection;
        private Matrix view;
        private Matrix world;
        #endregion 

        public Camera(GraphicsDevice graphicsDevice) {
            target = new Vector3(0f, 0f, 0f);
            position = new Vector3(0f, 0f, -100f);

            //projection = Matrix.CreateOrthographic(graphicsDevice.DisplayMode.Width, graphicsDevice.DisplayMode.Height, 1f, 1000f);
            projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(45f), graphicsDevice.DisplayMode.AspectRatio, 1f, 1000f);
            view = Matrix.CreateLookAt(position, target, Vector3.Up);
            world = Matrix.CreateWorld(target, Vector3.Forward, Vector3.Up);

        }

        public Vector3 GetTraget() {
            return target;
        }

        public Vector3 GetPosition() {
            return position;
        }

        public Matrix GetProjection() {
            return projection;
        }
        public Matrix GetView() {
            return view;
        }
        public Matrix GetWorld() {
            return world;
        }

    }
}
