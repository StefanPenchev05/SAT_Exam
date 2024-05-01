# 🚀 SAT Exam Preparation 🚀

Welcome to the **SAT Exam Preparation** repository! This project is designed to help students prepare for the SAT exam by providing them with a customizable study tool. This tool is built using C# for the backend and MySQL for database management.

## 🎯 Getting Started 🎯

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes.

### Prerequisites

What things you need to install the software and how to install them:

- .NET SDK (version specified in global.json)
- MySQL Server (latest stable version)
- Visual Studio or any compatible IDE that supports C#

### Installing

A step-by-step series of examples that tell you how to get a development environment running:

1. Clone the repo:
    ```bash
    git clone https://github.com/your-username/sat-exam-preparation.git
    ```
2. Navigate to the project directory:
    ```bash
    cd sat-exam-preparation
    ```
3. Restore the .NET project (this will install necessary packages):
    ```bash
    dotnet restore
    ```
4. Create a MySQL database and update the connection string in appsettings.json:
    ```json
    "ConnectionStrings": {
      "DefaultConnection": "server=localhost;userid=root;password=yourpassword;database=SATPrepDB;"
    }
    ```
5. Run the application:
    ```bash
    dotnet run
    ```

## 🎓 Using the Application 🎓

Describe how to use the application, including launching the application and any initial setup that might be required.

## 🧪 Running the Tests 🧪

Explain how to run the automated tests for this system:

```bash
dotnet test 
```

## 🛠️ Built With 🛠️

- **C#** - The primary programming language used.
- **.NET Core** - The framework used.
- **MySQL** - Database management system.

## ✍️ Authors ✍️

- **StefanPenchev05** - Initial work - [StefanPenchev05](https://github.com/StefanPenchev05)

## 📜 License 📜

This project is licensed under the MIT License - see the [LICENSE.md](LICENSE.md) file for details

## 🎉 Acknowledgments 🎉

- Hat tip to anyone whose code was used
- Inspiration
- etc