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
using System.Text;
using DnDTeamGame.Models.WeaponModels;
using DnDTeamGame.Models.VehicleModels;

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
            ForegroundColor = ConsoleColor.DarkRed;
            WriteLine("|===========================================|\n" +
                     "|                                           |\n" +
                     "|  Welcome to The New Dungeons and Dragons  |\n" +
                     "|  A Game of Fantasy and Destiny            |\n" +
                     "|       Made By: PutSomeRespectOnIt         |\n" +
                     "|                                           |\n" +
                     "|===========================================|\n" +
                     "|                                           |\n" +
                     "|  What Would You Like To Do?               |\n" +
                     "|  1. Manage Users                          |\n" +
                     "|  2. Manage A Game                         |\n" +
                     "|  3. Start Game                            |\n" +
                     "|  4. Manage Game Item Details              |\n" +
                     "|  0. Close Application                     |\n" +
                     "|                                           |\n" +
                     "|===========================================|");
            try
            {
                var userInput = int.Parse(Console.ReadLine()!);
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

                    case 0:
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
        WriteLine("|=========================================|\n" +
                    "|                                       |\n" +
                    "|  DnDTeamGame User Management          |\n" +
                    "|  What would you like to do with the   |\n" +
                    "|  Users?                               |\n" +
                    "|=======================================|\n" +
                    "|                                       |\n" +
                    "|  1. View All Users                    |\n" +
                    "|  2. View User By Id                   |\n" +
                    "|  3. Update Existing User              |\n" +
                    "|  4. Add a New User                    |\n" +
                    "|  5. Delete a User                     |\n" +
                    "|  0. Return to Main Menu               |\n" +
                    "|=======================================|");
        try
        {
            var userInput = int.Parse(Console.ReadLine()!);
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
        // httpClient.BaseAddress = new Uri("http://localhost:5211/api");
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
            System.Console.WriteLine($"Welcome to the Game {users.FirstName} {users.LastName}! Your UserName is - {users.UserName}");

            System.Console.WriteLine($"FirstName: {users.FirstName} \n LastName: {users.LastName} \n UserName: {users.UserName}");
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
        WriteLine("|=========================================|\n" +
                    "|                                       |\n" +
                    "| Thanks for Choosing to Play!          |\n" +
                    "|  To begin what is your First Name?    |\n" +
                    "|                                       |\n" +
                    "|=======================================|\n");
        string userFirstName = Console.ReadLine();
        PressAnyKeyToContinue();
        Clear();
        ForegroundColor = ConsoleColor.Magenta;
        WriteLine("|=========================================|\n" +
                    "|                                       |\n" +
                    "|  What is your Last Name?              |\n" +
                    "|                                       |\n" +
                    "|=======================================|\n");
        string userLastName = Console.ReadLine();
        PressAnyKeyToContinue();
        Clear();
        ForegroundColor = ConsoleColor.Magenta;
        WriteLine("|=========================================|\n" +
                    "|                                       |\n" +
                    "|       Please enter a UserName:        |\n" +
                    "|                                       |\n" +
                    "|=======================================|\n");
        string newUserName = Console.ReadLine();
        PressAnyKeyToContinue();
        Clear();
        ForegroundColor = ConsoleColor.Magenta;
        WriteLine("|=========================================|\n" +
                    "|                                       |\n" +
                    "|    Please enter an Email Address:     |\n" +
                    "|                                       |\n" +
                    "|=======================================|\n");
        string userEmail = Console.ReadLine();
        PressAnyKeyToContinue();
        Clear();
        ForegroundColor = ConsoleColor.Magenta;
        WriteLine("|=========================================|\n" +
                    "|                                       |\n" +
                    "|    Please enter a Password:           |\n" +
                    "|                                       |\n" +
                    "|=======================================|\n");
        string userPassword = Console.ReadLine();
        PressAnyKeyToContinue();
        Clear();
        ForegroundColor = ConsoleColor.Magenta;
        WriteLine("|=========================================|\n" +
                    "|                                       |\n" +
                    "|    Please enter Confirm Password:     |\n" +
                    "|                                       |\n" +
                    "|=======================================|\n");
        string userConfirmPassword = Console.ReadLine();

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
        WriteLine("|=========================================|\n" +
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

        WriteLine("UserId: ");
        if (int.TryParse(ReadLine(), out int userId))
        {
            var newGame = new GameDetailUI
            {
                GameName = gameName,
                GameDescription = gameDescription,
                UserId = userId,
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

        Write("User ID: ");
        if (int.TryParse(ReadLine(), out int userId))
        {
            var updatedGame = new GameDetailUI
            {
                GameId = gameId,
                GameName = gameName,
                GameDescription = gameDescription,
                UserId = userId,
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
        WriteLine("|=========================================|\n" +
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
                WriteLine($"GameName: {game.GameName} \n" +
                          "   \n" +
                          "GameDescription: \n" +
                          "  \n" +
                          "==============================================================================================================\n" +
                          "  \n" +
                          $"{game.GameDescription}\n" +
                          "     \n" +
                          "==============================================================================================================");
            }

            PressAnyKeyToContinue();
        }
    }

    private void StartAGame()
    {
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
                                 "|                                       |\n" +
                                 "|  1. Create a New Character            |\n" +
                                 "|  2. View Existing Game Character      |\n" +
                                 "|  0. Return to Main Menu               |\n" +
                                 "|=======================================|");

        try
        {
            var userInput = int.Parse(Console.ReadLine()!);
            switch (userInput)
            {
                case 1:
                    CreateACharacter();
                    break;

                case 2:
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

    private void CreateACharacter()
    {
        Clear();
        ForegroundColor = ConsoleColor.DarkGray;
        WriteLine("|=========================================|\n" +
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
            int baseHealth = 150;
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
            int baseHealth = 120;
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

        ViewAllHairStyles();
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
        ViewAllCharacterClasses();
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
        // ViewAllAbilities();
        System.Console.WriteLine("Please enter the Ability IDs separated by commas (e.g., 1,2) to assign your Abilities to your Character:");
        string userInput = Console.ReadLine();

        List<int> newAbilityIds = userInput
            .Split(',')
            .Select(id => int.Parse(id.Trim()))
            .ToList();
    }

    private void ManageWeapons()
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
                    "|  1. View All Weapons                  |\n" +
                    "|  2. View Weapon By Id                 |\n" +
                    "|  3. Update Existing Weapon            |\n" +
                    "|  4. Add a New Weapon                  |\n" +
                    "|  5. Delete a Weapon                   |\n" +
                    "|  0. Return to Main Menu               |\n" +
                    "|=======================================|");
        try
        {
            var userInput = int.Parse(Console.ReadLine()!);
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

        // Write("Weapon Damage Amount: ");
        // int weaponDamageAmount = int.Parse(Console.ReadLine()!);




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
                WriteLine("new game added successfully");
            }
            else
            {
                WriteLine("Failed to add new Game");
            }
            PressAnyKeyToContinue();
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

            foreach (var weapon in weapons)
            {
                WriteLine(
                          $"WeaponId {weapon.WeaponId} \n" +
                          $"GameName: {weapon.WeaponName} \n" +
                          $"WeaponType: {weapon.WeaponType} \n" +
                          $"WeaponDescription: {weapon.WeaponDescription} \n" +
                          $"WeaponRange: {weapon.WeaponIsARangedWeapon} \n" +
                          $"WeaponMelee: {weapon.WeaponIsAMeleeWeapon} \n" +
                          $"WeaponGenerateSplashDamage: {weapon.WeaponGeneratesSplashDamage} \n" +
                          $"RangeDistanceWeapon: {weapon.RangedWeaponDistance} \n" +
                          $"WeaponSplashDamageAmount: {weapon.WeaponSplashDamageAmount} \n" +
                          $"WeaponDamageAmount: {weapon.WeaponDamageAmount} \n");
            }

            PressAnyKeyToContinue();
        }
    }

    private void ViewWeaponById()
    {
        Clear();
        ForegroundColor = ConsoleColor.Black;
        WriteLine("Please enter a WeaponId to look up a Weapons.");
        var weaponId = int.Parse(Console.ReadLine()!);

        HttpClient httpClient = new HttpClient();

        HttpResponseMessage response = httpClient.GetAsync($"http://localhost:5211/api/Weapon/{weaponId}").Result;
        if (response.IsSuccessStatusCode)
        {
            WeaponDetailUI weapon = response.Content.ReadAsAsync<WeaponDetailUI>().Result;
            WriteLine(
                      $"WeaponId {weapon.WeaponId} \n" +
                      $"GameName: {weapon.WeaponName} \n" +
                      $"WeaponType: {weapon.WeaponType} \n" +
                      $"WeaponDescription: {weapon.WeaponDescription} \n" +
                      $"WeaponRange: {weapon.WeaponIsARangedWeapon} \n" +
                      $"WeaponMelee: {weapon.WeaponIsAMeleeWeapon} \n" +
                      $"WeaponGenerateSplashDamage: {weapon.WeaponGeneratesSplashDamage} \n" +
                      $"RangeDistanceWeapon: {weapon.RangedWeaponDistance} \n" +
                      $"WeaponSplashDamageAmount: {weapon.WeaponSplashDamageAmount} \n" +
                      $"WeaponDamageAmount: {weapon.WeaponDamageAmount} \n");
            PressAnyKeyToContinue();
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

        // Write("Weapon Damage Amount: ");
        // int weaponDamageAmount = int.Parse(Console.ReadLine()!);




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
    }

    private void ViewCharacterById()
    {
        Clear();
        ForegroundColor = ConsoleColor.DarkGreen;
        WriteLine("|====================================================|\n" +
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
            WriteLine("==================================================");
            WriteLine(character.CharacterName);
            Write("You have choosen to be a: ");
            WriteLine(character.CharacterClassName);
            WriteLine(character.CharacterClassDescription);
            WriteLine("==================================================");
            ReadKey();
            StartAGame();
        }
    }

    private void ViewAllHairStyles()
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

            PressAnyKeyToContinue();
        }
    }

    private void ViewAllCharacterClasses()
    {

        ForegroundColor = ConsoleColor.DarkRed;

        HttpClient httpClient = new HttpClient();

        HttpResponseMessage response = httpClient.GetAsync("http://localhost:5211/api/CharacterClass").Result;
        if (response.IsSuccessStatusCode)
        {
            List<CharacterClassListUI> characterClasses = response.Content.ReadAsAsync<List<CharacterClassListUI>>().Result;

            foreach (var characterClass in characterClasses)
            {
                WriteLine("=================================================================================================================|\n" +
                          "|                                                                                                                |\n" +
                          $"| Character Class ID: {characterClass.CharacterClassId} | Character Class Name: {characterClass.CharacterClassName}|\n" +
                          "|================================================================================================================|\n" +
                          "| Character Class Description:                                                                                   |\n" +
                          "|________________________________________________________________________________________________________________|\n" +
                          "|                                                                                                                |\n" +
                          $" {characterClass.CharacterClassDescription}                         \n" +
                          "                                                                                                                 ");
            }

            PressAnyKeyToContinue();
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

    // private void ViewAllAbilities()
    // {
    //     ForegroundColor = ConsoleColor.DarkCyan;

    //     HttpClient httpClient = new HttpClient();

    //     HttpResponseMessage response = httpClient.GetAsync("http://localhost:5211/api/Ability").Result;
    //     if (response.IsSuccessStatusCode)
    //     {
    //         List<AbilityDetailUI> abilities = response.Content.ReadAsAsync<List<AbilityDetailUI>>().Result;

    //         foreach (var ability in abilities)
    //         {
    //             WriteLine("=================================================================================================================|\n" +
    //                       "|                                                                                                                |\n" +
    //                       $"| Ability ID: {ability.AbilityId} | Ability Name: {ability.AbilityName}|\n" +
    //                       "|================================================================================================================|\n" +
    //                       "| Ability Description:                                                                                           |\n" +
    //                       "|________________________________________________________________________________________________________________|\n" +
    //                       "|                                                                                                                |\n" +
    //                       $" {ability.AbilityDescription}                         \n" +
    //                       "                                                                                                                 ");
    //         }

    //         PressAnyKeyToContinue();
    //     }
    // }
    private void ManageGameItemDetails()
    {
        Clear();
        ForegroundColor = ConsoleColor.Red;
        WriteLine("|=========================================|\n" +
                    "|                                       |\n" +
                    "|  DnDTeamGame Game Item Management     |\n" +
                    "|  What would you like to do?           |\n" +
                    "|  m                                    |\n" +
                    "|=======================================|\n" +
                    "|                                       |\n" +
                    "|  1. Manage Weapons                    |\n" +
                    "|  2. Manage Vehicles                   |\n" +
                    "|  3. Manage Character Classes          |\n" +
                    "|  4. Manage Abilities                  |\n" +
                    "|  5. Manage Armours                    |\n" +
                    "|  6. Manage Consumables                |\n" +
                    "|  7. Manage Body Types                 |\n" +
                    "|  8. Manage Hair Styles                |\n" +
                    "|  9. Manage Hair Colors                |\n" +
                    "| 10. Manage Maps                       |\n" +
                    "|  0. Return to Main Menu               |\n" +
                    "|=======================================|");
        try
        {
            var userInput = int.Parse(Console.ReadLine()!);
            switch (userInput)
            {
                case 1:
                    ManageWeapons();
                    break;
                case 2:
                    ManageVehicles();
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

    private void ManageWeapon()
    {
        Clear();
        ForegroundColor = ConsoleColor.White;
        WriteLine("|=======================================|\n" +
                    "|                                       |\n" +
                    "|                                       |\n" +
                    "|  What would you like to do with the   |\n" +
                    "|  Weapons?                             |\n" +
                    "|=======================================|\n" +
                    "|                                       |\n" +
                    "|  1. View All Weapons                  |\n" +
                    "|  2. View Weapons By Id                |\n" +
                    "|  3. Update Existing Weapon            |\n" +
                    "|  4. Add a New Weapon                  |\n" +
                    "|  5. Delete a Weapon                   |\n" +
                    "|  0. Return to Manage Game Items       |\n" +
                    "|=======================================|");
        try
        {
            var userInput = int.Parse(Console.ReadLine()!);
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


    // =========================================== Vehicle UI ============================================= //
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
                    "|  1. View All Vehicles                  |\n" +
                    "|  2. View Vehicle By Id                 |\n" +
                    "|  3. Update Existing Vehicle            |\n" +
                    "|  4. Add a New Vehicle                  |\n" +
                    "|  5. Delete a Vehicle                   |\n" +
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
                WriteLine("new game added successfully");
            }
            else
            {
                WriteLine("Failed to add new Game");
            }
            PressAnyKeyToContinue();
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

            foreach (var vehicle in vehicles)
            {
                WriteLine(
                          $"VehicleId {vehicle.VehicleId} \n" +
                          $"VehicleName: {vehicle.VehicleName} \n" +
                          $"VehicleSpeed: {vehicle.VehicleSpeed} \n" +
                          $"VehicleAbility: {vehicle.VehicleAbility} \n" +
                          $"VehicleType: {vehicle.VehicleType} \n" +
                          $"VehicleDescription: {vehicle.VehicleDescription} \n" +
                          $"VehicleAttackDamage: {vehicle.VehicleAttackDamage} \n" +
                          $"VehicleHealth: {vehicle.VehicleHealth} \n");
            }

            PressAnyKeyToContinue();
        }
    }

    private void ViewVehicleById()
    {
        Clear();
        ForegroundColor = ConsoleColor.Black;
        WriteLine("Please enter a VehicleId to look up a Vehicle Details.");
        var vehicleId = int.Parse(Console.ReadLine()!);

        HttpClient httpClient = new HttpClient();

        HttpResponseMessage response = httpClient.GetAsync($"http://localhost:5211/api/Vehicle/{vehicleId}").Result;
        if (response.IsSuccessStatusCode)
        {
            VehicleDetailUI vehicle = response.Content.ReadAsAsync<VehicleDetailUI>().Result;
                    WriteLine(
                          $"VehicleId {vehicle.VehicleId} \n" +
                          $"VehicleName: {vehicle.VehicleName} \n" +
                          $"VehicleSpeed: {vehicle.VehicleSpeed} \n" +
                          $"VehicleAbility: {vehicle.VehicleAbility} \n" +
                          $"VehicleType: {vehicle.VehicleType} \n" +
                          $"VehicleDescription: {vehicle.VehicleDescription} \n" +
                          $"VehicleAttackDamage: {vehicle.VehicleAttackDamage} \n" +
                          $"VehicleHealth: {vehicle.VehicleHealth} \n"
                          );
            PressAnyKeyToContinue();
        }
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
    }

    private bool ExitApplication()
    {
        return false;
    }

    private void DisplayDataValidationError(int userInputValue)
    {
        ForegroundColor = ConsoleColor.Blue;
        WriteLine($"Invalid Id Entry: {userInputValue}!");
        ResetColor();
        return;
    }

    private void PressAnyKeyToContinue()
    {
        WriteLine("Press any key to continue...");
        ReadKey();
    }
}