using Almirante.Engine.Core;
using Almirante.Engine.Resources;
using Almirante.Engine.Scenes;
using Almirante.Entities;
using Example.Entities;
using Example.Entities.Systems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Example.Scenes
{
    /// <summary>
    /// Play scene
    /// </summary>
    public class Play : Scene
    {
        /// <summary>
        /// Overlay
        /// </summary>
        private Texture2D background;

        /// <summary>
        /// 
        /// </summary>
        private Resource<Texture2D> map;

        /// <summary>
        /// Used to store all entities inside the game.
        /// </summary>
        private EntityManager entities;

        /// <summary>
        /// Player instance.
        /// </summary>
        private Player player;

        /// <summary>
        /// Scene initialization
        /// </summary>
        protected override void OnInitialize()
        {
            var device = AlmiranteEngine.Device;
            this.background = new Texture2D(device, 1, 1);
            this.background.SetData(new Color[] { Color.FromNonPremultiplied(0, 0, 0, 255) });
            this.map = AlmiranteEngine.Resources.LoadSync<Texture2D>("Map\\Map");
        }

        /// <summary>
        /// Uninitialize
        /// </summary>
        protected override void OnUninitialize()
        {
        }

        /// <summary>
        /// Entering the scene
        /// </summary>
        protected override void OnEnter()
        {
            // Creates a new entity manager
            this.entities = new EntityManager();

            // Registers the systems to be used by this manager
            this.entities.Systems.Add<ControlSystem>();
            this.entities.Systems.Add<CameraSystem>();

            // Creates the player with tag "player" so the systems can find the entity
            this.player = this.entities.Create<Player>("player");
            this.player.Name.Text = "Você";
            this.player.Name.Color = Color.White;
            this.player.Health.Value = 80;
            this.player.Health.Maximum = 100;
            this.player.Mana.Value = 25;
            this.player.Mana.Maximum = 100;
            this.player.Visual.File = "Characters\\Player";
            this.player.Position.X = 0;
            this.player.Position.Y = 0;
        }

        /// <summary>
        /// Leaving the scene
        /// </summary>
        protected override void OnLeave()
        {
            this.player = null;
            this.entities = null;
        }

        /// <summary>
        /// Update
        /// </summary>
        protected override void OnUpdate()
        {
            // Updates the entity system
            this.entities.Update(AlmiranteEngine.Time.Frame); 
        }

        /// <summary>
        /// Draw function
        /// </summary>
        /// <param name="batch"></param>
        protected override void OnDraw(SpriteBatch batch)
        {
            batch.Start();
            batch.Draw(this.background, new Rectangle(0, 0, 1280, 720), Color.White); // Background overlay (Black)
            batch.End();

            // Starts the batch drawing using the camera transformation matrix
            batch.Start(true);
            // Draws a background (map)
            int sx = -1000;
            int sy = -1000;
            for (int x = 0; x < 4; x++)
            {
                sy = -1000;
                for (int y = 0; y < 4; y++)
                {
                    batch.Draw(this.map.Content, new Vector2(sx, sy), Color.White);
                    sy += 500;
                }
                sx += 500;
            }
            // Draws the entities to the screen
            this.entities.Draw();
            // Ends the drawing
            batch.End();
        }
    }
}
