using Almirante.Engine.Core;
using Almirante.Engine.Fonts;
using Almirante.Engine.Resources;
using Almirante.Entities.Components;
using Almirante.Entities.Components.Attributes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Example.Entities.Components
{
    /// <summary>
    /// Text component
    /// </summary>
    public class FlashComponent : DrawableComponent
    {
        /// <summary>
        /// We need a position to draw the text
        /// </summary>
        [ComponentReference]
        private PositionComponent position = null;

        /// <summary>
        /// We need a position to draw the text
        /// </summary>
        [ComponentReference]
        private FadeComponent fade = null;

        /// <summary>
        /// Font
        /// </summary>
        private Resource<BitmapFont> font;

        /// <summary>
        /// Text
        /// </summary>
        public string Value
        {
            get;
            set;
        }

        /// <summary>
        /// Color of the text
        /// </summary>
        public Color Color
        {
            get;
            set;
        }

        /// <summary>
        /// Draws the text
        /// </summary>
        public override void Draw()
        {
            SpriteBatch batch = AlmiranteEngine.Batch;
            if (this.font.Loaded)
            {
                var color = this.Color;
                color.A = (byte) (this.fade.Tweener.Value * 255);
                batch.DrawFont(this.font.Content, new Vector2(this.position.X, this.position.Y), BitmapFontAlignment.Center, color, this.Value);
            }
        }

        /// <summary>
        /// Create the component
        /// </summary>
        public override void OnCreate()
        {
            this.font = AlmiranteEngine.Resources.LoadAsync<BitmapFont>("Fonts\\Pixel8"); 
        }
    }
}
