using System.Runtime.InteropServices;
using System.Reflection.Emit;
using System.Data;
using Internal;
using System;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text;
using System.Net.Http.Json;
using Newtonsoft.Json;
using static System.Console;
using DnDTeamGame.Data;
using DnDTeamGame.Data.Entities;
using DnDTeamGame.WebApi;
using DnDTeamGame.Models.CharacterModels;
using DnDTeamGame.Models.UserModels;
using DnDTeamGame.Models.Games;
using DnDTeamGame.Models.HairStyleModels;
using DnDTeamGame.Models.HairColorModels;
using DnDTeamGame.Models.BodyTypeModels;
using DnDTeamGame.Models.CharacterClassModels;
using DnDTeamGame.Models.AbilityModels;
using DnDTeamGame.Models.ArmourModels;
using DnDTeamGame.Models.ConsumableModels;
using DnDTeamGame.Models.VehicleModels;
using System.Text;
using DnDTeamGame.Models.WeaponModels;
using DnDTeamGame.Models.MapModels;


public class ProgramUI
{
    private readonly ApplicationDbContext _dbContext;

    HttpClient httpClient = new HttpClient();
    private bool IsRunning = true;

    public void RunApplication()
    {
        Run();
    }

    public void Run()
    {
        while (IsRunning)
        {
            Clear();
            // BackgroundColor = ConsoleColor.Blue;
            ForegroundColor = ConsoleColor.DarkGreen;
            WriteLine("|===========================================|\n" +
                     "|                                           |\n" +
                     "|  Welcome to The New Dungeons and Dragons  |\n" +
                     "|  A Game of Fantasy and Destiny            |\n" +
                     "|       Made By: PutSomeRespectOnIt         |\n" +
                     "|                                           |\n" +
                     "|===========================================|\n" +
                     "|  What Would You Like To Do?               |\n" +
                     "|                                           |");
            ConsoleKeyInfo key;
            int option = 1;
            bool isSelected = false;
            (int left, int top) = Console.GetCursorPosition();
            string color = "🐉\u001b[35m";

            while(!isSelected)
            {   Console.SetCursorPosition(left, top);
                WriteLine($"|{(option == 1 ? color : "  ")}1. Manage Users\u001b[32m                          |");
                WriteLine($"|{(option == 2 ? color : "  ")}2. Manage A Game\u001b[32m                         |");
                WriteLine($"|{(option == 3 ? color : "  ")}3. Start Game\u001b[32m                            |");
                WriteLine($"|{(option == 4 ? color : "  ")}4. Manage Game Item Details\u001b[32m              |");
                WriteLine($"|{(option == 5 ? color : "  ")}5. Close Application\u001b[32m                     |");
                WriteLine("|                                           |\u001b[32m");
                WriteLine("|===========================================|\u001b[32m");
            try
            {
                key = Console.ReadKey(true); 

                switch (key.Key)
                {
                    case ConsoleKey.DownArrow:
                        option = (option == 5 ? 1 : option + 1);
                        break;

                    case ConsoleKey.UpArrow:
                        option = (option == 1 ? 5 : option -1);
                        break;

                    case ConsoleKey.Enter:
                        isSelected = true;
                        break;

                    default:
                        WriteLine("Invalid Selection Please Try Again");
                        PressAnyKeyToContinue();
                        break;
                }
            }
            catch (Exception e)
            {
                System.Console.WriteLine("Bad selection.. Press any key to continue");
                Console.ReadKey();
            }
                
            }

            try
            {
                var userInput = option;
                switch (userInput)
                {
                    case 1:
                        ManageUsers();
                        break;

                    case 2:
                        ManageAGame();
                        break;

                    case 3:
                        StartAGame();
                        break;

                    case 4:
                        ManageGameItemDetails();
                        break;

                    case 5:
                        IsRunning = ExitApplication();
                        break;

                    default:
                        WriteLine("Invalid Selection Please Try Again");
                        PressAnyKeyToContinue();
                        break;
                }
            }
            catch (Exception e)
            {
                System.Console.WriteLine("Bad selection.. Press any key to continue");
                Console.ReadKey();
            }
        }
    }

    private void ManageUsers()
    {
        Clear();
        ForegroundColor = ConsoleColor.Red;
        WriteLine("|=======================================|\n" +
                    "|                                       |\n" +
                    "|  DnDTeamGame User Management          |\n" +
                    "|  What would you like to do with the   |\n" +
                    "|  Users?                               |\n" +
                    "|=======================================|\n" +
                    "|                                       |");

        ConsoleKeyInfo key;
        int option = 1;
        bool isSelected = false;
        (int left, int top) = Console.GetCursorPosition();
        string color = "💀\u001b[33m";

            while(!isSelected)
            {   Console.SetCursorPosition(left, top);
                WriteLine($"|{(option == 1 ? color : "  ")}1. View All Users \u001b[31m                   |");
                WriteLine($"|{(option == 2 ? color : "  ")}2. View User By Id\u001b[31m                   |");
                WriteLine($"|{(option == 3 ? color : "  ")}3. Update Existing User\u001b[31m              |");
                WriteLine($"|{(option == 4 ? color : "  ")}4. Add a New User\u001b[31m                    |");
                WriteLine($"|{(option == 5 ? color : "  ")}5. Delete a User\u001b[31m                     |");
                WriteLine($"|{(option == 6 ? color : "  ")}6. Return to Main Menu\u001b[31m               |");
                WriteLine("|                                       |\u001b[31m");
                WriteLine("|=======================================|\u001b[31m");
            try
            {
                key = Console.ReadKey(true); 

                switch (key.Key)
                {
                    case ConsoleKey.DownArrow:
                        option = (option == 6 ? 1 : option + 1);
                        break;

                    case ConsoleKey.UpArrow:
                        option = (option == 1 ? 6 : option -1);
                        break;

                    case ConsoleKey.Enter:
                        isSelected = true;
                        break;

                    default:
                        WriteLine("Invalid Selection Please Try Again");
                        PressAnyKeyToContinue();
                        break;
                }
            }
            catch (Exception e)
            {
                System.Console.WriteLine("Bad selection.. Press any key to continue");
                Console.ReadKey();
            }
                
            }            
        
        try
        {
            var userInput = option;
            switch (userInput)
            {
                case 1:
                    ViewAllUsers();
                    break;

                case 2:
                    ViewUserById();
                    break;

                case 3:
                    UpdateAnExistingUser();
                    break;

                case 4:
                    AddANewUser();
                    break;

                case 5:
                    DeleteExistingUser();
                    break;

                case 6:
                    Run();
                    break;

                default:
                    System.Console.WriteLine("Invalid Entry Please Try Again");
                    PressAnyKeyToContinue();
                    break;
            }
        }
        catch (Exception e)
        {
            System.Console.WriteLine("Bad selection.. Press any key to continue");
            Console.ReadKey();
        }            
        
    }

    private void ViewUserById()
    {
        Clear();
        ForegroundColor = ConsoleColor.Green;
        System.Console.WriteLine("Please enter a UserId to look up a User.");
        var userId = int.Parse(Console.ReadLine()!);

        HttpClient httpClient = new HttpClient();

        HttpResponseMessage response = httpClient.GetAsync($"http://localhost:5211/api/User/{userId}").Result;
        if (response.IsSuccessStatusCode)
        {
            UserDetailUI users = response.Content.ReadAsAsync<UserDetailUI>().Result;
            // var users = JsonSerializer.Deserialize<UserDetailUI>(content);
            // var users = _userService.GetUserByIdAsync(userId).Result;
            // System.Console.WriteLine($"Welcome to the Game {users.FirstName} {users.LastName}! Your UserName is - {users.UserName}");
            Clear();
            System.Console.WriteLine("|====================================================================|\n" +
                                    $"|  FirstName: {users.FirstName} || LastName: {users.LastName} || UserName: {users.UserName} \n" +
                                    $"|                                                                    |\n" +
                                    $"|====================================================================|\n");
            PressAnyKeyToContinue();
            ManageUsers();
        }
    }

    private void ViewAllUsers()
    {

    }

    private void UpdateAnExistingUser()
    {

    }

    private async void AddANewUser()
    {
        Clear();
        ForegroundColor = ConsoleColor.Magenta;
        WriteLine("|=======================================|\n" +
                    "|                                       |\n" +
                    "| Thanks for Choosing to Play!          |\n" +
                    "|  To begin what is your First Name?    |\n" +
                    "|                                       |\n" +
                    "|=======================================|\n");
        string userFirstName = Console.ReadLine();
        PressAnyKeyToContinue();
        Clear();
        ForegroundColor = ConsoleColor.Magenta;
        WriteLine("|=======================================|\n" +
                    "|                                       |\n" +
                    "|  What is your Last Name?              |\n" +
                    "|                                       |\n" +
                    "|=======================================|\n");
        string userLastName = Console.ReadLine();
        PressAnyKeyToContinue();
        Clear();
        ForegroundColor = ConsoleColor.Magenta;
        WriteLine("|=======================================|\n" +
                    "|                                       |\n" +
                    "|       Please enter a UserName:        |\n" +
                    "|                                       |\n" +
                    "|=======================================|\n");
        string newUserName = Console.ReadLine();
        PressAnyKeyToContinue();
        Clear();
        ForegroundColor = ConsoleColor.Magenta;
        WriteLine("|=======================================|\n" +
                    "|                                       |\n" +
                    "|    Please enter an Email Address:     |\n" +
                    "|                                       |\n" +
                    "|=======================================|\n");
        string userEmail = Console.ReadLine();
        PressAnyKeyToContinue();
        Clear();
        ForegroundColor = ConsoleColor.Magenta;
        WriteLine("|=======================================|\n" +
                    "|                                       |\n" +
                    "|    Please enter a Password:           |\n" +
                    "|                                       |\n" +
                    "|=======================================|\n");
        string userPassword = Console.ReadLine();
        PressAnyKeyToContinue();
        Clear();
        ForegroundColor = ConsoleColor.Magenta;
        WriteLine("|=======================================|\n" +
                    "|                                       |\n" +
                    "|    Please enter Confirm Password:     |\n" +
                    "|                                       |\n" +
                    "|=======================================|\n");
        string userConfirmPassword = Console.ReadLine();
        PressAnyKeyToContinue();

        HttpClient httpClient = new HttpClient();

        UserRegisterUI registerUser = new UserRegisterUI
        {
            UserName = newUserName,
            Password = userPassword,
            ConfirmPassword = userConfirmPassword,
            FirstName = userFirstName,
            LastName = userLastName,
            Email = userEmail
        };

        var userContent = new StringContent(JsonConvert.SerializeObject(registerUser), Encoding.UTF8, "application/json");

        HttpResponseMessage response = httpClient.PostAsync("http://localhost:5211/api/User/Register", userContent).Result;
        ReadKey();
        if (response.IsSuccessStatusCode)
        {
            UserDetailUI userCreated = response.Content.ReadAsAsync<UserDetailUI>().Result;
            Console.Clear();

            System.Console.WriteLine($"Welcome to the Game {registerUser.FirstName} {registerUser.LastName}! Your UserName is - {registerUser.UserName}");
            PressAnyKeyToContinue();
            ManageUsers();
        }
        else
        {
            Console.WriteLine("Internal server Error");
            PressAnyKeyToContinue();
        }
    }

    private void DeleteExistingUser()
    {
        Clear();
        ForegroundColor = ConsoleColor.DarkRed;
        WriteLine("|=======================================|\n" +
                    "|                                       |\n" +
                    "|  Please enter a UserId To Be Deleted: |\n" +
                    "|                                       |\n" +
                    "|=======================================|\n");
        int userId = int.Parse(Console.ReadLine()!);

        HttpClient httpClient = new HttpClient();

        HttpResponseMessage response = httpClient.DeleteAsync($"http://localhost:5211/api/User/{userId}").Result;

        if (response.IsSuccessStatusCode)
        {
            WriteLine($"User with the ID: {userId} was deleted successfully.");
        }
        else
        {
            WriteLine("Failed to delete the User. Status Code: " + response.StatusCode);
        }

        PressAnyKeyToContinue();
    }

    // ============= Game UI ========= \\

    private void ManageAGame()
    {
        Clear();
        ForegroundColor = ConsoleColor.White;
        WriteLine("|=======================================|\n" +
                    "|                                       |\n" +
                    "| Thanks for Choosing to Play!          |\n" +
                    "|  What would you like to do with the   |\n" +
                    "|  Game?                                |\n" +
                    "|=======================================|\n" +
                    "|                                       |\n" +
                    "|  1. View All Games                    |\n" +
                    "|  2. View Game By Id                   |\n" +
                    "|  3. Update Existing Game              |\n" +
                    "|  4. Add a New Game                    |\n" +
                    "|  5. Delete a Game                     |\n" +
                    "|  0. Return to Main Menu               |\n" +
                    "|=======================================|");
        try
        {
            var userInput = int.Parse(Console.ReadLine()!);
            switch (userInput)
            {
                case 1:
                    ViewAllGames();
                    break;

                case 2:
                    ViewGameById();
                    break;

                case 3:
                    UpdateAnExistingGame();
                    break;

                case 4:
                    AddANewGame();
                    break;

                case 5:
                    DeleteExistingGame();
                    break;

                case 0:
                    Run();
                    break;

                default:
                    System.Console.WriteLine("Invalid Entry Please Try Again");
                    PressAnyKeyToContinue();
                    break;
            }
        }
        catch (Exception e)
        {
            System.Console.WriteLine("Bad selection.. Press any key to continue");
            Console.ReadKey();
        }

    }

    private void DeleteExistingGame()
    {
        Clear();
        ForegroundColor = ConsoleColor.Green;
        WriteLine("Please enter the GameId of the game you want to delete:");
        int gameId = int.Parse(Console.ReadLine()!);

        HttpClient httpClient = new HttpClient();

        HttpResponseMessage response = httpClient.DeleteAsync($"http://localhost:5211/api/Game/{gameId}").Result;

        if (response.IsSuccessStatusCode)
        {
            WriteLine("Game deleted successfully.");
        }
        else
        {
            WriteLine("Failed to delete the game. Status Code: " + response.StatusCode);
        }

        PressAnyKeyToContinue();
    }


    private void AddANewGame()
    {
        Clear();
        ForegroundColor = ConsoleColor.DarkYellow;
        WriteLine("Enter the details for the new game:");

        Write("Game Name: ");
        string gameName = ReadLine()!;

        Write("Game Description: ");
        string gameDescription = ReadLine()!;
        {
            var newGame = new GameDetailUI
            {
                GameName = gameName,
                GameDescription = gameDescription
            };
            HttpClient httpClient = new HttpClient();

            var gameContent = new StringContent(JsonConvert.SerializeObject(newGame), Encoding.UTF8, "application/json");

            HttpResponseMessage response = httpClient.PostAsync("http://localhost:5211/api/Game", gameContent).Result;
            if (response.IsSuccessStatusCode)
            {
                WriteLine("new game added successfully");
            }
            else
            {
                WriteLine("Failed to add new Game");
            }
            PressAnyKeyToContinue();
        }
    }

    private void UpdateAnExistingGame()
    {
        Clear();
        ForegroundColor = ConsoleColor.DarkYellow;

        WriteLine("Enter the ID of the game you want to update:");
        int gameId = int.Parse(ReadLine()!);

        Write("Game Name: ");
        string gameName = ReadLine()!;

        Write("Game Description: ");
        string gameDescription = ReadLine()!;

        {
            var updatedGame = new GameDetailUI
            {
                GameId = gameId,
                GameName = gameName,
                GameDescription = gameDescription
            };

            HttpClient httpClient = new HttpClient();

            var updateContent = new StringContent(JsonConvert.SerializeObject(updatedGame), Encoding.UTF8, "application/json");

            HttpResponseMessage response = httpClient.PutAsync($"http://localhost:5211/api/Game", updateContent).Result;

            if (response.IsSuccessStatusCode)
            {
                WriteLine("Game is updated successfully.");
            }
            else
            {
                WriteLine("Failed to update the game. Status Code: " + response.StatusCode);
            }
        }

        PressAnyKeyToContinue();
    }

    private void ViewGameById()
    {
        Clear();
        ForegroundColor = ConsoleColor.Green;
        WriteLine("Please enter a GameId to look up a Games.");
        var gameId = int.Parse(Console.ReadLine()!);

        HttpClient httpClient = new HttpClient();

        HttpResponseMessage response = httpClient.GetAsync($"http://localhost:5211/api/Game/{gameId}").Result;
        if (response.IsSuccessStatusCode)
        {
            GameDetailUI games = response.Content.ReadAsAsync<GameDetailUI>().Result;
            WriteLine($"GameName: {games.GameName} \n GameDescription: {games.GameDescription} ");
            PressAnyKeyToContinue();
        }
    }

    private void ViewGameByIdForNewGame()
    {
        Clear();
        ForegroundColor = ConsoleColor.DarkMagenta;
        WriteLine("|=======================================|\n" +
                    "|                                       |\n" +
                    "|  Please enter a Game ID To Start:     |\n" +
                    "|                                       |\n" +
                    "|=======================================|\n");
        var gameId = int.Parse(Console.ReadLine()!);

        HttpClient httpClient = new HttpClient();

        HttpResponseMessage response = httpClient.GetAsync($"http://localhost:5211/api/Game/{gameId}").Result;
        if (response.IsSuccessStatusCode)
        {
            GameDetailUI game = response.Content.ReadAsAsync<GameDetailUI>().Result;
            WriteLine($"Thank you for choosing to Play: {game.GameName}");
            PressAnyKeyToContinue();
            Clear();
            WriteLine("=========================================================================================================================\n" +
                        "  \n" +
                       $"{game.GameDescription}\n" +
                        "     \n" +
                        "========================================================================================================================");
        }
    }

    private void ViewAllGames()
    {
        Clear();
        ForegroundColor = ConsoleColor.DarkMagenta;

        HttpClient httpClient = new HttpClient();

        HttpResponseMessage response = httpClient.GetAsync("http://localhost:5211/api/Game").Result;
        if (response.IsSuccessStatusCode)
        {
            List<GameDetailUI> games = response.Content.ReadAsAsync<List<GameDetailUI>>().Result;

            foreach (var game in games)
            {
                WriteLine($"|GameName: {game.GameName}                                                                                 |\n" +
                          "|                                                                                                                     |\n" +
                          "|GameDescription:                                                                                                     |\n" +
                          "|=====================================================================================================================|\n" +
                          "|  \n" +
                          " \n" +
                          $"  {game.GameDescription}\n" +
                          "|    \n" +
                          "|=====================================================================================================================|");
            }

            PressAnyKeyToContinue();
        }
    }

    private void StartAGame()
    {   
         Clear();
        ForegroundColor = ConsoleColor.DarkGray;
        WriteLine("|=============================================|\n" +
                "|                                             |\n" +
                "| In order to play a game please enter        |\n" +
                "|     your username to ensure proper access.  |\n" +
                "|                                             |\n" +
                "|=============================================|\n");
        string userName = Console.ReadLine();

        ForegroundColor = ConsoleColor.DarkGray;
        WriteLine("|=============================================|\n" +
                "|                                             |\n" +
                "| Please Enter your password to sign in to    |\n" +
                "| acces the Game you would like to play       |\n" +
                "|                                             |\n" +
                "|=============================================|\n");
        string userPassword = Console.ReadLine();

        ForegroundColor = ConsoleColor.DarkGray;
        WriteLine("|=============================================|\n" +
                "|                                             |\n" +
                "| Finally confirm your User Id to gain access |\n" +
                "| to the System.                              |\n" +
                "|                                             |\n" +
                "|=============================================|\n");
        int userId = int.Parse(Console.ReadLine()!);

        Clear();
        ForegroundColor = ConsoleColor.Cyan;
        WriteLine("|=======================================|\n" +
                    "|                                       |\n" +
                    "|  Let's Play A Game                    |\n" +
                    "|  Please choose one of the following:  |\n" +
                    "|                                       |\n" +
                    "|=======================================|\n" +
                    "|                                       |\n" +
                    "|  1. Start a Game                      |\n" +
                    "|  2. Create New Game                   |\n" +
                    "|  3. View Existing Game Character      |\n" +
                    "|  0. Return to Main Menu               |\n" +
                    "|=======================================|");
        try
        {
            var userInput = int.Parse(Console.ReadLine()!);
            switch (userInput)
            {
                case 1:
                    StartANewGame();
                    break;

                case 2:
                    AddANewGame();
                    break;

                case 3:
                    ViewCharacterById();
                    break;

                case 0:
                    Run();
                    break;

                default:
                    System.Console.WriteLine("Invalid Entry Please Try Again");
                    PressAnyKeyToContinue();
                    break;
            }
        }
        catch (Exception e)
        {
            System.Console.WriteLine("Bad selection.. Press any key to continue");
            Console.ReadKey();
        }
    }

    private void StartANewGame()
    {
        Clear();
        ViewGameByIdForNewGame();
        ForegroundColor = ConsoleColor.DarkCyan;
        System.Console.WriteLine("|===================================================|\n" +
                                 "|                                                   |\n" +
                                 "|  Will you rise to the challange or let the land   |\n" +
                                 "|      fall into Darkness?                          |\n" +
                                 "|===================================================|\n");
        PressAnyKeyToContinue();
        Clear();
        System.Console.WriteLine("|=======================================|\n" +
                                 "|                                       |\n" +
                                 "|  Please choose one of the following:  |\n" +
                                 "|                                       |\n" +
                                 "|=======================================|\n" +
                                 "|                                       |");
        ConsoleKeyInfo key;
        int option = 1;
        bool isSelected = false;
        (int left, int top) = Console.GetCursorPosition();
        string color = "🐉\u001b[35m";

        while(!isSelected)
        {   
            Console.SetCursorPosition(left, top);
                WriteLine($"|{(option == 1 ? color : "  ")}1. Create A New Character\u001b[36m           |");
                WriteLine($"|{(option == 2 ? color : "  ")}2. View Existing Game Character\u001b[36m      |");
                WriteLine($"|{(option == 3 ? color : "  ")}3. Return to Main Menu\u001b[36m               |");
                WriteLine("|                                       |\u001b[36m");
                WriteLine("|=======================================|\u001b[36m");
            try
            {
                key = Console.ReadKey(true); 

                switch (key.Key)
                {
                    case ConsoleKey.DownArrow:
                        option = (option == 3 ? 1 : option + 1);
                        break;

                    case ConsoleKey.UpArrow:
                        option = (option == 1 ? 3 : option -1);
                        break;

                    case ConsoleKey.Enter:
                        isSelected = true;
                        break;

                    default:
                        WriteLine("Invalid Selection Please Try Again");
                        PressAnyKeyToContinue();
                        break;
                }
            }
            catch (Exception e)
            {
                System.Console.WriteLine("Bad selection.. Press any key to continue");
                Console.ReadKey();
            }
                
        }

        try
        {
            var userInput = option;
            switch (userInput)
            {
                case 1:
                    CreateACharacter();
                    break;

                case 2:
                    ViewCharacterById();
                    break;

                case 3:
                    Run();
                    break;

                default:
                    System.Console.WriteLine("Invalid Entry Please Try Again");
                    PressAnyKeyToContinue();
                    break;
            }
        }
        catch (Exception e)
        {
            System.Console.WriteLine("Bad selection.. Press any key to continue");
            Console.ReadKey();
        }

    }

