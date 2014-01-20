﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLeGrand.Model
{
    class Light : Equipment
    {
        public Light(int id, String name, Boolean state, int number, int intensity)
        {
            this.id = id;
            this.name = name;
            this.state = state;
            this.number = number;
            this.intensity = intensity;
        }

        private int intensity;

        public int Intensity
        {
            get { return intensity; }
            set { intensity = value; }
        }
        
    }
}