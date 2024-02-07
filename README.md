# Using Semantic Kernel with local LLMs
## Running a local webserver with LMStudio to expose Phi-2 model

[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](/LICENSE)
[![Twitter: elbruno](https://img.shields.io/twitter/follow/elbruno.svg?style=social)](https://twitter.com/elbruno)
![GitHub: elbruno](https://img.shields.io/github/followers/elbruno?style=social)

✨ 
This is a quickstart for sample to show how to run a SLM (small language model: Phi-2) in local mode with LMStudioAI, and how to interact with the model using SemanticKernel.

## Getting started - Quick guide

1. **🌐 Start Local Inference Server**: Open [LM Studio](https://lmstudio.ai/) and start the webserver with your favourite LLM.     

1. **📤 One-click setup**: [Open a new Codespace](https://codespaces.new/elbruno/sk-phi2-localserver-lmstudio), giving you a fully configured cloud developer environment.

1. **💬 Change your chat questions**: Update the chat code in `src/sk-phi2-localserver-lmstudio/Program.cs`.     

1. **▶️ Run, one-click again**: Use VS Code's built-in *Run* command. Check LM Studio logs and app logs to see the model running.

1. **🔄 Iterate quickly:** Codespaces updates the server on each save, and VS Code's debugger lets you dig into the code execution.

## Getting Started with [LM Studio](https://lmstudio.ai/)

[LM Studio](https://lmstudio.ai/) is a desktop application that allows you to run open-source models locally on your computer. You can use LM Studio to discover, download, and chat with models from Hugging Face, or create your own custom models. LM Studio also lets you run a local inference server that mimics the OpenAI API, so you can use any model with your favorite tools and frameworks. LM Studio is available for Mac, Windows, and Linux, and you can download it from their website.

![Search for models in LM Studio](/images/20LMStudioSearchModel.png "Search for models in LM Studio")


### Download models locally and run a local inference server with LM Studio
Here are the steps to run a local server with LM Studio

1. Launch LM Studio and search for a LLM from **Hugging Face** using the search bar. You can filter the models by compatibility, popularity, or quantization level.
    For this demo we will use Phi-2.

1. Select a model and click **Download**. You can also view the model card for more information about the model.

1. Once the model is downloaded, go to the **Local Server section** and select the model from the drop-down menu. You can also adjust the server settings and parameters as you wish.

1. Click **Start Server** to run the model on your local machine. You will see a URL that you can use to access the server from your browser or other applications. 
    
    ***Important:** The server is compatible with the OpenAI API, so you can use the same code and format for your requests and responses.*

1. To stop the server, click **Stop Server**. You can also delete the model from your machine if you don’t need it anymore.

![Local Inference Server running in LM Studio](/images/22ServerRunning.png "Local Inference Server running in LM Studio")

## Phi-2

Phi-2 is a small language model (SLM) developed by Microsoft Research that has 2.7 billion parameters and demonstrates outstanding reasoning and language understanding capabilities. It was trained on a mix of synthetic and web datasets for natural language processing and coding. It achieves state-of-the-art performance among base language models with less than 13 billion parameters and matches or outperforms models up to 25x larger on complex benchmarks. We can use Phi-2 to generate text, code, or chat with it using the Azure AI Studio or the Hugging Face platform⁴. 😊

Here are some additional resources related to Phi-2:

- Phi-2: The surprising power of small language models. https://www.microsoft.com/en-us/research/blog/phi-2-the-surprising-power-of-small-language-models/
- Microsoft/phi-2 · Hugging Face. https://huggingface.co/microsoft/phi-2

## Run Local
1. Start the LM Studio Local Inference Server running with Phi-2.

1. Open `src/sk-phi2-localserver-lmstudio/Program.cs`. 

    Press [F5] To Start Debugging. Choose your prefered Debugger.

1. Once the project is compiled, the app should be running. 

    Check the logs to see the chat interaction. You can also check LM Studio logs to validate the LLM model outpus.
    ![Run simple demo](/images/30RunSimpleDemo.png "Run Simple demo")

## Run in Codespaces

1. Click here to open in GitHub Codespaces

    [![Open in GitHub Codespaces](https://img.shields.io/static/v1?style=for-the-badge&label=GitHub+Codespaces&message=Open&color=lightgrey&logo=github)](https://codespaces.new/elbruno/sk-phi2-localserver-lmstudio)

1. This action may take a couple of minutes. Once the Codespaces is initialized, check the Extensions tab and check that all extensions are installed.

1. The file `src/sk-phi2-localserver-lmstudio/Program.cs` should be open. If not, open it using the ***Explorer*** option from the Right Sidebar.

1. Using the  the ***Run and Debug*** option, run the program. Select "C# as the run option".

1. Run the app and check the CodeSpaces terminal and the LM Studio logs.


## Advanced chat demo.

*Coming soon!*

## Trouble shooting

1. *Important**: If your codespaces can't access the localhost endpoint, you may get an error similar to this one.

    ![Codespaces can't access localhost error](/images/35Localhostnetworkerror.png "Codespaces can't access localhost error")

    In order to solve this problem, you can use the **[Codespaces Network Bridge]("https://github.com/github/gh-net#codespaces-network-bridge")**. 

    The following command will connect the codespaces with your local machine ports:
    ```bash
    gh net start --your codespace--
    ```

## Author

👤 **Bruno Capuano**

* Website: https://elbruno.com
* Twitter: [@elbruno](https://twitter.com/elbruno)
* Github: [@elbruno](https://github.com/elbruno)
* LinkedIn: [@elbruno](https://linkedin.com/in/elbruno)

## 🤝 Contributing

Contributions, issues and feature requests are welcome!

Feel free to check [issues page](https://github.com/elbruno/sk-phi2-localserver-lmstudio/issues).

## Show your support

Give a ⭐️ if this project helped you!


## 📝 License

Copyright &copy; 2024 [Bruno Capuano](https://github.com/elbruno).

This project is [MIT](/LICENSE) licensed.

***