﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenWebNetDataContract.Model;
using InterfaceServiceLegrand;

namespace ServiceLegrand
{
    public class ServiceLegrand : IServiceLegrand
    {
        public Home serviceHome(string order, Home home, Dictionary<object, object> dico) {
            //Création Home
            Home loicHome = new Home(0, "La Maison de Loic", new List<Room>(), (float)150, (float)1500);

            Room cuisine = new Room(0, "Cuisine", (float)50, new List<Equipment>(), new Consumption(0, "200", "200"));

            cuisine.addEquipment(new Light(0, "Light1", false, 1, 50));
            cuisine.addEquipment(new Light(1, "Light2", false, 2, 50));
            cuisine.addEquipment(new Light(2, "Light3", false, 3, 50));

            Room salleDeBain = new Room(0, "Salle de Bain", (float)50, new List<Equipment>(), new Consumption(0, "200", "200"));
              
            salleDeBain.addEquipment(new Light(0, "Light1", false, 1, 50));
            salleDeBain.addEquipment(new Light(0, "Light2", false, 2, 50));
            salleDeBain.addEquipment(new Light(0, "Light3", false, 3, 50));
              
            Room salon = new Room(0, "Salon", (float)50, new List<Equipment>(), new Consumption(0, "200", "200"));
              
            salon.addEquipment(new Light(0, "Light1", false, 1, 50));
            salon.addEquipment(new Light(0, "Light2", false, 2, 50));
            salon.addEquipment(new Light(0, "Light3", false, 3, 50));
              
            loicHome.addRoom(cuisine);
            loicHome.addRoom(salleDeBain);
            loicHome.addRoom(salon);
            return loicHome;
        }

        public Equipment serviceEquipment(string order, Home home, Dictionary<object, object> dico) {
            throw new NotImplementedException();
        }

        public String getMot() {
            return "Hey!";
        }
    }
}
