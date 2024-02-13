﻿//    Copyright (c) 2024
//    Author      : Bruno Capuano
//    Change Log  :
//    - Sample console application to use Phi-2 in LM Studio with Semantic Kernel
//
//    The MIT License (MIT)
//
//    Permission is hereby granted, free of charge, to any person obtaining a copy
//    of this software and associated documentation files (the "Software"), to deal
//    in the Software without restriction, including without limitation the rights
//    to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//    copies of the Software, and to permit persons to whom the Software is
//    furnished to do so, subject to the following conditions:
//
//    The above copyright notice and this permission notice shall be included in
//    all copies or substantial portions of the Software.
//
//    THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//    IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//    FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//    AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//    LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//    OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//    THE SOFTWARE.

using Microsoft.Extensions.DependencyInjection;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using sk_customllm;

// Phi-2 in LM Studio
var phi2 = new CustomChatCompletionService();
phi2.ModelUrl = "http://localhost:1234/v1/chat/completions";

// semantic kernel builder
var builder = Kernel.CreateBuilder();
builder.Services.AddKeyedSingleton<IChatCompletionService>("phi2Chat", phi2);
var kernel = builder.Build();

// init chat
var chat = kernel.GetRequiredService<IChatCompletionService>();
var history = new ChatHistory();
history.AddSystemMessage("You are a useful assistant that replies using a funny style and emojis. Your name is Goku.");
history.AddUserMessage("hi, who are you?");

// print response
var result = await chat.GetChatMessageContentsAsync(history);
Console.WriteLine(result[^1].Content);

// ADVANCED CHAT DEMO
// // init chat
// var chat = kernel.GetRequiredService<IChatCompletionService>();
// var history = new ChatHistory();
// history.AddSystemMessage("You are a useful assistant that replies with short messages.");
// Console.WriteLine("Hint: type your question or type 'exit' to leave the conversation");

// // chat loop
// while (true)
// {
//     Console.Write("You: ");
//     var input = Console.ReadLine();
//     if (string.IsNullOrEmpty(input) || input.ToLower() == "exit")
//         break;
//     history.AddUserMessage(input);
//     history = (ChatHistory)await chat.GetChatMessageContentsAsync(history);
//     Console.WriteLine(history[^1].Content);
//     Console.WriteLine("---");
// }

// Console.WriteLine("Goodbye!");