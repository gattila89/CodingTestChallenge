using System.ComponentModel;
using System.Drawing;
using System.Reflection.PortableExecutable;
using System.Text.Json;

namespace WSCADTestChallenge.BL
{
    public abstract class Shape
    {

        public string type { get; set; }
        public string color { get; set; }
        public bool filled { get; set; } = false;
    }
}