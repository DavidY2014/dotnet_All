using System;
using System.Collections.Generic;
using System.Text;
using Advanced.Framework;

namespace AdvancedNet.Models
{
    [Custom]
    public class People
    {
        public int Id { get; set; } //property
        public string Name { get; set; }

        public string Age; //field
    }
}
