using Colors = AnsiTools.ANSICodes.Colors;
using AnsiTools;
using HTTPUtils;
using System.Text.Json;
using System.Runtime.CompilerServices;



public class Exam2
{

    const string myPersonalID = "84a06f57d16a4b3388fcbd499ce3c2ee87a1a9827836c2bf75f0a27674621d72"; 
    const string baseURL = "https://mm-203-module-2-server.onrender.com/";
    const string startEndpoint = "start/"; 
    const string taskEndpoint = "task/";
    string taskID = "kuTw53L";

     
    
    public async Task GetTask()
    {
        Console.Clear();
        Console.WriteLine("Starting Assignment 2");
        HttpUtils httpUtils = HttpUtils.instance;
        Response startRespons = await httpUtils.Get(baseURL + startEndpoint + myPersonalID);
        Console.WriteLine($"Start:\n{Colors.Magenta}{startRespons}{ANSICodes.Reset}\n\n"); 
         
    }

    public async Task taskOne()
    {
        //#### FIRST TASK 
        HttpUtils httpUtils = HttpUtils.instance;

        Response task1Response = await httpUtils.Get(baseURL + taskEndpoint + myPersonalID + "/" + taskID); 
        Console.WriteLine(task1Response);
    }

    public static async Task Main(string[] args)
        {
            Exam2 exam2 = new Exam2();
            await exam2.GetTask();
            await exam2.taskOne(); 
        }


};
   




