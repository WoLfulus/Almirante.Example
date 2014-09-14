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
    public class FadeComponent : Component
    {
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
        public ValueTweener Tweener
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        public override void OnCreate()
        {
            this.Tweener = new ValueTweener(0, 1);
            this.Tweener.Backward(this.Time);
            this.Tweener.Start();
        }
    }
}
