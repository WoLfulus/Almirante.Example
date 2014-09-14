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
    /// Player entity
    /// </summary>
    public class Player : Entity
    {
        /// <summary>
        /// Name of this player
        /// </summary>
        [Component]
        public NameComponent Name
        {
            get;
            set;
        }

        /// <summary>
        /// Texture of this player
        /// </summary>
        [Component]
        public VisualComponent Visual
        {
            get;
            set;
        }

        protected override void OnCreate()
        {
        }

        protected override void OnDestroy()
        {
        }
    }
}
