﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLeGrand.Model
{
    class Day
    {

        public Day()
        {

        }

        public Day(int id, String name)
        {
            this.id = id;
            this.name = name;
        }

        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private String name;

        public String Name
        {
            get { return name; }
            set { name = value; }
        }
    }
}


