//    Copyright (c) 2024
//    Author      : Bruno Capuano
//    Change Log  :
//    - Sample console application to use llama2 LLM running locally in Ubuntu with Semantic Kernel
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
using Microsoft.SemanticKernel.TextGeneration;
using sk_ollamacsharp;

// llama2 in Ubuntu local in WSL
var ollamaChat = new OllamaChatCompletionService();
ollamaChat.ModelUrl = "http://localhost:11434";
ollamaChat.ModelName = "llama2";

var ollamaText = new OllamaTextGenerationService();
ollamaText.ModelUrl = "http://localhost:11434";
ollamaText.ModelName = "llama2";

// semantic kernel builder
var builder = Kernel.CreateBuilder();
builder.Services.AddKeyedSingleton<IChatCompletionService>("ollamaChat", ollamaChat);
builder.Services.AddKeyedSingleton<ITextGenerationService>("ollamaText", ollamaText);
var kernel = builder.Build();

// text generation
Console.WriteLine("====================");
Console.WriteLine("TEXT GENERATION DEMO");
Console.WriteLine("====================");
var textGen = kernel.GetRequiredService<ITextGenerationService>();
var response = textGen.GetTextContentsAsync("The weather in January in Toronto is usually ").Result;
Console.WriteLine(response[^1].Text);

// chat
Console.WriteLine("====================");
Console.WriteLine("CHAT COMPLETION DEMO");
Console.WriteLine("====================");
var chat = kernel.GetRequiredService<IChatCompletionService>();
var history = new ChatHistory();
history.AddSystemMessage("You are a useful assistant that replies using a funny style and emojis. Your name is Goku.");
history.AddUserMessage("hi, who are you?");

// print response
var result = await chat.GetChatMessageContentsAsync(history);
Console.WriteLine(result[^1].Content);