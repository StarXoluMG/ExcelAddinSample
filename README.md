# Excel Add-in: News Headlines

This Excel add-in lets you see the popular news articles of the day for a specific country. It uses the open-source library ExcelDNA: [https://excel-dna.net/](https://excel-dna.net/)

## Table of Contents

* [Functionality](#functionality)
* [Prerequisites](#prerequisites)
* [Installation](#installation)
* [Testing Sample](#testing-sample)
* [License](#license) 

## Functionality

Connect to the open-source API, [https://newsapi.org/](https://newsapi.org/). Due to licensing, the API key is withheld, but they offer a free one for development purposes.

This add-in provides two Excel functions:

* **`extGetPopularArticlesByNameAndDate(name, date)`:** Retrieves popular articles for a given source (e.g., "BBC News") and date (YYYY-MM-DD). Returns a table with columns for title, url and date of publication.
* **`extgetHeadlines(country)`:** Retrieves top headlines for a specified country code (e.g., "us" for United States). Returns a table with columns for title, url and date of publication.

## Prerequisites

* Microsoft Excel 2016 or later
* .NET Framework 4.5 or later
* Visual Studio (recommended IDE)

## Installation

1. Get an API key from [https://newsapi.org/](https://newsapi.org/) and add it to the `App.config` file.

## Testing Sample

The documentation folder contains:

* A sample Excel sheet demonstrating the add-in's functionality.
* Examples of error handling.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
