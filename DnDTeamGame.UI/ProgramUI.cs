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
                     "|  2. Load Up a Game                        |\n" +
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
            PressAnyKeyToContinue();
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
                    "|=======================================|\n" );
        string userFirstName = Console.ReadLine();
        PressAnyKeyToContinue();
        Clear();
        ForegroundColor = ConsoleColor.Magenta;
        WriteLine("|=========================================|\n" +
                    "|                                       |\n" +
                    "|  What is your Last Name?              |\n" +
                    "|                                       |\n" +
                    "|=======================================|\n" );
        string userLastName = Console.ReadLine();
        PressAnyKeyToContinue();
        Clear();
        ForegroundColor = ConsoleColor.Magenta;
        WriteLine("|=========================================|\n" +
                    "|                                       |\n" +
                    "|       Please enter a UserName:        |\n" +
                    "|                                       |\n" +
                    "|=======================================|\n" );
        string newUserName = Console.ReadLine();
        PressAnyKeyToContinue();
        Clear();
        ForegroundColor = ConsoleColor.Magenta;
        WriteLine("|=========================================|\n" +
                    "|                                       |\n" +
                    "|    Please enter an Email Address:     |\n" +
                    "|                                       |\n" +
                    "|=======================================|\n" );
        string userEmail = Console.ReadLine();
        PressAnyKeyToContinue();
        Clear();
        ForegroundColor = ConsoleColor.Magenta;
        WriteLine("|=========================================|\n" +
                    "|                                       |\n" +
                    "|    Please enter a Password:           |\n" +
                    "|                                       |\n" +
                    "|=======================================|\n" );
        string userPassword = Console.ReadLine();
        PressAnyKeyToContinue();
        Clear();
        ForegroundColor = ConsoleColor.Magenta;
        WriteLine("|=========================================|\n" +
                    "|                                       |\n" +
                    "|    Please enter Confirm Password:     |\n" +
                    "|                                       |\n" +
                    "|=======================================|\n" );
        string userConfirmPassword = Console.ReadLine();

        HttpClient httpClient = new HttpClient();
        // httpClient.BaseAddress = new Uri("http://localhost:5211/api/User/");
        UserRegisterUI registerUser = new UserRegisterUI
        {
            UserName = newUserName,
            Password = userPassword,
            ConfirmPassword = userConfirmPassword,
            FirstName = userFirstName,
            LastName = userLastName,
            Email = userEmail
        };
        // System.Console.WriteLine(user);
        // PressAnyKeyToContinue();

        // // var content = new StringContent(user);
        var userContent = new StringContent(JsonConvert.SerializeObject(registerUser), Encoding.UTF8, "application/json");

        HttpResponseMessage response = httpClient.PostAsync("http://localhost:5211/api/User/Register", userContent).Result;
        ReadKey();
        if (response.IsSuccessStatusCode)
            {
                UserDetailUI userCreated = response.Content.ReadAsAsync<UserDetailUI>().Result;
                Console.Clear();

                System.Console.WriteLine($"Welcome to the Game {registerUser.FirstName} {registerUser.LastName}! Your UserName is - {registerUser.UserName}");
                PressAnyKeyToContinue();
            }
            else
            {
                Console.WriteLine("Internal server Error");
                PressAnyKeyToContinue();
            }
    }

    private void DeleteExistingUser()
    {

    }

    private void LoadAGame()
    {

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
            Console.Clear();
            System.Console.WriteLine(character.CharacterName);
            Console.Write("You have choosen to be a: ");
            Console.WriteLine(character.CharacterClassName);
            System.Console.WriteLine(character.CharacterClassDescription);
            Console.ReadKey();
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


