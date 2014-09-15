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

        /// <summary>
        /// Player health
        /// </summary>
        [Component]
        public HealthComponent Health
        {
            get;
            set;
        }

        /// <summary>
        /// Player health
        /// </summary>
        [Component]
        public ManaComponent Mana
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
