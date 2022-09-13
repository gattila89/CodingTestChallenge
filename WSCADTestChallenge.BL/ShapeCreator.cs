using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSCADTestChallenge.BL
{
    public class ShapeCreator : IShapeCreator
    {
        public Shape ShapeFactory(string type)
        {
            switch(type)
            {
                case "line": return new Line();
                case "circle": return new Circle();
                case "triangle": return new Triangle();
                default: throw new ArgumentException("Invalid type", "type");
            }
        }
    }
}
