﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    {
        // Задача 1: Загрузка файла из сети по URL и сохранение его локально
        string url = "https://emojiisland.com/cdn/shop/products/Emoji_Icon_-_Clown_emoji_large.png";
        string localFilePath = "clown.png";
        await DownloadFileAsync(url, localFilePath);

        // Задача 2: Асинхронное чтение и запись файлов
        string filePath = "input.txt";
        await WriteToFileAsync(filePath, "Привет, мир!");
        await ReadFromFileAsync(filePath);

        // Задача 3: Выполнение параллельных HTTP-запросов к нескольким серверам
        List<string> urls = new List<string> { "http://google.com", "http://yandex.ru", "http://yahoo.com" };
        await FetchDataAsync(urls);
    
    }

    static async Task DownloadFileAsync(string url, string filePath)
    {
        using (var httpClient = new HttpClient())
        {
            // Отправка запроса на сервер
            HttpResponseMessage response = await httpClient.GetAsync(url);
            
            if (response.IsSuccessStatusCode)
            {
                using (var file = new FileStream(filePath, FileMode.Create))
                {
                    // Сохранение файла
                    await response.Content.CopyToAsync(file);
                }
            }
            else
            {
                Console.WriteLine($"Ошибка: {response.StatusCode}");
            }
        }
    }

    static async Task WriteToFileAsync(string filePath, string content)
    {
        using (var writer = new StreamWriter(filePath))
        {
            await writer.WriteAsync(content); // запись в файл асинхронно
        }
        Console.WriteLine("Файл успешно записан.");
    }


    static async Task ReadFromFileAsync(string filePath)
    {
        using (var reader = new StreamReader(filePath))
        {
            string line;
            while ((line = await reader.ReadLineAsync()) != null)
            {
                Console.WriteLine(line); // Выведем в консоль
            }
        }
    }

    static async Task FetchDataAsync(List<string> urls)
    {
        using (var httpClient = new HttpClient())
        {
            foreach (var url in urls)
            {
                HttpResponseMessage response = await httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string responseData = await response.Content.ReadAsStringAsync();
                    string firstLine = responseData.Split('\n').FirstOrDefault();
                    Console.WriteLine(firstLine); // Выводим первую строку в консоль
                }
                else
                {
                    Console.WriteLine($"Ошибка из {url}. Ошибка: {response.StatusCode}");
                }
            }
        }
    } 
}