    private void CreateACharacter()
    {
        Clear();
        ForegroundColor = ConsoleColor.DarkGray;
        WriteLine("|=======================================|\n" +
                    "|                                       |\n" +
                    "| Your Courage will not be Forgotten    |\n" +
                    "|  What is your name Brave one?         |\n" +
                    "|                                       |\n" +
                    "|=======================================|\n");
        string newCharacterName = Console.ReadLine();
        System.Console.WriteLine($"{newCharacterName} do not fear the coming darkness it is no match for you!!");
        System.Console.WriteLine($"Let us get you ready to face your destiny {newCharacterName}!!");
        PressAnyKeyToContinue();

        Clear();
        ForegroundColor = ConsoleColor.DarkCyan;
        System.Console.WriteLine("|===================================================|\n" +
                                 "|                                                   |\n" +
                                 "|  You have 8 points to spend on Defense and Attack |\n" +
                                 "|      Choose wisely!!                              |\n" +
                                 "|===================================================|\n");
        int skillPoints = 8;
        ForegroundColor = ConsoleColor.DarkCyan;
        System.Console.WriteLine("|===================================================|\n" +
                                 "|                                                   |\n" +
                                 "|  Please input a value between 1 and 8 for your    |\n" +
                                 "|      Base Attack.                                 |\n" +
                                 "|===================================================|\n");

        int baseAttack = int.Parse(Console.ReadLine()!);
        skillPoints -= baseAttack;

        Clear();
        ForegroundColor = ConsoleColor.DarkCyan;
        System.Console.WriteLine("|===================================================|\n" +
                                 "|                                                   |\n" +
                                 $"|  You now have {skillPoints} points to spend      |\n" +
                                 "|        on Defense                                 |\n" +
                                 "|===================================================|\n");

        ForegroundColor = ConsoleColor.DarkCyan;
        System.Console.WriteLine("|===================================================|\n" +
                                 "|                                                   |\n" +
                                 $"|  Please input a value between 1 and {skillPoints}|\n" +
                                 "|      for your Base Defense.                       |\n" +
                                 "|===================================================|\n");
        int baseDefense = int.Parse(Console.ReadLine()!);

        Clear();
        int baseHealth = 100;
        ForegroundColor = ConsoleColor.DarkRed;
        System.Console.WriteLine("|===================================================|\n" +
                                 "|                                                   |\n" +
                                 $"|  Now {newCharacterName}, we  need to ensure that \n" +
                                 "|      your health is restored.                     |\n" +
                                 "|===================================================|\n");
        if (baseDefense > 3)
        {
            ForegroundColor = ConsoleColor.DarkRed;
            System.Console.WriteLine("|===================================================|\n" +
                                     "|                                                   |\n" +
                                    $"| {newCharacterName}'s Health has beed restored to  |\n" +
                                     "|      150 HealthPoints                             |\n" +
                                     "|===================================================|\n");
            baseHealth = 150;
            PressAnyKeyToContinue();
        }
        else
        {
            ForegroundColor = ConsoleColor.DarkRed;
            System.Console.WriteLine("|===================================================|\n" +
                                     "|                                                   |\n" +
                                    $"| {newCharacterName}'s Health has beed restored to  \n" +
                                     "|      120 HealthPoints                             |\n" +
                                     "|===================================================|\n");
            baseHealth = 120;
            PressAnyKeyToContinue();
        }

        Clear();
        ForegroundColor = ConsoleColor.DarkGreen;
        WriteLine("|=========================================|\n" +
                    "|                                       |\n" +
                    "| Now we need to learn more about you.  |\n" +
                    "|  Please enter a brief desciption      |\n" +
                    "|    or Catchphrase for your character. |\n" +
                    "|=======================================|\n");
        string newCharacterDescription = Console.ReadLine();
        PressAnyKeyToContinue();

        Clear();
        ForegroundColor = ConsoleColor.DarkGreen;
        WriteLine("|=========================================|\n" +
                    "|                                       |\n" +
                    "| Now Lets see what Hair Style you want |\n" +
                    "|  have on this adventure.              |\n" +
                    "|   Please choose from the following:   |\n" +
                    "|=======================================|\n");

        ViewAllHairStylesForCharacterCreate();
        System.Console.WriteLine("\n" +
            "Please enter a Hair Style ID to assign a Hair Style to your Character");
        int newHairStyleId = int.Parse(Console.ReadLine()!);

        Clear();
        ForegroundColor = ConsoleColor.DarkGreen;
        WriteLine("|=========================================|\n" +
                    "|                                       |\n" +
                    "| Now Lets see what Hair Color you want |\n" +
                    "|  to have on this adventure.           |\n" +
                    "|   Please choose from the following:   |\n" +
                    "|=======================================|\n");
        ViewAllHairColors();
        System.Console.WriteLine("\n" +
            "Please enter a Hair Color ID to assign a Hair Color to your Character");
        int newHairColorId = int.Parse(Console.ReadLine()!);

        Clear();
        ForegroundColor = ConsoleColor.DarkGreen;
        WriteLine("|=========================================|\n" +
                    "|                                       |\n" +
                    "| Now Lets see what Body Type you want  |\n" +
                    "|  to have on this adventure.           |\n" +
                    "|   Please choose from the following:   |\n" +
                    "|=======================================|\n");
        ViewAllBodyTypes();
        System.Console.WriteLine("\n" +
            "Please enter a Body Type ID to assign a Body Type to your Character");
        int newBodyTypeId = int.Parse(Console.ReadLine()!);

        Clear();
        ForegroundColor = ConsoleColor.DarkBlue;
        WriteLine("|===============================================|\n" +
                    "|                                             |\n" +
                    $"| Now {newCharacterName}, tell me what class |\n" +
                    "|  have you chosen to become proficient in?   |\n" +
                    "|   Please choose from the following:         |\n" +
                    "|=============================================|\n");
        ViewAllCharacterClassesForCharacterCreate();
        System.Console.WriteLine("\n" +
            "Please enter a Character Class ID to assign a Character Class to your Character");
        int newCharacterClassId = int.Parse(Console.ReadLine()!);

        Clear();
        ForegroundColor = ConsoleColor.DarkYellow;
        WriteLine("|===============================================|\n" +
                    "|                                             |\n" +
                    $"| Now {newCharacterName}, you need to choose |\n" +
                    "|  two abilities to help you with the journey.|\n" +
                    "|   Please choose from the following:         |\n" +
                    "|=============================================|\n");
        ViewAllAbilitiesForCharacterCreate();
        System.Console.WriteLine("Please enter the Ability IDs separated by commas (e.g., 1,2) to assign your Abilities to your Character:");
        string userInput = Console.ReadLine();

        List<int> newAbilityIds = userInput
            .Split(',')
            .Select(id => int.Parse(id.Trim()))
            .ToList();

        Clear();
        ForegroundColor = ConsoleColor.DarkMagenta;
        WriteLine("|===============================================|\n" +
                    "|                                             |\n" +
                    $"| Now {newCharacterName}, you need to choose  \n" +
                    "|  an armour to help you with the journey.    |\n" +
                    "|   Please choose from the following:         |\n" +
                    "|=============================================|\n");
        ViewAllArmoursForCharacterCreate();
        System.Console.WriteLine("Please enter the Armour Id separated by commas (e.g., 1,2) to assign your Armours to your Character:");
        string userArmourInput = Console.ReadLine();

        List<int> newArmourIds = userArmourInput
            .Split(',')
            .Select(id => int.Parse(id.Trim()))
            .ToList();

        Clear();
        ForegroundColor = ConsoleColor.DarkMagenta;
        WriteLine("|=============================================|\n" +
                    "|                                             |\n" +
                    $"| Now {newCharacterName}, you need to choose |\n" +
                    "|  a weapon to help you with the journey.     |\n" +
                    "|   Please choose from the following:         |\n" +
                    "|=============================================|\n");
        ViewAllWeaponsForCharacterCreate();
        System.Console.WriteLine("Please enter the Weapon ID separated by commas (e.g., 1,2) to assign Weapons to your Character:");
        string userWeaponInput = Console.ReadLine();

        List<int> newWeaponIds = userWeaponInput
            .Split(',')
            .Select(id => int.Parse(id.Trim()))
            .ToList();

        Clear();
        ForegroundColor = ConsoleColor.DarkBlue;
        WriteLine("|=============================================|\n" +
                    "|                                             |\n" +
                    $"| Now {newCharacterName}, you need to choose       |\n" +
                    "|  a consumable to help you with the journey. |\n" +
                    "|   Please choose from the following:         |\n" +
                    "|=============================================|\n");
        ViewAllConsumablesForCharacterCreate();
        System.Console.WriteLine("Please enter the Consumable ID(s) separated by commas (e.g., 1,2) to assign Consumable(s) to your Character:");
        string userConsumableInput = Console.ReadLine();

        List<int> newConsumableIds = userConsumableInput
            .Split(',')
            .Select(id => int.Parse(id.Trim()))
            .ToList();

        Clear();
        ForegroundColor = ConsoleColor.DarkBlue;
        WriteLine("|===============================================|\n" +
                    "|                                             |\n" +
                    $"| Finally {newCharacterName}, you need       |\n" +
                    "|  a vehicle to help you with the journey.    |\n" +
                    "|   Please choose from the following:         |\n" +
                    "|=============================================|\n");
        ViewAllVehiclesForCharacterCreate();
        System.Console.WriteLine("Please enter the Vehicle ID(s) separated by commas (e.g., 1,2) to assign Vehicle(s) to your Character:");
        string userVehicleInput = Console.ReadLine();

        List<int> newVehicleIds = userVehicleInput
            .Split(',')
            .Select(id => int.Parse(id.Trim()))
            .ToList();

        Clear();
        ForegroundColor = ConsoleColor.DarkBlue;
        WriteLine("|=============================================|\n" +
                    "|                                             |\n" +
                    $"| Please Enter your User ID to save your      |\n" +
                    "|     Character.                              |\n" +
                    "|                                             |\n" +
                    "|=============================================|\n");
        int userId = int.Parse(Console.ReadLine()!);
        PressAnyKeyToContinue();

        CharacterCreate createCharacter = new CharacterCreate
        {
            CharacterName = newCharacterName,
            CharacterHealth = baseHealth,
            CharacterBaseAttackDamage = baseAttack,
            CharacterBaseDefense = baseDefense,
            CharacterDescription = newCharacterDescription,
            HairColorId = newHairColorId,
            HairStyleId = newHairStyleId,
            BodyTypeId = newBodyTypeId,
            CharacterClassId = newCharacterClassId,
            UserId = userId,
            AbilityList = newAbilityIds,
            WeaponList = newWeaponIds,
            ArmourList = newArmourIds,
            ConsumableList = newConsumableIds,
            VehicleList = newVehicleIds,
        };

        var characterContent = new StringContent(JsonConvert.SerializeObject(createCharacter), Encoding.UTF8, "application/json");

        HttpResponseMessage response = httpClient.PostAsync("http://localhost:5211/api/Character", characterContent).Result;
        
        if (response.IsSuccessStatusCode)
        {
            CharacterListUI characterCreated = response.Content.ReadAsAsync<CharacterListUI>().Result;
            Console.Clear();
            ForegroundColor = ConsoleColor.Cyan;
            WriteLine("|=============================================|\n" +
                      "|                                             |\n" +
                      "| You have successfully create a new          |\n" +
                      "|     Character. Here is the information on   |\n" +
                      "|       the character you created             |\n" +
                      "|=============================================|\n");
            
            PressAnyKeyToContinue();

            WriteLine("==============================================================================================================================================");
            WriteLine(characterCreated.CharacterName);
            Write("You have choosen to be a: ");
            WriteLine(characterCreated.CharacterClassName);
            WriteLine(" \n" +
                     $" Here is an overview of the {characterCreated.CharacterClassName} Class:\n" +
                      "==============================================================================================================================================");
            WriteLine(characterCreated.CharacterClassDescription);
            WriteLine("  \n" +
                      "==============================================================================================================================================");
            WriteLine($"Your Character's current health is at {characterCreated.CharacterHealth} HP \n" +
                      "     \n" +
                      "==============================================================================================================================================");
            WriteLine($"Your Character's current Attack Stat is at {characterCreated.CharacterBaseAttackDamage}\n" +
                      "     \n" +
                      "==============================================================================================================================================");
            WriteLine($"Your Character's current Defense Stat is at {characterCreated.CharacterBaseDefense}\n" +
                      "     \n" +
                      "==============================================================================================================================================");
            WriteLine($"Your Current Hair Color is {characterCreated.HairColorName}\n" +
                      "     \n" +
                      "==============================================================================================================================================");
            WriteLine($"Your Current Hair Style is {characterCreated.HairStyleName}\n" +
                      "     \n" +
                      "==============================================================================================================================================");
            WriteLine("You have the following Ability(s):");

            int abilityNumber = 1;
            foreach(var abilityName in characterCreated.AbilityName)
            {
                System.Console.WriteLine(" \n" +
                                        $"Ability {abilityNumber}: {abilityName} \n" +
                                        " \n" +
                                        "-----------------------------------------------------------------------------------------------------------------------------------------------");
                abilityNumber++;
            }

            int abilityDescriptionNumber = 1;
            foreach(var abilityDescription in characterCreated.AbilityDescription)
            {
                System.Console.WriteLine(" \n" +
                                        $"Ability {abilityDescriptionNumber} Description: {abilityDescription}\n" +
                                        " \n" +
                                        "-----------------------------------------------------------------------------------------------------------------------------------------------");
                abilityDescriptionNumber++;
            }

            WriteLine("  ");
            WriteLine("You have the following Armour(s):");

            int armourNumber = 1;
            foreach(var armourName in characterCreated.ArmourName)
            {
                System.Console.WriteLine(" \n" +
                                        $"Armour {armourNumber}: {armourName} \n" +
                                        " \n" +
                                        "-----------------------------------------------------------------------------------------------------------------------------------------------");
                armourNumber++;
            }

            int armourDescriptionNumber = 1;
            foreach(var armourDescription in characterCreated.ArmourDescription)
            {
                System.Console.WriteLine(" \n" +
                                        $"Armour {armourDescriptionNumber} Description: {armourDescription}\n" +
                                        " \n" +
                                        "-----------------------------------------------------------------------------------------------------------------------------------------------");
                armourDescriptionNumber++;
            }

            WriteLine("  ");
            WriteLine("You have the following Weapon(s):");

            int weaponNumber = 1;
            foreach(var weaponName in characterCreated.WeaponName)
            {
                System.Console.WriteLine(" \n" +
                                        $"Weapon {weaponNumber}: {weaponName} \n" +
                                        " \n" +
                                        "-----------------------------------------------------------------------------------------------------------------------------------------------");
                weaponNumber++;
            }

            int weaponDescriptionNumber = 1;
            foreach(var weaponDescription in characterCreated.WeaponDescription)
            {
                System.Console.WriteLine(" \n" +
                                        $"Weapon {weaponDescriptionNumber} Description: {weaponDescription}\n" +
                                        " \n" +
                                        "-----------------------------------------------------------------------------------------------------------------------------------------------");
                weaponDescriptionNumber++;
            }

            WriteLine("  ");
            WriteLine("You have the following Vehicle(s):");

            int vehicleNumber = 1;
            foreach(var vehicleName in characterCreated.VehicleName)
            {
                System.Console.WriteLine(" \n" +
                                        $"Vehicle {vehicleNumber}: {vehicleName} \n" +
                                        " \n" +
                                        "-----------------------------------------------------------------------------------------------------------------------------------------------");
                vehicleNumber++;
            }

            int vehicleDescriptionNumber = 1;
            foreach(var vehicleDescription in characterCreated.VehicleDescription)
            {
                System.Console.WriteLine(" \n" +
                                        $"Vehicle {vehicleDescriptionNumber} Description: {vehicleDescription}\n" +
                                        " \n" +
                                        "-----------------------------------------------------------------------------------------------------------------------------------------------");
                vehicleDescriptionNumber++;
            }

            WriteLine("  ");
            WriteLine("You have the following Consumable(s):");

            int ConsumableNumber = 1;
            foreach(var ConsumableName in characterCreated.ConsumableName)
            {
                System.Console.WriteLine(" \n" +
                                        $"Consumable {ConsumableNumber}: {ConsumableName} \n" +
                                        " \n" +
                                        "-----------------------------------------------------------------------------------------------------------------------------------------------");
                ConsumableNumber++;
            }

            int ConsumableDescriptionNumber = 1;
            foreach(var ConsumableDescription in characterCreated.ConsumableDescription)
            {
                System.Console.WriteLine(" \n" +
                                        $"Consumable {ConsumableDescriptionNumber} Description: {ConsumableDescription}\n" +
                                        " \n" +
                                        "-----------------------------------------------------------------------------------------------------------------------------------------------");
                ConsumableDescriptionNumber++;
            }

            PressAnyKeyToContinue();

            Console.Clear();
            System.Console.WriteLine("Now your journey can truly begin");
            PressAnyKeyToContinue();
            Clear();

            System.Console.WriteLine(characterCreated.ClassBackstoryForCharacter);
            WriteLine("   ");
            WriteLine("You exit your workshop and enter the crowded Craftsman District of the grand city of Celestia......");
            PressAnyKeyToContinue();
            WriteLine("Tune in next week to see how the story unfolds.......");
            ReadKey();
            Run();
        }
        else
        {
            Console.WriteLine("Internal server Error");
            PressAnyKeyToContinue();
            Run();
        }
    }

    private void AddANewCharacter()
    {
        Clear();
        ForegroundColor = ConsoleColor.DarkGray;
        WriteLine("|=======================================|\n" +
                    "|                                       |\n" +
                    "| Your Courage will not be Forgotten    |\n" +
                    "|  What is your name Brave one?         |\n" +
                    "|                                       |\n" +
                    "|=======================================|\n");
        string newCharacterName = Console.ReadLine();
        System.Console.WriteLine($"{newCharacterName} do not fear the coming darkness it is no match for you!!");
        System.Console.WriteLine($"Let us get you ready to face your destiny {newCharacterName}!!");
        PressAnyKeyToContinue();

        Clear();
        ForegroundColor = ConsoleColor.DarkCyan;
        System.Console.WriteLine("|===================================================|\n" +
                                 "|                                                   |\n" +
                                 "|  You have 8 points to spend on Defense and Attack |\n" +
                                 "|      Choose wisely!!                              |\n" +
                                 "|===================================================|\n");
        int skillPoints = 8;
        ForegroundColor = ConsoleColor.DarkCyan;
        System.Console.WriteLine("|===================================================|\n" +
                                 "|                                                   |\n" +
                                 "|  Please input a value between 1 and 8 for your    |\n" +
                                 "|      Base Attack.                                 |\n" +
                                 "|===================================================|\n");

        int baseAttack = int.Parse(Console.ReadLine()!);
        skillPoints -= baseAttack;

        Clear();
        ForegroundColor = ConsoleColor.DarkCyan;
        System.Console.WriteLine("|===================================================|\n" +
                                 "|                                                   |\n" +
                                 $"|  You now have {skillPoints} points to spend      |\n" +
                                 "|        on Defense                                 |\n" +
                                 "|===================================================|\n");

        ForegroundColor = ConsoleColor.DarkCyan;
        System.Console.WriteLine("|===================================================|\n" +
                                 "|                                                   |\n" +
                                 $"|  Please input a value between 1 and {skillPoints}|\n" +
                                 "|      for your Base Defense.                       |\n" +
                                 "|===================================================|\n");
        int baseDefense = int.Parse(Console.ReadLine()!);

        Clear();
        int baseHealth = 100;
        ForegroundColor = ConsoleColor.DarkRed;
        System.Console.WriteLine("|===================================================|\n" +
                                 "|                                                   |\n" +
                                 $"|  Now {newCharacterName}, we  need to ensure that \n" +
                                 "|      your health is restored.                     |\n" +
                                 "|===================================================|\n");
        if (baseDefense > 3)
        {
            ForegroundColor = ConsoleColor.DarkRed;
            System.Console.WriteLine("|===================================================|\n" +
                                     "|                                                   |\n" +
                                    $"| {newCharacterName}'s Health has beed restored to  |\n" +
                                     "|      150 HealthPoints                             |\n" +
                                     "|===================================================|\n");
            baseHealth = 150;
            PressAnyKeyToContinue();
        }
        else
        {
            ForegroundColor = ConsoleColor.DarkRed;
            System.Console.WriteLine("|===================================================|\n" +
                                     "|                                                   |\n" +
                                    $"| {newCharacterName}'s Health has beed restored to  \n" +
                                     "|      120 HealthPoints                             |\n" +
                                     "|===================================================|\n");
            baseHealth = 120;
            PressAnyKeyToContinue();
        }

        Clear();
        ForegroundColor = ConsoleColor.DarkGreen;
        WriteLine("|=========================================|\n" +
                    "|                                       |\n" +
                    "| Now we need to learn more about you.  |\n" +
                    "|  Please enter a brief desciption      |\n" +
                    "|    or Catchphrase for your character. |\n" +
                    "|=======================================|\n");
        string newCharacterDescription = Console.ReadLine();
        PressAnyKeyToContinue();

        Clear();
        ForegroundColor = ConsoleColor.DarkGreen;
        WriteLine("|=========================================|\n" +
                    "|                                       |\n" +
                    "| Now Lets see what Hair Style you want |\n" +
                    "|  have on this adventure.              |\n" +
                    "|   Please choose from the following:   |\n" +
                    "|=======================================|\n");

        ViewAllHairStylesForCharacterCreate();
        System.Console.WriteLine("\n" +
            "Please enter a Hair Style ID to assign a Hair Style to your Character");
        int newHairStyleId = int.Parse(Console.ReadLine()!);

        Clear();
        ForegroundColor = ConsoleColor.DarkGreen;
        WriteLine("|=========================================|\n" +
                    "|                                       |\n" +
                    "| Now Lets see what Hair Color you want |\n" +
                    "|  to have on this adventure.           |\n" +
                    "|   Please choose from the following:   |\n" +
                    "|=======================================|\n");
        ViewAllHairColors();
        System.Console.WriteLine("\n" +
            "Please enter a Hair Color ID to assign a Hair Color to your Character");
        int newHairColorId = int.Parse(Console.ReadLine()!);

        Clear();
        ForegroundColor = ConsoleColor.DarkGreen;
        WriteLine("|=========================================|\n" +
                    "|                                       |\n" +
                    "| Now Lets see what Body Type you want  |\n" +
                    "|  to have on this adventure.           |\n" +
                    "|   Please choose from the following:   |\n" +
                    "|=======================================|\n");
        ViewAllBodyTypes();
        System.Console.WriteLine("\n" +
            "Please enter a Body Type ID to assign a Body Type to your Character");
        int newBodyTypeId = int.Parse(Console.ReadLine()!);

        Clear();
        ForegroundColor = ConsoleColor.DarkBlue;
        WriteLine("|===============================================|\n" +
                    "|                                             |\n" +
                    $"| Now {newCharacterName}, tell me what class |\n" +
                    "|  have you chosen to become proficient in?   |\n" +
                    "|   Please choose from the following:         |\n" +
                    "|=============================================|\n");
        ViewAllCharacterClassesForCharacterCreate();
        System.Console.WriteLine("\n" +
            "Please enter a Character Class ID to assign a Character Class to your Character");
        int newCharacterClassId = int.Parse(Console.ReadLine()!);

        Clear();
        ForegroundColor = ConsoleColor.DarkYellow;
        WriteLine("|===============================================|\n" +
                    "|                                             |\n" +
                    $"| Now {newCharacterName}, you need to choose |\n" +
                    "|  two abilities to help you with the journey.|\n" +
                    "|   Please choose from the following:         |\n" +
                    "|=============================================|\n");
        ViewAllAbilitiesForCharacterCreate();
        System.Console.WriteLine("Please enter the Ability IDs separated by commas (e.g., 1,2) to assign your Abilities to your Character:");
        string userInput = Console.ReadLine();

        List<int> newAbilityIds = userInput
            .Split(',')
            .Select(id => int.Parse(id.Trim()))
            .ToList();

        Clear();
        ForegroundColor = ConsoleColor.DarkMagenta;
        WriteLine("|===============================================|\n" +
                    "|                                             |\n" +
                    $"| Now {newCharacterName}, you need to choose  \n" +
                    "|  an armour to help you with the journey.    |\n" +
                    "|   Please choose from the following:         |\n" +
                    "|=============================================|\n");
        ViewAllArmoursForCharacterCreate();
        System.Console.WriteLine("Please enter the Armour Id separated by commas (e.g., 1,2) to assign your Armours to your Character:");
        string userArmourInput = Console.ReadLine();

        List<int> newArmourIds = userArmourInput
            .Split(',')
            .Select(id => int.Parse(id.Trim()))
            .ToList();

        Clear();
        ForegroundColor = ConsoleColor.DarkMagenta;
        WriteLine("|=============================================|\n" +
                    "|                                             |\n" +
                    $"| Now {newCharacterName}, you need to choose |\n" +
                    "|  a weapon to help you with the journey.     |\n" +
                    "|   Please choose from the following:         |\n" +
                    "|=============================================|\n");
        ViewAllWeaponsForCharacterCreate();
        System.Console.WriteLine("Please enter the Weapon ID separated by commas (e.g., 1,2) to assign Weapons to your Character:");
        string userWeaponInput = Console.ReadLine();

        List<int> newWeaponIds = userWeaponInput
            .Split(',')
            .Select(id => int.Parse(id.Trim()))
            .ToList();

        Clear();
        ForegroundColor = ConsoleColor.DarkBlue;
        WriteLine("|=============================================|\n" +
                    "|                                             |\n" +
                    $"| Now {newCharacterName}, you need to choose       |\n" +
                    "|  a consumable to help you with the journey. |\n" +
                    "|   Please choose from the following:         |\n" +
                    "|=============================================|\n");
        ViewAllConsumablesForCharacterCreate();
        System.Console.WriteLine("Please enter the Consumable ID(s) separated by commas (e.g., 1,2) to assign Consumable(s) to your Character:");
        string userConsumableInput = Console.ReadLine();

        List<int> newConsumableIds = userConsumableInput
            .Split(',')
            .Select(id => int.Parse(id.Trim()))
            .ToList();

        Clear();
        ForegroundColor = ConsoleColor.DarkBlue;
        WriteLine("|===============================================|\n" +
                    "|                                             |\n" +
                    $"| Finally {newCharacterName}, you need       |\n" +
                    "|  a vehicle to help you with the journey.    |\n" +
                    "|   Please choose from the following:         |\n" +
                    "|=============================================|\n");
        ViewAllVehiclesForCharacterCreate();
        System.Console.WriteLine("Please enter the Vehicle ID(s) separated by commas (e.g., 1,2) to assign Vehicle(s) to your Character:");
        string userVehicleInput = Console.ReadLine();

        List<int> newVehicleIds = userVehicleInput
            .Split(',')
            .Select(id => int.Parse(id.Trim()))
            .ToList();

        Clear();
        ForegroundColor = ConsoleColor.DarkBlue;
        WriteLine("|=============================================|\n" +
                    "|                                             |\n" +
                    $"| Please Enter your User ID to save your      |\n" +
                    "|     Character.                              |\n" +
                    "|                                             |\n" +
                    "|=============================================|\n");
        int userId = int.Parse(Console.ReadLine()!);
        PressAnyKeyToContinue();

        CharacterCreate createCharacter = new CharacterCreate
        {
            CharacterName = newCharacterName,
            CharacterHealth = baseHealth,
            CharacterBaseAttackDamage = baseAttack,
            CharacterBaseDefense = baseDefense,
            CharacterDescription = newCharacterDescription,
            HairColorId = newHairColorId,
            HairStyleId = newHairStyleId,
            BodyTypeId = newBodyTypeId,
            CharacterClassId = newCharacterClassId,
            UserId = userId,
            AbilityList = newAbilityIds,
            WeaponList = newWeaponIds,
            ArmourList = newArmourIds,
            ConsumableList = newConsumableIds,
            VehicleList = newVehicleIds,
        };

        var characterContent = new StringContent(JsonConvert.SerializeObject(createCharacter), Encoding.UTF8, "application/json");

        HttpResponseMessage response = httpClient.PostAsync("http://localhost:5211/api/Character", characterContent).Result;
        
        if (response.IsSuccessStatusCode)
        {
            CharacterListUI characterCreated = response.Content.ReadAsAsync<CharacterListUI>().Result;
            Console.Clear();
            ForegroundColor = ConsoleColor.Cyan;
            WriteLine("|=============================================|\n" +
                      "|                                             |\n" +
                      "| You have successfully create a new          |\n" +
                      "|     Character. Here is the information on   |\n" +
                      "|       the character you created             |\n" +
                      "|=============================================|\n");
            
            PressAnyKeyToContinue();

            WriteLine("==============================================================================================================================================");
            WriteLine(characterCreated.CharacterName);
            Write("You have choosen to be a: ");
            WriteLine(characterCreated.CharacterClassName);
            WriteLine(" \n" +
                     $" Here is an overview of the {characterCreated.CharacterClassName} Class:\n" +
                      "==============================================================================================================================================");
            WriteLine(characterCreated.CharacterClassDescription);
            WriteLine("  \n" +
                      "==============================================================================================================================================");
            WriteLine($"Your Character's current health is at {characterCreated.CharacterHealth} HP \n" +
                      "     \n" +
                      "==============================================================================================================================================");
            WriteLine($"Your Character's current Attack Stat is at {characterCreated.CharacterBaseAttackDamage}\n" +
                      "     \n" +
                      "==============================================================================================================================================");
            WriteLine($"Your Character's current Defense Stat is at {characterCreated.CharacterBaseDefense}\n" +
                      "     \n" +
                      "==============================================================================================================================================");
            WriteLine($"Your Current Hair Color is {characterCreated.HairColorName}\n" +
                      "     \n" +
                      "==============================================================================================================================================");
            WriteLine($"Your Current Hair Style is {characterCreated.HairStyleName}\n" +
                      "     \n" +
                      "==============================================================================================================================================");
            WriteLine("You have the following Ability(s):");

            int abilityNumber = 1;
            foreach(var abilityName in characterCreated.AbilityName)
            {
                System.Console.WriteLine(" \n" +
                                        $"Ability {abilityNumber}: {abilityName} \n" +
                                        " \n" +
                                        "-----------------------------------------------------------------------------------------------------------------------------------------------");
                abilityNumber++;
            }

            int abilityDescriptionNumber = 1;
            foreach(var abilityDescription in characterCreated.AbilityDescription)
            {
                System.Console.WriteLine(" \n" +
                                        $"Ability {abilityDescriptionNumber} Description: {abilityDescription}\n" +
                                        " \n" +
                                        "-----------------------------------------------------------------------------------------------------------------------------------------------");
                abilityDescriptionNumber++;
            }

            WriteLine("  ");
            WriteLine("You have the following Armour(s):");

            int armourNumber = 1;
            foreach(var armourName in characterCreated.ArmourName)
            {
                System.Console.WriteLine(" \n" +
                                        $"Armour {armourNumber}: {armourName} \n" +
                                        " \n" +
                                        "-----------------------------------------------------------------------------------------------------------------------------------------------");
                armourNumber++;
            }

            int armourDescriptionNumber = 1;
            foreach(var armourDescription in characterCreated.ArmourDescription)
            {
                System.Console.WriteLine(" \n" +
                                        $"Armour {armourDescriptionNumber} Description: {armourDescription}\n" +
                                        " \n" +
                                        "-----------------------------------------------------------------------------------------------------------------------------------------------");
                armourDescriptionNumber++;
            }

            WriteLine("  ");
            WriteLine("You have the following Weapon(s):");

            int weaponNumber = 1;
            foreach(var weaponName in characterCreated.WeaponName)
            {
                System.Console.WriteLine(" \n" +
                                        $"Weapon {weaponNumber}: {weaponName} \n" +
                                        " \n" +
                                        "-----------------------------------------------------------------------------------------------------------------------------------------------");
                weaponNumber++;
            }

            int weaponDescriptionNumber = 1;
            foreach(var weaponDescription in characterCreated.WeaponDescription)
            {
                System.Console.WriteLine(" \n" +
                                        $"Weapon {weaponDescriptionNumber} Description: {weaponDescription}\n" +
                                        " \n" +
                                        "-----------------------------------------------------------------------------------------------------------------------------------------------");
                weaponDescriptionNumber++;
            }

            WriteLine("  ");
            WriteLine("You have the following Vehicle(s):");

            int vehicleNumber = 1;
            foreach(var vehicleName in characterCreated.VehicleName)
            {
                System.Console.WriteLine(" \n" +
                                        $"Vehicle {vehicleNumber}: {vehicleName} \n" +
                                        " \n" +
                                        "-----------------------------------------------------------------------------------------------------------------------------------------------");
                vehicleNumber++;
            }

            int vehicleDescriptionNumber = 1;
            foreach(var vehicleDescription in characterCreated.VehicleDescription)
            {
                System.Console.WriteLine(" \n" +
                                        $"Vehicle {vehicleDescriptionNumber} Description: {vehicleDescription}\n" +
                                        " \n" +
                                        "-----------------------------------------------------------------------------------------------------------------------------------------------");
                vehicleDescriptionNumber++;
            }

            WriteLine("  ");
            WriteLine("You have the following Consumable(s):");

            int ConsumableNumber = 1;
            foreach(var ConsumableName in characterCreated.ConsumableName)
            {
                System.Console.WriteLine(" \n" +
                                        $"Consumable {ConsumableNumber}: {ConsumableName} \n" +
                                        " \n" +
                                        "-----------------------------------------------------------------------------------------------------------------------------------------------");
                ConsumableNumber++;
            }

            int ConsumableDescriptionNumber = 1;
            foreach(var ConsumableDescription in characterCreated.ConsumableDescription)
            {
                System.Console.WriteLine(" \n" +
                                        $"Consumable {ConsumableDescriptionNumber} Description: {ConsumableDescription}\n" +
                                        " \n" +
                                        "-----------------------------------------------------------------------------------------------------------------------------------------------");
                ConsumableDescriptionNumber++;
            }

            PressAnyKeyToContinue();

            Console.Clear();
            System.Console.WriteLine("Now your journey can truly begin");
            PressAnyKeyToContinue();
        }
        else
        {
            Console.WriteLine("Internal server Error");
            PressAnyKeyToContinue();
            StartAGame();
        }
    }

