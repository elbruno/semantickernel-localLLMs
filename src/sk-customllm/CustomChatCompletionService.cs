using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using System.Net.Http.Headers;
using System.Text.Json;
using sk_customllm.Models;

namespace sk_customllm
{
    public class CustomChatCompletionService : IChatCompletionService
    {
        // public property for the model url endpoint
        public string ModelUrl { get; set; }
        public string ModelName { get; set; }

        public IReadOnlyDictionary<string, object?> Attributes => throw new NotImplementedException();

        public async Task<IReadOnlyList<ChatMessageContent>> GetChatMessageContentsAsync(ChatHistory chatHistory, PromptExecutionSettings? executionSettings = null, Kernel? kernel = null, CancellationToken cancellationToken = default)
        {
            using (var httpClient = new HttpClient())
            {
                using (var request = new HttpRequestMessage(new HttpMethod("POST"), ModelUrl))
                {

                    // iterate though chatHistory and generate a json document based on the Root class
                    var root = new ChatRequest();
                    for (int i = 0; i < chatHistory.Count; i++)
                    {
                        var message = chatHistory[i];
                        var msg = new ChatMessage();
                        msg.role = message.Role.ToString().ToLower();
                        msg.content = message.Content;
                        root.messages.Add(msg);
                    }

                    // validate if ModelName is not empty and add it to the root object
                    if (!string.IsNullOrEmpty(ModelName))
                    {
                        root.model = ModelName;
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

    }
}
