//contains animation states
//contains animation textures
//box collider
//input
//update
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using EndlessRunner.Core;
using EndlessRunner.Core.Components;
using System;

namespace EndlessRunner.Core.Entitys
{
    public class Player
    {
        public enum AnimationState
        {
            idle,
            running,
            sliding,
            jump,
            count
        }

        public AnimationState animationState = AnimationState.running;

        private Texture2D[] spriteSheets;
        private AnimatedTexture[] animatedSprites;
        private BoxCollider boxCollider;
        public Vector2 position;
        private Vector2 velocity;
        private float drag = 15f;
        private bool isMoving;
        //private float gravity = 8f;
        private float gravity = 10f;
        public bool isOnGround;

        float speed = 15f;
        float jumpSpeed = 5f;
        float maxHortSpeed = 4f;
        float maxFallSpeed = 5f;
        public Player(float x, float y)
        {
            position = new Vector2(x, y);
            velocity = Vector2.Zero;
            spriteSheets = new Texture2D[(int)AnimationState.count];
            animatedSprites = new AnimatedTexture[(int)AnimationState.count];
            boxCollider = new BoxCollider(32, 32, x, y);
        }
        public void Load(Game game)
        {
            spriteSheets[0] = game.Content.Load<Texture2D>("idle-sheet");
            animatedSprites[0] = new AnimatedTexture(spriteSheets[0], 12f, 1, 7);
            spriteSheets[1] = game.Content.Load<Texture2D>("1-sheet");
            animatedSprites[1] = new AnimatedTexture(spriteSheets[1], 12f, 1, 8);
            spriteSheets[2] = game.Content.Load<Texture2D>("slide-sheet");
            animatedSprites[2] = new AnimatedTexture(spriteSheets[2], 12f, 1, 4);
            spriteSheets[3] = game.Content.Load<Texture2D>("jump-sheet");
            animatedSprites[3] = new AnimatedTexture(spriteSheets[3], 12f, 1, 3);

            animatedSprites[0].AnimationSpeed = 12f; //idle
            animatedSprites[1].AnimationSpeed = 12f; //running
            animatedSprites[2].AnimationSpeed = 12f; //sliding
            animatedSprites[3].AnimationSpeed = 0f; //jump

            //boxCollider.DebugSetup(game.GraphicsDevice);        
        }

        float count = 0;
        public void Input(GameTime gameTime)
        {
            var delta = (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (Keyboard.GetState().IsKeyDown(Keys.Space) && isOnGround)
            {
                velocity.Y = -jumpSpeed;
                isOnGround = false;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                if(velocity.X<0)
                    velocity.X = 0;
                Move(delta * speed, 0);
                velocity.X = MathF.Min(velocity.X, maxHortSpeed);

                isMoving = true;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                if(velocity.X>0)
                    velocity.X = 0;
                Move(delta * -speed, 0);
                velocity.X = MathF.Max(velocity.X, -maxHortSpeed);
                isMoving = true;
            }

            if (Keyboard.GetState().IsKeyUp(Keys.A) && Keyboard.GetState().IsKeyUp(Keys.D))
                isMoving = false;

            animatedSprites[(int)animationState].Update(gameTime);

            Console.WriteLine(velocity);
        }

        public void Update(GameTime gameTime)
        {
            var delta = (float)gameTime.ElapsedGameTime.TotalSeconds;

            position += velocity;
            //animatedSprites[1].AnimationSpeed = 6f + velocity.X*.75f;

            boxCollider.SetPosition(position.X, position.Y);

            if (!isMoving)
            {
                if (velocity.X > 0.1f)
                    velocity.X -= delta * drag;
                else if (velocity.X < -0.1f)
                    velocity.X += delta * drag;
                else
                {
                    velocity.X = 0;
                }
            }

            if (!isOnGround)
            {
                //velocity.Y += gravity * delta;
                velocity.Y = MathF.Min(velocity.Y, maxFallSpeed);
                //animationState = AnimationState.jump;
            }
            else
            {
                velocity.Y = 0;
                animationState = AnimationState.running;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            animatedSprites[(int)animationState].Draw(spriteBatch, position);
            //boxCollider.DebugDraw(spriteBatch);
        }

        public void Move(float x, float y)
        {
            velocity += new Vector2(x, y);
        }

        public void SetPosition(float x, float y)
        {
            position = new Vector2(x, y);
        }

        public BoxCollider GetCollider()
        {
            return boxCollider;
        }
    }
}