    private void ViewCharacterById()
    {
        Clear();
        ForegroundColor = ConsoleColor.DarkGreen;
        WriteLine("|===================================================|\n" +
                    "|                                                   |\n" +
                    "|  Please enter a Character Id to View a Character: |\n" +
                    "|                                                   |\n" +
                    "|===================================================|\n");
        int characterId = int.Parse(Console.ReadLine()!);
        HttpClient httpClient = new HttpClient();
        HttpResponseMessage response = httpClient.GetAsync($"http://localhost:5211/api/Character/{characterId}").Result;
        if (response.IsSuccessStatusCode)
        {
            // var content = response.Content.ReadAsStringAsync().Result;
            // var characters = JsonConvert.DeserializeObject<CharacterListUI>(content);

            CharacterListUI character = response.Content.ReadAsAsync<CharacterListUI>().Result;
            Clear();
            WriteLine("==============================================================================================================================================");
            WriteLine(character.CharacterName);
            Write("You have choosen to be a: ");
            WriteLine(character.CharacterClassName);
            WriteLine(" \n" +
                     $" Here is an overview of the {character.CharacterClassName} Class:\n" +
                      "==============================================================================================================================================");
            WriteLine(character.CharacterClassDescription);
            WriteLine("  \n" +
                      "==============================================================================================================================================");
            WriteLine($"Your Character's current health is at {character.CharacterHealth} HP \n" +
                      "     \n" +
                      "==============================================================================================================================================");
            WriteLine($"Your Character's current Attack Stat is at {character.CharacterBaseAttackDamage}\n" +
                      "     \n" +
                      "==============================================================================================================================================");
            WriteLine($"Your Character's current Defense Stat is at {character.CharacterBaseDefense}\n" +
                      "     \n" +
                      "==============================================================================================================================================");
            WriteLine($"Your Current Hair Color is {character.HairColorName}\n" +
                      "     \n" +
                      "==============================================================================================================================================");
            WriteLine($"Your Current Hair Style is {character.HairStyleName}\n" +
                      "     \n" +
                      "==============================================================================================================================================");
            WriteLine("You have the following Ability(s):");

            int abilityNumber = 1;
            foreach(var abilityName in character.AbilityName)
            {
                System.Console.WriteLine(" \n" +
                                        $"Ability {abilityNumber}: {abilityName} \n" +
                                        " \n" +
                                        "-----------------------------------------------------------------------------------------------------------------------------------------------");
                abilityNumber++;
            }

            int abilityDescriptionNumber = 1;
            foreach(var abilityDescription in character.AbilityDescription)
            {
                System.Console.WriteLine(" \n" +
                                        $"Ability {abilityDescriptionNumber} Description: {abilityDescription}\n" +
                                        " \n" +
                                        "-----------------------------------------------------------------------------------------------------------------------------------------------");
                abilityDescriptionNumber++;
            }

            WriteLine("  ");
            WriteLine("You have the following Armour(s):");

            int armourNumber = 1;
            foreach(var armourName in character.ArmourName)
            {
                System.Console.WriteLine(" \n" +
                                        $"Armour {armourNumber}: {armourName} \n" +
                                        " \n" +
                                        "-----------------------------------------------------------------------------------------------------------------------------------------------");
                armourNumber++;
            }

            int armourDescriptionNumber = 1;
            foreach(var armourDescription in character.ArmourDescription)
            {
                System.Console.WriteLine(" \n" +
                                        $"Armour {armourDescriptionNumber} Description: {armourDescription}\n" +
                                        " \n" +
                                        "-----------------------------------------------------------------------------------------------------------------------------------------------");
                armourDescriptionNumber++;
            }

            WriteLine("  ");
            WriteLine("You have the following Weapon(s):");

            int weaponNumber = 1;
            foreach(var weaponName in character.WeaponName)
            {
                System.Console.WriteLine(" \n" +
                                        $"Weapon {weaponNumber}: {weaponName} \n" +
                                        " \n" +
                                        "-----------------------------------------------------------------------------------------------------------------------------------------------");
                weaponNumber++;
            }

            int weaponDescriptionNumber = 1;
            foreach(var weaponDescription in character.WeaponDescription)
            {
                System.Console.WriteLine(" \n" +
                                        $"Weapon {weaponDescriptionNumber} Description: {weaponDescription}\n" +
                                        " \n" +
                                        "-----------------------------------------------------------------------------------------------------------------------------------------------");
                weaponDescriptionNumber++;
            }

            WriteLine("  ");
            WriteLine("You have the following Vehicle(s):");

            int vehicleNumber = 1;
            foreach(var vehicleName in character.VehicleName)
            {
                System.Console.WriteLine(" \n" +
                                        $"Vehicle {vehicleNumber}: {vehicleName} \n" +
                                        " \n" +
                                        "-----------------------------------------------------------------------------------------------------------------------------------------------");
                vehicleNumber++;
            }

            int vehicleDescriptionNumber = 1;
            foreach(var vehicleDescription in character.VehicleDescription)
            {
                System.Console.WriteLine(" \n" +
                                        $"Vehicle {vehicleDescriptionNumber} Description: {vehicleDescription}\n" +
                                        " \n" +
                                        "-----------------------------------------------------------------------------------------------------------------------------------------------");
                vehicleDescriptionNumber++;
            }

            WriteLine("  ");
            WriteLine("You have the following Consumable(s):");

            int ConsumableNumber = 1;
            foreach(var ConsumableName in character.ConsumableName)
            {
                System.Console.WriteLine(" \n" +
                                        $"Consumable {ConsumableNumber}: {ConsumableName} \n" +
                                        " \n" +
                                        "-----------------------------------------------------------------------------------------------------------------------------------------------");
                ConsumableNumber++;
            }

            int ConsumableDescriptionNumber = 1;
            foreach(var ConsumableDescription in character.ConsumableDescription)
            {
                System.Console.WriteLine(" \n" +
                                        $"Consumable {ConsumableDescriptionNumber} Description: {ConsumableDescription}\n" +
                                        " \n" +
                                        "-----------------------------------------------------------------------------------------------------------------------------------------------");
                ConsumableDescriptionNumber++;
            }
            // WriteLine(string.Join(System.Environment.NewLine, character.VehicleName));
            // WriteLine(string.Join(System.Environment.NewLine, character.VehicleDescription));
            // WriteLine(string.Join(System.Environment.NewLine, character.WeaponName));
            // WriteLine(string.Join(System.Environment.NewLine, character.WeaponDescription));
            // WriteLine(string.Join(System.Environment.NewLine, character.ArmourName));
            // WriteLine(string.Join(System.Environment.NewLine, character.ArmourDescription));
            // WriteLine(string.Join(System.Environment.NewLine, character.ConsumableName));
            // WriteLine(string.Join(System.Environment.NewLine, character.ConsumableDescription));
            PressAnyKeyToContinue();
            ManageCharacters();
        }
    }

    private void ViewAllCharacters()
    {

        ForegroundColor = ConsoleColor.DarkYellow;
        WriteLine("|=============================================|\n" +
                    "|                                             |\n" +
                    $"| Please Enter your User ID to see your       |\n" +
                    "|     Characters.                             |\n" +
                    "|                                             |\n" +
                    "|=============================================|\n");
        int userId = int.Parse(Console.ReadLine()!);
        HttpClient httpClient = new HttpClient();

        HttpResponseMessage response = httpClient.GetAsync($"http://localhost:5211/api/Character/CharacterByUser/{userId}").Result;
        if (response.IsSuccessStatusCode)
        {
            List<CharacterListUI> characters = response.Content.ReadAsAsync<List<CharacterListUI>>().Result;

            foreach (var character in characters)
            {
                WriteLine("=================================================================================================================|\n" +
                          "|                                                                                                                |\n" +
                          $"| Character ID: {character.CharacterId} | Character Name: {character.CharacterName}|\n" +
                          "|================================================================================================================|\n" +
                          "| Character Description/Catch Phrase:                                                                            |\n" +
                          "|________________________________________________________________________________________________________________|\n" +
                          "|                                                                                                                |\n" +
                          $" {character.CharacterDescription}                         \n" +
                          "|================================================================================================================|\n" +
                          "                                                                                                                 ");
            }

            PressAnyKeyToContinue();
            ManageCharacters();
        }
    }

    private void UpdateExistingCharacter()
    {
        Clear();
        ForegroundColor = ConsoleColor.DarkCyan;
        WriteLine("|=============================================|\n" +
                "|                                             |\n" +
                "| In order to update a character please enter |\n" +
                "|     your username to ensure proper access.  |\n" +
                "|                                             |\n" +
                "|=============================================|\n");
        string userName = Console.ReadLine();

        ForegroundColor = ConsoleColor.DarkCyan;
        WriteLine("|=============================================|\n" +
                "|                                             |\n" +
                "| Please Enter your password to sign in to    |\n" +
                "| acces the Character you would like to make  |\n" +
                "|       changes to.                           |\n" +
                "|=============================================|\n");
        string userPassword = Console.ReadLine();

        ForegroundColor = ConsoleColor.DarkCyan;
        WriteLine("|=============================================|\n" +
                "|                                             |\n" +
                "| Finally confirm your User Id to gain access |\n" +
                "| to the Character you would like to make     |\n" +
                "|       changes to.                           |\n" +
                "|=============================================|\n");
        int userId = int.Parse(Console.ReadLine()!);

        Clear();
        ForegroundColor = ConsoleColor.DarkRed;
        WriteLine("|=============================================|\n" +
                "|                                             |\n" +
                "| Please Enter the Character Id for the       |\n" +
                "|     Character you would like to make        |\n" +
                "|       changes to.                           |\n" +
                "|=============================================|\n");
        int characterId = int.Parse(Console.ReadLine()!);

        Clear();
        ForegroundColor = ConsoleColor.DarkGray;
        WriteLine("|==================================================|\n" +
                    "|                                                 |\n" +
                    "| If you want to update your character name please|\n" +
                    "| input a new name. If you do not please enter    |\n" +
                    "| your character's current name.                  |\n" +
                    "|                                                 |\n" +
                    "|=================================================|\n");
        string newCharacterName = Console.ReadLine();

        Clear();
        ForegroundColor = ConsoleColor.DarkGreen;
        WriteLine("|=========================================|\n" +
                    "|                                       |\n" +
                    "| Now you can update your catchphrase.  |\n" +
                    "|  Please enter a brief desciption      |\n" +
                    "|    or Catchphrase for your character. |\n" +
                    "|=======================================|\n");
        string newCharacterDescription = Console.ReadLine();
        PressAnyKeyToContinue();

        Clear();
        ForegroundColor = ConsoleColor.DarkGreen;
        WriteLine("|=========================================|\n" +
                    "|                                       |\n" +
                    "| Now Lets see what Hair Style you want |\n" +
                    "|  to have for the character now.       |\n" +
                    "|   Please choose from the following:   |\n" +
                    "|=======================================|\n");

        ViewAllHairStylesForCharacterCreate();
        System.Console.WriteLine("\n" +
            "Please enter a Hair Style ID to assign a Hair Style to your Character");
        int newHairStyleId = int.Parse(Console.ReadLine()!);

        Clear();
        ForegroundColor = ConsoleColor.DarkGreen;
        WriteLine("|=========================================|\n" +
                    "|                                       |\n" +
                    "| Now Lets see what Hair Color you want |\n" +
                    "|  to have for your Character now.      |\n" +
                    "|   Please choose from the following:   |\n" +
                    "|=======================================|\n");
        ViewAllHairColors();
        System.Console.WriteLine("\n" +
            "Please enter a Hair Color ID to assign a Hair Color to your Character");
        int newHairColorId = int.Parse(Console.ReadLine()!);

        Clear();
        ForegroundColor = ConsoleColor.DarkGreen;
        WriteLine("|=========================================|\n" +
                    "|                                       |\n" +
                    "| Now Lets see what Body Type you want  |\n" +
                    "|  to have for your Character now.      |\n" +
                    "|   Please choose from the following:   |\n" +
                    "|=======================================|\n");
        ViewAllBodyTypes();
        System.Console.WriteLine("\n" +
            "Please enter a Body Type ID to assign a Body Type to your Character");
        int newBodyTypeId = int.Parse(Console.ReadLine()!);

        Clear();
        ForegroundColor = ConsoleColor.DarkYellow;
        WriteLine("|===============================================|\n" +
                    "|                                             |\n" +
                    "| You can now choose to update the abilities  |\n" +
                    "|  your character has to help on the journey. |\n" +
                    "|   Please choose from the following:         |\n" +
                    "|=============================================|\n");
        ViewAllAbilitiesForCharacterCreate();
        System.Console.WriteLine("Please enter the Ability IDs separated by commas (e.g., 1,2) to assign your Abilities to your Character:");
        string userInput = Console.ReadLine();

        List<int> newAbilityIds = userInput
            .Split(',')
            .Select(id => int.Parse(id.Trim()))
            .ToList();

        Clear();
        ForegroundColor = ConsoleColor.DarkMagenta;
        WriteLine("|===============================================|\n" +
                    "|                                             |\n" +
                    $"| Now {newCharacterName}, you need to choose  \n" +
                    "|  an armour to help you with the journey.    |\n" +
                    "|   Please choose from the following:         |\n" +
                    "|=============================================|\n");
        ViewAllArmoursForCharacterCreate();
        System.Console.WriteLine("Please enter the Armour Id separated by commas (e.g., 1,2) to assign your Armours to your Character:");
        string userArmourInput = Console.ReadLine();

        List<int> newArmourIds = userArmourInput
            .Split(',')
            .Select(id => int.Parse(id.Trim()))
            .ToList();

        Clear();
        ForegroundColor = ConsoleColor.DarkMagenta;
        WriteLine("|=============================================|\n" +
                    "|                                             |\n" +
                    "| Now you need to choose at least one weapon  |\n" +
                    "| to help you with the journey.               |\n" +
                    "|   Please choose from the following:         |\n" +
                    "|=============================================|\n");
        ViewAllWeaponsForCharacterCreate();
        System.Console.WriteLine("Please enter the Weapon ID separated by commas (e.g., 1,2) to assign Weapons to your Character:");
        string userWeaponInput = Console.ReadLine();

        List<int> newWeaponIds = userWeaponInput
            .Split(',')
            .Select(id => int.Parse(id.Trim()))
            .ToList();

        Clear();
        ForegroundColor = ConsoleColor.DarkBlue;
        WriteLine("|=============================================|\n" +
                    "|                                             |\n" +
                    "| Now you need to choose some consumable(s)   |\n" +
                    "| to help you with the journey ahead.         |\n" +
                    "|      Please choose from the following:      |\n" +
                    "|=============================================|\n");
        ViewAllConsumablesForCharacterCreate();
        System.Console.WriteLine("Please enter the Consumable ID(s) separated by commas (e.g., 1,2) to assign Consumable(s) to your Character:");
        string userConsumableInput = Console.ReadLine();

        List<int> newConsumableIds = userConsumableInput
            .Split(',')
            .Select(id => int.Parse(id.Trim()))
            .ToList();

        Clear();
        ForegroundColor = ConsoleColor.DarkBlue;
        WriteLine("|===============================================|\n" +
                    "|                                             |\n" +
                    $"| Finally {newCharacterName}, you need       |\n" +
                    "|  a vehicle to help you with the journey.    |\n" +
                    "|   Please choose from the following:         |\n" +
                    "|=============================================|\n");
        ViewAllVehiclesForCharacterCreate();
        System.Console.WriteLine("Please enter the Vehicle ID(s) separated by commas (e.g., 1,2) to assign Vehicle(s) to your Character:");
        string userVehicleInput = Console.ReadLine();

        List<int> newVehicleIds = userVehicleInput
            .Split(',')
            .Select(id => int.Parse(id.Trim()))
            .ToList();

        CharacterUpdate updatedCharacter = new CharacterUpdate
        {
            CharacterId = characterId,
            CharacterName = newCharacterName,
            DateModified = DateTime.Now,
            CharacterDescription = newCharacterDescription,
            HairColorId = newHairColorId,
            HairStyleId = newHairStyleId,
            BodyTypeId = newBodyTypeId,
            UserId = userId,
            AbilityList = newAbilityIds,
            WeaponList = newWeaponIds,
            ArmourList = newArmourIds,
            ConsumableList = newConsumableIds,
            VehicleList = newVehicleIds
        };

        HttpClient httpClient = new HttpClient();

        var characterUpdate = new StringContent(JsonConvert.SerializeObject(updatedCharacter), Encoding.UTF8, "application/json");

        HttpResponseMessage response = httpClient.PutAsync("http://localhost:5211/api/Character", characterUpdate).Result;
        if (response.IsSuccessStatusCode)
        {
            Clear();
            ForegroundColor = ConsoleColor.DarkYellow;
            WriteLine("|=============================================|\n" +
                      "|                                             |\n" +
                      "|                                             |\n" +
                      "|   Character has been updated successfully.  |\n" +
                      "|                                             |\n" +
                      "|                                             |\n" +
                      "|=============================================|\n");
            PressAnyKeyToContinue();
            ManageCharacters();
        }
        else
        {
            WriteLine("Failed to updated the give Character. Status Code: " + response.StatusCode);
        }
        PressAnyKeyToContinue();
        ManageCharacters();
    }

    private void DeleteExistingCharacter()
    {
        Clear();
        ForegroundColor = ConsoleColor.DarkRed;
        WriteLine("|=============================================|\n" +
                    "|                                             |\n" +
                    "| Please Enter your Character ID to delete    |\n" +
                    "|    your Character.                          |\n" +
                    "|                                             |\n" +
                    "|=============================================|\n");
        int characterId = int.Parse(Console.ReadLine()!);
        
        Write($"Are your sure you want to delete the character with the ID: {characterId}? \n" +
                "Please input y to delete or n to cancel deletion: ");
            string userInputYesorNo = ReadLine()!;
            if (userInputYesorNo.ToLower() == "Y".ToLower())
            {
                HttpClient httpClient = new HttpClient();

                HttpResponseMessage response = httpClient.DeleteAsync($"http://localhost:5211/api/Character/{characterId}").Result;

                if (response.IsSuccessStatusCode)
                {
                    WriteLine("Character was deleted successfully.");
                    PressAnyKeyToContinue();
                }
                else
                {
                    WriteLine("Failed to delete the Character. Status Code: " + response.StatusCode);
                    PressAnyKeyToContinue();
                    
                }
            }
            else
            {
                WriteLine("|=============================================|\n" +
                        "|                                             |\n" +
                        $"| Deletion of the Character with ID: {characterId} |\n" +
                        "|    has been Canceled                        |\n" +
                        "|                                             |\n" +
                        "|=============================================|\n");
            }

        PressAnyKeyToContinue();
        ManageCharacters();
    }

    private void ManageCharacters()
    {
        Console.Clear();
        ForegroundColor = ConsoleColor.White;
        WriteLine("|=======================================|\n" +
                    "|                                       |\n" +
                    "|  What would you like to do with the   |\n" +
                    "|        Characters?                    |\n" +
                    "|                                       |\n" +
                    "|=======================================|\n" +
                    "|                                       |");
        ConsoleKeyInfo key;
        int option = 1;
        bool isSelected = false;
        (int left, int top) = Console.GetCursorPosition();
        string color = "👻\u001b[35m";

            while(!isSelected)
            {   Console.SetCursorPosition(left, top);
                WriteLine($"|{(option == 1 ? color : "  ")}1. View All Characters\u001b[37m               |");
                WriteLine($"|{(option == 2 ? color : "  ")}2. View Characters By Character Id\u001b[37m   |");
                WriteLine($"|{(option == 3 ? color : "  ")}3. Update Existing Character\u001b[37m         |");
                WriteLine($"|{(option == 4 ? color : "  ")}4. Add a New Character\u001b[37m               |");
                WriteLine($"|{(option == 5 ? color : "  ")}5. Delete a Character\u001b[37m                |");
                WriteLine($"|{(option == 6 ? color : "  ")}6. Return to Main Menu\u001b[37m               |");
                WriteLine("|                                       |\u001b[37m");
                WriteLine("|=======================================|\u001b[37m");
            try
            {
                key = Console.ReadKey(true); 

                switch (key.Key)
                {
                    case ConsoleKey.DownArrow:
                        option = (option == 6 ? 1 : option + 1);
                        break;

                    case ConsoleKey.UpArrow:
                        option = (option == 1 ? 6 : option -1);
                        break;

                    case ConsoleKey.Enter:
                        isSelected = true;
                        break;

                    default:
                        WriteLine("Invalid Selection Please Try Again");
                        PressAnyKeyToContinue();
                        break;
                }
            }
            catch (Exception e)
            {
                System.Console.WriteLine("Bad selection.. Press any key to continue");
                Console.ReadKey();
            }
                
            }            
        
        try
        {
            var userInput = option;
            switch (userInput)
            {
                case 1:
                    ViewAllCharacters();
                    break;

                case 2:
                    ViewCharacterById();
                    break;

                case 3:
                    UpdateExistingCharacter();
                    break;

                case 4:
                    AddANewCharacter();
                    break;

                case 5:
                    DeleteExistingCharacter();
                    break;

                case 6:
                    ManageGameItemDetails();
                    break;

                default:
                    System.Console.WriteLine("Invalid Entry Please Try Again");
                    PressAnyKeyToContinue();
                    break;
            }
        }
        catch (Exception e)
        {
            System.Console.WriteLine("Bad selection.. Press any key to continue");
            Console.ReadKey();
        }
    }
    
