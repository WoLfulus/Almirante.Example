using Almirante.Engine.Core;
using Almirante.Entities;
using Almirante.Entities.Filters;
using Almirante.Entities.Systems;
using Almirante.Entities.Systems.Multithreaded;
using Example.Entities.Components;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Example.Entities.Systems
{
    /// <summary>
    /// Mana system
    /// </summary>
    public class ManaRegenSystem : ParallelEntityProcessor
    {
        /// <summary>
        /// Stores the next time the mana regen must occur.
        /// </summary>
        private double nextRegen = 0f;

        /// <summary>
        /// Mana regenerators.
        /// This system will filter all entities that are composed of both mana, and mana regen components.
        /// </summary>
        public ManaRegenSystem()
            : base(Filter.Create().Has(typeof(ManaComponent), typeof(ManaRegenComponent)))
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        protected override void Process(Entity entity)
        {
            var mana = entity.GetComponent<ManaComponent>();
            var regen = entity.GetComponent<ManaRegenComponent>();

            if (mana.Value >= mana.Maximum)
            {
                return;
            }

            var dif = regen.Value;
            if (mana.Value + regen.Value > mana.Maximum)
            {
                dif = mana.Maximum - mana.Value;
            }

            mana.Value += dif;

            Debug.WriteLine("Regenerate " + dif + " mana.");
            // Create information entity
        }

        /// <summary>
        /// Checks if this system can be executed.
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public override bool CanExecute(double time)
        {
            if (this.nextRegen <= AlmiranteEngine.Time.Total)
            {
                this.nextRegen = AlmiranteEngine.Time.Total + 1;
                return true;
            }
            return false;
        }
    }
}
