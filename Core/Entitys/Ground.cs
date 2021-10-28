using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using EndlessRunner.Core.Components;
using System;

namespace EndlessRunner.Core.Entitys
{
    public class Ground
    {
        public Vector2 Position { get; set; }
        private BoxCollider boxCollider;
        Texture2D texture;

        Random random;
        int startSpeed;

        public Ground(float x, float y, Player playerForCollision)
        {
            boxCollider = new BoxCollider(32, 32, x, y - 20);
            Position = new Vector2(x, y);
            random = new Random();
            startSpeed = random.Next(12, 35);
        }

        public void Load(Game game)
        {
            texture = game.Content.Load<Texture2D>("ground-object");
        }

        public void Update(GameTime gameTime)
        {
            var delta = (float)gameTime.ElapsedGameTime.TotalSeconds;
            boxCollider.SetPosition(Position.X-10f, Position.Y - 30f);

            Move(-startSpeed * delta, 0);

            if (Position.X < -20)
            {
                SetPosition(440, random.Next(120, 200));
                startSpeed = random.Next(12, 35);

            }
        }

        public void Move(float x, float y)
        {
            Position += new Vector2(x, y);
        }

        public void SetPosition(float x, float y)
        {
            Position = new Vector2(x, y);
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, Position, null, Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
        }

        public BoxCollider GetCollider()
        {
            return boxCollider;
        }
    }
}