    private void ManageWeapons()
    {
        Console.Clear();
        ForegroundColor = ConsoleColor.White;
        WriteLine("|=======================================|\n" +
                    "|                                       |\n" +
                    "|  What would you like to do with the   |\n" +
                    "|        Weapons?                       |\n" +
                    "|                                       |\n" +
                    "|=======================================|\n" +
                    "|                                       |");

        ConsoleKeyInfo key;
        int option = 1;
        bool isSelected = false;
        (int left, int top) = Console.GetCursorPosition();
        string color = "🐉\u001b[35m";

            while(!isSelected)
            {   Console.SetCursorPosition(left, top);
                WriteLine($"|{(option == 1 ? color : "  ")}1. View All Weapons\u001b[37m                  |");
                WriteLine($"|{(option == 2 ? color : "  ")}2. View Weapon By Id\u001b[37m                 |");
                WriteLine($"|{(option == 3 ? color : "  ")}3. Update Existing Weapon\u001b[37m            |");
                WriteLine($"|{(option == 4 ? color : "  ")}4. Add a New Weapon\u001b[37m                  |");
                WriteLine($"|{(option == 5 ? color : "  ")}5. Delete a Weapon\u001b[37m                   |");
                WriteLine($"|{(option == 6 ? color : "  ")}6. Return to Previous Menu\u001b[37m           |");
                WriteLine("|                                       |\u001b[37m");
                WriteLine("|=======================================|\u001b[37m");
            try
            {
                key = Console.ReadKey(true); 

                switch (key.Key)
                {
                    case ConsoleKey.DownArrow:
                        option = (option == 6 ? 1 : option + 1);
                        break;

                    case ConsoleKey.UpArrow:
                        option = (option == 1 ? 6 : option -1);
                        break;

                    case ConsoleKey.Enter:
                        isSelected = true;
                        break;

                    default:
                        WriteLine("Invalid Selection Please Try Again");
                        PressAnyKeyToContinue();
                        break;
                }
            }
            catch (Exception e)
            {
                System.Console.WriteLine("Bad selection.. Press any key to continue");
                Console.ReadKey();
            }
                
            }            
        
        try
        {
            var userInput = option;
            switch (userInput)
            {
                case 1:
                    ViewAllWeapons();
                    break;

                case 2:
                    ViewWeaponById();
                    break;

                case 3:
                    UpdateAnExistingWeapon();
                    break;

                case 4:
                    AddANewWeapon();
                    break;

                case 5:
                    DeleteExistingWeapon();
                    break;

                case 6:
                    ManageGameItemDetails();
                    break;

                default:
                    System.Console.WriteLine("Invalid Entry Please Try Again");
                    PressAnyKeyToContinue();
                    break;
            }
        }
        catch (Exception e)
        {
            System.Console.WriteLine("Bad selection.. Press any key to continue");
            Console.ReadKey();
        }
    }

    private void AddANewWeapon()
    {
        Clear();
        ForegroundColor = ConsoleColor.DarkYellow;
        WriteLine("Enter the details for the new Weapon:");

        Write("Weapon Name: ");
        string weaponName = ReadLine()!;

        Write("Weapon Type: ");
        string weaponType = ReadLine()!;


        Write("Weapon Description: ");
        string weaponDescription = ReadLine()!;

        Write("Weapon Range: ");
        bool weaponIsARangedWeapon = bool.Parse(Console.ReadLine()!);

        Write("Weapon Melee: ");
        bool weaponIsAMeleeWeapon = bool.Parse(Console.ReadLine()!);

        Write("Weapon Generates Splash Damage: ");
        bool weaponGeneratesSplashDamage = bool.Parse(Console.ReadLine()!);

        Write("Range Distance Weapon: ");
        string rangedWeaponDistance = ReadLine()!;

        Write("Weapon Splash Damage Amount: ");
        int weaponSplashDamageAmount = int.Parse(Console.ReadLine()!);

        WriteLine("Weapon Damage Amount: ");
        if (int.TryParse(ReadLine(), out int weaponDamageAmount))
        {
            var newWeapon = new WeaponDetailUI
            {
                WeaponName = weaponName,
                WeaponType = weaponType,
                WeaponDescription = weaponDescription,
                WeaponIsARangedWeapon = weaponIsARangedWeapon,
                WeaponIsAMeleeWeapon = weaponIsAMeleeWeapon,
                WeaponGeneratesSplashDamage = weaponGeneratesSplashDamage,
                RangedWeaponDistance = rangedWeaponDistance,
                WeaponSplashDamageAmount = weaponSplashDamageAmount,
                WeaponDamageAmount = weaponDamageAmount

            };
            HttpClient httpClient = new HttpClient();

            var weaponContent = new StringContent(JsonConvert.SerializeObject(newWeapon), Encoding.UTF8, "application/json");

            HttpResponseMessage response = httpClient.PostAsync("http://localhost:5211/api/Weapon", weaponContent).Result;
            if (response.IsSuccessStatusCode)
            {
                WeaponDetailUI weaponCreated = response.Content.ReadAsAsync<WeaponDetailUI>().Result;
                Clear();
                ForegroundColor = ConsoleColor.DarkMagenta;
                WriteLine("New weapon was added successfully");
                WriteLine("|=========================================================================================================================================================================|\n" +
                          "|                                                                                                                                                                         |\n" +
                          $"| WeaponId: {weaponCreated.WeaponId} ||  WeaponName: {weaponCreated.WeaponName}                                    \n" +
                          "|                                                                                                                                                                         |\n" +
                          "|=========================================================================================================================================================================|\n" +
                          "|                                                                                                                                                                         |\n" +
                          $"|Weapon Type: {weaponCreated.WeaponType} ||  Weapon Description: {weaponCreated.WeaponDescription}                  \n" +
                          "|                                                                                                                                                                         |\n" +
                          "|=========================================================================================================================================================================|\n" +
                          "|                                                                                                                                                                         |\n" +
                          $"|Weapon Is Ranged: {weaponCreated.WeaponIsARangedWeapon}  ||  Weapon is Melee Weapon: {weaponCreated.WeaponIsAMeleeWeapon}\n" +
                          "|                                                                                                                                                                         |\n" +
                          "|=========================================================================================================================================================================|\n" +
                          "|                                                                                                                                                                         |\n" +
                          $"|Weapon Generates Splash Damage: {weaponCreated.WeaponGeneratesSplashDamage} \n" +
                          "|                                                                                                                                                                         |\n" +
                          "|=========================================================================================================================================================================|\n" +
                          "|                                                                                                                                                                         |\n" +
                          $"|Range Distance for Weapon: {weaponCreated.RangedWeaponDistance}  ||  Weapon Splash Damage Amount: {weaponCreated.WeaponSplashDamageAmount}\n" +
                          "|                                                                                                                                                                         |\n" +
                          "|=========================================================================================================================================================================|\n" +
                          "|                                                                                                                                                                         |\n" +
                          $"|Weapon Damage Amount: {weaponCreated.WeaponDamageAmount} \n" +
                          "|                                                                                                                                                                         |\n" +
                          "|=========================================================================================================================================================================|\n");
                WriteLine("  ");

                PressAnyKeyToContinue();
                ManageWeapons();
            }
            else
            {
                WriteLine("Failed to add new Weapon");
            }
            PressAnyKeyToContinue();
            ManageWeapons();
        }
    }

    private void ViewAllWeapons()
    {
        Clear();
        ForegroundColor = ConsoleColor.DarkMagenta;

        HttpClient httpClient = new HttpClient();

        HttpResponseMessage response = httpClient.GetAsync("http://localhost:5211/api/Weapon").Result;
        if (response.IsSuccessStatusCode)
        {
            List<WeaponDetailUI> weapons = response.Content.ReadAsAsync<List<WeaponDetailUI>>().Result;
            System.Console.WriteLine("|=============================================|\n" +
                                     "|                                             |\n" +
                                     $"| Here are all the weapons currently          |\n" +
                                     "|     Available                               |\n" +
                                     "|                                             |\n" +
                                     "|=============================================|\n");
            foreach (var weapon in weapons)
            {
                WriteLine("|=========================================================================================================================================================================|\n" +
                          "|                                                                                                                                                                         |\n" +
                          $"| Weapon Id: {weapon.WeaponId} ||  Weapon Name: {weapon.WeaponName}                                    \n" +
                          "|                                                                                                                                                                         |\n" +
                          "|=========================================================================================================================================================================|\n" +
                          "|                                                                                                                                                                         |\n" +
                          $"|Weapon Type: {weapon.WeaponType} ||  Weapon Description: {weapon.WeaponDescription}                  \n" +
                          "|                                                                                                                                                                         |\n" +
                          "|=========================================================================================================================================================================|\n" +
                          "|                                                                                                                                                                         |\n" +
                          $"|Weapon Is Ranged: {weapon.WeaponIsARangedWeapon}  ||  Weapon is Melee Weapon: {weapon.WeaponIsAMeleeWeapon}\n" +
                          "|                                                                                                                                                                         |\n" +
                          "|=========================================================================================================================================================================|\n" +
                          "|                                                                                                                                                                         |\n" +
                          $"|Weapon Generates Splash Damage: {weapon.WeaponGeneratesSplashDamage} \n" +
                          "|                                                                                                                                                                         |\n" +
                          "|=========================================================================================================================================================================|\n" +
                          "|                                                                                                                                                                         |\n" +
                          $"|Range Distance for Weapon: {weapon.RangedWeaponDistance}  ||  Weapon Splash Damage Amount: {weapon.WeaponSplashDamageAmount}\n" +
                          "|                                                                                                                                                                         |\n" +
                          "|=========================================================================================================================================================================|\n" +
                          "|                                                                                                                                                                         |\n" +
                          $"|Weapon Damage Amount: {weapon.WeaponDamageAmount} \n" +
                          "|                                                                                                                                                                         |\n" +
                          "|=========================================================================================================================================================================|\n");
                WriteLine("  ");
                WriteLine("  ");
                WriteLine("  ");
            }
            
            PressAnyKeyToContinue();
            ManageWeapons();
        }
    }

    private void ViewAllWeaponsForCharacterCreate()
    {
        ForegroundColor = ConsoleColor.DarkMagenta;

        HttpClient httpClient = new HttpClient();

        HttpResponseMessage response = httpClient.GetAsync("http://localhost:5211/api/Weapon").Result;
        if (response.IsSuccessStatusCode)
        {
            List<WeaponDetailUI> weapons = response.Content.ReadAsAsync<List<WeaponDetailUI>>().Result;
            System.Console.WriteLine("|=============================================|\n" +
                                     "|                                             |\n" +
                                     $"| Here are all the weapons currently          |\n" +
                                     "|     Available                               |\n" +
                                     "|                                             |\n" +
                                     "|=============================================|\n");
            foreach (var weapon in weapons)
            {
                WriteLine("|=========================================================================================================================================================================|\n" +
                          "|                                                                                                                                                                         |\n" +
                          $"| Weapon Id: {weapon.WeaponId} ||  Weapon Name: {weapon.WeaponName}                                    \n" +
                          "|                                                                                                                                                                         |\n" +
                          "|=========================================================================================================================================================================|\n" +
                          "|                                                                                                                                                                         |\n" +
                          $"|Weapon Type: {weapon.WeaponType} ||  Weapon Description: {weapon.WeaponDescription}                  \n" +
                          "|                                                                                                                                                                         |\n" +
                          "|=========================================================================================================================================================================|\n" +
                          "|                                                                                                                                                                         |\n" +
                          $"|Weapon Is Ranged: {weapon.WeaponIsARangedWeapon}  ||  Weapon is Melee Weapon: {weapon.WeaponIsAMeleeWeapon}\n" +
                          "|                                                                                                                                                                         |\n" +
                          "|=========================================================================================================================================================================|\n" +
                          "|                                                                                                                                                                         |\n" +
                          $"|Weapon Generates Splash Damage: {weapon.WeaponGeneratesSplashDamage} \n" +
                          "|                                                                                                                                                                         |\n" +
                          "|=========================================================================================================================================================================|\n" +
                          "|                                                                                                                                                                         |\n" +
                          $"|Range Distance for Weapon: {weapon.RangedWeaponDistance}  ||  Weapon Splash Damage Amount: {weapon.WeaponSplashDamageAmount}\n" +
                          "|                                                                                                                                                                         |\n" +
                          "|=========================================================================================================================================================================|\n" +
                          "|                                                                                                                                                                         |\n" +
                          $"|Weapon Damage Amount: {weapon.WeaponDamageAmount} \n" +
                          "|                                                                                                                                                                         |\n" +
                          "|=========================================================================================================================================================================|\n");
                WriteLine("  ");
                WriteLine("  ");
                WriteLine("  ");
            }
        }
    }

    private void ViewWeaponById()
    {
        Clear();
        ForegroundColor = ConsoleColor.DarkMagenta;
        WriteLine("Please enter a WeaponId to look up a Weapons.");
        var weaponId = int.Parse(Console.ReadLine()!);

        HttpClient httpClient = new HttpClient();

        HttpResponseMessage response = httpClient.GetAsync($"http://localhost:5211/api/Weapon/{weaponId}").Result;
        if (response.IsSuccessStatusCode)
        {
            WeaponDetailUI weapon = response.Content.ReadAsAsync<WeaponDetailUI>().Result;
            WriteLine("|=========================================================================================================================================================================|\n" +
                          "|                                                                                                                                                                         |\n" +
                          $"| WeaponId: {weapon.WeaponId} ||  WeaponName: {weapon.WeaponName}                                    \n" +
                          "|                                                                                                                                                                         |\n" +
                          "|=========================================================================================================================================================================|\n" +
                          "|                                                                                                                                                                         |\n" +
                          $"|Weapon Type: {weapon.WeaponType} ||  Weapon Description: {weapon.WeaponDescription}                  \n" +
                          "|                                                                                                                                                                         |\n" +
                          "|=========================================================================================================================================================================|\n" +
                          "|                                                                                                                                                                         |\n" +
                          $"|Weapon Is Ranged: {weapon.WeaponIsARangedWeapon}  ||  Weapon is Melee Weapon: {weapon.WeaponIsAMeleeWeapon}\n" +
                          "|                                                                                                                                                                         |\n" +
                          "|=========================================================================================================================================================================|\n" +
                          "|                                                                                                                                                                         |\n" +
                          $"|Weapon Generates Splash Damage: {weapon.WeaponGeneratesSplashDamage} \n" +
                          "|                                                                                                                                                                         |\n" +
                          "|=========================================================================================================================================================================|\n" +
                          "|                                                                                                                                                                         |\n" +
                          $"|Range Distance for Weapon: {weapon.RangedWeaponDistance}  ||  Weapon Splash Damage Amount: {weapon.WeaponSplashDamageAmount}\n" +
                          "|                                                                                                                                                                         |\n" +
                          "|=========================================================================================================================================================================|\n" +
                          "|                                                                                                                                                                         |\n" +
                          $"|Weapon Damage Amount: {weapon.WeaponDamageAmount} \n" +
                          "|                                                                                                                                                                         |\n" +
                          "|=========================================================================================================================================================================|\n");
                WriteLine("  ");

            PressAnyKeyToContinue();
            ManageWeapons();
        }
    }

    private void UpdateAnExistingWeapon()
    {
        Clear();
        ForegroundColor = ConsoleColor.DarkYellow;
        WriteLine("Enter the ID of the weapon you want to update:");
        int weaponId = int.Parse(ReadLine()!);

        Write("Weapon Name: ");
        string weaponName = ReadLine()!;

        Write("Weapon Type: ");
        string weaponType = ReadLine()!;


        Write("Weapon Description: ");
        string weaponDescription = ReadLine()!;

        Write("Weapon Range: ");
        bool weaponIsARangedWeapon = bool.Parse(Console.ReadLine()!);

        Write("Weapon Melee: ");
        bool weaponIsAMeleeWeapon = bool.Parse(Console.ReadLine()!);

        Write("Weapon Generates Splash Damage: ");
        bool weaponGeneratesSplashDamage = bool.Parse(Console.ReadLine()!);

        Write("Range Distance Weapon: ");
        string rangedWeaponDistance = ReadLine()!;

        Write("Weapon Splash Damage Amount: ");
        int weaponSplashDamageAmount = int.Parse(Console.ReadLine()!);

        WriteLine("Weapon Damage Amount: ");
        if (int.TryParse(ReadLine(), out int weaponDamageAmount))
        {
            var updateWeapon = new WeaponDetailUI
            {
                WeaponId = weaponId,
                WeaponName = weaponName,
                WeaponType = weaponType,
                WeaponDescription = weaponDescription,
                WeaponIsARangedWeapon = weaponIsARangedWeapon,
                WeaponIsAMeleeWeapon = weaponIsAMeleeWeapon,
                WeaponGeneratesSplashDamage = weaponGeneratesSplashDamage,
                RangedWeaponDistance = rangedWeaponDistance,
                WeaponSplashDamageAmount = weaponSplashDamageAmount,
                WeaponDamageAmount = weaponDamageAmount

            };
            HttpClient httpClient = new HttpClient();

            var weaponContent = new StringContent(JsonConvert.SerializeObject(updateWeapon), Encoding.UTF8, "application/json");

            HttpResponseMessage response = httpClient.PutAsync("http://localhost:5211/api/Weapon", weaponContent).Result;
            if (response.IsSuccessStatusCode)
            {
                WriteLine("Weapon is updated successfully");
            }
            else
            {
                WriteLine("Failed to updated a weapon. Status Code: " + response.StatusCode);
            }
            PressAnyKeyToContinue();
            ManageWeapons();
        }
    }

    private void DeleteExistingWeapon()
    {
        Clear();
        ForegroundColor = ConsoleColor.Cyan;
        WriteLine("Please enter the WeaponID of the weapon you want to delete:");
        int weaponId = int.Parse(Console.ReadLine()!);

        HttpClient httpClient = new HttpClient();

        HttpResponseMessage response = httpClient.DeleteAsync($"http://localhost:5211/api/Weapon/{weaponId}").Result;

        if (response.IsSuccessStatusCode)
        {
            WriteLine("Weapon was deleted successfully.");
        }
        else
        {
            WriteLine("Failed to delete a weapon. Status Code: " + response.StatusCode);
        }

        PressAnyKeyToContinue();
        ManageWeapons();
    }

    private void ViewAllHairStyles()
    {
        Clear();
        ForegroundColor = ConsoleColor.DarkMagenta;

        HttpClient httpClient = new HttpClient();

        HttpResponseMessage response = httpClient.GetAsync("http://localhost:5211/api/HairStyle").Result;
        if (response.IsSuccessStatusCode)
        {
            List<HairStyleDetailUI> hairStyles = response.Content.ReadAsAsync<List<HairStyleDetailUI>>().Result;
            
            WriteLine("|=============================================|\n" +
                      "|                                             |\n" +
                      $"| Here is the information on the Hair Styles |\n" +
                      "|   that are available.                       |\n" +
                      "|                                             |\n" +
                      "|=============================================|\n");
            WriteLine("   ");  

            foreach (var hairStyle in hairStyles)
            {        
                WriteLine("======================================================================|\n" +
                          "|                                                                     |\n" +
                          $"|  Hair Style ID: {hairStyle.HairStyleId} | Hair Style Name: {hairStyle.HairStyleName}\n" +
                          "                                                                      ");
            }

            PressAnyKeyToContinue();
            ManageHairStyles();
        }
    }

    private void ViewAllHairStylesForCharacterCreate()
    {
        ForegroundColor = ConsoleColor.DarkMagenta;

        HttpClient httpClient = new HttpClient();

        HttpResponseMessage response = httpClient.GetAsync("http://localhost:5211/api/HairStyle").Result;
        if (response.IsSuccessStatusCode)
        {
            List<HairStyleDetailUI> hairStyles = response.Content.ReadAsAsync<List<HairStyleDetailUI>>().Result;

            foreach (var hairStyle in hairStyles)
            {
                WriteLine("======================================================================|\n" +
                          "|                                                                     |\n" +
                          $"|  Hair Style ID: {hairStyle.HairStyleId} | Hair Style Name: {hairStyle.HairStyleName}\n" +
                          "                                                                      ");
            }
        }
    }

    private void ViewAllCharacterClasses()
    {
        Clear();
        ForegroundColor = ConsoleColor.DarkMagenta;

        HttpClient httpClient = new HttpClient();

        HttpResponseMessage response = httpClient.GetAsync("http://localhost:5211/api/CharacterClass").Result;
        if (response.IsSuccessStatusCode)
        {
            List<CharacterClassListUI> characterClasses = response.Content.ReadAsAsync<List<CharacterClassListUI>>().Result;

            WriteLine("|=============================================|\n" +
                      "|                                             |\n" +
                      $"| Here is the information on the Character   |\n" +
                      "|  Classes that are available.                |\n" +
                      "|                                             |\n" +
                      "|=============================================|\n");
            WriteLine("   ");  

            foreach (var characterClass in characterClasses)
            {
                WriteLine("|=========================================================================================================================================================================|\n" +
                          "|                                                                                                                                                                         |\n" +
                          $"| Character Class Id: {characterClass.CharacterClassId} ||  Character Class Name: {characterClass.CharacterClassName}                                    \n" +
                          "|                                                                                                                                                                         |\n" +
                          "|=========================================================================================================================================================================|\n" +
                          "|                                                                                                                                                                         |\n" +
                          "|Character Class Description:                                                                                                                                             |\n" +
                          "|=========================================================================================================================================================================|\n" +
                          "|                                                                                                                                                                         |\n" +
                          $"|{characterClass.CharacterClassDescription} \n" +
                          "|                                                                                                                                                                         |\n" +
                          "|=========================================================================================================================================================================|\n" +
                          "|                                                                                                                                                                         |\n" +
                          $"|Character Class Special Ability: {characterClass.CharacterClassSpecialAbility}  \n" +
                          "|=========================================================================================================================================================================|\n" +
                          "|                                                                                                                                                                         |\n" +
                          $"{characterClass.SpecialAbilityDescription} \n" +
                          "|                                                                                                                                                                         |\n" +
                          "|=========================================================================================================================================================================|\n" +
                          "|                                                                                                                                                                         |\n" +
                          $"|Special Ability Is an Attack: {characterClass.SpecialAbilityIsAnAttack}  ||  Special Ability Heals: {characterClass.SpecialAbilityHeals} \n" +
                          "|                                                                                                                                                                         |\n" +
                          "|=========================================================================================================================================================================|\n" +
                          "|                                                                                                                                                                         |\n" +
                          $"|Special Ability Provides Defense: {characterClass.SpecialAbilityProvidesDefense}  ||  Special Ability Provides Status Effect: {characterClass.SpecialAbilityProvidesStatusEffect} \n" +
                          "|                                                                                                                                                                         |\n" +
                          "|=========================================================================================================================================================================|\n" +
                          "|                                                                                                                                                                         |\n" +
                          $"|Special Ability Damage Amount: {characterClass.SpecialAbilityDamage}  ||  Special Ability Healing Amount: {characterClass.SpecialAbilityHealingAmount} \n" +
                          "|                                                                                                                                                                         |\n" +
                          "|=========================================================================================================================================================================|\n" +
                          "|                                                                                                                                                                         |\n" +
                          $"|Special Ability Defense Amount: {characterClass.SpeacialAbilityDefenseAmount}  ||  Special Ability Duration: {characterClass.SpecialAbilityDuration} \n" +
                          "|                                                                                                                                                                         |\n" +
                          "|=========================================================================================================================================================================|\n");
                WriteLine("  ");
                WriteLine("  ");
                WriteLine("  ");
            }

            PressAnyKeyToContinue();
            ManageCharacterClasses();
        }
    }

    private void ViewAllCharacterClassesForCharacterCreate()
    {
        ForegroundColor = ConsoleColor.DarkMagenta;

        HttpClient httpClient = new HttpClient();

        HttpResponseMessage response = httpClient.GetAsync("http://localhost:5211/api/CharacterClass").Result;
        if (response.IsSuccessStatusCode)
        {
            List<CharacterClassListUI> characterClasses = response.Content.ReadAsAsync<List<CharacterClassListUI>>().Result;

            foreach (var characterClass in characterClasses)
            {
                WriteLine("|=========================================================================================================================================================================|\n" +
                          "|                                                                                                                                                                         |\n" +
                          $"| Character Class Id: {characterClass.CharacterClassId} ||  Character Class Name: {characterClass.CharacterClassName}                                    \n" +
                          "|                                                                                                                                                                         |\n" +
                          "|=========================================================================================================================================================================|\n" +
                          "|                                                                                                                                                                         |\n" +
                          "|Character Class Description:                                                                                                                                             |\n" +
                          "|=========================================================================================================================================================================|\n" +
                          "|                                                                                                                                                                         |\n" +
                          $"|{characterClass.CharacterClassDescription} \n" +
                          "|                                                                                                                                                                         |\n" +
                          "|=========================================================================================================================================================================|\n" +
                          "|                                                                                                                                                                         |\n" +
                          $"|Character Class Special Ability: {characterClass.CharacterClassSpecialAbility}  \n" +
                          "|=========================================================================================================================================================================|\n" +
                          "|                                                                                                                                                                         |\n" +
                          $"{characterClass.SpecialAbilityDescription} \n" +
                          "|                                                                                                                                                                         |\n" +
                          "|=========================================================================================================================================================================|\n" +
                          "|                                                                                                                                                                         |\n" +
                          $"|Special Ability Is an Attack: {characterClass.SpecialAbilityIsAnAttack}  ||  Special Ability Heals: {characterClass.SpecialAbilityHeals} \n" +
                          "|                                                                                                                                                                         |\n" +
                          "|=========================================================================================================================================================================|\n" +
                          "|                                                                                                                                                                         |\n" +
                          $"|Special Ability Provides Defense: {characterClass.SpecialAbilityProvidesDefense}  ||  Special Ability Provides Status Effect: {characterClass.SpecialAbilityProvidesStatusEffect} \n" +
                          "|                                                                                                                                                                         |\n" +
                          "|=========================================================================================================================================================================|\n" +
                          "|                                                                                                                                                                         |\n" +
                          $"|Special Ability Damage Amount: {characterClass.SpecialAbilityDamage}  ||  Special Ability Healing Amount: {characterClass.SpecialAbilityHealingAmount} \n" +
                          "|                                                                                                                                                                         |\n" +
                          "|=========================================================================================================================================================================|\n" +
                          "|                                                                                                                                                                         |\n" +
                          $"|Special Ability Defense Amount: {characterClass.SpeacialAbilityDefenseAmount}  ||  Special Ability Duration: {characterClass.SpecialAbilityDuration} \n" +
                          "|                                                                                                                                                                         |\n" +
                          "|=========================================================================================================================================================================|\n");
                WriteLine("  ");
                WriteLine("  ");
                WriteLine("  ");
            }

        }
    }

