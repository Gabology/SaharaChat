using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SaharaChat.Models
{
    public class Avatar
    {
        public Avatar(string name, string color)
        {
            Name = name;
            Color = color;
        }

        public string Name { get; private set; }
        public string Color { get; private set; }
    }
}