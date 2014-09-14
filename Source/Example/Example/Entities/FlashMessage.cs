using Almirante.Entities;
using Almirante.Entities.Components.Attributes;
using Example.Entities.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Example.Entities
{
    /// <summary>
    /// Entity used to display regen information on screen.
    /// </summary>
    public class FlashMessage : Entity
    {
        /// <summary>
        /// Text
        /// </summary>
        [Component]
        public FlashComponent Content
        {
            get;
            set;
        }

        /// <summary>
        /// Movement
        /// </summary>
        [Component]
        public MovementComponent Movement
        {
            get;
            set;
        }

        /// <summary>
        /// Message fading
        /// </summary>
        [Component]
        public FadeComponent Fade
        {
            get;
            set;
        }

        /// <summary>
        /// Create
        /// </summary>
        protected override void OnCreate()
        {
        }

        /// <summary>
        /// Destroy
        /// </summary>
        protected override void OnDestroy()
        {
        }
    }
}