    private void ViewAllConsumables()
    {
        Clear();
        ForegroundColor = ConsoleColor.DarkRed;

        HttpClient httpClient = new HttpClient();

        HttpResponseMessage response = httpClient.GetAsync("http://localhost:5211/api/Consumable").Result;
        if (response.IsSuccessStatusCode)
        {
            List<ConsumableDetailUI> consumables = response.Content.ReadAsAsync<List<ConsumableDetailUI>>().Result;

             WriteLine("|=============================================|\n" +
                          "|                                             |\n" +
                          $"| Here is the information on the Consumables |\n" +
                          "|   that are available.                       |\n" +
                          "|                                             |\n" +
                          "|=============================================|\n");
                    
                WriteLine("  ");

            foreach (var consumable in consumables)
            {
                WriteLine("|=========================================================================================================================================================================|\n" +
                          "|                                                                                                                                                                         |\n" +
                          $"| Consumable Id: {consumable.ConsumableId} ||  Consumable Name: {consumable.ConsumableName}                                    \n" +
                          "|                                                                                                                                                                         |\n" +
                          "|=========================================================================================================================================================================|\n" +
                          "|                                                                                                                                                                         |\n" +
                          $"| Consumable Description: {consumable.ConsumableDescription}                  \n" +
                          "|                                                                                                                                                                         |\n" +
                          "|=========================================================================================================================================================================|\n" +
                          "|                                                                                                                                                                         |\n" +
                          $"|Consumable Effect: {consumable.ConsumableEffect}  || Consumable Increases Health: {consumable.ConsumableIncreaseHealth}\n" +
                          "|                                                                                                                                                                         |\n" +
                          "|=========================================================================================================================================================================|\n" +
                          "|                                                                                                                                                                         |\n" +
                          $"|Consumable Increases Defense: {consumable.ConsumableIncreaseDefense}  ||  Consumable Increases Attack: {consumable.ConsumableIncreaseAttack}  \n" +
                          "|                                                                                                                                                                         |\n" +
                          "|=========================================================================================================================================================================|\n" +
                          "|                                                                                                                                                                         |\n" +
                          $"|Consumable Does Damage To An Enemy: {consumable.ConsumableDoesDamageToEnemy}  ||  Consumable Health Increase Amount: {consumable.ConsumableHealthIncreaseAmount}\n" +
                          "|                                                                                                                                                                         |\n" +
                          "|=========================================================================================================================================================================|\n" +
                          "|                                                                                                                                                                         |\n" +
                          $"|Consumable Defense Increase Amount: {consumable.ConsumableDefenseIncreaseAmount}  ||  Consumable Attack Increase Amount: {consumable.ConsumableAttackIncreaseAmount}  \n" +
                          "|                                                                                                                                                                         |\n" +
                          "|=========================================================================================================================================================================|\n" +
                          "|                                                                                                                                                                         |\n" +
                          $"|Console Damage Amount to Enemy: {consumable.ConsumableDamageToEnemy}     \n" +
                          "|                                                                                                                                                                         |\n" +
                          "|=========================================================================================================================================================================|\n");
                WriteLine("  ");
                WriteLine("  ");
            }

            PressAnyKeyToContinue();
            ManageConsumables();
        }
    }

    private void ViewAllConsumablesForCharacterCreate()
    {
        ForegroundColor = ConsoleColor.DarkRed;

        HttpClient httpClient = new HttpClient();

        HttpResponseMessage response = httpClient.GetAsync("http://localhost:5211/api/Consumable").Result;
        if (response.IsSuccessStatusCode)
        {
            List<ConsumableDetailUI> consumables = response.Content.ReadAsAsync<List<ConsumableDetailUI>>().Result;

            foreach (var consumable in consumables)
            {
                WriteLine("|=========================================================================================================================================================================|\n" +
                          "|                                                                                                                                                                         |\n" +
                          $"| Consumable Id: {consumable.ConsumableId} ||  Consumable Name: {consumable.ConsumableName}                                    \n" +
                          "|                                                                                                                                                                         |\n" +
                          "|=========================================================================================================================================================================|\n" +
                          "|                                                                                                                                                                         |\n" +
                          $"| Consumable Description: {consumable.ConsumableDescription}                  \n" +
                          "|                                                                                                                                                                         |\n" +
                          "|=========================================================================================================================================================================|\n" +
                          "|                                                                                                                                                                         |\n" +
                          $"|Consumable Effect: {consumable.ConsumableEffect}  || Consumable Increases Health: {consumable.ConsumableIncreaseHealth}\n" +
                          "|                                                                                                                                                                         |\n" +
                          "|=========================================================================================================================================================================|\n" +
                          "|                                                                                                                                                                         |\n" +
                          $"|Consumable Increases Defense: {consumable.ConsumableIncreaseDefense}  ||  Consumable Increases Attack: {consumable.ConsumableIncreaseAttack}  \n" +
                          "|                                                                                                                                                                         |\n" +
                          "|=========================================================================================================================================================================|\n" +
                          "|                                                                                                                                                                         |\n" +
                          $"|Consumable Does Damage To An Enemy: {consumable.ConsumableDoesDamageToEnemy}  ||  Consumable Health Increase Amount: {consumable.ConsumableHealthIncreaseAmount}\n" +
                          "|                                                                                                                                                                         |\n" +
                          "|=========================================================================================================================================================================|\n" +
                          "|                                                                                                                                                                         |\n" +
                          $"|Consumable Defense Increase Amount: {consumable.ConsumableDefenseIncreaseAmount}  ||  Consumable Attack Increase Amount: {consumable.ConsumableAttackIncreaseAmount}  \n" +
                          "|                                                                                                                                                                         |\n" +
                          "|=========================================================================================================================================================================|\n" +
                          "|                                                                                                                                                                         |\n" +
                          $"|Console Damage Amount to Enemy: {consumable.ConsumableDamageToEnemy}     \n" +
                          "|                                                                                                                                                                         |\n" +
                          "|=========================================================================================================================================================================|\n");
                WriteLine("  ");
                WriteLine("  ");
            }

        }
    }

    private void ViewAllHairColors()
    {

        ForegroundColor = ConsoleColor.DarkGreen;

        HttpClient httpClient = new HttpClient();

        HttpResponseMessage response = httpClient.GetAsync("http://localhost:5211/api/HairColor").Result;
        if (response.IsSuccessStatusCode)
        {
            List<HairColorDetailUI> hairColors = response.Content.ReadAsAsync<List<HairColorDetailUI>>().Result;

            foreach (var hairColor in hairColors)
            {
                WriteLine("======================================================================|\n" +
                          "|                                                                     |\n" +
                          $"|  Hair Color ID: {hairColor.HairColorId} | Hair Color Name: {hairColor.HairColorName}\n" +
                          "                                                                      ");
            }

            PressAnyKeyToContinue();
        }
    }

    private void ViewAllBodyTypes()
    {

        ForegroundColor = ConsoleColor.DarkCyan;

        HttpClient httpClient = new HttpClient();

        HttpResponseMessage response = httpClient.GetAsync("http://localhost:5211/api/BodyType").Result;
        if (response.IsSuccessStatusCode)
        {
            List<BodyTypeDetailUI> bodyTypes = response.Content.ReadAsAsync<List<BodyTypeDetailUI>>().Result;

            foreach (var bodyType in bodyTypes)
            {
                WriteLine("======================================================================|\n" +
                          "|                                                                     |\n" +
                          $"|  Body Type Id: {bodyType.BodyTypeId} | Body Type Name: {bodyType.BodyTypeName}\n" +
                          "                                                                      ");
            }

            PressAnyKeyToContinue();
        }
    }

    private void ViewAllAbilities()
    {
        Clear();
        ForegroundColor = ConsoleColor.DarkCyan;

        HttpClient httpClient = new HttpClient();

        HttpResponseMessage response = httpClient.GetAsync("http://localhost:5211/api/Ability").Result;
        if (response.IsSuccessStatusCode)
        {
            List<AbilityDetailUI> abilities = response.Content.ReadAsAsync<List<AbilityDetailUI>>().Result;

            WriteLine("|=============================================|\n" +
                      "|                                             |\n" +
                      $"| Here is the information on the Abilities   |\n" +
                      "|   that are available.                       |\n" +
                      "|                                             |\n" +
                      "|=============================================|\n");
                    
            WriteLine("  ");

            foreach (var ability in abilities)
            {
                WriteLine("|=========================================================================================================================================================================|\n" +
                          "|                                                                                                                                                                         |\n" +
                          $"| Ability Id: {ability.AbilityId} ||  Ability Name: {ability.AbilityName}                                    \n" +
                          "|                                                                                                                                                                         |\n" +
                          "|=========================================================================================================================================================================|\n" +
                          "|                                                                                                                                                                         |\n" +
                          $"| Ability Description: {ability.AbilityDescription}                  \n" +
                          "|                                                                                                                                                                         |\n" +
                          "|=========================================================================================================================================================================|\n" +
                          "|                                                                                                                                                                         |\n" +
                          $"|Ability Effect Type: {ability.AbilityEffectType}  ||  Ability is an Attack: {ability.AbilityEffectAttack}\n" +
                          "|                                                                                                                                                                         |\n" +
                          "|=========================================================================================================================================================================|\n" +
                          "|                                                                                                                                                                         |\n" +
                          $"|Ability Enhances Health: {ability.AbilityEffectHealthEnhancement}  ||  Ability Enhances Defence: {ability.AbilityEffectDefenseEnhancement}  \n" +
                          "|                                                                                                                                                                         |\n" +
                          "|=========================================================================================================================================================================|\n" +
                          "|                                                                                                                                                                         |\n" +
                          $"|Ability Has A Status Effect: {ability.AbilityHasStatusEffect}  ||  Ability Does Damage to Single Enemy: {ability.AbilityDamageSingleEnemy}\n" +
                          "|                                                                                                                                                                         |\n" +
                          "|=========================================================================================================================================================================|\n" +
                          "|                                                                                                                                                                         |\n" +
                          $"|Ability Does Damage to Multipl Enemies: {ability.AbilityDamageMultipleEnemy}  ||  Ability Attack Damage Amount: {ability.AbilityAttackDamage}  \n" +
                          "|                                                                                                                                                                         |\n" +
                          "|=========================================================================================================================================================================|\n" +
                          "|                                                                                                                                                                         |\n" +
                          $"|Ability Healing Amount: {ability.AbilityHealingAmount} || Ability Defense Increase Amount: {ability.AbilityDefenseIncrease} || Ability Effect Time Limit: {ability.AbilityEffectTimeLimit}\n" +
                          "|                                                                                                                                                                         |\n" +
                          "|=========================================================================================================================================================================|\n");
                WriteLine("  ");
                WriteLine("  ");
            }
            }

            PressAnyKeyToContinue();
            ManageAbilities();
    }

    private void ViewAllAbilitiesForCharacterCreate()
    {
        ForegroundColor = ConsoleColor.DarkCyan;

        HttpClient httpClient = new HttpClient();

        HttpResponseMessage response = httpClient.GetAsync("http://localhost:5211/api/Ability").Result;
        if (response.IsSuccessStatusCode)
        {
            List<AbilityDetailUI> abilities = response.Content.ReadAsAsync<List<AbilityDetailUI>>().Result;

            foreach (var ability in abilities)
            {
                WriteLine("|=========================================================================================================================================================================|\n" +
                          "|                                                                                                                                                                         |\n" +
                          $"| Ability Id: {ability.AbilityId} ||  Ability Name: {ability.AbilityName}                                    \n" +
                          "|                                                                                                                                                                         |\n" +
                          "|=========================================================================================================================================================================|\n" +
                          "|                                                                                                                                                                         |\n" +
                          $"| Ability Description: {ability.AbilityDescription}                  \n" +
                          "|                                                                                                                                                                         |\n" +
                          "|=========================================================================================================================================================================|\n" +
                          "|                                                                                                                                                                         |\n" +
                          $"|Ability Effect Type: {ability.AbilityEffectType}  ||  Ability is an Attack: {ability.AbilityEffectAttack}\n" +
                          "|                                                                                                                                                                         |\n" +
                          "|=========================================================================================================================================================================|\n" +
                          "|                                                                                                                                                                         |\n" +
                          $"|Ability Enhances Health: {ability.AbilityEffectHealthEnhancement}  ||  Ability Enhances Defence: {ability.AbilityEffectDefenseEnhancement}  \n" +
                          "|                                                                                                                                                                         |\n" +
                          "|=========================================================================================================================================================================|\n" +
                          "|                                                                                                                                                                         |\n" +
                          $"|Ability Has A Status Effect: {ability.AbilityHasStatusEffect}  ||  Ability Does Damage to Single Enemy: {ability.AbilityDamageSingleEnemy}\n" +
                          "|                                                                                                                                                                         |\n" +
                          "|=========================================================================================================================================================================|\n" +
                          "|                                                                                                                                                                         |\n" +
                          $"|Ability Does Damage to Multipl Enemies: {ability.AbilityDamageMultipleEnemy}  ||  Ability Attack Damage Amount: {ability.AbilityAttackDamage}  \n" +
                          "|                                                                                                                                                                         |\n" +
                          "|=========================================================================================================================================================================|\n" +
                          "|                                                                                                                                                                         |\n" +
                          $"|Ability Healing Amount: {ability.AbilityHealingAmount} || Ability Defense Increase Amount: {ability.AbilityDefenseIncrease} || Ability Effect Time Limit: {ability.AbilityEffectTimeLimit}\n" +
                          "|                                                                                                                                                                         |\n" +
                          "|=========================================================================================================================================================================|\n");
                WriteLine("  ");
                WriteLine("  ");
            }
            }

    }

    private void ViewAllArmours()
    {
        Clear();
        ForegroundColor = ConsoleColor.DarkCyan;

        HttpClient httpClient = new HttpClient();

        HttpResponseMessage response = httpClient.GetAsync("http://localhost:5211/api/Armour").Result;
        if (response.IsSuccessStatusCode)
        {
            List<ArmourDetailUI> armours = response.Content.ReadAsAsync<List<ArmourDetailUI>>().Result;

            WriteLine("|=============================================|\n" +
                      "|                                             |\n" +
                      $"| Here is the information on the Armours that|\n" +
                      "|     are available.                          |\n" +
                      "|                                             |\n" +
                      "|=============================================|\n");
                    
            WriteLine("  ");

            foreach (var armour in armours)
            {
                WriteLine("|=========================================================================================================================================================================|\n" +
                          "|                                                                                                                                                                         |\n" +
                          $"| Armour Id: {armour.ArmourId} ||  ArmourName: {armour.ArmourName}                                    \n" +
                          "|                                                                                                                                                                         |\n" +
                          "|=========================================================================================================================================================================|\n" +
                          "|                                                                                                                                                                         |\n" +
                          $"| Armour Description: {armour.ArmourDescription}                  \n" +
                          "|                                                                                                                                                                         |\n" +
                          "|=========================================================================================================================================================================|\n" +
                          "|                                                                                                                                                                         |\n" +
                          $"|Armour Provides Defense: {armour.ArmourProvidesDefense}  ||  Armour Increases Health: {armour.ArmourIncreasesHealth}\n" +
                          "|                                                                                                                                                                         |\n" +
                          "|=========================================================================================================================================================================|\n" +
                          "|                                                                                                                                                                         |\n" +
                          $"|Armour Increases Sword Attacks: {armour.ArmourIncreasesSwordAttacks}  ||  Armour Increases Ranged Attacks: {armour.ArmourIncreasesRangedAttacks}  \n" +
                          "|                                                                                                                                                                         |\n" +
                          "|=========================================================================================================================================================================|\n" +
                          "|                                                                                                                                                                         |\n" +
                          $"|Sword Damage Increase: {armour.IncreasedSwordDamageAmount}  ||  Health Increase Amount: {armour.IncreasedHealthAmount}\n" +
                          "|                                                                                                                                                                         |\n" +
                          "|=========================================================================================================================================================================|\n" +
                          "|                                                                                                                                                                         |\n" +
                          $"|Ranged Damage Increase Amount: {armour.IncreasedRangeAttackDamageAmount}  ||  Armour Protection Amount: {armour.IncreasedDefenseAmount}  \n" +
                          "|                                                                                                                                                                         |\n" +
                          "|=========================================================================================================================================================================|\n");
                WriteLine("  ");
                WriteLine("  ");
            }

            PressAnyKeyToContinue();
            ManageArmours();
        }
    }

    private void ViewAllArmoursForCharacterCreate()
    {
        ForegroundColor = ConsoleColor.DarkCyan;

        HttpClient httpClient = new HttpClient();

        HttpResponseMessage response = httpClient.GetAsync("http://localhost:5211/api/Armour").Result;
        if (response.IsSuccessStatusCode)
        {
            List<ArmourDetailUI> armours = response.Content.ReadAsAsync<List<ArmourDetailUI>>().Result;

            foreach (var armour in armours)
            {
                WriteLine("|=========================================================================================================================================================================|\n" +
                          "|                                                                                                                                                                         |\n" +
                          $"| Armour Id: {armour.ArmourId} ||  ArmourName: {armour.ArmourName}                                    \n" +
                          "|                                                                                                                                                                         |\n" +
                          "|=========================================================================================================================================================================|\n" +
                          "|                                                                                                                                                                         |\n" +
                          $"| Armour Description: {armour.ArmourDescription}                  \n" +
                          "|                                                                                                                                                                         |\n" +
                          "|=========================================================================================================================================================================|\n" +
                          "|                                                                                                                                                                         |\n" +
                          $"|Armour Provides Defense: {armour.ArmourProvidesDefense}  ||  Armour Increases Health: {armour.ArmourIncreasesHealth}\n" +
                          "|                                                                                                                                                                         |\n" +
                          "|=========================================================================================================================================================================|\n" +
                          "|                                                                                                                                                                         |\n" +
                          $"|Armour Increases Sword Attacks: {armour.ArmourIncreasesSwordAttacks}  ||  Armour Increases Ranged Attacks: {armour.ArmourIncreasesRangedAttacks}  \n" +
                          "|                                                                                                                                                                         |\n" +
                          "|=========================================================================================================================================================================|\n" +
                          "|                                                                                                                                                                         |\n" +
                          $"|Sword Damage Increase: {armour.IncreasedSwordDamageAmount}  ||  Health Increase Amount: {armour.IncreasedHealthAmount}\n" +
                          "|                                                                                                                                                                         |\n" +
                          "|=========================================================================================================================================================================|\n" +
                          "|                                                                                                                                                                         |\n" +
                          $"|Ranged Damage Increase Amount: {armour.IncreasedRangeAttackDamageAmount}  ||  Armour Protection Amount: {armour.IncreasedDefenseAmount}  \n" +
                          "|                                                                                                                                                                         |\n" +
                          "|=========================================================================================================================================================================|\n");
                WriteLine("  ");
                WriteLine("  ");

            }
        }
    }

    private void ManageGameItemDetails()
    {
        Clear();
        ForegroundColor = ConsoleColor.Red;
        WriteLine("|=======================================|\n" +
                    "|                                       |\n" +
                    "|  DnDTeamGame Game Item Management     |\n" +
                    "|  What would you like to do?           |\n" +
                    "|                                       |\n" +
                    "|=======================================|\n" +
                    "|                                       |");
        ConsoleKeyInfo key;
        int option = 1;
        bool isSelected = false;
        (int left, int top) = Console.GetCursorPosition();
        string color = "👻\u001b[37m";

        while(!isSelected)
        {   
            Console.SetCursorPosition(left, top);
            WriteLine($"|{(option == 1 ? color : "  ")}1. Manage Weapons\u001b[31m                    |");
            WriteLine($"|{(option == 2 ? color : "  ")}2. Manage Vehicles\u001b[31m                   |");
            WriteLine($"|{(option == 3 ? color : "  ")}3. Manage Character Classes\u001b[31m          |");
            WriteLine($"|{(option == 4 ? color : "  ")}4. Manage Abilities\u001b[31m                  |");
            WriteLine($"|{(option == 5 ? color : "  ")}5. Manage Armours\u001b[31m                    |");
            WriteLine($"|{(option == 6 ? color : "  ")}6. Manage Consumables\u001b[31m                |");
            WriteLine($"|{(option == 7 ? color : "  ")}7. Manage Body Types\u001b[31m                 |");
            WriteLine($"|{(option == 8 ? color : "  ")}8. Manage Hair Styles\u001b[31m                |");
            WriteLine($"|{(option == 9 ? color : "  ")}9. Manage Hair Colors\u001b[31m                |");
            WriteLine($"|{(option == 10 ? color : "  ")}10. Manage Maps\u001b[31m                      |");
            WriteLine($"|{(option == 11 ? color : "  ")}11. Manage Characters\u001b[31m                |");
            WriteLine($"|{(option == 12 ? color : "  ")}12. Return to Main Menu\u001b[31m              |");
            WriteLine("|                                       |\u001b[31m");
            WriteLine("|=======================================|\u001b[31m");
            try
            {
                key = Console.ReadKey(true); 

                switch (key.Key)
                {
                    case ConsoleKey.DownArrow:
                        option = (option == 12 ? 1 : option + 1);
                        break;

                    case ConsoleKey.UpArrow:
                        option = (option == 1 ? 12 : option -1);
                        break;

                    case ConsoleKey.Enter:
                        isSelected = true;
                        break;

                    default:
                        WriteLine("Invalid Selection Please Try Again");
                        PressAnyKeyToContinue();
                        break;
                }
            }
            catch (Exception e)
            {
                System.Console.WriteLine("Bad selection.. Press any key to continue");
                Console.ReadKey();
            }
                
        }                        

        try
        {
            var userInput = option;
            switch (userInput)
            {
                case 1:
                    ManageWeapons();
                    break;

                case 2:
                    ManageVehicles();
                    break;

                case 3:
                    ManageCharacterClasses();
                    break;

                case 4:
                    ManageAbilities();
                    break;

                case 5:
                    ManageArmours();
                    break;

                case 6:
                    ManageConsumables();
                    break;
                case 7:
                    ManageBodyTypes();
                    break;
                case 8:
                    ManageHairStyles();
                    break;
                case 9:
                    ManageHairColors();
                    break;
                case 10:
                    ManageMaps();
                    break;
                case 11:
                    ManageCharacters();
                    break;
                case 12:
                    Run();
                    break;

                default:
                    System.Console.WriteLine("Invalid Entry Please Try Again");
                    PressAnyKeyToContinue();
                    break;
            }
        }

        catch (Exception e)
        {
            System.Console.WriteLine("Bad selection.. Press any key to continue");
            Console.ReadKey();
        }

    }

// ========================================= Map UI ================================== //
    private void ManageMaps()
    {
        Clear();
        ForegroundColor = ConsoleColor.White;
        WriteLine("|=======================================|\n" +
                    "|                                       |\n" +
                    "|                                       |\n" +
                    "|  What would you like to do with the   |\n" +
                    "|  Map?                                 |\n" +
                    "|=======================================|\n" +
                    "|                                       |\n" +
                    "|  1. View All Map                      |\n" +
                    "|  2. View Map By Id                    |\n" +
                    "|  3. Update Existing Map               |\n" +
                    "|  4. Add a New Map                     |\n" +
                    "|  5. Delete a Map                      |\n" +
                    "|  0. Return to Manage Game Items       |\n" +
                    "|=======================================|");
        try
        {
            var userInput = int.Parse(Console.ReadLine()!);
            switch (userInput)
            {
                case 1:
                    ViewAllMaps();
                    break;

                case 2:
                    ViewMapById();
                    break;

                case 3:
                    UpdateAnExistingMap();
                    break;

                case 4:
                    AddANewMap();
                    break;

                case 5:
                    DeleteExistingMap();
                    break;

                case 0:
                    ManageGameItemDetails();
                    break;

                default:
                    System.Console.WriteLine("Invalid Entry Please Try Again");
                    PressAnyKeyToContinue();
                    break;
            }
        }
        catch (Exception e)
        {
            System.Console.WriteLine("Bad selection.. Press any key to continue");
            Console.ReadKey();
        }    
    }

    private void AddANewMap()
    {
        Clear();
        ForegroundColor = ConsoleColor.DarkYellow;
        WriteLine("Enter the details for the Map:");

        Write("Map Name: ");
        string mapName= ReadLine()!;

        Write("MapType: ");
        string mapType = ReadLine()!;

        Write("MapDescription: ");
        string mapDescription = ReadLine()!;

        Write("IsDayTime: ");
        bool isDayTime = bool.Parse(ReadLine()!);

        Write("PrecipitationType: ");
        string precipitationType = ReadLine()!;

            var newMap= new MapDetailsUI
            {
                MapName = mapName,
                MapType = mapType,
                MapDescription = mapDescription,
                IsDaytime = isDayTime,
                PrecipitationType = precipitationType
            };
            HttpClient httpClient = new HttpClient();

            var mapContent = new StringContent(JsonConvert.SerializeObject(newMap), Encoding.UTF8, "application/json");

            HttpResponseMessage response = httpClient.PostAsync("http://localhost:5211/api/Map", mapContent).Result;
            if (response.IsSuccessStatusCode)
            {
                WriteLine("The new Map was added successfully!!!");
            }
            else
            {
                WriteLine("Failed to add new Map");
            }
            PressAnyKeyToContinue();     
            ManageMaps();
    }

    private void ViewAllMaps()
    {
        Clear();
        ForegroundColor = ConsoleColor.DarkMagenta;

        HttpClient httpClient = new HttpClient();

        HttpResponseMessage response = httpClient.GetAsync("http://localhost:5211/api/Map").Result;
        if (response.IsSuccessStatusCode)
        {
            List<MapDetailsUI> maps = response.Content.ReadAsAsync<List<MapDetailsUI>>().Result;

            foreach (var map in maps)
            {
                WriteLine(
                          $"MapId {map.MapId} \n" +
                          $"MapName: {map.MapName} \n" +
                          $"MapType: {map.MapType} \n" +
                          $"MapDescription: {map.MapDescription} \n" +
                          $"IsDayTime: {map.IsDaytime} \n" +
                          $"PrecipitationType: {map.PrecipitationType} \n");
            }
            PressAnyKeyToContinue();
            ManageMaps();
        }    
    }

