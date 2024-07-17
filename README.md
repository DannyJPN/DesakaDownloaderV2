# DesakaDownloader

DesakaDownloader is a C# .NET application designed to download and extract product information from various e-commerce websites. The application parses HTML pages to extract product details such as name, price, discount, photos, descriptions, and variants. The extracted data can be saved in multiple formats including JSON, XML, Excel, and CSV. Additionally, the project includes an AI library for data extraction and property repair using OpenAI. The application features a WPF-based user interface for user interaction.

## Overview

DesakaDownloader is structured into several libraries, each responsible for a specific functionality:

- **EntitiesLibrary**: Contains entity definitions for e-shops and products.
- **ParsersLibrary**: Handles HTML parsing for different e-commerce websites.
- **ConvertersLibrary**: Converts extracted data into a standardized format.
- **AILibrary**: Integrates with OpenAI for data extraction and property repair.
- **DataExportLibrary**: Exports data in various formats (JSON, XML, Excel, CSV).
- **DataImportLibrary**: Imports data from various formats (JSON, XML, Excel, CSV).
- **Downloader**: Manages the download and extraction process.
- **UI**: A WPF-based user interface for user interaction.

### Technologies Used

- **C# .NET 8.0 SDK**: For building the application.
- **Visual Studio**: IDE for .NET development.
- **HtmlAgilityPack**: For parsing HTML documents.
- **System.Drawing.Common**: For image handling.
- **Newtonsoft.Json**: For JSON serialization.
- **ClosedXML**: For handling Excel files.
- **CsvHelper**: For handling CSV files.
- **OpenAI**: For integrating with the OpenAI API.

### Project Structure

- **EntitiesLibrary**: Defines e-shop and product entities.
- **ParsersLibrary**: Contains parsers for extracting product information.
- **ConvertersLibrary**: Converts extracted data to a standardized format.
- **AILibrary**: Connects to OpenAI for data extraction and repair.
- **DataExportLibrary**: Exports data to JSON, XML, Excel, and CSV formats.
- **DataImportLibrary**: Imports data from JSON, XML, Excel, and CSV formats.
- **Downloader**: Core logic for managing the download and extraction process.
- **UI**: WPF-based user interface for interacting with the application.

## Features

1. **Multi-Eshop Support**:
   - Supports extracting product information from multiple e-commerce websites.
   - Eshops include Contra.de, Nittaku.com, Pincesobchod.cz, Pincesobchod.sk, Sportspin.cz, Stoten.cz, and Vsenastolnitenis.cz.

2. **Data Extraction**:
   - Extracts product details such as name, price, discount, photos, descriptions, and variants from HTML pages.
   - Utilizes HtmlAgilityPack for HTML parsing.

3. **Data Conversion**:
   - Converts extracted products into a standardized format using various product converters.

4. **AI Integration**:
   - Uses OpenAI for data extraction and property repair.

5. **Data Export**:
   - Saves extracted data in multiple formats including JSON, XML, Excel, and CSV.

6. **Data Import**:
   - Supports importing product data from JSON, XML, Excel, and CSV files.

7. **Asynchronous Programming**:
   - Ensures efficient and responsive data processing using asynchronous methods.

8. **User Interface**:
   - A WPF-based user interface for interacting with the application.

## Getting Started

### Requirements

- **C# .NET 8.0 SDK**
- **Visual Studio**

### Quickstart

1. **Clone the repository**:
   ```sh
   git clone https://github.com/yourusername/DesakaDownloader.git
   cd DesakaDownloader
   ```

2. **Open the solution in Visual Studio**:
   - Open `DesakaDownloader.sln` in Visual Studio.

3. **Restore NuGet packages**:
   - In Visual Studio, go to `Tools` > `NuGet Package Manager` > `Package Manager Console`.
   - Run the following command:
     ```sh
     Update-Package -reinstall
     ```

4. **Build the solution**:
   - In Visual Studio, build the solution by selecting `Build` > `Build Solution`.

5. **Set the startup project**:
   - Right-click on `DesakaDownloader.UI` in the Solution Explorer and select `Set as Startup Project`.

6. **Run the application**:
   - Press `F5` or click on the `Start` button in Visual Studio to run the application.

### License

```
© 2024 DesakaDownloader. All rights reserved.
```