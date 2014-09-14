using Almirante.Engine.Core;
using Almirante.Engine.Fonts;
using Almirante.Engine.Interface;
using Almirante.Engine.Resources;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Example.Interface
{
    /// <summary>
    /// Label
    /// </summary>
    class Label : Control
    {
        /// <summary>
        /// Font
        /// </summary>
        private Resource<BitmapFont> font;

        /// <summary>
        /// Color.
        /// </summary>
        public Color Color
        {
            get;
            set;
        }

        /// <summary>
        /// Alignment
        /// </summary>
        public BitmapFontAlignment Alignment
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the button text.
        /// </summary>
        public string Text
        {
            get;
            set;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Textbox"/> class.
        /// </summary>
        public Label()
        {
            this.Text = "";
            this.font = AlmiranteEngine.Resources.LoadSync<BitmapFont>("Fonts\\Font");
            this.Color = Color.White;
            this.Alignment = BitmapFontAlignment.Left;
        }

        /// <summary>
        /// Called when drawing the HUD component.
        /// </summary>
        /// <param name="batch">The sprite batch instance.</param>
        /// <param name="position"></param>
        protected override void OnDraw(SpriteBatch batch, Vector2 position)
        {
            batch.DrawFont(this.font.Content, position, this.Alignment, this.Color, this.Text);
        }
    }
}