    private void ViewMapById()
    {
        Clear();
        ForegroundColor = ConsoleColor.DarkMagenta;
        WriteLine("Please enter a MapId to look up a Map.");
        var mapId = int.Parse(Console.ReadLine()!);

        HttpClient httpClient = new HttpClient();

        HttpResponseMessage response = httpClient.GetAsync($"http://localhost:5211/api/Map/{mapId}").Result;
        if (response.IsSuccessStatusCode)
        {
            MapDetailsUI map = response.Content.ReadAsAsync<MapDetailsUI>().Result;
                WriteLine(
                          $"MapName: {map.MapName} \n" +
                          $"MapType: {map.MapType} \n" +
                          $"MapDescription: {map.MapDescription} \n" +
                          $"IsDayTime: {map.IsDaytime} \n" +
                          $"PrecipitationType: {map.PrecipitationType} \n");
            PressAnyKeyToContinue();
            ManageMaps();
        }          
    }

    private void UpdateAnExistingMap()
    {
        Clear();
        ForegroundColor = ConsoleColor.DarkYellow;
        WriteLine("Enter the ID of the Map you want to update:");
        int mapId = int.Parse(ReadLine()!);

        Write("Map Name: ");
        string mapName= ReadLine()!;

        Write("MapType");
        string mapType = ReadLine()!;

        Write("MapDescription");
        string mapDescription = ReadLine()!;

        Write("IsDayTime");
        bool isDayTime = bool.Parse(ReadLine()!);

        Write("PrecipitationType");
        string precipitationType = ReadLine()!;

        var newMap= new MapDetailsUI
            {
                MapId = mapId,
                MapName = mapName,
                MapType = mapType,
                MapDescription = mapDescription,
                IsDaytime = isDayTime,
                PrecipitationType = precipitationType
            };
            HttpClient httpClient = new HttpClient();

            var mapContent = new StringContent(JsonConvert.SerializeObject(newMap), Encoding.UTF8, "application/json");

            HttpResponseMessage response = httpClient.PutAsync("http://localhost:5211/api/Map", mapContent).Result;
            if (response.IsSuccessStatusCode)
            {
                WriteLine("Map is updated successfully");
            }
            else
            {
                WriteLine("Failed to update Map");
            }
            PressAnyKeyToContinue(); 
            ManageMaps();    
    }

    private void DeleteExistingMap()
    {
        Clear();
        ForegroundColor = ConsoleColor.Cyan;
        WriteLine("Please enter the MapId of the Map you want to delete:");
        int mapId = int.Parse(Console.ReadLine()!);

        HttpClient httpClient = new HttpClient();

        HttpResponseMessage response = httpClient.DeleteAsync($"http://localhost:5211/api/Map/{mapId}").Result;

        if (response.IsSuccessStatusCode)
        {
            WriteLine("Map was deleted successfully.");
        }
        else
        {
            WriteLine("Failed to delete a Map. Status Code: " + response.StatusCode);
        }

        PressAnyKeyToContinue(); 
        ManageMaps();
    }

    // ===================================== HairColor UI ============================================ //
    private void ManageHairColors()
    {
        Clear();
        ForegroundColor = ConsoleColor.White;
        WriteLine("|=======================================|\n" +
                    "|                                       |\n" +
                    "|                                       |\n" +
                    "|  What would you like to do with the   |\n" +
                    "|  Hair Color?                          |\n" +
                    "|=======================================|\n" +
                    "|                                       |\n" +
                    "|  1. View All HairColor                |\n" +
                    "|  2. View HairColor By Id              |\n" +
                    "|  3. Update Existing HairColor         |\n" +
                    "|  4. Add a New HairColor               |\n" +
                    "|  5. Delete a HairColor                |\n" +
                    "|  0. Return to Manage Game Items       |\n" +
                    "|=======================================|");
        try
        {
            var userInput = int.Parse(Console.ReadLine()!);
            switch (userInput)
            {
                case 1:
                    ViewAllHairColors();
                    break;

                case 2:
                    ViewHairColorById();
                    break;

                case 3:
                    UpdateAnExistingHairColor();
                    break;

                case 4:
                    AddANewHairColor();
                    break;

                case 5:
                    DeleteExistingHairColor();
                    break;

                case 0:
                    ManageGameItemDetails();
                    break;

                default:
                    System.Console.WriteLine("Invalid Entry Please Try Again");
                    PressAnyKeyToContinue();
                    break;
            }
        }
        catch (Exception e)
        {
            System.Console.WriteLine("Bad selection.. Press any key to continue");
            Console.ReadKey();
        }    
    }

    private void AddANewHairColor()
    {
        Clear();
        ForegroundColor = ConsoleColor.DarkYellow;
        WriteLine("Enter the details for the new HairColor:");

        Write("Hair Color Name: ");
        string hairColorName= ReadLine()!;

            var newHairStyle = new HairColorDetailUI
            {
                HairColorName = hairColorName
            };
            HttpClient httpClient = new HttpClient();

            var hairColorContent = new StringContent(JsonConvert.SerializeObject(newHairStyle), Encoding.UTF8, "application/json");

            HttpResponseMessage response = httpClient.PostAsync("http://localhost:5211/api/HairColor", hairColorContent).Result;
            if (response.IsSuccessStatusCode)
            {
                WriteLine("new Hair Color is added successfully");
            }
            else
            {
                WriteLine("Failed to add new Hair Color");
            }
            PressAnyKeyToContinue(); 
            ManageHairColors();   
    }

    private void ViewHairColorById()
    {
        Clear();
        ForegroundColor = ConsoleColor.DarkMagenta;
        WriteLine("Please enter a Hair Color Id to look up a Hair Color.");
        var hairColorId = int.Parse(Console.ReadLine()!);

        HttpClient httpClient = new HttpClient();

        HttpResponseMessage response = httpClient.GetAsync($"http://localhost:5211/api/HairColor/{hairColorId}").Result;
        if (response.IsSuccessStatusCode)
        {
            HairColorDetailUI hairColor = response.Content.ReadAsAsync<HairColorDetailUI>().Result;
            WriteLine(
                      $"Hair Color Id {hairColor.HairColorId} \n" +
                      $"Hair Color Name: {hairColor.HairColorName} \n");
            PressAnyKeyToContinue();
            ManageHairColors();
        }       
    }

    private void UpdateAnExistingHairColor()
    {
        Clear();
        ForegroundColor = ConsoleColor.DarkYellow;
        WriteLine("Enter the ID of the Hair Color you want to update:");
        int hairColorId = int.Parse(ReadLine()!);

        Write("Hair Color Name: ");
        string hairColorName= ReadLine()!;

            var newHairColor = new HairColorDetailUI
            {
                HairColorId = hairColorId,
                HairColorName = hairColorName
            };
            HttpClient httpClient = new HttpClient();

            var hairColorContent = new StringContent(JsonConvert.SerializeObject(newHairColor), Encoding.UTF8, "application/json");

            HttpResponseMessage response = httpClient.PutAsync("http://localhost:5211/api/HairColor", hairColorContent).Result;
            if (response.IsSuccessStatusCode)
            {
                WriteLine("Hair Color is updated successfully");
            }
            else
            {
                WriteLine("Failed to update Hair Color");
            }
            PressAnyKeyToContinue();
            ManageHairColors();
    }

    private void DeleteExistingHairColor()
    {
        Clear();
        ForegroundColor = ConsoleColor.Cyan;
        WriteLine("Please enter the Hair Color Id of the Hair Color you want to delete:");
        int hairColorId = int.Parse(Console.ReadLine()!);

        HttpClient httpClient = new HttpClient();

        HttpResponseMessage response = httpClient.DeleteAsync($"http://localhost:5211/api/HairColor/{hairColorId}").Result;

        if (response.IsSuccessStatusCode)
        {
            WriteLine("HairColor was deleted successfully.");
        }
        else
        {
            WriteLine("Failed to delete a Hair Color. Status Code: " + response.StatusCode);
        }

        PressAnyKeyToContinue(); 
        ManageHairColors();
    }


    //================================ HairStyle UI ======================================= //
    private void ManageHairStyles()
    {
        Clear();
        ForegroundColor = ConsoleColor.White;
        WriteLine("|=======================================|\n" +
                    "|                                       |\n" +
                    "|                                       |\n" +
                    "|  What would you like to do with the   |\n" +
                    "|  Hair Style?                          |\n" +
                    "|=======================================|\n" +
                    "|                                       |\n" +
                    "|  1. View All HairStyles               |\n" +
                    "|  2. View HairStyle By Id              |\n" +
                    "|  3. Update Existing HairStyle         |\n" +
                    "|  4. Add a New HairStyle               |\n" +
                    "|  5. Delete a HairStyle                |\n" +
                    "|  0. Return to Manage Game Items       |\n" +
                    "|=======================================|");
        try
        {
            var userInput = int.Parse(Console.ReadLine()!);
            switch (userInput)
            {
                case 1:
                    ViewAllHairStyles();
                    break;

                case 2:
                    ViewHairStylesById();
                    break;

                case 3:
                    UpdateAnExistingHairStyles();
                    break;

                case 4:
                    AddANewHairStyles();
                    break;

                case 5:
                    DeleteExistingHairStyles();
                    break;

                case 0:
                    ManageGameItemDetails();
                    break;

                default:
                    System.Console.WriteLine("Invalid Entry Please Try Again");
                    PressAnyKeyToContinue();
                    break;
            }
        }
        catch (Exception e)
        {
            System.Console.WriteLine("Bad selection.. Press any key to continue");
            Console.ReadKey();
        }    
    }

    private void AddANewHairStyles()
    {
        Clear();
        ForegroundColor = ConsoleColor.DarkYellow;
        WriteLine("Enter the details for the new Hair Style:");

        Write("Hair Style Name: ");
        string hairStyleName= ReadLine()!;

            var newHairStyle = new HairStyleDetailUI
            {
                HairStyleName = hairStyleName
            };
            HttpClient httpClient = new HttpClient();

            var hairStyleContent = new StringContent(JsonConvert.SerializeObject(newHairStyle), Encoding.UTF8, "application/json");

            HttpResponseMessage response = httpClient.PostAsync("http://localhost:5211/api/HairStyle", hairStyleContent).Result;
            if (response.IsSuccessStatusCode)
            {
                WriteLine("new Hair Style is added successfully");
            }
            else
            {
                WriteLine("Failed to add new Hair Style");
            }
            PressAnyKeyToContinue();
            ManageHairStyles();
    }

    private void ViewHairStylesById()
    {
        Clear();
        ForegroundColor = ConsoleColor.DarkMagenta;
        WriteLine("Please enter a Hair Style Id to look up a Hair Style.");
        var hairStyleId = int.Parse(Console.ReadLine()!);

        HttpClient httpClient = new HttpClient();

        HttpResponseMessage response = httpClient.GetAsync($"http://localhost:5211/api/HairStyle/{hairStyleId}").Result;
        if (response.IsSuccessStatusCode)
        {
            HairStyleDetailUI hairStyle = response.Content.ReadAsAsync<HairStyleDetailUI>().Result;
            WriteLine(
                      $"Hair Style Id {hairStyle.HairStyleId} \n" +
                      $"Hair Style Name: {hairStyle.HairStyleName} \n");
            PressAnyKeyToContinue();
            ManageHairStyles();
        }       
    }

    private void UpdateAnExistingHairStyles()
    {
        Clear();
        ForegroundColor = ConsoleColor.DarkYellow;
        WriteLine("Enter the ID of the Hair Style you want to update:");
        int hairStyleId = int.Parse(ReadLine()!);

        Write("Hair Style Name: ");
        string hairStyleName= ReadLine()!;

            var newHairStyle = new HairStyleDetailUI
            {
                HairStyleId = hairStyleId,
                HairStyleName = hairStyleName
            };
            HttpClient httpClient = new HttpClient();

            var hairStyleContent = new StringContent(JsonConvert.SerializeObject(newHairStyle), Encoding.UTF8, "application/json");

            HttpResponseMessage response = httpClient.PutAsync("http://localhost:5211/api/HairStyle", hairStyleContent).Result;
            if (response.IsSuccessStatusCode)
            {
                WriteLine("Hair Style is updated successfully");
            }
            else
            {
                WriteLine("Failed to update Hair Style");
            }
            PressAnyKeyToContinue();
            ManageHairStyles();       
    }

    private void DeleteExistingHairStyles()
    {
        Clear();
        ForegroundColor = ConsoleColor.Cyan;
        WriteLine("Please enter the Hair Style Id of the Hair Style you want to delete:");
        int hairStyleId = int.Parse(Console.ReadLine()!);

        HttpClient httpClient = new HttpClient();

        HttpResponseMessage response = httpClient.DeleteAsync($"http://localhost:5211/api/HairStyle/{hairStyleId}").Result;

        if (response.IsSuccessStatusCode)
        {
            WriteLine("Hair Style was deleted successfully.");
        }
        else
        {
            WriteLine("Failed to delete a Hair Style. Status Code: " + response.StatusCode);
        }

        PressAnyKeyToContinue(); 
        ManageHairStyles();     
    }

    private void ManageBodyTypes()
    {
        Clear();
        ForegroundColor = ConsoleColor.White;
        WriteLine("|=======================================|\n" +
                    "|                                       |\n" +
                    "|                                       |\n" +
                    "|  What would you like to do with the   |\n" +
                    "|  Body Types?                          |\n" +
                    "|=======================================|\n" +
                    "|                                       |\n" +
                    "|  1. View All Body Types               |\n" +
                    "|  2. View Body Type By Id              |\n" +
                    "|  3. Update A Existing Body Type       |\n" +
                    "|  4. Add a New Body Type               |\n" +
                    "|  5. Delete a Body Type                |\n" +
                    "|  0. Return to Manage Game Items       |\n" +
                    "|=======================================|");
        try
        {
            var userInput = int.Parse(Console.ReadLine()!);
            switch (userInput)
            {
                case 1:
                    ViewAllBodyTypes();
                    break;

                case 2:
                    ViewBodyTypesById();
                    break;

                case 3:
                    UpdateAnExistingBodyTypes();
                    break;

                case 4:
                    AddANewBodyTypes();
                    break;

                case 5:
                    DeleteExistingBodyTypes();
                    break;

                case 0:
                    ManageGameItemDetails();
                    break;

                default:
                    System.Console.WriteLine("Invalid Entry Please Try Again");
                    PressAnyKeyToContinue();
                    break;
            }
        }
        catch (Exception e)
        {
            System.Console.WriteLine("Bad selection.. Press any key to continue");
            Console.ReadKey();
        }
    }

    private void AddANewBodyTypes()
    {
        Clear();
        ForegroundColor = ConsoleColor.DarkYellow;
        WriteLine("Enter the details for the new Body Type:");

        Write("Body Type Name: ");
        string bodyTypeName= ReadLine()!;

            var newBodyType = new BodyTypeDetailUI
            {
                BodyTypeName = bodyTypeName
            };
            HttpClient httpClient = new HttpClient();

            var bodyTypeContent = new StringContent(JsonConvert.SerializeObject(newBodyType), Encoding.UTF8, "application/json");

            HttpResponseMessage response = httpClient.PostAsync("http://localhost:5211/api/BodyType", bodyTypeContent).Result;
            if (response.IsSuccessStatusCode)
            {
                WriteLine("new Body Type is added successfully");
            }
            else
            {
                WriteLine("Failed to add new Body Type");
            }
            PressAnyKeyToContinue();
            ManageBodyTypes();
    }

    private void ViewBodyTypesById()
    {
        Clear();
        ForegroundColor = ConsoleColor.DarkMagenta;
        WriteLine("Please enter a Body Type Id to look up a Body Type.");
        var bodyTypeId = int.Parse(Console.ReadLine()!);

        HttpClient httpClient = new HttpClient();

        HttpResponseMessage response = httpClient.GetAsync($"http://localhost:5211/api/BodyType/{bodyTypeId}").Result;
        if (response.IsSuccessStatusCode)
        {
            BodyTypeDetailUI bodyType = response.Content.ReadAsAsync<BodyTypeDetailUI>().Result;
            WriteLine(
                      $"Body Type Id {bodyType.BodyTypeId} \n" +
                      $"Body Type Name: {bodyType.BodyTypeName} \n");
            PressAnyKeyToContinue();
            ManageBodyTypes();
        }    
    }

    private void UpdateAnExistingBodyTypes()
    {
        Clear();
        ForegroundColor = ConsoleColor.DarkYellow;
        WriteLine("Enter the ID of the Body Type you want to update:");
        int bodyTypeId = int.Parse(ReadLine()!);

        Write("Body Type Name: ");
        string bodyTypeName= ReadLine()!;

            var newBodyType = new BodyTypeDetailUI
            {
                BodyTypeId = bodyTypeId,
                BodyTypeName = bodyTypeName
            };
            HttpClient httpClient = new HttpClient();

            var bodyTypeContent = new StringContent(JsonConvert.SerializeObject(newBodyType), Encoding.UTF8, "application/json");

            HttpResponseMessage response = httpClient.PutAsync("http://localhost:5211/api/BodyType", bodyTypeContent).Result;
            if (response.IsSuccessStatusCode)
            {
                WriteLine("Body Type is updated successfully");
            }
            else
            {
                WriteLine("Failed to update Body Type");
            }
            PressAnyKeyToContinue();
            ManageBodyTypes();    
    }

    private void DeleteExistingBodyTypes()
    {
        Clear();
        ForegroundColor = ConsoleColor.Cyan;
        WriteLine("Please enter the Body Type Id of the Body Type you want to delete:");
        int bodyTypeId = int.Parse(Console.ReadLine()!);

        HttpClient httpClient = new HttpClient();

        HttpResponseMessage response = httpClient.DeleteAsync($"http://localhost:5211/api/BodyType/{bodyTypeId}").Result;

        if (response.IsSuccessStatusCode)
        {
            WriteLine("Body Type was deleted successfully.");
        }
        else
        {
            WriteLine("Failed to delete a Body Type. Status Code: " + response.StatusCode);
        }

        PressAnyKeyToContinue();
        ManageBodyTypes();    
    }

    private void ManageConsumables()
    {
        Clear();
        ForegroundColor = ConsoleColor.White;
        WriteLine("|=======================================|\n" +
                    "|                                       |\n" +
                    "|                                       |\n" +
                    "|  What would you like to do with the   |\n" +
                    "|  Consumables?                         |\n" +
                    "|=======================================|\n" +
                    "|                                       |\n" +
                    "|  1. View All Consumables              |\n" +
                    "|  2. View Consumables By Id            |\n" +
                    "|  3. Update An Existing Consumable     |\n" +
                    "|  4. Add a New Consumable              |\n" +
                    "|  5. Delete a Consumable               |\n" +
                    "|  0. Return to Manage Game Items       |\n" +
                    "|=======================================|");
        try
        {
            var userInput = int.Parse(Console.ReadLine()!);
            switch (userInput)
            {
                case 1:
                    ViewAllConsumables();
                    break;

                case 2:
                    ViewConsumableById();
                    break;

                case 3:
                    UpdateAnExistingConsumable();
                    break;

                case 4:
                    AddANewConsumable();
                    break;

                case 5:
                    DeleteExistingConsumables();
                    break;

                case 0:
                    ManageGameItemDetails();
                    break;

                default:
                    System.Console.WriteLine("Invalid Entry Please Try Again");
                    PressAnyKeyToContinue();
                    break;
            }
        }
        catch (Exception e)
        {
            System.Console.WriteLine("Bad selection.. Press any key to continue");
            Console.ReadKey();
        }
    }

    private void AddANewConsumable()
    {
        Clear();
        ForegroundColor = ConsoleColor.DarkYellow;
        WriteLine("Enter the details for the new Consumable:");

        Write("Consumable Name: ");
        string consumableName= ReadLine()!;

        Write("Consumable Description: ");
        string consumableDescription = ReadLine()!;

        Write("Consumable Effect: ");
        string consumableEffect = ReadLine()!;

        Write("Consumable IncreaseHealth: ");
        bool consumableIncreaseHealth = bool.Parse(Console.ReadLine()!);

        Write("Consumable Increase Defense: ");
        bool consumableIncreaseDefense = bool.Parse(ReadLine()!);

        Write("Consumable Increase Attack: ");
        bool consumableIncreaseAttack = bool.Parse(Console.ReadLine()!);

        Write("Consumable Does Damage To Enemy: ");
        bool consumableDoesDamageToEnemy = bool.Parse(Console.ReadLine()!);

        Write("Consumable Health Increase Amount: ");
        int consumableHealthIncreaseAmount = int.Parse(Console.ReadLine()!);

        Write("Consumable Defense Increase Amount: ");
        int consumableDefenseIncreaseAmount = int.Parse(Console.ReadLine()!);

        Write("Consumable Damage To Enemy: ");
        string consumableDamageToEnemy = ReadLine()!;

        WriteLine("Consumable Attack Increase Amount: ");
        if (int.TryParse(ReadLine(), out int consumableAttackIncreaseAmount))
        {
            var newConsumable = new ConsumableDetailUI
            {
                ConsumableName = consumableName,
                ConsumableDescription = consumableDescription,
                ConsumableEffect = consumableEffect,
                ConsumableIncreaseHealth = consumableIncreaseHealth,
                ConsumableIncreaseDefense = consumableIncreaseDefense,
                ConsumableIncreaseAttack = consumableIncreaseAttack,
                ConsumableDoesDamageToEnemy = consumableDoesDamageToEnemy,
                ConsumableHealthIncreaseAmount = consumableHealthIncreaseAmount,
                ConsumableDefenseIncreaseAmount = consumableDefenseIncreaseAmount,
                ConsumableAttackIncreaseAmount = consumableAttackIncreaseAmount,
                ConsumableDamageToEnemy = consumableDamageToEnemy

            };
            HttpClient httpClient = new HttpClient();

            var consumableContent = new StringContent(JsonConvert.SerializeObject(newConsumable), Encoding.UTF8, "application/json");

            HttpResponseMessage response = httpClient.PostAsync("http://localhost:5211/api/Consumable", consumableContent).Result;
            if (response.IsSuccessStatusCode)
            {
                WriteLine("The New Consumable has beem added successfully!!!!");
            }
            else
            {
                WriteLine("Failed to add the new consumable!!!!!");
            }
            PressAnyKeyToContinue();
            ManageConsumables();
        }
    }

    private void ViewConsumableById()
    {
        Clear();
        ForegroundColor = ConsoleColor.DarkMagenta;
        WriteLine("Please enter a Consumable Id to look up a Consumable.");
        var consumableId = int.Parse(Console.ReadLine()!);

        HttpClient httpClient = new HttpClient();

        HttpResponseMessage response = httpClient.GetAsync($"http://localhost:5211/api/Consumable/{consumableId}").Result;
        if (response.IsSuccessStatusCode)
        {
            ConsumableDetailUI consumable = response.Content.ReadAsAsync<ConsumableDetailUI>().Result;

            WriteLine("|=============================================|\n" +
                      "|                                             |\n" +
                      $"| Here is the information on the Consumable   |\n" +
                      $"|  with ID: {consumableId}                    |\n" +
                      "|                                             |\n" +
                      "|=============================================|\n");

            WriteLine("  ");
            
            WriteLine("|=========================================================================================================================================================================|\n" +
                          "|                                                                                                                                                                         |\n" +
                          $"| Consumable Id: {consumable.ConsumableId} ||  Consumable Name: {consumable.ConsumableName}                                    \n" +
                          "|                                                                                                                                                                         |\n" +
                          "|=========================================================================================================================================================================|\n" +
                          "|                                                                                                                                                                         |\n" +
                          $"| Consumable Description: {consumable.ConsumableDescription}                  \n" +
                          "|                                                                                                                                                                         |\n" +
                          "|=========================================================================================================================================================================|\n" +
                          "|                                                                                                                                                                         |\n" +
                          $"|Consumable Effect: {consumable.ConsumableEffect}  || Consumable Increases Health: {consumable.ConsumableIncreaseHealth}\n" +
                          "|                                                                                                                                                                         |\n" +
                          "|=========================================================================================================================================================================|\n" +
                          "|                                                                                                                                                                         |\n" +
                          $"|Consumable Increases Defense: {consumable.ConsumableIncreaseDefense}  ||  Consumable Increases Attack: {consumable.ConsumableIncreaseAttack}  \n" +
                          "|                                                                                                                                                                         |\n" +
                          "|=========================================================================================================================================================================|\n" +
                          "|                                                                                                                                                                         |\n" +
                          $"|Consumable Does Damage To An Enemy: {consumable.ConsumableDoesDamageToEnemy}  ||  Consumable Health Increase Amount: {consumable.ConsumableHealthIncreaseAmount}\n" +
                          "|                                                                                                                                                                         |\n" +
                          "|=========================================================================================================================================================================|\n" +
                          "|                                                                                                                                                                         |\n" +
                          $"|Consumable Defense Increase Amount: {consumable.ConsumableDefenseIncreaseAmount}  ||  Consumable Attack Increase Amount: {consumable.ConsumableAttackIncreaseAmount}  \n" +
                          "|                                                                                                                                                                         |\n" +
                          "|=========================================================================================================================================================================|\n" +
                          "|                                                                                                                                                                         |\n" +
                          $"|Consumable Damage Amount to Enemy: {consumable.ConsumableDamageToEnemy}     \n" +
                          "|                                                                                                                                                                         |\n" +
                          "|=========================================================================================================================================================================|\n");
                WriteLine("  ");
                WriteLine("  ");
            PressAnyKeyToContinue();
            ManageConsumables();
        }
    }

