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
        /// Health regenerators.
        /// This system will filter all entities that are composed of both health, and health regen components.
        /// </summary>
        public HealthRegenSystem()
            : base(Filter.Create().Has(typeof(HealthComponent), typeof(HealthRegenComponent)))
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entity"></param>
        protected override void Process(Entity entity)
        {
            var health = entity.GetComponent<HealthComponent>();
            var regen = entity.GetComponent<HealthRegenComponent>();

            if (health.Value >= health.Maximum)
            {
                return;
            }

            var dif = regen.Value;
            if (health.Value + regen.Value > health.Maximum)
            {
                dif = health.Maximum - health.Value;
            }

            health.Value += dif;

            var message = entity.Manager.Create<FlashMessage>(null, "flashmessage");

            message.Position.X = entity.Position.X + 20;
            message.Position.Y = entity.Position.Y - 32;
            
            message.Fade.Time = 2;
           
            message.Movement.Time = 2;
            message.Movement.Finish = new Vector2(entity.Position.X + 20, entity.Position.Y - 52);

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
