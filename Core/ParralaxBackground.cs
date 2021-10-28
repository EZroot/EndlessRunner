//backgrounds as textures
//move them
//draw next one
//draw previous one
//move at x speed
//contains texture
//columns
//rows
//animation speed
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace EndlessRunner.Core
{
    public class ParralaxBackground
    {
        public Texture2D texture_mountainBg;
        private Vector2 position_mountainBg;
        private Vector2 startPosition_mountainBg;

        public Texture2D texture_mountainforeground_trees;
        private Vector2 position_mountainforeground_trees;
        private Vector2 startPosition_mountainforeground_trees;

        public Texture2D texture_mountain_far;
        private Vector2 position_mountain_far;
        private Vector2 startPosition_mountain_far;

        public Texture2D texture_mountain_mountain;
        private Vector2 position_mountain_mountain;
        private Vector2 startPosition_mountain_mountain;

        public Texture2D texture_mountain_trees;
        private Vector2 position_mountain_trees;
        private Vector2 startPosition_mountain_trees;

        Texture2D groundFloor;
        Vector2 position_groundFloor;
        Vector2 startPosition_groundFloor;

        Texture2D grass;
        Vector2 position_grass;
        Vector2 startPosition_grass;

        public ParralaxBackground(float startX, float startY)
        {
            startPosition_mountainBg = new Vector2(startX, startY);
            startPosition_mountain_far = new Vector2(startX, startY);
            startPosition_mountain_mountain = new Vector2(startX, startY);
            startPosition_mountain_trees = new Vector2(startX, startY);
            startPosition_mountainforeground_trees = new Vector2(startX, startY);

            startPosition_groundFloor = new Vector2(startX, startY);
            startPosition_grass = new Vector2(startX, startY);
        }


        public void Load(Game game)
        {
            texture_mountainBg = game.Content.Load<Texture2D>("parallax-mountain-bg");
            texture_mountainforeground_trees = game.Content.Load<Texture2D>("parallax-mountain-foreground-trees");
            texture_mountain_far = game.Content.Load<Texture2D>("parallax-mountain-montain-far");
            texture_mountain_mountain = game.Content.Load<Texture2D>("parallax-mountain-mountains");
            texture_mountain_trees = game.Content.Load<Texture2D>("parallax-mountain-trees");

            groundFloor = game.Content.Load<Texture2D>("ground-pixel");
            grass = game.Content.Load<Texture2D>("ground-grass");
        }

        public void Update(GameTime gameTime)
        {
            var delta = (float)gameTime.ElapsedGameTime.TotalSeconds;

            position_mountainBg += new Vector2(delta * -1.0f, 0f);
            position_mountain_far += new Vector2(delta * -2.0f, 0f);
            position_mountain_mountain += new Vector2(delta * -6.0f, 0f);
            position_mountain_trees += new Vector2(delta * -12.0f, 0f);
            position_mountainforeground_trees += new Vector2(delta * -65.0f, 0f);

            if (position_mountainBg.X < -544)
                position_mountainBg = Vector2.Zero;
            if (position_mountain_far.X < -500)
                position_mountain_far = Vector2.Zero;
            if (position_mountain_mountain.X < -1088)
                position_mountain_mountain = Vector2.Zero;
            if (position_mountain_trees.X < -1088)
                position_mountain_trees = Vector2.Zero;
            if (position_mountainforeground_trees.X < -1088)
                position_mountainforeground_trees = Vector2.Zero;

            position_groundFloor += new Vector2(delta * -100.0f, 0f);
            if (position_groundFloor.X < -64)
                position_groundFloor = Vector2.Zero;

            position_grass += new Vector2(delta * -100f, 0f);
            if (position_grass.X < -64)
                position_grass = Vector2.Zero;
        }

        public void Draw(SpriteBatch spriteBatch)
        {

            for (int i = 0; i < 11; i++)
            {
                spriteBatch.Draw(grass, startPosition_grass + new Vector2(position_grass.X  - 100 + i * 64, position_grass.Y + 277), null, Color.White, 0f, Vector2.Zero, 2f, SpriteEffects.None, 0f);
                spriteBatch.Draw(groundFloor, startPosition_groundFloor + new Vector2(position_groundFloor.X - 100 + i * 64, position_groundFloor.Y + 277), null, Color.White, 0f, Vector2.Zero, 2f, SpriteEffects.None, 0f);
            }
            
            spriteBatch.Draw(texture_mountainforeground_trees, startPosition_mountainforeground_trees + position_mountainforeground_trees, null, Color.White, 0f, Vector2.Zero, 2f, SpriteEffects.None, 0f);
            spriteBatch.Draw(texture_mountainforeground_trees, new Vector2(startPosition_mountainforeground_trees.X + 1088, startPosition_mountainforeground_trees.Y) + position_mountainforeground_trees,
             null, Color.White, 0f, Vector2.Zero, 2f, SpriteEffects.None, 0f);
            
            spriteBatch.Draw(texture_mountain_trees, startPosition_mountain_trees + position_mountain_trees, null, Color.White, 0f, Vector2.Zero, 2f, SpriteEffects.None, 0f);
            spriteBatch.Draw(texture_mountain_trees, new Vector2(startPosition_mountain_trees.X + 1088, startPosition_mountain_trees.Y) + position_mountain_trees,
             null, Color.White, 0f, Vector2.Zero, 2f, SpriteEffects.None, 0f);
            
            spriteBatch.Draw(texture_mountain_mountain, startPosition_mountain_mountain + position_mountain_mountain, null, Color.White, 0f, Vector2.Zero, 2f, SpriteEffects.None, 0f);
            spriteBatch.Draw(texture_mountain_mountain, new Vector2(startPosition_mountain_mountain.X + 1088, startPosition_mountain_mountain.Y) + position_mountain_mountain,
             null, Color.White, 0f, Vector2.Zero, 2f, SpriteEffects.None, 0f);
            
            spriteBatch.Draw(texture_mountain_far, startPosition_mountain_far + position_mountain_far, null, Color.White, 0f, Vector2.Zero, 2f, SpriteEffects.None, 0f);
            spriteBatch.Draw(texture_mountain_far, new Vector2(startPosition_mountain_far.X + 500f, startPosition_mountain_far.Y) + position_mountain_far,
             null, Color.White, 0f, Vector2.Zero, 2f, SpriteEffects.None, 0f);
            
            spriteBatch.Draw(texture_mountainBg, startPosition_mountainBg + position_mountainBg, null, Color.White, 0f, Vector2.Zero, 2f, SpriteEffects.None, 0f);
            spriteBatch.Draw(texture_mountainBg, new Vector2(startPosition_mountainBg.X + 500f, startPosition_mountainBg.Y) + position_mountainBg,
             null, Color.White, 0f, Vector2.Zero, 2f, SpriteEffects.None, 0f);
        }
    }
}
