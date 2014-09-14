using Almirante.Engine.Core;
using Almirante.Entities.Components;
using Almirante.Entities.Systems;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Example.Entities.Systems
{
    /// <summary>
    /// This is the entity system that controls the player movement.
    /// </summary>
    public class ControlSystem : EntitySystem
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="time"></param>
        protected override void OnExecute(double time)
        {
            // Find the player 
            var entity = this.GetEntityByTag("player");
            if (entity == null)
            {
                return;
            }

            // Get the position component from the player
            var position = entity.GetComponent<PositionComponent>();

            // Movement logic
            Vector2 movement = Vector2.Zero;
            if (AlmiranteEngine.Input.Keyboard[Keys.Up].Down)
            {
                movement.Y = -100.0f;
            }
            if (AlmiranteEngine.Input.Keyboard[Keys.Down].Down)
            {
                movement.Y = 100.0f;
            }
            if (AlmiranteEngine.Input.Keyboard[Keys.Left].Down)
            {
                movement.X = -100.0f;
            }
            if (AlmiranteEngine.Input.Keyboard[Keys.Right].Down)
            {
                movement.X = 100.0f;
            }

            position.X = position.X + (movement.X * (float) time);
            position.Y = position.Y + (movement.Y * (float) time);
        }
    }
}
