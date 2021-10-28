using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace EndlessRunner.Core.Components
{
    public class BoxCollider
    {
        Vector2 _position; //x,y
        Vector2 _startPos;
        Vector2 _scale; //width,height

        public Vector2 Position { get { return _position; } set { _position = value; } }
        public Vector2 Scale { get { return _scale; } set { _scale = value; } }

        //debug shit
        Texture2D debugTexture;

        public BoxCollider(int width, int height, float x, float y)
        {
            Scale = new Vector2(width, height);
            Position = new Vector2(x, y);
            _startPos = Position;
        }

        public void SetPosition(float x, float y)
        {
            Position = new Vector2(x, y);
        }

        public void DebugSetup(GraphicsDevice device)
        {
            debugTexture = new Texture2D(device, 1,1);
            debugTexture.SetData(new[] { Color.White });
        }
        public void DebugDraw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(debugTexture, new Vector2(Position.X,Position.Y), null,
                      Color.Red, 0f, Vector2.Zero, new Vector2(100,100),
                      SpriteEffects.None, 0f);
        }

        public bool OnCollision(BoxCollider other)
        {
            //The sides of the rectangles
            float leftA, leftB;
            float rightA, rightB;
            float topA, topB;
            float bottomA, bottomB;

            //Calculate the sides of rect A
            leftA = Position.X;
            rightA = Position.X + Scale.X;
            topA = Position.Y;
            bottomA = Position.Y + Scale.Y;

            //Calculate the sides of rect B
            leftB = other.Position.X;
            rightB = other.Position.X + other.Scale.X;
            topB = other.Position.Y;
            bottomB = other.Position.Y + other.Scale.Y;

            //If any of the sides from A are outside of B
            if (bottomA <= topB)
            {
                return false;
            }

            if (topA >= bottomB)
            {
                return false;
            }

            if (rightA <= leftB)
            {
                return false;
            }

            if (leftA >= rightB)
            {
                return false;
            }
            //If none of the sides from A are outside B
            return true;
        }
    }
}
