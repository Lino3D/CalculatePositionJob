using SQLPositionFinder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleLibTestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            PositionFinder finder = new PositionFinder();
            // Z tym działa
            //   var result = finder.FindFloor("64ae0c861fb0,-87;28be9bd2090e,-90;");

            var result = finder.FindFloor("64ae0c8461fb0,-82;28be9bd2090e,-70;");
            string domek = "";
        }
    }
}
