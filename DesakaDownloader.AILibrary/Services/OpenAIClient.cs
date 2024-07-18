using OpenAI_API;
using OpenAI_API.Completions;
using System;
using System.Threading.Tasks;

namespace DesakaDownloader.AILibrary.Services
{
    public class OpenAIClient
    {
        private readonly OpenAIAPI _client;

        public OpenAIClient(string apiKey)
        {
            _client = new OpenAIAPI(apiKey);
        }

        public async Task<string> ExtractInformationAsync(string productDescription)
        {
            try
            {
                Console.WriteLine("Extracting information from product description...");
                CompletionRequest completionRequest = new CompletionRequest
                {
                    Model = "text-davinci-003",
                    Prompt = $"Extract key information from the following product description:\n\n{productDescription}",
                    MaxTokens = 150
                };

                CompletionResult completionResponse = await _client.Completions.CreateCompletionAsync(completionRequest);
                Console.WriteLine("Information extraction completed successfully.");
                return completionResponse.Completions[0].Text.Trim();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error extracting information: {ex.Message}");
                Console.WriteLine(ex.ToString());
                throw;
            }
        }

        public async Task<string> RepairPropertiesAsync(string productProperties)
        {
            try
            {
                Console.WriteLine("Repairing product properties...");
                CompletionRequest completionRequest = new CompletionRequest
                {
                    Model = "text-davinci-003",
                    Prompt = $"Repair the following product properties if needed:\n\n{productProperties}",
                    MaxTokens = 150
                };

                CompletionResult completionResponse = await _client.Completions.CreateCompletionAsync(completionRequest);
                Console.WriteLine("Property repair completed successfully.");
                return completionResponse.Completions[0].Text.Trim();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error repairing properties: {ex.Message}");
                Console.WriteLine(ex.ToString());
                throw;
            }
        }
    }
}