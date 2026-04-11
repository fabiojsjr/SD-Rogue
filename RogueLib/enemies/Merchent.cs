using System.Numerics;

namespace RogueLib.enemies
{
    internal class Merchent
    {
        private Vector2 pos;
        private string v1;
        private int v2;

        public Merchent(Vector2 pos, string v1, int v2)
        {
            this.pos = pos;
            this.v1 = v1;
            this.v2 = v2;
        }
    }
}