using System.Net.Http.Headers;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using static System.Console;
using DnDTeamGame.Data;
using DnDTeamGame.Data.Entities;
using DnDTeamGame.WebApi;
using DnDTeamGame.Services.WeaponServices;
using DnDTeamGame.Services.AbilityServices;
using DnDTeamGame.Services.BodyTypeServices;
using DnDTeamGame.Services.ArmourServices;
using DnDTeamGame.Services.CharacterClassServices;
using DnDTeamGame.Services.HairColorServices;
using DnDTeamGame.Services.HairStyleServices;
using DnDTeamGame.Services.ConsumableServices;
using DnDTeamGame.Services.UserServices;
using DnDTeamGame.Services.MapServices;
using DnDTeamGame.Services.Games;
using DnDTeamGame.Services.VehicleServices;
using DnDTeamGame.Services.CharacterServices;
using DnDTeamGame.Models.CharacterModels;
using DnDTeamGame.Models.UserModels;
using DnDTeamGame.Models.Games;
using System.Text;
using DnDTeamGame.Models.WeaponModels;

public class ProgramUI
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IUserService _userService;
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
            ForegroundColor = ConsoleColor.Blue;
            WriteLine("|==========================================|\n" +
                     "|                                           |\n" +
                     "|  Welcome to The New Dungeons and Dragons  |\n" +
                     "|  A Game of Fantasy and Destiny            |\n" +
                     "|       Made By: PutSomeRespectOnIt         |\n" +
                     "|                                           |\n" +
                     "|===========================================|\n" +
                     "|                                           |\n" +
                     "|  What Would You Like To Do?               |\n" +
                     "|  1. Manage Users                          |\n" +
                     "|  2. Load Up a Game                        |\n" +
                     "|  3. Make a Weapon                         |\n" +
                     "|  4. Make a Vehicles                       |\n" +
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
                        LoadAGame();
                        break;
                    case 3:
                        MakeAWeapon();
                        break;
                    case 4:
                        MakeAVehicle();
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

    private void ViewAllUsers()
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
        System.Console.WriteLine($"FirstName: {users.FirstName} \n LastName: {users.LastName} \n UserName: {users.UserName}");
            PressAnyKeyToContinue();
        }
    }

    private void ViewUserById()
    {

    }

    private void UpdateAnExistingUser()
    {

    }

    private void AddANewUser()
    {
        Clear();
        ForegroundColor = ConsoleColor.Red;
        WriteLine("|=========================================|\n" +
                    "|                                       |\n" +
                    "| Thanks for Choosing to Play!          |\n" +
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
    }

    private void DeleteExistingUser()
    {

    }

// ============= Game UI ========= \\
    private void LoadAGame()
    {
        Clear();
        ForegroundColor = ConsoleColor.White;
        WriteLine("  |=======================================|\n" +
                    "|                                       |\n" +
                    "| Thanks for Choosing to Play!          |\n" +
                    "|  What would you like to do with the   |\n" +
                    "|  Game?                               |\n" +
                    "|=======================================|\n" +
                    "|                                       |\n" +
                    "|  1. View All Game                     |\n" +
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
        if(int.TryParse(ReadLine(),out int userId))
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

    private void ViewAllGames()
    {
        Clear();
        ForegroundColor = ConsoleColor.DarkYellow;

        HttpClient httpClient = new HttpClient();

        HttpResponseMessage response = httpClient.GetAsync("http://localhost:5211/api/Game").Result;
        if (response.IsSuccessStatusCode)
        {
            List<GameDetailUI> games = response.Content.ReadAsAsync<List<GameDetailUI>>().Result;
            
            foreach (var game in games)
            {
                WriteLine($"GameName: {game.GameName} \n GameDescription: {game.GameDescription}");
            }

            PressAnyKeyToContinue();
        }
    }


// ============= Weapons UI ========= \\
    private void MakeAWeapon()
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
        string weaponType =ReadLine()!;


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
        if(int.TryParse(ReadLine(),out int weaponDamageAmount))
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
        }    }

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
        string weaponType =ReadLine()!;


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
        if(int.TryParse(ReadLine(),out int weaponDamageAmount))
        {
            var updateWeapon = new WeaponDetailUI
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

// ============= Vehicles UI ========= \\

    private void MakeAVehicle()
    {
        throw new NotImplementedException();
    }

    static void Main(string[] args)
    {
        HttpClient httpClient = new HttpClient();
        HttpResponseMessage response = httpClient.GetAsync("http://localhost:5211/api/Character/1005").Result;
        if (response.IsSuccessStatusCode)
        {
            // var content = response.Content.ReadAsStringAsync().Result;
            // var characters = JsonConvert.DeserializeObject<CharacterListUI>(content);

            CharacterListUI character = response.Content.ReadAsAsync<CharacterListUI>().Result;
            Clear();
            WriteLine(character.CharacterName);
            Write("You have choosen to be a: ");
            WriteLine(character.CharacterClassName);
            WriteLine(character.CharacterClassDescription);
            ReadKey();
        //     foreach(var theCharacters in allCharacters.CharacterName)
        //     {
        //         System.Console.WriteLine(theCharacters.CharacterName);
        //     }
        }
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




