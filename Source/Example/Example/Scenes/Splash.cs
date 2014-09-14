using Almirante.Engine.Core;
using Almirante.Engine.Resources;
using Almirante.Engine.Scenes;
using Almirante.Engine.Tweens;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Example.Scenes
{
    /// <summary>
    /// Define your initial scene.
    /// This is the main scene that the game will load, because it's marked with [Startup] attribute.
    /// </summary>
    [Startup]
    public class Splash : Scene
    {
        /// <summary>
        /// Resource used by the splash screen.
        /// </summary>
        private Resource<Texture2D> logo;

        /// <summary>
        /// Stores the logo position
        /// </summary>
        private Vector2 position;

        /// <summary>
        /// Splash fade.
        /// </summary>
        private ValueTweener fade;

        /// <summary>
        /// Scene creation.
        /// </summary>
        protected override void OnInitialize()
        {
            // Loads a texture from file. In this case the logo texture.
            this.logo = AlmiranteEngine.Resources.LoadSync<Texture2D>("Textures/Logo");
            this.position = new Vector2((1280 - this.logo.Content.Width) / 2, (720 - this.logo.Content.Height) / 2);

            // Defines the logo transition.
            // What this tweener will do?
            // - Starts on 0
            // - Fade from 0 to 1 for 2 seconds
            // - Wait 1 second
            // - Fade from 1 to 0 for 2 seconds
            // - Wait 1/2 second
            // - Call an action when its done.
            this.fade = new ValueTweener(0, 1)
                .Forward(2) // 0 to 1 in 2 seconds
                .Wait(1) // wait for 1 second
                .Backward(2) // 1 to 0 in 2 seconds
                .Wait(0.5f) // wait half second
                .Action(() => { // call the action
                    AlmiranteEngine.Scenes.Switch<Home>(); // Switch the scene to main menu
                });
        }

        /// <summary>
        /// Scene destruction.
        /// </summary>
        protected override void OnUninitialize()
        {
        }

        /// <summary>
        /// Scene logic.
        /// </summary>
        protected override void OnUpdate()
        {
            this.fade.Update(AlmiranteEngine.Time.Frame); // Updates the tweener
        }

        /// <summary>
        /// Scene enter
        /// </summary>
        protected override void OnEnter()
        {
            this.fade.Restart(); // Restarts the tweener when entering the scene
        }

        /// <summary>
        /// Scene rendering.
        /// </summary>
        /// <param name="batch">Sprite batch</param>
        protected override void OnDraw(SpriteBatch batch)
        {
            // While the tweener is active
            if (!this.fade.IsFinished) 
            {
                // Begins the batch drawing
                batch.Start(); // Use start instead of Begin

                // Draws the logo
                // We use the tweener's value as the color (fade)
                batch.Draw(this.logo.Content, this.position, Color.White * this.fade.Value);

                // Ends the batch drawing
                batch.End();
            }
        }
    }
}
