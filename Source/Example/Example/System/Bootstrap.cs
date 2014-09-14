using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Almirante.Engine.Core;

namespace Example.System
{
    /// <summary>
    /// Define bootstrap configuration class. 
    /// This will allow you to setup the game configuration like resolution, virtual resolution, and some other settings.
    /// </summary>
    public class Bootstrap : Bootstrapper
    {
        /// <summary>
        /// Startup method
        /// </summary>
        /// <param name="arguments"></param>
        /// <returns>The type of the main game class.</returns>
        protected override Type OnStartup(string[] arguments)
        {
            // Returning null here will force the engine to search for PUBLIC classes that inherits 
            // Scene class and are marked as [Startup] to run as the initial scene.
            // On our case, it will resolve to Scenes.Splash, but we can specify it directly if we want to.
            // For example if we want to skip splash screen on debug builds:
            #if DEBUG
              return typeof(Scenes.Home);
            #else
              return null;
            #endif
        }

        /// <summary>
        /// Setup your game configuration here.
        /// </summary>
        /// <param name="settings">Settings</param>
        protected override void OnConfigure(Settings settings)
        {
            // Window title
            settings.WindowTitle = "Tábua";

            // Cursor visibility over the game.
            settings.IsCursorVisible = true;

            // This is the actual screen resolution. 
            // If higher than base, the game will be "stretched" to fit the screen, otherwise it will shrink.
            settings.Resolution.SetResolution(1280, 720, false); // Try messing with this values

            // This is the base resolution (all coordinates on the screen will follow this)
            settings.Resolution.SetBaseResolution(1280, 720); // DONT CHANGE

            // Several other settings.
            settings.VerticalSync = false;
        }
    }
}
