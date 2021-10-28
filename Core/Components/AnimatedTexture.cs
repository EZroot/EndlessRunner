//contains texture
//columns
//rows
//animation speed
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
namespace EndlessRunner.Core.Components
{
    public class AnimatedTexture
    {
        public Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }

        public float AnimationSpeed { get; set; }
        private float animationTick;
        private int currentFrame;
        private int totalFrames;

        public AnimatedTexture(Texture2D spriteSheet, float animationSpeed, int rows, int cloumns)
        {
            Texture = spriteSheet;
            Rows = rows;
            Columns = cloumns;
            currentFrame = 0;
            totalFrames = Rows * Columns;
            AnimationSpeed = animationSpeed;
            animationTick = 0;
        }

        public void Update(GameTime gameTime)
        {
            var delta = (float)gameTime.ElapsedGameTime.TotalSeconds;
            animationTick += delta * AnimationSpeed;
            
            if (animationTick > 1)
            {
                currentFrame++;
                animationTick = 0;
            }

            if (currentFrame >= totalFrames)
                currentFrame = 0;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            int width = Texture.Width / Columns;
            int height = Texture.Height / Rows;
            int row = currentFrame / Columns;
            int column = currentFrame % Columns;

            Rectangle sourceRect = new Rectangle(width * column, height * row, width, height);
            Rectangle destRect = new Rectangle((int)position.X, (int)position.Y, width, height);

            spriteBatch.Draw(Texture, destRect, sourceRect, Color.White);
        }
    }
}
