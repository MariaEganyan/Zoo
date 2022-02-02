using System;
using System.Collections.Generic;
using System.Text;

namespace Zoo_Maria_Eganyan
{
    public class AnimalDescription:Attribute
    {
        private string Description { get; set; }
        public AnimalDescription(string description)
        {
            this.Description = description;
        }
    }
}
