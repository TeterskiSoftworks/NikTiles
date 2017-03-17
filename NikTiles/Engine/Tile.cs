using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsGraphicsDevice;

namespace NikTiles.Engine {
    public class Tile {

        #region Declarations
        //heightmap
        //floor material
        //      floor-side material
        //two walls, north-west and north-east
        //      each wall has its own material


        //Geometric Info
        private VertexPositionColor[] triangleVertices;
        private VertexBuffer vertexBuffer;
        private GraphicsDevice graphicsDevice;
        #endregion

        public Tile(GraphicsDevice graphicsDevice) {
            this.graphicsDevice = graphicsDevice;

            //Create Tragiangle
            triangleVertices = new VertexPositionColor[3];
            triangleVertices[0] = new VertexPositionColor(new Vector3(0, 20, 0), Color.Red);
            triangleVertices[1] = new VertexPositionColor(new Vector3(-20, -20, 0), Color.Green);
            triangleVertices[2] = new VertexPositionColor(new Vector3(20, -20, 0), Color.Blue);

            vertexBuffer = new VertexBuffer(graphicsDevice, typeof(VertexPositionColor), 3, BufferUsage.WriteOnly);
            vertexBuffer.SetData(triangleVertices);
        }

        public void Draw() {
            graphicsDevice.SetVertexBuffer(vertexBuffer);
        }

    }
}
