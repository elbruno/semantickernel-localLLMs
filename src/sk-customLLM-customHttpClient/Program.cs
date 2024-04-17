﻿//    Copyright (c) 2024
//    Author      : Bruno Capuano
//    Change Log  :
//    - This class demonstrates the usage of a custom HTTP client and the integration of the OpenAI Chat Completion API with the Semantic Kernel library. It creates a custom HTTP client, initializes a kernel with the OpenAI Chat Completion API, and invokes a prompt to generate a response. It also demonstrates the initialization of a chat session and prints the response from the chat service.
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

using sk_customllm;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;

// create custom http client
var customHttpMessageHandler = new CustomHttpMessageHandler();
customHttpMessageHandler.CustomLlmUrl = "http://localhost:11434";
HttpClient client = new HttpClient(customHttpMessageHandler);

// create kernel
var builder = Kernel.CreateBuilder();
builder.AddOpenAIChatCompletion("llama2", "api-key", httpClient: client);
var kernel = builder.Build();

// invoke a simple prompt to the chat service
string prompt = "Write a joke about kittens";
var response = await kernel.InvokePromptAsync(prompt);
Console.WriteLine(response.GetValue<string>());

// init chat
var chat = kernel.GetRequiredService<IChatCompletionService>();
var history = new ChatHistory();
history.AddSystemMessage("You are a useful assistant that replies using a funny style and emojis. Your name is Goku.");
history.AddUserMessage("hi, who are you?");

// print response
var result = await chat.GetChatMessageContentsAsync(history);
Console.WriteLine(result[^1].Content);