    private void UpdateAnExistingConsumable()
    {
        Clear();
        ForegroundColor = ConsoleColor.DarkYellow;
        WriteLine("Enter the ID of the Consumable you want to update:");
        int consumableId = int.Parse(ReadLine()!);

        Write("Consumable Name: ");
        string consumableName= ReadLine()!;

        Write("Consumable Description: ");
        string consumableDescription = ReadLine()!;


        Write("Consumable Effect: ");
        string consumableEffect = ReadLine()!;

        Write("Consumable IncreaseHealth: ");
        bool consumableIncreaseHealth = bool.Parse(Console.ReadLine()!);

        Write("Consumable Increase Defense: ");
        bool consumableIncreaseDefense = bool.Parse(ReadLine()!);

        Write("Consumable Increase Attack: ");
        bool consumableIncreaseAttack = bool.Parse(Console.ReadLine()!);

        Write("Consumable Does Damage To Enemy: ");
        bool consumableDoesDamageToEnemy = bool.Parse(Console.ReadLine()!);

        Write("Consumable Health Increase Amount: ");
        int consumableHealthIncreaseAmount = int.Parse(Console.ReadLine()!);

        Write("Consumable Defense Increase Amount: ");
        int consumableDefenseIncreaseAmount = int.Parse(Console.ReadLine()!);

        Write("Consumable Damage To Enemy: ");
        string consumableDamageToEnemy = ReadLine()!;

        WriteLine("Consumable Attack Increase Amount: ");
        if (int.TryParse(ReadLine(), out int consumableAttackIncreaseAmount))
        {
            var updateConsumable = new ConsumableDetailUI
            {
                ConsumableId = consumableId,
                ConsumableName = consumableName,
                ConsumableDescription = consumableDescription,
                ConsumableEffect = consumableEffect,
                ConsumableIncreaseHealth = consumableIncreaseHealth,
                ConsumableIncreaseDefense = consumableIncreaseDefense,
                ConsumableIncreaseAttack = consumableIncreaseAttack,
                ConsumableDoesDamageToEnemy = consumableDoesDamageToEnemy,
                ConsumableHealthIncreaseAmount = consumableHealthIncreaseAmount,
                ConsumableDefenseIncreaseAmount = consumableDefenseIncreaseAmount,
                ConsumableAttackIncreaseAmount = consumableAttackIncreaseAmount,
                ConsumableDamageToEnemy = consumableDamageToEnemy

            };
            HttpClient httpClient = new HttpClient();

            var consumableContent = new StringContent(JsonConvert.SerializeObject(updateConsumable), Encoding.UTF8, "application/json");

            HttpResponseMessage response = httpClient.PutAsync("http://localhost:5211/api/Consumable", consumableContent).Result;
            if (response.IsSuccessStatusCode)
            {
                WriteLine("Consumable has been updated successfully");
            }
            else
            {
                WriteLine("Failed to update Consumable");
            }
            PressAnyKeyToContinue();
            ManageConsumables();
        }    
    }

    private void DeleteExistingConsumables()
    {
        Clear();
        ForegroundColor = ConsoleColor.Cyan;
        WriteLine("Please enter the Consumable Id of the consumable you want to delete:");
        int consumableId = int.Parse(Console.ReadLine()!);

        HttpClient httpClient = new HttpClient();

        HttpResponseMessage response = httpClient.DeleteAsync($"http://localhost:5211/api/Consumable/{consumableId}").Result;

        if (response.IsSuccessStatusCode)
        {
            WriteLine("Consumable was deleted successfully.");
        }
        else
        {
            WriteLine("Failed to delete a consumable. Status Code: " + response.StatusCode);
        }

        PressAnyKeyToContinue();
        ManageConsumables();
    }

    private void ViewArmourById()
    {
        Clear();
        ForegroundColor = ConsoleColor.DarkGreen;
        WriteLine("|====================================================|\n" +
                    "|                                                   |\n" +
                    "|  Please enter an Armour Id to View an Armour:     |\n" +
                    "|                                                   |\n" +
                    "|===================================================|\n");
        int armourId = int.Parse(Console.ReadLine()!);
        HttpClient httpClient = new HttpClient();
        HttpResponseMessage response = httpClient.GetAsync($"http://localhost:5211/api/Armours/{armourId}").Result;
        if (response.IsSuccessStatusCode)
        {
            // var content = response.Content.ReadAsStringAsync().Result;
            // var characters = JsonConvert.DeserializeObject<CharacterListUI>(content);

            ArmourDetailUI armour = response.Content.ReadAsAsync<ArmourDetailUI>().Result;
            Clear();

            WriteLine("|=============================================|\n" +
                      "|                                             |\n" +
                      $"| Here is the information on the Armour       |\n" +
                      $"|  with ID: {armourId}                        |\n" +
                      "|                                             |\n" +
                      "|=============================================|\n");
            WriteLine("   ");

            WriteLine("|=========================================================================================================================================================================|\n" +
                      "|                                                                                                                                                                         |\n" +
                      $"| Armour Id: {armour.ArmourId} ||  ArmourName: {armour.ArmourName}                                    \n" +
                      "|                                                                                                                                                                         |\n" +
                      "|=========================================================================================================================================================================|\n" +
                      "|                                                                                                                                                                         |\n" +
                      $"| Armour Description: {armour.ArmourDescription}                  \n" +
                      "|                                                                                                                                                                         |\n" +
                      "|=========================================================================================================================================================================|\n" +
                      "|                                                                                                                                                                         |\n" +
                      $"|Armour Provides Defense: {armour.ArmourProvidesDefense}  ||  Armour Increases Health: {armour.ArmourIncreasesHealth}\n" +
                      "|                                                                                                                                                                         |\n" +
                      "|=========================================================================================================================================================================|\n" +
                      "|                                                                                                                                                                         |\n" +
                      $"|Armour Increases Sword Attacks: {armour.ArmourIncreasesSwordAttacks}  ||  Armour Increases Ranged Attacks: {armour.ArmourIncreasesRangedAttacks}  \n" +
                      "|                                                                                                                                                                         |\n" +
                      "|=========================================================================================================================================================================|\n" +
                      "|                                                                                                                                                                         |\n" +
                      $"|Sword Damage Increase: {armour.IncreasedSwordDamageAmount}  ||  Health Increase Amount: {armour.IncreasedHealthAmount}\n" +
                      "|                                                                                                                                                                         |\n" +
                      "|=========================================================================================================================================================================|\n" +
                      "|                                                                                                                                                                         |\n" +
                      $"|Ranged Damage Increase Amount: {armour.IncreasedRangeAttackDamageAmount}  ||  Armour Protection Amount: {armour.IncreasedDefenseAmount}  \n" +
                      "|                                                                                                                                                                         |\n" +
                      "|=========================================================================================================================================================================|\n");
                WriteLine("  ");
                WriteLine("  ");

            PressAnyKeyToContinue();
            ManageArmours();
        }
    }

    private void UpdateAnExistingArmour()
    {
        Clear();
        ForegroundColor = ConsoleColor.DarkYellow;
        WriteLine("Enter the ID of the Armour you want to update:");
        int armourId = int.Parse(ReadLine()!);

        Write("Armour Name: ");
        string armourName = ReadLine()!;

        Write("Armour Description: ");
        string armourDescription = ReadLine()!;

        Write("Armour Provides Defense: ");
        bool armourProvidesDefense = bool.Parse(Console.ReadLine()!);

        Write("Armour Increases Health: ");
        bool armourIncreasesHealth = bool.Parse(Console.ReadLine()!);

        Write("Armour Increases Sword Attacks: ");
        bool armourIncreasesSwordAttacks = bool.Parse(Console.ReadLine()!);

        Write("Armour Increases Ranged Attacks: ");
        bool armourIncreasesRangedAttacks = bool.Parse(Console.ReadLine()!);

        Write("Health Increase: ");
        int increasedHealthAmount = int.Parse(Console.ReadLine()!);

        Write("Sword Damage Increase: ");
        int increasedSwordDamageAmount = int.Parse(Console.ReadLine()!);

        Write("Ranged Damage Increase: ");
        int increasedRangeAttackDamageAmount = int.Parse(Console.ReadLine()!);

        Write("Defense Increase: ");
        int increasedDefenseAmount = int.Parse(Console.ReadLine()!);


        WriteLine("Armour Protection Amount: ");
        if (int.TryParse(ReadLine(), out int armourprotectionAmount))
        {
            var updateArmour = new ArmourDetailUI
            {
                ArmourName = armourName,
                ArmourDescription = armourDescription,
                ArmourProvidesDefense = armourProvidesDefense,
                ArmourIncreasesHealth = armourIncreasesHealth,
                ArmourIncreasesSwordAttacks = armourIncreasesSwordAttacks,
                ArmourIncreasesRangedAttacks = armourIncreasesRangedAttacks,
            };
            HttpClient httpClient = new HttpClient();

            var armourContent = new StringContent(JsonConvert.SerializeObject(updateArmour), Encoding.UTF8, "application/json");

            HttpResponseMessage response = httpClient.PutAsync("http://localhost:5211/api/Armour", armourContent).Result;
            if (response.IsSuccessStatusCode)
            {
                WriteLine("Armour has been updated successfully");
            }
            else
            {
                WriteLine("Failed to update armour. Status Code: " + response.StatusCode);
                }
                PressAnyKeyToContinue();
        }
    }

    private void DeleteExistingArmour()
    {
        Clear();
        ForegroundColor = ConsoleColor.Cyan;
        WriteLine("Please enter the ArmourID of the armour you want to delete:");
        int armourId = int.Parse(Console.ReadLine()!);

        HttpClient httpClient = new HttpClient();

        HttpResponseMessage response = httpClient.DeleteAsync($"http://localhost:5211/api/Armour/{armourId}").Result;

        if (response.IsSuccessStatusCode)
        {
            WriteLine("Armour was deleted successfully.");
        }
        else
        {
            WriteLine("Failed to delete an armour. Status Code: " + response.StatusCode);
        }

        PressAnyKeyToContinue();
        ManageArmours();
    }

    private void AddANewArmour()
    {
        Clear();
        ForegroundColor = ConsoleColor.DarkYellow;
        WriteLine("Enter the details for the new Armour:");

        Write("Armour Name: ");
        string armourName = ReadLine()!;

        Write("Armour Description: ");
        string armourDescription = ReadLine()!;

        Write("Armour Provides Defense: ");
        bool armourProvidesDefense = bool.Parse(Console.ReadLine()!);

        Write("Armour Increases Health: ");
        bool armourIncreasesHealth = bool.Parse(Console.ReadLine()!);

        Write("Armour Increases Sword Attacks: ");
        bool armourIncreasesSwordAttacks = bool.Parse(Console.ReadLine()!);

        Write("Armour Increases Ranged Attacks: ");
        bool armourIncreasesRangedAttacks = bool.Parse(Console.ReadLine()!);

        Write("Health Increase: ");
        int increasedHealthAmount = int.Parse(Console.ReadLine()!);

        Write("Sword Damage Increase: ");
        int increasedSwordDamageAmount = int.Parse(Console.ReadLine()!);

        Write("Ranged Damage Increase: ");
        int increasedRangeAttackDamageAmount = int.Parse(Console.ReadLine()!);

        Write("Defense Increase: ");
        int increasedDefenseAmount = int.Parse(Console.ReadLine()!);

        WriteLine("Armour Protection Amount: ");
        if (int.TryParse(ReadLine(), out int armourProtectionAmount))
        {
            var newArmour = new ArmourDetailUI
            {
                ArmourName = armourName,
                ArmourDescription = armourDescription,
                ArmourProvidesDefense = armourProvidesDefense,
                ArmourIncreasesHealth = armourIncreasesHealth,
                ArmourIncreasesSwordAttacks = armourIncreasesSwordAttacks,
                ArmourIncreasesRangedAttacks = armourIncreasesRangedAttacks,
                IncreasedHealthAmount = increasedHealthAmount,
                IncreasedSwordDamageAmount = increasedSwordDamageAmount,
                IncreasedRangeAttackDamageAmount = increasedRangeAttackDamageAmount,
                IncreasedDefenseAmount = increasedDefenseAmount,

            };
            HttpClient httpClient = new HttpClient();

            var armourContent = new StringContent(JsonConvert.SerializeObject(newArmour), Encoding.UTF8, "application/json");

            HttpResponseMessage response = httpClient.PostAsync("http://localhost:5211/api/Armour", armourContent).Result;
            if (response.IsSuccessStatusCode)
            {
                ArmourDetailUI armourCreated = response.Content.ReadAsAsync<ArmourDetailUI>().Result;
                WriteLine("|=============================================|\n" +
                          "|                                             |\n" +
                          $"| Here is the information on the armour that  |\n" +
                          "|     was created.                            |\n" +
                          "|                                             |\n" +
                          "|=============================================|\n");
                    
                WriteLine("  ");
                WriteLine("|=========================================================================================================================================================================|\n" +
                          "|                                                                                                                                                                         |\n" +
                          $"| Armour Id: {armourCreated.ArmourId} ||  ArmourName: {armourCreated.ArmourName}                                    \n" +
                          "|                                                                                                                                                                         |\n" +
                          "|=========================================================================================================================================================================|\n" +
                          "|                                                                                                                                                                         |\n" +
                          $"| Armour Description: {armourCreated.ArmourDescription}                  \n" +
                          "|                                                                                                                                                                         |\n" +
                          "|=========================================================================================================================================================================|\n" +
                          "|                                                                                                                                                                         |\n" +
                          $"|Armour Provides Defense: {armourCreated.ArmourProvidesDefense}  ||  Armour Increases Health: {armourCreated.ArmourIncreasesHealth}\n" +
                          "|                                                                                                                                                                         |\n" +
                          "|=========================================================================================================================================================================|\n" +
                          "|                                                                                                                                                                         |\n" +
                          $"|Armour Increases Sword Attacks: {armourCreated.ArmourIncreasesSwordAttacks}  ||  Armour Increases Ranged Attacks: {armourCreated.ArmourIncreasesRangedAttacks}  \n" +
                          "|                                                                                                                                                                         |\n" +
                          "|=========================================================================================================================================================================|\n" +
                          "|                                                                                                                                                                         |\n" +
                          $"|Sword Damage Increase: {armourCreated.IncreasedSwordDamageAmount}  ||  Health Increase Amount: {armourCreated.IncreasedHealthAmount}\n" +
                          "|                                                                                                                                                                         |\n" +
                          "|=========================================================================================================================================================================|\n" +
                          "|                                                                                                                                                                         |\n" +
                          $"|Ranged Damage Increase Amount: {armourCreated.IncreasedRangeAttackDamageAmount}  ||  Armour Protection Amount: {armourCreated.IncreasedDefenseAmount}  \n" +
                          "|                                                                                                                                                                         |\n" +
                          "|=========================================================================================================================================================================|\n");
                WriteLine("  ");

                WriteLine("The New Armour was added successfully");
            }
            else
            {
                WriteLine("Failed to add the New Armour");
            }
            PressAnyKeyToContinue();
            ManageArmours();
        }
    }
    private void ManageArmours()
    {
        Clear();
        ForegroundColor = ConsoleColor.White;
        WriteLine("|========================================|\n" +
                    "|                                       |\n" +
                    "|                                       |\n" +
                    "|  What would you like to do with the   |\n" +
                    "|  Armours?                             |\n" +
                    "|=======================================|\n" +
                    "|                                       |\n" +
                    "|  1. View All Armours                  |\n" +
                    "|  2. View Armours By Id                |\n" +
                    "|  3. Update Existing Armour            |\n" +
                    "|  4. Add a New Armour                  |\n" +
                    "|  5. Delete an Armour                  |\n" +
                    "|  0. Return to Manage Game Items       |\n" +
                    "|=======================================|\n");
        try
        {
            var userInput = int.Parse(Console.ReadLine()!);
            switch (userInput)
            {
                case 1:
                    ViewAllArmours();
                    break;

                case 2:
                    ViewArmourById();
                    break;

                case 3:
                    UpdateAnExistingArmour();
                    break;

                case 4:
                    AddANewArmour();
                    break;

                case 5:
                    DeleteExistingArmour();
                    break;

                case 0:
                    ManageGameItemDetails();
                    break;

                default:
                    System.Console.WriteLine("Invalid Entry Please Try Again");
                    PressAnyKeyToContinue();
                    break;
            }
        }
        catch (Exception e)
        {
            System.Console.WriteLine("Bad selection.. Press any key to continue");
            Console.ReadKey();
        }
    }

    private void ManageVehicles()
    {
        Clear();
        ForegroundColor = ConsoleColor.White;
        WriteLine("  |=======================================|\n" +
                    "|                                       |\n" +
                    "| Thanks for Choosing to Play!          |\n" +
                    "|  What would you like to do with the   |\n" +
                    "|  Game?                                |\n" +
                    "|=======================================|\n" +
                    "|                                       |\n" +
                    "|  1. View All Vehicles                 |\n" +
                    "|  2. View Vehicle By Id                |\n" +
                    "|  3. Update Existing Vehicle           |\n" +
                    "|  4. Add a New Vehicle                 |\n" +
                    "|  5. Delete a Vehicle                  |\n" +
                    "|  0. Return to Main Menu               |\n" +
                    "|=======================================|");
        try
        {
            var userInput = int.Parse(Console.ReadLine()!);
            switch (userInput)
            {
                case 1:
                    ViewAllVehicles();
                    break;

                case 2:
                    ViewVehicleById();
                    break;

                case 3:
                    UpdateAnExistingVehicle();
                    break;

                case 4:
                    AddANewVehicle();
                    break;

                case 5:
                    DeleteExistingVehicle();
                    break;

                case 0:
                    ManageGameItemDetails();

                    break;

                default:
                    System.Console.WriteLine("Invalid Entry Please Try Again");
                    PressAnyKeyToContinue();
                    break;
            }
        }
        catch (Exception e)
        {
            System.Console.WriteLine("Bad selection.. Press any key to continue");
            Console.ReadKey();
        }
    }

    private void ManageAbilities()
    {
        Clear();
        ForegroundColor = ConsoleColor.White;
        WriteLine("|=======================================|\n" +
                    "|                                       |\n" +
                    "|                                       |\n" +
                    "|  What would you like to do with the   |\n" +
                    "|  Abilities?                           |\n" +
                    "|=======================================|\n" +
                    "|                                       |\n" +
                    "|  1. View All Abilities                |\n" +
                    "|  2. View Abilities By Id              |\n" +
                    "|  3. Update Existing Ability           |\n" +
                    "|  4. Add a New Ability                 |\n" +
                    "|  5. Delete an Ability                 |\n" +
                    "|  0. Return to Manage Game Items       |\n" +
                    "|=======================================|");
        try
        {
            var userInput = int.Parse(Console.ReadLine()!);
            switch (userInput)
            {
                case 1:
                    ViewAllAbilities();
                    break;

                case 2:
                    ViewAbilityById();
                    break;

                case 3:
                    UpdateAnExistingAbility();
                    break;

                case 4:
                    AddANewAbility();
                    break;

                case 5:
                    DeleteExistingAbility();
                    break;

                case 0:
                    ManageGameItemDetails();
                    break;

                default:
                    System.Console.WriteLine("Invalid Entry Please Try Again");
                    PressAnyKeyToContinue();
                    break;
            }
        }
        catch (Exception e)
        {
            System.Console.WriteLine("Bad selection.. Press any key to continue");
            Console.ReadKey();
        }
    }

    private void ViewAbilityById()
    {
        Clear();
        ForegroundColor = ConsoleColor.DarkGreen;
        WriteLine("|====================================================|\n" +
                    "|                                                   |\n" +
                    "|  Please enter an Ability Id to View an Ability:   |\n" +
                    "|                                                   |\n" +
                    "|===================================================|\n");
        int abilityId = int.Parse(Console.ReadLine()!);
        HttpClient httpClient = new HttpClient();
        HttpResponseMessage response = httpClient.GetAsync($"http://localhost:5211/api/Ability/{abilityId}").Result;
        if (response.IsSuccessStatusCode)
        {
            AbilityDetailUI ability = response.Content.ReadAsAsync<AbilityDetailUI>().Result;
            
            Clear();

            WriteLine("|=============================================|\n" +
                      "|                                             |\n" +
                      $"| Here is the information on the Ability      |\n" +
                      $"|  with ID: {abilityId}                    |\n" +
                      "|                                             |\n" +
                      "|=============================================|\n");

            WriteLine("|=========================================================================================================================================================================|\n" +
                      "|                                                                                                                                                                         |\n" +
                      $"| Ability Id: {ability.AbilityId} ||  Ability Name: {ability.AbilityName}                                    \n" +
                      "|                                                                                                                                                                         |\n" +
                      "|=========================================================================================================================================================================|\n" +
                      "|                                                                                                                                                                         |\n" +
                      $"| Ability Description: {ability.AbilityDescription}                  \n" +
                      "|                                                                                                                                                                         |\n" +
                      "|=========================================================================================================================================================================|\n" +
                      "|                                                                                                                                                                         |\n" +
                      $"|Ability Effect Type: {ability.AbilityEffectType}  ||  Ability is an Attack: {ability.AbilityEffectAttack}\n" +
                      "|                                                                                                                                                                         |\n" +
                      "|=========================================================================================================================================================================|\n" +
                      "|                                                                                                                                                                         |\n" +
                      $"|Ability Enhances Health: {ability.AbilityEffectHealthEnhancement}  ||  Ability Enhances Defence: {ability.AbilityEffectDefenseEnhancement}  \n" +
                      "|                                                                                                                                                                         |\n" +
                      "|=========================================================================================================================================================================|\n" +
                      "|                                                                                                                                                                         |\n" +
                      $"|Ability Has A Status Effect: {ability.AbilityHasStatusEffect}  ||  Ability Does Damage to Single Enemy: {ability.AbilityDamageSingleEnemy}\n" +
                      "|                                                                                                                                                                         |\n" +
                      "|=========================================================================================================================================================================|\n" +
                      "|                                                                                                                                                                         |\n" +
                      $"|Ability Does Damage to Multipl Enemies: {ability.AbilityDamageMultipleEnemy}  ||  Ability Attack Damage Amount: {ability.AbilityAttackDamage}  \n" +
                      "|                                                                                                                                                                         |\n" +
                      "|=========================================================================================================================================================================|\n" +
                      "|                                                                                                                                                                         |\n" +
                      $"|Ability Healing Amount: {ability.AbilityHealingAmount} || Ability Defense Increase Amount: {ability.AbilityDefenseIncrease} || Ability Effect Time Limit: {ability.AbilityEffectTimeLimit}\n" +
                      "|                                                                                                                                                                         |\n" +
                      "|=========================================================================================================================================================================|\n");
                WriteLine("  ");
                WriteLine("  ");

            PressAnyKeyToContinue();
            ManageAbilities();
        }
    }

    private void UpdateAnExistingAbility()
    {
        Clear();
        ForegroundColor = ConsoleColor.DarkYellow;
        WriteLine("Enter the ID of the Ability you want to update:");
        int abilityId = int.Parse(ReadLine()!);

        Write("Ability Name: ");
        string abilityName = ReadLine()!;

        Write("Ability Description: ");
        string abilityDescription = ReadLine()!;

        Write("Ability Effect Type: ");
        string abilityEffectType = ReadLine()!;

        Write("Ability Effects Attack: ");
        bool abilityEffectAttack = bool.Parse(Console.ReadLine()!);

        Write("Ability Enhances Health: ");
        bool abilityEffectHealthEnhancement = bool.Parse(Console.ReadLine()!);

        Write("Ability Enhances Defense: ");
        bool abilityEffectDefenseEnhancement = bool.Parse(Console.ReadLine()!);

        Write("Ability Has Status Effect: ");
        bool abilityHasStatusEffect = bool.Parse(Console.ReadLine()!);

        Write("Ability Has Single Enemy Damage: ");
        bool abilityDamageSingleEnemy = bool.Parse(Console.ReadLine()!);

        Write("Ability Has Multiple Enemy Damage: ");
        bool abilityDamageMultipleEnemy = bool.Parse(Console.ReadLine()!);

        Write("Ability Attack Damage: ");
        int abilityAttackDamage = int.Parse(Console.ReadLine()!);

        Write("Ability Healing Amount: ");
        int abilityHealingAmount = int.Parse(Console.ReadLine()!);

        Write("Ability Defense Increase: ");
        int abilityDefenseIncrease = int.Parse(Console.ReadLine()!);

        Write("Ability Effect Time Limit: ");
        string? abilityEffectTimeLimit = ReadLine()!;

        WriteLine("Ability: ");
        if (int.TryParse(ReadLine(), out int abilityDamageAmount))
        {
            var updateAbility = new AbilityDetailUI
            {
                AbilityName = abilityName,
                AbilityDescription = abilityDescription,
                AbilityEffectType = abilityEffectType,
                AbilityEffectAttack = abilityEffectAttack,
                AbilityEffectHealthEnhancement = abilityEffectHealthEnhancement,
                AbilityEffectDefenseEnhancement = abilityEffectDefenseEnhancement,
                AbilityHasStatusEffect = abilityHasStatusEffect,
                AbilityHealingAmount = abilityHealingAmount,
                AbilityDamageSingleEnemy = abilityDamageSingleEnemy,
                AbilityDamageMultipleEnemy = abilityDamageMultipleEnemy,
                AbilityAttackDamage = abilityAttackDamage,
                AbilityDefenseIncrease = abilityDefenseIncrease,
                AbilityEffectTimeLimit = abilityEffectTimeLimit


            };
            HttpClient httpClient = new HttpClient();

            var abilityContent = new StringContent(JsonConvert.SerializeObject(updateAbility), Encoding.UTF8, "application/json");

            HttpResponseMessage response = httpClient.PutAsync("http://localhost:5211/api/Ability", abilityContent).Result;
            if (response.IsSuccessStatusCode)
            {
                WriteLine("Ability has been updated successfully");
            }
            else
            {
                WriteLine("Failed to update the ability. Status Code: " + response.StatusCode);
            }
            PressAnyKeyToContinue();
            ManageAbilities();
        }
    }

