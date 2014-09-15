using Almirante.Engine.Core;
using Almirante.Entities;
using Almirante.Entities.Filters;
using Almirante.Entities.Systems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Example.Entities.Systems
{
    /// <summary>
    /// Message flashing system
    /// </summary>
    public class FlashingSystem : EntityProcessor
    {
        /// <summary>
        /// Flashing system
        /// </summary>
        public FlashingSystem()
            : base(Filter.Create().Is(typeof(FlashMessage)))
        {
        }

        /// <summary>
        /// Process messages
        /// </summary>
        /// <param name="entity"></param>
        protected override void Process(Entity entity)
        {
            var message = entity as FlashMessage;
            if (message != null)
            {
                message.Fade.Tweener.Update(AlmiranteEngine.Time.Frame);
                if (message.Fade.Tweener.IsFinished)
                {
                    entity.Kill();
                    return;
                }

                message.Dislocation.Tweener.Update(AlmiranteEngine.Time.Frame);
                message.Position.X = message.Dislocation.Tweener.Value.X;
                message.Position.Y = message.Dislocation.Tweener.Value.Y;
            }
        }
    }
}
