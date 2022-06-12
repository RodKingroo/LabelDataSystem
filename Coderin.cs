using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabelBaseSys
{
    internal class Coderin
    {
        private static char Encod(char text, ushort key, string mis)
        {

            if (mis == "Destrict") text = (char)(text ^ key);

            return text;
        }
        public string EncodDestruct(string textOuter, ushort key)
        {
            var ch = textOuter.ToArray();
            string newTextOuter = "";
            foreach (var c in ch) newTextOuter += Encod(c, key, "Destrict");
            return newTextOuter;

        }
    }
}
