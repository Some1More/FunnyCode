﻿using Rocket.Chat.Net.Bot.Interfaces;
using Rocket.Chat.Net.Bot;
using Rocket.Chat.Net.Interfaces;
using Rocket.Chat.Net.Models.LoginOptions;

namespace FunnyCode.Infrastructure.RocketChat;

public class Class1
{
    public async void Main()
    {
        const string username = "m@silvenga.com";
        const string password = "silverlight";
        const string rocketServerUrl = "dev0:3000"; // just the host and port
        const bool useSsl = false; // Basically use ws or wss.

        // Create the bot - an abstraction of the driver
        RocketChatBot bot = new(rocketServerUrl, useSsl);

        // Connect to Rocket.Chat
        await bot.ConnectAsync();

        // Login
        ILoginOption loginOption = new EmailLoginOption
        {
            Email = username,
            Password = password
        };
        await bot.LoginAsync(loginOption);

        // Start listening for messages
        await bot.SubscribeAsync();

        // Add possible responses to be checked in order
        // This is not thead safe, FYI 
        IBotResponse giphyResponse = new GiphyResponse();
        bot.AddResponse(giphyResponse);

        // And that's it
        // Checkout GiphyResponse in the example project for more info.
    }
}