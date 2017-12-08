using System;
using System.Collections.Generic;
using DbConnection;

namespace _10_CrudMySQL
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Welcome! Please choose and action: 'Read', 'Add', 'Delete', 'Update' or 'Quit'");
            string Action = "";
            while(Action != "Quit"){
                Action = Console.ReadLine();
                System.Console.WriteLine($"You have chosen: '{Action}'");
                switch(Action){
                    case "Read":
                        Read();
                        break;
                    case "Add":
                        Create();
                        break;
                    case "Delete":
                        Delete();
                        break;
                    case "Update":
                        Update();
                        break;
                    case "Quit":
                        
                        break;
                    default:
                        System.Console.WriteLine("That is an invalid option. Please try again.");
                        break;
                }
            }
        }
            public static void Read(){
                System.Console.WriteLine("Here are all of the current Users");
                List <Dictionary<string, object>> Users = DbConnector.Query("SELECT * FROM Users;");
                    for (int i = 0; i < Users.Count; i++){
                        System.Console.WriteLine(Users[i]["idUsers"]+ ": " + Users[i]["first_name"]+ " " + Users[i]["last_name"] + " " + Users[i]["favorite_num"]);
                    }
                    System.Console.WriteLine("What would you like to do now? 'Read', 'Add', 'Delete', 'Update' or 'Quit'");
            }
            public static void Create(){
                Read();
                System.Console.WriteLine("Add a user:");
                System.Console.WriteLine("First Name:");
                string first_name = System.Console.ReadLine();
                System.Console.WriteLine("Last Name:");
                string last_name = System.Console.ReadLine();
                System.Console.WriteLine("Favorite Number:");
                string favorite_num = System.Console.ReadLine();
                
                DbConnector.Execute($"INSERT INTO Users (first_name, last_name, favorite_num, created_at, updated_at) VALUES ('{first_name}', '{last_name}', '{favorite_num}', NOW(), NOW())"); 
                Read();
                System.Console.WriteLine("What would you like to do now? 'Read', 'Add', 'Delete', 'Update' or 'Quit'");
            }
            public static void Delete(){
                Read();
                System.Console.WriteLine("Please select the number of the user would you like to delete.");
                string UserID = Console.ReadLine();
                DbConnector.Execute($"DELETE FROM Users WHERE idUsers = {UserID};");
                Read();
                System.Console.WriteLine("What would you like to do now? 'Read', 'Add', 'Delete', 'Update' or 'Quit'");
            }
            public static void Update(){
                Read();
                System.Console.WriteLine("Please select the number of the user would you like to update.");
                string UserID = Console.ReadLine();
                System.Console.WriteLine("First Name:");
                string first_name = System.Console.ReadLine();
                System.Console.WriteLine("Last Name:");
                string last_name = System.Console.ReadLine();
                System.Console.WriteLine("Favorite Number:");
                string favorite_num = System.Console.ReadLine();
                
                DbConnector.Execute($"UPDATE Users SET first_name='{first_name}', last_name='{last_name}', favorite_num='{favorite_num}', updated_at=NOW() WHERE idUsers = {UserID};");
                Read();
                System.Console.WriteLine("What would you like to do now? 'Read', 'Add', 'Delete', 'Update' or 'Quit'");  
            }

    } 
}        
