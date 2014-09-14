using Almirante.Engine.Core;
using Almirante.Engine.Fonts;
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
    /// <summary>
    /// Login screen
    /// </summary>
    public class Login : Scene
    {
        /// <summary>
        /// Overlay
        /// </summary>
        private Texture2D overlay;

        /// <summary>
        /// 
        /// </summary>
        private Textbox textlogin;

        /// <summary>
        /// 
        /// </summary>
        private Textbox textpassword;

        /// <summary>
        /// Play
        /// </summary>
        private Button enter;

        /// <summary>
        /// Exit
        /// </summary>
        private Button back;

        /// <summary>
        /// Initialization
        /// </summary>
        protected override void OnInitialize()
        {
            var device = AlmiranteEngine.Device;
            this.overlay = new Texture2D(device, 1, 1);
            this.overlay.SetData(new Color[] { Color.FromNonPremultiplied(0, 0, 0, 255) });

            var label_login = new Label()
            {
                Text = "Login:",
                Visible = true,
                Size = new Vector2(200, 15),
                Position = new Vector2((1280 - 200) / 2, (720 - 30) / 2)
            };
            this.Interface.Controls.Add(label_login);

            this.textlogin = new Textbox()
            {
                Visible = true,
                Size = new Vector2(200, 30),
                Position = label_login.Position + new Vector2(0, 20)
            };
            this.Interface.Controls.Add(this.textlogin);

            var label_password = new Label()
            {
                Text = "Senha:",
                Visible = true,
                Size = new Vector2(200, 15),
                Position = this.textlogin.Position + new Vector2(0, 40)
            };
            this.Interface.Controls.Add(label_password);

            this.textpassword = new Textbox()
            {
                Password = true,
                Visible = true,
                Size = new Vector2(200, 30),
                Position = label_password.Position + new Vector2(0, 20)
            };
            this.Interface.Controls.Add(this.textpassword);

            this.enter = new Button()
            {
                Text = "Jogar",
                Visible = true,
                Size = new Vector2(200, 30),
                Position = textpassword.Position + new Vector2(0, 40)
            };
            this.enter.MouseClick += OnEnter;
            this.Interface.Controls.Add(this.enter);

            this.back = new Button()
            {
                Text = "Voltar",
                Visible = true,
                Size = new Vector2(200, 30),
                Position = this.enter.Position + new Vector2(0, 40)
            };
            this.back.MouseClick += OnBack;
            this.Interface.Controls.Add(this.back);
        }

        /// <summary>
        /// Exit button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnBack(object sender, Almirante.Engine.Interface.MouseEventArgs e)
        {
            AlmiranteEngine.Scenes.Pop();
        }

        /// <summary>
        /// Play button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnEnter(object sender, Almirante.Engine.Interface.MouseEventArgs e)
        {
            AlmiranteEngine.Scenes.Switch<Play>();
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
            batch.Draw(this.overlay, new Rectangle(0, 0, 1280, 720), Color.White * 0.80f); // Background overlay (Black)
            batch.End();
        }
    }
}
