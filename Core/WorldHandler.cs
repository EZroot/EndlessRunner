//spawns player
//spawns worlds
//spawns camera

//start of game
//generates grounds
//speeds up
//win + lose condition

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using EndlessRunner.Core.Entitys;
using EndlessRunner.Core.Components;
using System;
namespace EndlessRunner.Core
{
    public class WorldHandler
    {
        Camera camera;
        Player player;
        Ground ground;
        Ground ground2;
        Ground ground3;
        Ground ground4;
        ParralaxBackground background;

        public WorldHandler()
        {

        }
        public void Load(Viewport viewport, Game game)
        {
            camera = new Camera(-160, -110, 2f, viewport);
            background = new ParralaxBackground(0, 20);
            background.Load(game);

            player = new Player(150, 245);
            player.Load(game);

            /*
            ground = new Ground(50, 180, player);
            ground.Load(game);
            ground2 = new Ground(150, 180, player);
            ground2.Load(game);
            ground3 = new Ground(250, 180, player);
            ground3.Load(game);
            ground4 = new Ground(350, 180, player);
            ground4.Load(game);*/
        }

        public void Update(GameTime gameTime)
        {
            /*if (player.GetCollider().OnCollision(ground.GetCollider())
            || player.GetCollider().OnCollision(ground2.GetCollider())
            || player.GetCollider().OnCollision(ground3.GetCollider())
            || player.GetCollider().OnCollision(ground4.GetCollider()))
            {
                player.isOnGround = true;
            }
            else
                player.isOnGround = false;*/

            //spawn ground
            //speed up background, ground movement, etc
            player.Update(gameTime);
            player.Input(gameTime);

            /*ground.Update(gameTime);
            ground2.Update(gameTime);
            ground3.Update(gameTime);
            ground4.Update(gameTime);*/

            background.Update(gameTime);
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch, GraphicsDeviceManager graphics)
        {
            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend, SamplerState.PointClamp, null, null, null, camera.GetTransform(graphics.GraphicsDevice));

            background.Draw(spriteBatch);

            /*ground.Draw(spriteBatch);
            ground2.Draw(spriteBatch);
            ground3.Draw(spriteBatch);
            ground4.Draw(spriteBatch);*/

            player.Draw(spriteBatch);

            spriteBatch.End();
        }
    }
}
