using Almirante.Engine.Core;
using Almirante.Entities;
using Almirante.Entities.Filters;
using Almirante.Entities.Systems;
using Almirante.Entities.Systems.Multithreaded;
using Example.Entities.Components;
using Microsoft.Xna.Framework;
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
        /// Random generator
        /// </summary>
        private Random random = new Random(Environment.TickCount);

        /// <summary>
        /// Mana regenerators.
        /// This system will filter all entities that are composed of both mana, and mana regen components.
        /// </summary>
        public ManaRegenSystem()
            : base(Filter.Create().Has(typeof(ManaComponent)))
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        protected override void Process(Entity entity)
        {
            var mana = entity.GetComponent<ManaComponent>();

            if (mana.Value >= mana.Maximum)
            {
                return;
            }

            var dif = mana.Regen;
            if (mana.Value + mana.Regen > mana.Maximum)
            {
                dif = mana.Maximum - mana.Value;
            }

            mana.Value += dif;

            var message = entity.Manager.Create<FlashMessage>();
            message.Position.X = entity.Position.X + 35;
            message.Position.Y = entity.Position.Y + 5;
            message.Fade.Time = 2;
            message.Dislocation.Time = 2;
            message.Dislocation.Finish = new Vector2(entity.Position.X + 35 + random.Next(10, 20), entity.Position.Y + 5 + random.Next(10, 20));
            message.Content.Color = Color.LightBlue;
            message.Content.Value = "+" + ((int)dif).ToString();
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
