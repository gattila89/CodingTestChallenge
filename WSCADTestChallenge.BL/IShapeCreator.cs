using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSCADTestChallenge.BL
{
    public interface IShapeCreator
    {
        Shape ShapeFactory(string type);
    }
}
