using Microsoft.SemanticKernel.TextGeneration;
using Microsoft.SemanticKernel;
using System.Runtime.CompilerServices;
using Microsoft.SemanticKernel.ChatCompletion;
using System.Net.Http.Headers;
using System.Text.Json;
using SKPhi2Local.Models;

namespace SKPhi2Local.LMStudio
{
    public class Phi2GenerationService : ITextGenerationService, IChatCompletionService
    {
        // public property for the model url endpoint
        public string ModelUrl { get; set; }

        public IReadOnlyDictionary<string, object?> Attributes => new Dictionary<string, object?>();

        public async Task<IReadOnlyList<ChatMessageContent>> GetChatMessageContentsAsync(ChatHistory chatHistory, PromptExecutionSettings? executionSettings = null, Kernel? kernel = null, CancellationToken cancellationToken = default)
        {
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("POST"), ModelUrl))
                {

                    // iterate though chatHistory and generate a json document based on the Root class
                    var root = new ChatRequest();
                    foreach (var message in chatHistory)
                    {
                        var msg = new ChatMessage();
                        msg.role = message.Role.ToString().ToLower();
                        msg.content = message.Content;
                        root.messages.Add(msg);
                    }

                    // generate the json string from the root object
                    var jsonString = JsonSerializer.Serialize(root);
                    request.Content = new StringContent(jsonString);
                    request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
                    var httpResponse = await httpClient.SendAsync(request);

                    // get the response content
                    var responseContent = await httpResponse.Content.ReadAsStringAsync();

                    // deserialize the response content into a ChatResponse object
                    var chatResponse = JsonSerializer.Deserialize<ChatResponse>(responseContent);

                    // add httpResponse content to chatHistory
                    chatHistory.AddAssistantMessage(chatResponse.choices[0].message.content);
                }
            }

            return chatHistory;
        }

        public IAsyncEnumerable<StreamingChatMessageContent> GetStreamingChatMessageContentsAsync(ChatHistory chatHistory, PromptExecutionSettings? executionSettings = null, Kernel? kernel = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<StreamingTextContent> GetStreamingTextContents(string prompt, PromptExecutionSettings? executionSettings = null, Kernel? kernel = null, [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public IAsyncEnumerable<StreamingTextContent> GetStreamingTextContentsAsync(string prompt, PromptExecutionSettings? executionSettings = null, Kernel? kernel = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<TextContent>> GetTextContentsAsync(string prompt, PromptExecutionSettings? executionSettings = null, Kernel? kernel = null, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
