using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayersGuide.Classes
{
    /// <summary>
    /// The Arrow class represents an arrow with various properties such as length, head type, and fletching type.
    /// It provides methods to prompt the user for input regarding these properties and calculate the cost of the arrow.
    /// </summary>
    public enum ArrowHead
    {
        Steel,
        Wood,
        Obsidian
    }

    public enum ArrowFletching
    {
        Plastic,
        TurkeyFeather,
        GooseFeather,
    }

    public class Arrow
    {

        private int _length;
        private ArrowHead _arrowHead;
        private ArrowFletching _arrowFletching;

        public Arrow(int length, ArrowFletching arrowFletching, ArrowHead arrowHead)
        {
            _length = length;
            _arrowHead = arrowHead;
            _arrowFletching = arrowFletching;

        }

        public int getLength() => _length;
        public ArrowHead getHeadType() => _arrowHead;
        public ArrowFletching getFletchingType() => _arrowFletching;

        public int GetCost()
        {
            int arrowHeadCost = _arrowHead switch
            {
                ArrowHead.Steel => 10,
                ArrowHead.Wood => 3,
                ArrowHead.Obsidian => 5,
                _ => 0
            };

            int fletchingCost = _arrowFletching switch
            {
                ArrowFletching.Plastic => 10,
                ArrowFletching.TurkeyFeather => 5,
                ArrowFletching.GooseFeather => 3,
                _ => 0
            };

            double shaftCost = _length * 0.05;

            return (int)(arrowHeadCost + fletchingCost + shaftCost);
        }

    }
}
