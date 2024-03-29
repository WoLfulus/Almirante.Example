﻿using Almirante.Engine.Core;
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
    /// Health component
    /// </summary>
    public class HealthComponent : DrawableComponent
    {
        /// <summary>
        /// In order to draw the components into the screen,
        /// we must access the position component of the entity.
        /// We do this by marking the component with [ComponentReference]
        /// and the engine will inject the instance into this component.
        /// </summary>
        [ComponentReference]
        private PositionComponent position = null;

        /// <summary>
        /// Current health
        /// </summary>
        public float Value
        {
            get;
            set;
        }

        /// <summary>
        /// Maximum health
        /// </summary>
        public float Maximum
        {
            get;
            set;
        }

        /// <summary>
        /// Regeneration
        /// </summary>
        public float Regen
        {
            get;
            set;
        }

        /// <summary>
        /// Bar size
        /// </summary>
        private const int BarSize = 32;
        private const int DrawOffset = 5;

        /// <summary>
        /// Creation
        /// </summary>
        public override void OnCreate()
        {
        }

        /// <summary>
        /// Destruction
        /// </summary>
        public override void OnDestroy()
        {
        }

        /// <summary>
        /// Draws the component to the screen.
        /// </summary>
        public override void Draw()
        {
            float percent = Value / Maximum;

            var color = Color.GreenYellow;
            if (percent >= 0.75)
            {
                color = Color.GreenYellow;
            }
            else if (percent >= 0.40)
            {
                color = Color.Orange;
            }
            else if (percent >= 0.25)
            {
                color = Color.OrangeRed;
            }
            else
            {
                color = Color.Red;
            }

            SpriteBatch batch = AlmiranteEngine.Batch;
            batch.DrawLine(this.position.X - (BarSize / 2), this.position.Y + DrawOffset, this.position.X + (BarSize / 2), this.position.Y + DrawOffset, Color.Black, 4);
            batch.DrawLine(this.position.X - (BarSize / 2) + 1, this.position.Y + DrawOffset + 1, this.position.X - (BarSize / 2) + (BarSize * percent) - 1, this.position.Y + DrawOffset + 1, color, 2);
        }
    }
}
