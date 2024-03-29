﻿using Colors = AnsiTools.ANSICodes.Colors;
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
        Console.WriteLine("Starting Assignment 2");
        HttpUtils httpUtils = HttpUtils.instance;
        Response startRespons = await httpUtils.Get(baseURL + startEndpoint + myPersonalID);
        Console.WriteLine($"Start:\n{Colors.Magenta}{startRespons}{ANSICodes.Reset}\n\n"); 
        Response taskResponse = await httpUtils.Get(baseURL + taskEndpoint + myPersonalID + "/" + taskID); 
        TaskDetails taskDetails = JsonSerializer.Deserialize<TaskDetails>(taskResponse.content);
        PrintTaskDetails(taskDetails);
    }
    public async Task taskOne()
    {
        HttpUtils httpUtils = HttpUtils.instance;
        Response taskResponse = await httpUtils.Get(baseURL + taskEndpoint + myPersonalID + "/" + taskID);
        TaskDetails taskDetails = JsonSerializer.Deserialize<TaskDetails>(taskResponse.content);

        string[] parts = taskDetails.parameters.Split(',');
        List<int> primeNumbers = new List<int>();

        foreach (string part in parts)
        {
            if (int.TryParse(part, out int number))
            {
                if (IsPrime(number))
                {
                    primeNumbers.Add(number);
                }
            }
            else
            {
                Console.WriteLine($"Invalid number: {part}");
            }
        }

        primeNumbers.Sort();

        string answer = string.Join(",", primeNumbers);

        Response taskAnswerResponse = await httpUtils.Post(baseURL + taskEndpoint + myPersonalID + "/" + taskID, answer);
        Console.WriteLine($"Answer: {Colors.Green}{taskAnswerResponse}{ANSICodes.Reset}");
    }
     public async Task taskTwo()
    {
        await GetTask();
        HttpUtils httpUtils = HttpUtils.instance;
        Response task2Response = await httpUtils.Get(baseURL + taskEndpoint + myPersonalID + "/" + taskID); 
        TaskDetails taskDetails = JsonSerializer.Deserialize<TaskDetails>(task2Response.content);

        string[] parts = taskDetails.parameters.Split(',');
        List<string> results = new List<string>();

        foreach (string part in parts)
        {
            if (int.TryParse(part, out int number))
            {
                string result = IsEven(number) ? "even" : "odd";
                results.Add(result);
            }
            else
            {
                Console.WriteLine($"Invalid number: {part}");
                
                results.Add("error");
            }
        }
        string answer2 = string.Join(",", results);
        Response task2AnswerResponse = await httpUtils.Post(baseURL + taskEndpoint + myPersonalID + "/" + taskID, answer2);
        Console.WriteLine($"Answer: {Colors.Green}{task2AnswerResponse}{ANSICodes.Reset}");
    }
    public async Task taskThree()
    {
        await GetTask();
        HttpUtils httpUtils = HttpUtils.instance;
        Response taskResponse = await httpUtils.Get(baseURL + taskEndpoint + myPersonalID + "/" + taskID);
        TaskDetails taskDetails = JsonSerializer.Deserialize<TaskDetails>(taskResponse.content);

            string[] parts = taskDetails.parameters.Split(',');
            int sum = 0;

            foreach (string part in parts)
            {
                if (int.TryParse(part, out int number))
                {
                    sum += number;
                }
                else
                {
                    Console.WriteLine($"Invalid number: {part}");
                }
            }
            string answer = sum.ToString();

            Response task3AnswerResponse = await httpUtils.Post(baseURL + taskEndpoint + myPersonalID + "/" + taskID, answer);
            Console.WriteLine($"Answer: {Colors.Green}{task3AnswerResponse}{ANSICodes.Reset}");
        }

    public async Task taskFour()
    {
        await GetTask();
        HttpUtils httpUtils = HttpUtils.instance;
        Response task4Response = await httpUtils.Get(baseURL + taskEndpoint + myPersonalID + "/" + taskID);
        TaskDetails taskDetails = JsonSerializer.Deserialize<TaskDetails>(task4Response.content);

        string[] parts = taskDetails.parameters.Split(',');
        int[] numbers = Array.ConvertAll(parts, int.Parse);

        int lastNumber = numbers[numbers.Length - 1];
        int nextNumber = lastNumber + (lastNumber - numbers[numbers.Length - 2]);
        string answer = nextNumber.ToString();
        Response taskAnswerResponse = await httpUtils.Post(baseURL + taskEndpoint + myPersonalID + "/" + taskID, answer);
        Console.WriteLine($"Answer: {Colors.Green}{taskAnswerResponse}{ANSICodes.Reset}");
    }

    public static async Task Main(string[] args)
        {
            Exam2 exam2 = new Exam2();
            await exam2.GetTask();
            await exam2.taskOne(); 
            exam2.taskID = "aLp96";
            await exam2.taskTwo();
            exam2.taskID = "psu31_4";
            await exam2.taskThree();
            exam2.taskID = "KO1pD3";
            await exam2.taskFour();
        }
    static void PrintTaskDetails(TaskDetails taskDetails)
        {
            Console.WriteLine($"TASK: {ANSICodes.Effects.Bold}{taskDetails.title}{ANSICodes.Reset}\n{taskDetails.description}\nParameters: {Colors.Yellow}{taskDetails.parameters}{ANSICodes.Reset}");
            Console.WriteLine($"Task ID: {taskDetails.taskID}");
            Console.WriteLine($"User ID: {taskDetails.usierID}");
            
        }
    static bool IsPrime(int num)
        {
            if (num <= 1)
            {
                return false;
            }

            if (num <= 3)
            {
                return true;
            }

            if (num % 2 == 0 || num % 3 == 0)
            {
                return false;
            }

            for (int i = 5; i * i <= num; i += 6)
            {
                if (num % i == 0 || num % (i + 2) == 0)
                {
                    return false;
                }
            }

            return true;
        }
    static bool IsEven(int num)
    {
        return num % 2 == 0;
    }

    class TaskDetails
    {
        public string? title { get; set; }
        public string? description { get; set; }
        public string? taskID { get; set; }
        public string? usierID { get; set; }
        public string? parameters { get; set; }

        
    }

};





