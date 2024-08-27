using KomodoInsuranceApp.Models;
using KomodoInsuranceApp.Repositories;

namespace KomodoInsuranceApp
{
    class Program
    {
        static void Main(string[] args)
        {
            BadgeRepository badgeRepo = new BadgeRepository();
            bool running = true;

            while (running)
            {
                Console.WriteLine("Hello Security Admin, What would you like to do?");
                Console.WriteLine("1. Add a badge");
                Console.WriteLine("2. Edit a badge");
                Console.WriteLine("3. List all Badges");
                Console.WriteLine("4. Exit");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddBadge(badgeRepo);
                        break;
                    case "2":
                        EditBadge(badgeRepo);
                        break;
                    case "3":
                        ListAllBadges(badgeRepo);
                        break;
                    case "4":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static void AddBadge(BadgeRepository badgeRepo)
        {
            Console.WriteLine("What is the number on the badge:");
            int badgeID = int.Parse(Console.ReadLine());

            Console.WriteLine("List a door that it needs access to:");
            string door = Console.ReadLine();

            Badge badge = new Badge { BadgeID = badgeID, Name = "Badge " + badgeID };
            badge.DoorNames.Add(door);

            bool addingDoors = true;
            while (addingDoors)
            {
                Console.WriteLine("Any other doors(y/n)?");
                string response = Console.ReadLine();
                if (response.ToLower() == "y")
                {
                    Console.WriteLine("List a door that it needs access to:");
                    door = Console.ReadLine();
                    badge.DoorNames.Add(door);
                }
                else
                {
                    addingDoors = false;
                }
            }

            badgeRepo.AddBadge(badge);
        }

        static void EditBadge(BadgeRepository badgeRepo)
        {
            Console.WriteLine("What is the badge number to update?");
            int badgeID = int.Parse(Console.ReadLine());

            if (badgeRepo.GetAllBadges().ContainsKey(badgeID))
            {
                Console.WriteLine($"{badgeID} has access to doors {string.Join(", ", badgeRepo.GetAllBadges()[badgeID].DoorNames)}.");
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("1. Remove a door");
                Console.WriteLine("2. Add a door");

                string choice = Console.ReadLine();
                if (choice == "1")
                {
                    Console.WriteLine("Which door would you like to remove?");
                    string door = Console.ReadLine();
                    badgeRepo.GetAllBadges()[badgeID].DoorNames.Remove(door);
                    Console.WriteLine("Door removed.");
                }
                else if (choice == "2")
                {
                    Console.WriteLine("List a door that it needs access to:");
                    string door = Console.ReadLine();
                    badgeRepo.GetAllBadges()[badgeID].DoorNames.Add(door);
                }
            }
            else
            {
                Console.WriteLine("Badge not found.");
            }
        }

        static void ListAllBadges(BadgeRepository badgeRepo)
        {
            Console.WriteLine("Badge #\tDoor Access");
            foreach (var badge in badgeRepo.GetAllBadges())
            {
                Console.WriteLine($"{badge.Key}\t{string.Join(", ", badge.Value.DoorNames)}");
            }
        }
    }
}
