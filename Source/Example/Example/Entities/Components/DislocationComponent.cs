using Almirante.Engine.Tweens;
using Almirante.Entities.Components;
using Almirante.Entities.Components.Attributes;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Example.Entities.Components
{
    /// <summary>
    /// Fade component
    /// </summary>
    public class DislocationComponent : Component
    {
        /// <summary>
        /// Reference to position
        /// </summary>
        [ComponentReference]
        private PositionComponent position = null;

        /// <summary>
        /// 
        /// </summary>
        public Vector2 Finish
        {
            set
            {
                this.Tweener = new VectorTweener(new Vector2(this.position.X, this.position.Y), value);
                this.Tweener.Forward(this.Time);
                this.Tweener.Start();
            }
        }

        /// <summary>
        /// Time
        /// </summary>
        public float Time
        {
            get;
            set;
        }

        /// <summary>
        /// Tweener
        /// </summary>
        public VectorTweener Tweener
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        public override void OnCreate()
        {
        }
    }
}
