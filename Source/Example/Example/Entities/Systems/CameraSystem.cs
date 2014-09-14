using Almirante.Engine.Core;
using Almirante.Entities.Components;
using Almirante.Entities.Systems;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Example.Entities.Systems
{
    /// <summary>
    /// Camera system
    /// </summary>
    public class CameraSystem : EntitySystem
    {
        /// <summary>
        /// Executes the system
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

            // Updates the camera with the player position
            AlmiranteEngine.Camera.Position = new Vector2(position.X, position.Y);
        }
    }
}
