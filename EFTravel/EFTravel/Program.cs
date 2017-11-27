using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFTravel
{
    class Program
    {
        static void Main(string[] args)
        {
           
            ConsoleKeyInfo keyInfo;
         
           

            

            do
            {
                Console.WriteLine();
                Console.WriteLine("Make a choice [0-4]");
                Console.WriteLine("1. New Trip");
                Console.WriteLine("2. List all trips (with Ids)");
                Console.WriteLine("3. Delete trip by Id");
                Console.WriteLine("4. Modify a trip by Id");
                Console.WriteLine("0. Exit");
                Console.WriteLine("Enter your choice: ");
                Console.WriteLine();
                keyInfo = Console.ReadKey();
                switch (keyInfo.Key)
                {
                    
                    case ConsoleKey.D1:
                        //add new trip
                        Console.WriteLine();
                        Trip trip = new Trip();
                        Console.Write("Enter Traveler Name: ");          
                        trip.TravelerName = Console.ReadLine();
                        Console.WriteLine();
                        Console.Write("Enter From Where: ");                        
                        trip.FromWhere = Console.ReadLine();
                        Console.WriteLine();
                        Console.Write("Enter To Where: ");
                        trip.ToWhere = Console.ReadLine();
                        Console.WriteLine();
                        Console.Write("Enter Departure Date: ");
                        trip.DepartureDate = DateTime.Parse(Console.ReadLine());

                        using (TravelDbContext ctx = new TravelDbContext())
                        {
                            ctx.Trips.Add(trip); //schedules trip to be added to table
                            ctx.SaveChanges();
                            Console.WriteLine("Trip saved!");
                        }
                        break;
                    case ConsoleKey.D2:
                        //list all trips with Ids
                        Console.WriteLine();
                        using (TravelDbContext ctx = new TravelDbContext())
                        {
                            var trips = (from t in ctx.Trips select t).ToList<Trip>();

                            foreach (var tr in trips)
                            {                               
                                Console.WriteLine("Trip #{0} has {1} travelling from {2} to {3} on {4}",
                                    tr.TripId, tr.TravelerName, tr.FromWhere, tr.ToWhere,
                                    tr.DepartureDate.ToShortDateString());
                            }
                        }
                        break;
                    case ConsoleKey.D3:
                        Console.WriteLine();
                        //delete trip by ID
                        using (TravelDbContext ctx = new TravelDbContext())
                        {
                            //delete method 1: fetch then delete
                            Console.WriteLine("Select an Id to delete: ");
                            int tripId = Convert.ToInt32(Console.ReadLine());
                            var tripList = (from t in ctx.Trips where t.TripId == tripId select t).ToList<Trip>();
                            if (tripList.Count == 0)
                            {
                                Console.WriteLine("No record found to delete");
                            }
                            else
                            {                                
                                Trip ttd = tripList[0];
                                ctx.Trips.Remove(ttd);
                                ctx.SaveChanges();
                                Console.WriteLine("Trip successfully deleted");

                            }  
                        }
                        break;
                    case ConsoleKey.D4:
                        Console.WriteLine();
                        //modify a trip by ID
                        using (TravelDbContext ctx = new TravelDbContext())
                        {
                            Console.Write("Select Trip ID: ");
                            int tripId = Convert.ToInt32(Console.ReadLine());
                            var trips = (from t in ctx.Trips where t.TripId == tripId select t).ToList<Trip>();
                            if (trips.Count == 0)
                            {
                                Console.WriteLine("Unable to find record with Id=" + tripId);
                                continue;
                            }

                            Trip updateTrip = trips[0];
                            Console.WriteLine();
                            Console.WriteLine("Make a selection");
                            Console.WriteLine("5. Update Traveler Name");
                            Console.WriteLine("6. Update From Where");
                            Console.WriteLine("7. Update To Where");
                            Console.WriteLine("8. Update Departure Date");
                            ConsoleKeyInfo KeyClicked;
                            KeyClicked = Console.ReadKey();
                            switch (KeyClicked.Key)
                            {
                                case ConsoleKey.D5:
                                    //update name
                                    Console.WriteLine("Enter a new name");
                                    updateTrip.TravelerName = Console.ReadLine();
                                    ctx.SaveChanges();
                                    Console.WriteLine("Successfully updated!");
                                    break;
                                case ConsoleKey.D6:
                                    //update from where
                                    Console.WriteLine("Enter a new departure location");
                                    updateTrip.FromWhere = Console.ReadLine();
                                    ctx.SaveChanges();
                                    Console.WriteLine("Successfully updated!");
                                    break;
                                case ConsoleKey.D7:
                                    //update to where
                                    Console.WriteLine("Enter a new destination");
                                    updateTrip.ToWhere = Console.ReadLine();
                                    ctx.SaveChanges();
                                    Console.WriteLine("Successfully updated!");
                                    break;
                                case ConsoleKey.D8:
                                    //update date
                                    Console.WriteLine("Enter a new departure date");
                                    updateTrip.DepartureDate = DateTime.Parse(Console.ReadLine());
                                    ctx.SaveChanges();
                                    Console.WriteLine("Successfully updated!");
                                    break;
                                default: Console.WriteLine("Select between 5-8");
                                    break;
                            }
                        }
                        break;
                    default:
                        Console.WriteLine();
                        Console.WriteLine("Press 0 to exit");
                        break;
                }
            }
            while (keyInfo.Key != ConsoleKey.D0);
        }
    }
}
