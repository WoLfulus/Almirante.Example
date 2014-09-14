using Almirante.Entities.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Example.Entities.Components
{
    /// <summary>
    /// Health regen
    /// </summary>
    public class ManaRegenComponent : Component
    {
        /// <summary>
        /// Health restore component
        /// </summary>
        public float Value
        {
            get;
            set;
        }

        /// <summary>
        /// Create
        /// </summary>
        public override void OnCreate()
        {
        }

        /// <summary>
        /// Destroy
        /// </summary>
        public override void OnDestroy()
        {
        }
    }
}
