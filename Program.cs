using HTTPUtils;
using System;
using System.Text.Json;
using AnsiTools;
using Colors = AnsiTools.ANSICodes.Colors;

public class Program
{
    private const string myPersonalID = "84a06f57d16a4b3388fcbd499ce3c2ee87a1a9827836c2bf75f0a27674621d72";
    private const string baseURL = "https://mm-203-module-2-server.onrender.com/";
    private const string startEndpoint = "start/";
    private const string taskEndpoint = "task/";

    public class taskDetails
    {
        public string title { get; set; }
        public string description { get; set; }
        public string taskID { get; set; }
        public string userID { get; set; }
        public string parameters { get; set; }
    }

    public static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine("Starting Assignment 2");

        // Register and get the first task
        string taskID = RegisterAndGetFirstTask();

        // Perform the first task
        PerformFirstTask(taskID);
    }

    private static string RegisterAndGetFirstTask()
    {
        HttpUtils httpUtils = HttpUtils.instance;

        // Register and get the first task
        Response startResponse = httpUtils.Get(baseURL + startEndpoint + myPersonalID).Result;
        Console.WriteLine($"Start:\n{Colors.Magenta}{startResponse}{ANSICodes.Reset}\n\n");

        // Extract task ID from the response
        // Adjust this part based on the actual structure of the response
        string taskID = "kuTw53L"; // Placeholder, replace with actual task ID from response
        return taskID;
    }

    private static void PerformFirstTask(string taskID)
    {
        HttpUtils httpUtils = HttpUtils.instance;

        // Fetch details of the task from the server
        Response taskResponse = httpUtils.Get(baseURL + taskEndpoint + myPersonalID + "/" + taskID).Result;

        // Deserialize JSON response into TaskDetails object
        taskDetails taskDetails = JsonSerializer.Deserialize<taskDetails>(taskResponse.content);

        // Print formatted task details
        Console.WriteLine($"Title: {taskDetails.title}");
        Console.WriteLine($"Description: {taskDetails.description}");
        Console.WriteLine($"Task ID: {taskDetails.taskID}");
        Console.WriteLine($"User ID: {taskDetails.userID}");
        Console.WriteLine($"Parameters: {taskDetails.parameters}");
        
        
    }
    
}