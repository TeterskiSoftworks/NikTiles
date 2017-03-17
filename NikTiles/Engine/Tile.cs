using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using NikTiles.Editor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsGraphicsDevice;

namespace NikTiles.Engine {
    public class Tile {

        #region Declarations
        //Geometric Info
        private VertexPositionColorTexture[] floorVertices;
        private VertexBuffer vertexBuffer;
        private GraphicsDevice graphicsDevice;
        #endregion


        /// <summary>
        /// 
        /// </summary>
        /// <param name="graphicsDevice">Pass in GraphicsDevice</param>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        public Tile(GraphicsDevice graphicsDevice, int x, int y) {
            this.graphicsDevice = graphicsDevice;

            //Create Tragiangle
            floorVertices = new VertexPositionColorTexture[4];
            floorVertices[0] = new VertexPositionColorTexture(new Vector3( 32,  32, 0), Color.Red,   new Vector2(1,0));
            floorVertices[1] = new VertexPositionColorTexture(new Vector3(-32,  32, 0), Color.Blue,  new Vector2(0,0));
            floorVertices[2] = new VertexPositionColorTexture(new Vector3( 32, -32, 0), Color.Green, new Vector2(1,1));
            floorVertices[3] = new VertexPositionColorTexture(new Vector3(-32, -32, 0), Color.White, new Vector2(0,1));

            vertexBuffer = new VertexBuffer(graphicsDevice, typeof(VertexPositionColorTexture), 4, BufferUsage.WriteOnly);
            vertexBuffer.SetData(floorVertices);
        }

        /// <summary>
        /// Adds the tiles verteces to the vertexBuffer in order to be drawn.
        /// </summary>
        public void Draw(BasicEffect basicEffect) {
            graphicsDevice.SetVertexBuffer(vertexBuffer);
            basicEffect.Texture = ContentLoader.textures["test1"];

        }

    }
}
