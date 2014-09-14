using Almirante.Engine.Core;
using Almirante.Engine.Resources;
using Almirante.Engine.Scenes;
using Almirante.Engine.Scenes.Transitions;
using Example.Interface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Example.Scenes
{
    public class Home : Scene
    {
        /// <summary>
        /// Logo
        /// </summary>
        private Resource<Texture2D> logo;

        /// <summary>
        /// BG
        /// </summary>
        private Resource<Texture2D> background;

        /// <summary>
        /// Play
        /// </summary>
        private Button play;

        /// <summary>
        /// Exit
        /// </summary>
        private Button exit;

        /// <summary>
        /// Initialization
        /// </summary>
        protected override void OnInitialize()
        {
            this.logo = AlmiranteEngine.Resources.LoadSync<Texture2D>("Interface\\Logo");
            this.background = AlmiranteEngine.Resources.LoadSync<Texture2D>("Interface\\Background");
            
            this.play = new Button()
            {
                Text = "Jogar", 
                Visible = true, 
                Size = new Vector2(200, 30), 
                Position = new Vector2(50, 520)
            };
            this.play.MouseClick += OnPlay;
            this.Interface.Controls.Add(this.play);

            this.exit = new Button()
            {
                Text = "Sair",
                Visible = true,
                Size = new Vector2(200, 30),
                Position = new Vector2(50, 560)
            };
            this.exit.MouseClick += OnExit;
            this.Interface.Controls.Add(this.exit);
        }

        protected override void OnActivate()
        {
            base.OnActivate();
        }

        /// <summary>
        /// Exit button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnExit(object sender, Almirante.Engine.Interface.MouseEventArgs e)
        {
            AlmiranteEngine.Stop();
        }

        /// <summary>
        /// Play button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void OnPlay(object sender, Almirante.Engine.Interface.MouseEventArgs e)
        {
            AlmiranteEngine.Scenes.Push<Login>();
        }

        /// <summary>
        /// Destroy
        /// </summary>
        protected override void OnUninitialize()
        {
        }

        /// <summary>
        /// Update
        /// </summary>
        protected override void OnUpdate()
        {
        }

        /// <summary>
        /// Draw
        /// </summary>
        /// <param name="batch"></param>
        protected override void OnDraw(SpriteBatch batch)
        {
            batch.Start(); // Use start instead of Begin
            batch.Draw(this.background.Content, Vector2.Zero, Color.White);
            batch.Draw(this.logo.Content, new Vector2(this.background.Content.Width - this.logo.Content.Width, 0), Color.White);
            batch.End();
        }
    }
}
