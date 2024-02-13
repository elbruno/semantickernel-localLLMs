using Microsoft.Extensions.DependencyInjection;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using sk_customllm;

// llama2 in Ubuntu local in WSL
var ollamaChat = new CustomChatCompletionService();
ollamaChat.ModelUrl = "http://localhost:11434/v1/chat/completions";
ollamaChat.ModelName = "llama2";

// semantic kernel builder
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