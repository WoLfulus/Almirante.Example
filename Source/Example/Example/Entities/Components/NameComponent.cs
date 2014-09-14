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
    /// 
    /// </summary>
    public class NameComponent : DrawableComponent
    {
#pragma warning disable 0649

        /// <summary>
        /// In order to draw the components into the screen,
        /// we must access the position component of the entity.
        /// We do this by marking the component with [ComponentReference]
        /// and the engine will inject the instance into this component.
        /// </summary>
        [ComponentReference]
        private PositionComponent position;

#pragma warning restore 0649

        /// <summary>
        /// Font used in this component
        /// </summary>
        private Resource<BitmapFont> font;

        /// <summary>
        /// The text of this name.
        /// </summary>
        public string Text
        {
            get;
            set;
        }

        /// <summary>
        /// Color
        /// </summary>
        public Color Color
        {
            get;
            set;
        }

        /// <summary>
        /// Draws the component to the screen.
        /// </summary>
        public override void Draw()
        {
            SpriteBatch batch = AlmiranteEngine.Batch;

            // We must check if font is loaded, because we requests it asynchronously.
            if (this.font.Loaded) 
            {
                batch.DrawFont(this.font.Content, new Vector2(this.position.X, this.position.Y + 13), BitmapFontAlignment.Center, this.Color, this.Text);
            }
        }

        /// <summary>
        /// Component creation
        /// </summary>
        public override void OnCreate()
        {
            this.font = AlmiranteEngine.Resources.LoadAsync<BitmapFont>("Fonts\\Pixel8"); 
        }

        /// <summary>
        /// Component destruction
        /// </summary>
        public override void OnDestroy()
        { 
            // Disposes this component
            this.font.Dispose();
        }
    }
}
