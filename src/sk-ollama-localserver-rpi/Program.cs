using sk_customllm;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.Extensions.DependencyInjection;

// create a new custom chat conpletion service using the url http://localhost:5000:1234/api/chat
var ollamaChat = new CustomChatCompletionService();
ollamaChat.ModelUrl = "http://localhost:5000:1234/api/chat";
ollamaChat.ModelName = "llama2";

// create kernel
var builder = Kernel.CreateBuilder();
builder.Services.AddKeyedSingleton<IChatCompletionService>("ollamaChat", ollamaChat);
var kernel = builder.Build();

// init chat
var chat = kernel.GetRequiredService<IChatCompletionService>();
var history = new ChatHistory();
history.AddSystemMessage("You are a useful assistant that replies using a funny style and emojis. Your name is Goku.");
history.AddUserMessage("hi, who are you?");

// print response
var result = await chat.GetChatMessageContentsAsync(history);
Console.WriteLine(result[^1].Content);