    private void AddANewAbility()
    {
        Clear();
        ForegroundColor = ConsoleColor.DarkYellow;
        WriteLine("Enter the details for the new Abililty:");

        Write("Ability Name: ");
        string abilityName = ReadLine()!;

        Write("Ability Description: ");
        string abilityDescription = ReadLine()!;

        Write("Ability Effect Type: ");
        string abilityEffectType = ReadLine()!;

        Write("Ability Effects Attack: ");
        bool abilityEffectAttack = bool.Parse(Console.ReadLine()!);

        Write("Ability Enhances Health: ");
        bool abilityEffectHealthEnhancement = bool.Parse(Console.ReadLine()!);

        Write("Ability Enhances Defense: ");
        bool abilityEffectDefenseEnhancement = bool.Parse(Console.ReadLine()!);

        Write("Ability Has Status Effect: ");
        bool abilityHasStatusEffect = bool.Parse(Console.ReadLine()!);

        Write("Ability Has Single Enemy Damage: ");
        bool abilityDamageSingleEnemy = bool.Parse(Console.ReadLine()!);

        Write("Ability Has Multiple Enemy Damage: ");
        bool abilityDamageMultipleEnemy = bool.Parse(Console.ReadLine()!);

        Write("Ability Attack Damage: ");
        int abilityAttackDamage = int.Parse(Console.ReadLine()!);

        Write("Ability Healing Amount: ");
        int abilityHealingAmount = int.Parse(Console.ReadLine()!);

        Write("Ability Defense Increase: ");
        int abilityDefenseIncrease = int.Parse(Console.ReadLine()!);

        Write("Ability Effect Time Limit: ");
        string? abilityEffectTimeLimit = ReadLine()!;

        WriteLine("Ability Damage and Protection Amount: ");
        if (int.TryParse(ReadLine(), out int abilityDamageAmount))
        {
            var newAbility = new AbilityDetailUI
            {
                AbilityName = abilityName,
                AbilityDescription = abilityDescription,
                AbilityEffectType = abilityEffectType,
                AbilityEffectAttack = abilityEffectAttack,
                AbilityEffectHealthEnhancement = abilityEffectHealthEnhancement,
                AbilityEffectDefenseEnhancement = abilityEffectDefenseEnhancement,
                AbilityHasStatusEffect = abilityHasStatusEffect,
                AbilityHealingAmount = abilityHealingAmount,
                AbilityDamageSingleEnemy = abilityDamageSingleEnemy,
                AbilityDamageMultipleEnemy = abilityDamageMultipleEnemy,
                AbilityAttackDamage = abilityAttackDamage,
                AbilityDefenseIncrease = abilityDefenseIncrease,
                AbilityEffectTimeLimit = abilityEffectTimeLimit

            };
            HttpClient httpClient = new HttpClient();

            var abilityContent = new StringContent(JsonConvert.SerializeObject(newAbility), Encoding.UTF8, "application/json");

            HttpResponseMessage response = httpClient.PostAsync("http://localhost:5211/api/Ability", abilityContent).Result;
            if (response.IsSuccessStatusCode)
            {
                WriteLine("The new ability has been added successfully!!!");
            }
            else
            {
                WriteLine("Failed to add new Ability");
            }
            PressAnyKeyToContinue();
            ManageAbilities();
        }
    }

    private void DeleteExistingAbility()
    {
        Clear();
        ForegroundColor = ConsoleColor.Cyan;
        WriteLine("Please enter the AbilityID of the ability you want to delete:");
        int abilityId = int.Parse(Console.ReadLine()!);

        HttpClient httpClient = new HttpClient();

        HttpResponseMessage response = httpClient.DeleteAsync($"http://localhost:5211/api/Ability/{abilityId}").Result;

        if (response.IsSuccessStatusCode)
        {
            WriteLine("Ability was deleted successfully.");
        }
        else
        {
            WriteLine("Failed to delete an ability. Status Code: " + response.StatusCode);
        }

        PressAnyKeyToContinue();
        ManageAbilities();
    }

    private void AddANewVehicle()
    {
        Clear();
        ForegroundColor = ConsoleColor.DarkYellow;
        WriteLine("Enter the details for the new Vehicles:");

        Write("Vehicle Name: ");
        string vehicleName = ReadLine()!;

        Write("Vehicle Spped: ");
        double vehicleSpeed = double.Parse(ReadLine()!);

        Write("Vehicle Ability: ");
        string vehicleAbility = ReadLine()!;

        Write("Vehicle Type: ");
        string vehicleType = ReadLine()!;


        Write("vehicle Description: ");
        string vehicleDescription = ReadLine()!;

        Write("Vehicle Health: ");
        double vehicleHealth = double.Parse(Console.ReadLine()!);


        WriteLine("Vehicle Attack Damage: ");
        if (int.TryParse(ReadLine(), out int vehicleAttackDamage))
        {
            var newVehicle = new VehicleDetailUI
            {
                VehicleName = vehicleName,
                VehicleSpeed = vehicleSpeed,
                VehicleAbility = vehicleAbility,
                VehicleType = vehicleType,
                VehicleDescription = vehicleDescription,
                VehicleAttackDamage = vehicleAttackDamage,
                VehicleHealth = vehicleHealth
            };
            HttpClient httpClient = new HttpClient();

            var VehicleContent = new StringContent(JsonConvert.SerializeObject(newVehicle), Encoding.UTF8, "application/json");

            HttpResponseMessage response = httpClient.PostAsync("http://localhost:5211/api/Vehicle", VehicleContent).Result;
            if (response.IsSuccessStatusCode)
            {
                WriteLine("The new Vehicle was added successfully!!!");
            }
            else
            {
                WriteLine("Failed to add the new vehicle to the game.");
            }
            PressAnyKeyToContinue();
            ManageVehicles();
        }
    }

    private void ViewAllVehicles()
    {
        Clear();
        ForegroundColor = ConsoleColor.DarkMagenta;

        HttpClient httpClient = new HttpClient();

        HttpResponseMessage response = httpClient.GetAsync("http://localhost:5211/api/Vehicle").Result;
        if (response.IsSuccessStatusCode)
        {
            List<VehicleDetailUI> vehicles = response.Content.ReadAsAsync<List<VehicleDetailUI>>().Result;

            WriteLine("|=============================================|\n" +
                      "|                                             |\n" +
                      $"| Here are all the Vehicles currently        |\n" +
                      "|     Available                               |\n" +
                      "|                                             |\n" +
                      "|=============================================|\n");

            foreach (var vehicle in vehicles)
            {
                WriteLine("|=========================================================================================================================================================================|\n" +
                          "|                                                                                                                                                                         |\n" +
                          $"| Vehicle Id: {vehicle.VehicleId} ||  Vehicle Name: {vehicle.VehicleName}                                    \n" +
                          "|                                                                                                                                                                         |\n" +
                          "|=========================================================================================================================================================================|\n" +
                          "|                                                                                                                                                                         |\n" +
                          $"|Vehicle Speed: {vehicle.VehicleSpeed} ||  Vehicle Description: {vehicle.VehicleDescription}                  \n" +
                          "|                                                                                                                                                                         |\n" +
                          "|=========================================================================================================================================================================|\n" +
                          "|                                                                                                                                                                         |\n" +
                          $"|Vehicle Ability: {vehicle.VehicleAbility}  ||  Vehicle Type: {vehicle.VehicleType}\n" +
                          "|                                                                                                                                                                         |\n" +
                          "|=========================================================================================================================================================================|\n" +
                          "|                                                                                                                                                                         |\n" +
                          $"|Vehicle Attack Damage: {vehicle.VehicleAttackDamage}  ||  Vehicle Health: {vehicle.VehicleHealth}\n" +
                          "|                                                                                                                                                                         |\n" +
                          "|=========================================================================================================================================================================|\n");
                WriteLine("  ");
                WriteLine("  ");
                WriteLine("  ");
            }

            PressAnyKeyToContinue();
            ManageVehicles();
        }
    }

    private void ViewAllVehiclesForCharacterCreate()
    {
        ForegroundColor = ConsoleColor.DarkMagenta;

        HttpClient httpClient = new HttpClient();

        HttpResponseMessage response = httpClient.GetAsync("http://localhost:5211/api/Vehicle").Result;
        if (response.IsSuccessStatusCode)
        {
            List<VehicleDetailUI> vehicles = response.Content.ReadAsAsync<List<VehicleDetailUI>>().Result;

            foreach (var vehicle in vehicles)
            {
                WriteLine("|=========================================================================================================================================================================|\n" +
                          "|                                                                                                                                                                         |\n" +
                          $"| Vehicle Id: {vehicle.VehicleId} ||  Vehicle Name: {vehicle.VehicleName}                                    \n" +
                          "|                                                                                                                                                                         |\n" +
                          "|=========================================================================================================================================================================|\n" +
                          "|                                                                                                                                                                         |\n" +
                          $"|Vehicle Speed: {vehicle.VehicleSpeed} ||  Vehicle Description: {vehicle.VehicleDescription}                  \n" +
                          "|                                                                                                                                                                         |\n" +
                          "|=========================================================================================================================================================================|\n" +
                          "|                                                                                                                                                                         |\n" +
                          $"|Vehicle Ability: {vehicle.VehicleAbility}  ||  Vehicle Type: {vehicle.VehicleType}\n" +
                          "|                                                                                                                                                                         |\n" +
                          "|=========================================================================================================================================================================|\n" +
                          "|                                                                                                                                                                         |\n" +
                          $"|Vehicle Attack Damage: {vehicle.VehicleAttackDamage}  ||  Vehicle Health: {vehicle.VehicleHealth}\n" +
                          "|                                                                                                                                                                         |\n" +
                          "|=========================================================================================================================================================================|\n");
                WriteLine("  ");
                WriteLine("  ");
                WriteLine("  ");
            }
        }
    }

    private void ViewVehicleById()
    {
        Clear();
        ForegroundColor = ConsoleColor.DarkMagenta;
        WriteLine("Please enter a VehicleId to look up a Vehicle Details.");
        var vehicleId = int.Parse(Console.ReadLine()!);

        HttpClient httpClient = new HttpClient();

        HttpResponseMessage response = httpClient.GetAsync($"http://localhost:5211/api/Vehicle/{vehicleId}").Result;
        if (response.IsSuccessStatusCode)
        {
            VehicleDetailUI vehicle = response.Content.ReadAsAsync<VehicleDetailUI>().Result;

            WriteLine("|=========================================================================================================================================================================|\n" +
                      "|                                                                                                                                                                         |\n" +
                      $"| Vehicle Id: {vehicle.VehicleId} ||  Vehicle Name: {vehicle.VehicleName}                                    \n" +
                      "|                                                                                                                                                                         |\n" +
                      "|=========================================================================================================================================================================|\n" +
                      "|                                                                                                                                                                         |\n" +
                      $"|Vehicle Speed: {vehicle.VehicleSpeed} ||  Vehicle Description: {vehicle.VehicleDescription}                  \n" +
                      "|                                                                                                                                                                         |\n" +
                      "|=========================================================================================================================================================================|\n" +
                      "|                                                                                                                                                                         |\n" +
                      $"|Vehicle Ability: {vehicle.VehicleAbility}  ||  Vehicle Type: {vehicle.VehicleType}\n" +
                      "|                                                                                                                                                                         |\n" +
                      "|=========================================================================================================================================================================|\n" +
                      "|                                                                                                                                                                         |\n" +
                      $"|Vehicle Attack Damage: {vehicle.VehicleAttackDamage}  ||  Vehicle Health: {vehicle.VehicleHealth}\n" +
                      "|                                                                                                                                                                         |\n" +
                      "|=========================================================================================================================================================================|\n");
            WriteLine("  ");
        }
    }

    private void DeleteExistingVehicle()
    {
        Clear();
        ForegroundColor = ConsoleColor.Green;
        WriteLine("Please enter the VehicleId of the vehicle you want to delete:");
        int vehicleId = int.Parse(Console.ReadLine()!);

        HttpClient httpClient = new HttpClient();

        HttpResponseMessage response = httpClient.DeleteAsync($"http://localhost:5211/api/Vehicle/{vehicleId}").Result;

        if (response.IsSuccessStatusCode)
        {
            WriteLine("Vehicle was deleted successfully.");
        }
        else
        {
            WriteLine("Failed to delete the Vehicle. Status Code: " + response.StatusCode);
        }

        PressAnyKeyToContinue();
        ManageVehicles();
    }

    private void UpdateAnExistingVehicle()
    {
        Clear();
        ForegroundColor = ConsoleColor.DarkYellow;
        WriteLine("Enter the ID of the Vehicle you want to update:");
        int vehicleId = int.Parse(ReadLine()!);

        Write("Vehicle Name: ");
        string vehicleName = ReadLine()!;

        Write("Vehicle Spped: ");
        double vehicleSpeed = double.Parse(ReadLine()!);

        Write("Vehicle Ability: ");
        string vehicleAbility = ReadLine()!;

        Write("Vehicle Type: ");
        string vehicleType = ReadLine()!;


        Write("vehicle Description: ");
        string vehicleDescription = ReadLine()!;

        Write("Vehicle Health: ");
        double vehicleHealth = double.Parse(Console.ReadLine()!);


        WriteLine("Vehicle Attack Damage: ");
        if (int.TryParse(ReadLine(), out int vehicleAttackDamage))
        {
            var updateVehicle = new VehicleDetailUI
            {
                VehicleId = vehicleId,
                VehicleName = vehicleName,
                VehicleSpeed = vehicleSpeed,
                VehicleAbility = vehicleAbility,
                VehicleType = vehicleType,
                VehicleDescription = vehicleDescription,
                VehicleAttackDamage = vehicleAttackDamage,
                VehicleHealth = vehicleHealth
            };
            HttpClient httpClient = new HttpClient();

            var VehicleContent = new StringContent(JsonConvert.SerializeObject(updateVehicle), Encoding.UTF8, "application/json");

            HttpResponseMessage response = httpClient.PutAsync("http://localhost:5211/api/Vehicle", VehicleContent).Result;
            if (response.IsSuccessStatusCode)
            {
                WriteLine("Vehicle Updated Successfully");
            }
            else
            {
                WriteLine("Failed to Upate a Vehicle!" + response.StatusCode);
            }
            PressAnyKeyToContinue();
            ManageVehicles();
        }
    }

    private void ManageCharacterClasses()
    {
        Console.Clear();
        ForegroundColor = ConsoleColor.White;
        WriteLine("|=======================================|\n" +
                    "|                                       |\n" +
                    "|  What would you like to do with the   |\n" +
                    "|        Character Classes?             |\n" +
                    "|                                       |\n" +
                    "|=======================================|\n" +
                    "|                                       |");
        ConsoleKeyInfo key;
        int option = 1;
        bool isSelected = false;
        (int left, int top) = Console.GetCursorPosition();
        string color = "👻\u001b[35m";

            while(!isSelected)
            {   Console.SetCursorPosition(left, top);
                WriteLine($"|{(option == 1 ? color : "  ")}1. View All Character Classes\u001b[37m        |");
                WriteLine($"|{(option == 2 ? color : "  ")}2. View Character Class By Id\u001b[37m        |");
                WriteLine($"|{(option == 3 ? color : "  ")}3. Update Existing Character Class\u001b[37m   |");
                WriteLine($"|{(option == 4 ? color : "  ")}4. Add a New Character Class\u001b[37m         |");
                WriteLine($"|{(option == 5 ? color : "  ")}5. Delete a Character Class\u001b[37m          |");
                WriteLine($"|{(option == 6 ? color : "  ")}6. Return to Main Menu\u001b[37m               |");
                WriteLine("|                                       |\u001b[37m");
                WriteLine("|=======================================|\u001b[37m");
            try
            {
                key = Console.ReadKey(true); 

                switch (key.Key)
                {
                    case ConsoleKey.DownArrow:
                        option = (option == 6 ? 1 : option + 1);
                        break;

                    case ConsoleKey.UpArrow:
                        option = (option == 1 ? 6 : option -1);
                        break;

                    case ConsoleKey.Enter:
                        isSelected = true;
                        break;

                    default:
                        WriteLine("Invalid Selection Please Try Again");
                        PressAnyKeyToContinue();
                        break;
                }
            }
            catch (Exception e)
            {
                System.Console.WriteLine("Bad selection.. Press any key to continue");
                Console.ReadKey();
            }
                
            }            
        
        try
        {
            var userInput = option;
            switch (userInput)
            {
                case 1:
                    ViewAllCharacterClasses();
                    break;

                case 2:
                    ViewCharacterClassById();
                    break;

                case 3:
                    UpdateExistingCharacterClass();
                    break;

                case 4:
                    AddANewCharacterClass();
                    break;

                case 5:
                    DeleteExistingCharacterClass();
                    break;

                case 6:
                    ManageGameItemDetails();
                    break;

                default:
                    System.Console.WriteLine("Invalid Entry Please Try Again");
                    PressAnyKeyToContinue();
                    break;
            }
        }
        catch (Exception e)
        {
            System.Console.WriteLine("Bad selection.. Press any key to continue");
            Console.ReadKey();
        }
    }

    private void ViewCharacterClassById()
    {
        Clear();
        ForegroundColor = ConsoleColor.DarkBlue;
        WriteLine("Please enter a Character Class Id to look up a Character.");
        var characterClassId = int.Parse(Console.ReadLine()!);

        HttpClient httpClient = new HttpClient();

        HttpResponseMessage response = httpClient.GetAsync($"http://localhost:5211/api/Consumable/{characterClassId}").Result;
        if (response.IsSuccessStatusCode)
        {
            CharacterClassListUI characterClass = response.Content.ReadAsAsync<CharacterClassListUI>().Result;

            WriteLine("|=============================================|\n" +
                      "|                                             |\n" +
                      $"| Here is the information on the Character    |\n" +
                      $"|  Class with ID: {characterClassId}          |\n" +
                      "|                                             |\n" +
                      "|=============================================|\n");

            WriteLine("  ");

             WriteLine("|=========================================================================================================================================================================|\n" +
                          "|                                                                                                                                                                         |\n" +
                          $"| Character Class Id: {characterClass.CharacterClassId} ||  Character Class Name: {characterClass.CharacterClassName}                                    \n" +
                          "|                                                                                                                                                                         |\n" +
                          "|=========================================================================================================================================================================|\n" +
                          "|                                                                                                                                                                         |\n" +
                          "|Character Class Description:                                                                                                                                             |\n" +
                          "|=========================================================================================================================================================================|\n" +
                          "|                                                                                                                                                                         |\n" +
                          $"|{characterClass.CharacterClassDescription} \n" +
                          "|                                                                                                                                                                         |\n" +
                          "|=========================================================================================================================================================================|\n" +
                          "|                                                                                                                                                                         |\n" +
                          $"|Character Class Special Ability: {characterClass.CharacterClassSpecialAbility}  \n" +
                          "|=========================================================================================================================================================================|\n" +
                          "|                                                                                                                                                                         |\n" +
                          $"{characterClass.SpecialAbilityDescription} \n" +
                          "|                                                                                                                                                                         |\n" +
                          "|=========================================================================================================================================================================|\n" +
                          "|                                                                                                                                                                         |\n" +
                          $"|Special Ability Is an Attack: {characterClass.SpecialAbilityIsAnAttack}  ||  Special Ability Heals: {characterClass.SpecialAbilityHeals} \n" +
                          "|                                                                                                                                                                         |\n" +
                          "|=========================================================================================================================================================================|\n" +
                          "|                                                                                                                                                                         |\n" +
                          $"|Special Ability Provides Defense: {characterClass.SpecialAbilityProvidesDefense}  ||  Special Ability Provides Status Effect: {characterClass.SpecialAbilityProvidesStatusEffect} \n" +
                          "|                                                                                                                                                                         |\n" +
                          "|=========================================================================================================================================================================|\n" +
                          "|                                                                                                                                                                         |\n" +
                          $"|Special Ability Damage Amount: {characterClass.SpecialAbilityDamage}  ||  Special Ability Healing Amount: {characterClass.SpecialAbilityHealingAmount} \n" +
                          "|                                                                                                                                                                         |\n" +
                          "|=========================================================================================================================================================================|\n" +
                          "|                                                                                                                                                                         |\n" +
                          $"|Special Ability Defense Amount: {characterClass.SpeacialAbilityDefenseAmount}  ||  Special Ability Duration: {characterClass.SpecialAbilityDuration} \n" +
                          "|                                                                                                                                                                         |\n" +
                          "|=========================================================================================================================================================================|\n");
        }
        
        PressAnyKeyToContinue();
        ManageCharacterClasses();
    }

    private void DeleteExistingCharacterClass()
    {
        Clear();
        ForegroundColor = ConsoleColor.Green;
        WriteLine("Please enter the Character Class Id of the Class you want to delete:");
        int classId = int.Parse(Console.ReadLine()!);

        HttpClient httpClient = new HttpClient();

        HttpResponseMessage response = httpClient.DeleteAsync($"http://localhost:5211/api/Vehicle/{classId}").Result;

        if (response.IsSuccessStatusCode)
        {
            WriteLine("Character Class was deleted successfully.");
        }
        else
        {
            WriteLine("Failed to delete the Character Class. Status Code: " + response.StatusCode);
        }

        PressAnyKeyToContinue();
        ManageCharacterClasses();
    }

    private void UpdateExistingCharacterClass()
    {

    }

    private void AddANewCharacterClass()
    {
        Clear();
        ForegroundColor = ConsoleColor.DarkYellow;
        WriteLine("Please Enter the details for the new Character Class in the following Prompts:");
        PressAnyKeyToContinue();
        Clear();

        Write("Pleass enter a name for the Character Class: ");
        string characterClassName = ReadLine()!;
        Clear();

        Write("Please enter a Description for the Character Class: ");
        string characterClassDescription = ReadLine()!;
        Clear();

        Write("Please enter a Character Class Special Ability: ");
        string characterClassSpecialAbility = Console.ReadLine();
        Clear();

        Write("Please enter a desccription for the special ability: ");
        string specialAbilityDescription = Console.ReadLine();
        Clear();

        Write("Please enter true or false for if Special Ability is an Attack: ");
        bool specialAbilityIsAnAttack = bool.Parse(Console.ReadLine()!);
        Clear();

        Write("Please enter true or false for if Special Ability Heals: ");
        bool specialAbilityHeals = bool.Parse(Console.ReadLine()!);
        Clear();

        Write("Please enter true or false for if Special Ability Provides Defense: ");
        bool specialAbilityProvidesDefense = bool.Parse(Console.ReadLine()!);
        Clear();

        Write("Please enter true or false for if Special Ability Provides a Status Effect: ");
        bool specialAbilityProvidesStatusEffect = bool.Parse(Console.ReadLine()!);
        Clear();

        Write("Please enter a value for the Amount of Damage the Special Ability does : ");
        int specialAbilityDamage = int.Parse(Console.ReadLine()!);
        Clear();

        Write("Please enter a value for the Amount of Healing the Special Ability does: ");
        int specialAbilityHealingAmount = int.Parse(Console.ReadLine()!);
        Clear();

        Write("Please enter a value for the Amount of Defense the Special Ability provides: ");
        int speacialAbilityDefenseAmount = int.Parse(Console.ReadLine()!);
        Clear();

        Write("Please enter how long the Special Ability Lasts: ");
        string specialAbilityDuration = Console.ReadLine();

        CharacterClassCreate characterClassCreation = new CharacterClassCreate
        {
            CharacterClassName = characterClassName,
            CharacterClassDescription = characterClassDescription,
            CharacterClassSpecialAbility = characterClassSpecialAbility,
            SpecialAbilityDescription = specialAbilityDescription,
            SpecialAbilityIsAnAttack = specialAbilityIsAnAttack,
            SpecialAbilityHeals = specialAbilityHeals,
            SpecialAbilityProvidesDefense = specialAbilityProvidesDefense,
            SpecialAbilityProvidesStatusEffect = specialAbilityProvidesStatusEffect,
            SpecialAbilityDamage = specialAbilityDamage,
            SpecialAbilityHealingAmount = specialAbilityHealingAmount,
            SpeacialAbilityDefenseAmount = speacialAbilityDefenseAmount,
            SpecialAbilityDuration = specialAbilityDuration
        };

        var createClass = new StringContent(JsonConvert.SerializeObject(characterClassCreation), Encoding.UTF8, "application/json");

        HttpResponseMessage response = httpClient.PostAsync("http://localhost:5211/api/CharacterClass", createClass).Result;
        if (response.IsSuccessStatusCode)
        {
            CharacterClassListUI classCreated = response.Content.ReadAsAsync<CharacterClassListUI>().Result;

            WriteLine("|=============================================|\n" +
                          "|                                             |\n" +
                          $"| Here is the information on the Character   |\n" +
                          "|  Class that was created.                    |\n" +
                          "|                                             |\n" +
                          "|=============================================|\n");
                    
            WriteLine("  ");
            WriteLine("|=========================================================================================================================================================================|\n" +
                      "|                                                                                                                                                                         |\n" +
                      $"| Character Class Id: {classCreated.CharacterClassId} ||  Character Class Name: {classCreated.CharacterClassName}                                    \n" +
                      "|                                                                                                                                                                         |\n" +
                      "|=========================================================================================================================================================================|\n" +
                      "|                                                                                                                                                                         |\n" +
                      "|Character Class Description:                                                                                                                                             |\n" +
                      "|=========================================================================================================================================================================|\n" +
                      "|                                                                                                                                                                         |\n" +
                      $"|{classCreated.CharacterClassDescription} \n" +
                      "|                                                                                                                                                                         |\n" +
                      "|=========================================================================================================================================================================|\n" +
                      "|                                                                                                                                                                         |\n" +
                      $"|Character Class Special Ability: {classCreated.CharacterClassSpecialAbility}  \n" +
                      "|=========================================================================================================================================================================|\n" +
                      "|                                                                                                                                                                         |\n" +
                      $"{classCreated.SpecialAbilityDescription} \n" +
                      "|                                                                                                                                                                         |\n" +
                      "|=========================================================================================================================================================================|\n" +
                      "|                                                                                                                                                                         |\n" +
                      $"|Special Ability Is an Attack: {classCreated.SpecialAbilityIsAnAttack}  ||  Special Ability Heals: {classCreated.SpecialAbilityHeals} \n" +
                      "|                                                                                                                                                                         |\n" +
                      "|=========================================================================================================================================================================|\n" +
                      "|                                                                                                                                                                         |\n" +
                      $"|Special Ability Provides Defense: {classCreated.SpecialAbilityProvidesDefense}  ||  Special Ability Provides Status Effect: {classCreated.SpecialAbilityProvidesStatusEffect} \n" +
                      "|                                                                                                                                                                         |\n" +
                      "|=========================================================================================================================================================================|\n" +
                      "|                                                                                                                                                                         |\n" +
                      $"|Special Ability Damage Amount: {classCreated.SpecialAbilityDamage}  ||  Special Ability Healing Amount: {classCreated.SpecialAbilityHealingAmount} \n" +
                      "|                                                                                                                                                                         |\n" +
                      "|=========================================================================================================================================================================|\n" +
                      "|                                                                                                                                                                         |\n" +
                      $"|Special Ability Defense Amount: {classCreated.SpeacialAbilityDefenseAmount}  ||  Special Ability Duration: {classCreated.SpecialAbilityDuration} \n" +
                      "|                                                                                                                                                                         |\n" +
                      "|=========================================================================================================================================================================|\n");
                WriteLine("  ");
        }

        PressAnyKeyToContinue();
        ManageCharacterClasses();
    }

    private bool ExitApplication()
    {
        return false;
    }

    private void PressAnyKeyToContinue()
    {
        WriteLine("Press any key to continue...");
        ReadKey();
    }
}
