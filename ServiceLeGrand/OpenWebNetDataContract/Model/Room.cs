﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OpenWebNetDataContract.Model
{
    [DataContract]
    public class Room
    {

        public Room()
        {

        }

        public Room(int id, String name, float surface, List<Equipment> equipments, Consumption consumption, Home _parent)
        {
            this.id = id;
            this.name = name;
            this.surface = surface;
            this.equipments = equipments;
            this.consumption = consumption;
            this._parent = _parent;
        }

        [DataMember]
        private Home _parent;

        public Home _Parent
        {
            get { return _parent; }
            set { _parent = value; }
        }
        

        [DataMember]
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        [DataMember]
        private String name;

        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        [DataMember]
        private float surface;

        public float Surface
        {
            get { return surface; }
            set { surface = value; }
        }

        [DataMember]
        private List<Equipment> equipments;

        public List<Equipment> Equipments
        {
            get { return equipments; }
            set { equipments = value; }
        }

        [DataMember]
        private Consumption consumption;

        public Consumption Consumption
        {
            get { return consumption; }
            set { consumption = value; }
        }

        Room add(String name, float surface, List<Equipment> equipments, Consumption consumption)
        {
            CAD.SQLite db;
            try
            {
                //Ajout de la room en base
                db = CAD.SQLite.getInstance();

                String InsertQuery = "INSERT INTO Room (Name, Surface) VALUES ('" + name + "', '" + surface + "');";
                int rowsUpdated = db.ExecuteNonQuery(InsertQuery);

                //Recuperation de l'id de la room (mail doit etre unique)
                if (rowsUpdated > 0)
                {
                    DataTable result;
                    String selectQuery = "SELECT Id FROM Room WHERE name = '" + name + "'";
                    result = db.GetDataTable(selectQuery);
                    int id = 0;

                    foreach (DataRow r in result.Rows)
                    {
                        id = int.Parse(r["Id"].ToString());
                    }



                    //Creation de lobjet Room et link avec Equipement
                    if (id != 0)
                    {
                        if (equipments != null && equipments.Count > 0)
                        {
                            foreach (Equipment equipment in equipments)
                            {
                                if (equipment is Radiator)
                                {
                                    Radiator radiator = (Radiator)equipment;
                                    InsertQuery = "INSERT INTO Radiator (ID_Room) VALUES ('" + id + "') WHERE ID = '" + radiator.Id + "';";
                                    rowsUpdated = db.ExecuteNonQuery(InsertQuery);
                                    if (rowsUpdated > 0)
                                    {
                                        Console.WriteLine("Radiator " + radiator.Id + " updated");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Failed to link Radiator with Room");
                                    }
                                }
                                else if (equipment is Light)
                                {
                                    Light light = (Light)equipment;
                                    InsertQuery = "INSERT INTO Light (ID_Room) VALUES ('" + id + "') WHERE ID = '" + light.Id + "';";
                                    rowsUpdated = db.ExecuteNonQuery(InsertQuery);
                                    if (rowsUpdated > 0)
                                    {
                                        Console.WriteLine("Light " + light.Id + " updated");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Failed to link Light with Room");
                                    }
                                }
                                else if (equipment is Shutter)
                                {
                                    Shutter shutter = (Shutter)equipment;
                                    InsertQuery = "INSERT INTO Shutter (ID_Room) VALUES ('" + id + "') WHERE ID = '" + shutter.Id + "';";
                                    rowsUpdated = db.ExecuteNonQuery(InsertQuery);
                                    if (rowsUpdated > 0)
                                    {
                                        Console.WriteLine("Shutter " + shutter.Id + " updated");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Failed to link Shutter with Room");
                                    }
                                }
                                else if (equipment is Alarm)
                                {
                                    Alarm alarm = (Alarm)equipment;
                                    InsertQuery = "INSERT INTO Alarm (ID_Room) VALUES ('" + id + "') WHERE ID = '" + alarm.Id + "';";
                                    rowsUpdated = db.ExecuteNonQuery(InsertQuery);
                                    if (rowsUpdated > 0)
                                    {
                                        Console.WriteLine("Alarm " + alarm.Id + " updated");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Failed to link Alarm with Room");
                                    }
                                }
                            }

                            if (consumption != null) {
                                InsertQuery = "INSERT INTO Consumption (ID_Room) VALUES ('" + id + "') WHERE ID = '" + consumption.Id + "';";
                                rowsUpdated = db.ExecuteNonQuery(InsertQuery);
                                if (rowsUpdated > 0)
                                {
                                    Console.WriteLine("Consumption " + consumption.Id + " updated");
                                }
                                else
                                {
                                    Console.WriteLine("Failed to link Consumption with Room");
                                }
                            }
                        }

                        Room room = new Room(id, name, surface, equipments, consumption);
                        Console.WriteLine("New Room Created");
                        return room;
                    }
                    else
                    {
                        Console.WriteLine("Erreur creation Room");
                        return null;
                    }
                }
                else
                {
                    Console.WriteLine("Erreur creation Room");
                    return null;
                }
            }
            catch (Exception fail)
            {
                String error = "Erreur creation Room - The following error has occurred:\n\n";
                error += fail.Message.ToString() + "\n";
                Console.WriteLine(error);
                return null;
            }
        }

        Boolean remove(Room room)
        {
            throw new NotImplementedException();
        }

        Room update(Room room)
        {
            throw new NotImplementedException();
        }

    }
}
