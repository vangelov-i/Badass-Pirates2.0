namespace Badass_Pirates.Handler.CombatHandler
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Badass_Pirates.GameObjects.Players;
    using Badass_Pirates.GameObjects.Ships;

    using Microsoft.Xna.Framework;

    public class CombatHandler
    {
        public void OrdinalAttack(Player player, Vector2 position)
        {
            //TODO not implemented at all
            int x = 0;
            int y = 0;
            Vector2 pos = player.Ship.Position;
            pos.X = x;
            pos.Y = y;
        }
    }
}
