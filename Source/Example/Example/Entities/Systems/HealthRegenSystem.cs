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
    /// Health system
    /// </summary>
    public class HealthRegenSystem : ParallelEntityProcessor
    {
        /// <summary>
        /// Stores the next time the health regen must occur.
        /// </summary>
        private double nextRegen = 0f;

        /// <summary>
        /// Random generator
        /// </summary>
        private Random random = new Random(Environment.TickCount);

        /// <summary>
        /// Health regenerators.
        /// This system will filter all entities that are composed of both health, and health regen components.
        /// </summary>
        public HealthRegenSystem()
            : base(Filter.Create().Has(typeof(HealthComponent)))
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        protected override void Process(Entity entity)
        {
            var health = entity.GetComponent<HealthComponent>();
            if (health.Value >= health.Maximum)
            {
                return;
            }

            var dif = health.Regen;
            if (health.Value + health.Regen > health.Maximum)
            {
                dif = health.Maximum - health.Value;
            }

            health.Value += dif;

            var message = entity.Manager.Create<FlashMessage>();
            message.Position.X = entity.Position.X + 35;
            message.Position.Y = entity.Position.Y + 0;
            message.Fade.Time = 2;
            message.Dislocation.Time = 2;
            message.Dislocation.Finish = new Vector2(entity.Position.X + 35 + random.Next(10, 20), entity.Position.Y - random.Next(10, 20));
            message.Content.Color = Color.GreenYellow;
            message.Content.Value = "+" + ((int) dif).ToString();
        }

        /// <summary>
        /// Checks if this system can be executed.
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public override bool CanExecute(double time)
        {
            if (nextRegen <= AlmiranteEngine.Time.Total)
            {
                nextRegen = AlmiranteEngine.Time.Total + 1;
                return true;
            }
            return false;
        }
    }
}
