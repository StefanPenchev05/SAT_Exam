# Implement a Simple Contact List Using HashSet<T>

This C# console application provides a straightforward approach to managing a unique list of contacts. By utilizing a `HashSet<T>`, we ensure that each contact, represented as a string (name), remains unique within our list. The application supports multiple operations, making it a perfect project to familiarize yourself with `HashSet<T>` and basic console I/O operations.

## Features Overview

Below are the main features supported by the Contact List application:

### 📌 Add a Contact
- **Functionality:** Allows the user to add a new contact to the list.
- **Unique Constraint:** If the contact already exists, the application will inform the user and refrain from adding a duplicate.

### 🗑️ Remove a Contact
- **Functionality:** Users can remove an existing contact.
- **Validation:** If the contact doesn't exist, the application notifies the user.

### 🔍 Check if a Contact Exists
- **Functionality:** Quickly check the existence of a contact in the list.

### 📄 Display All Contacts
- **Functionality:** View all the contacts stored in the list.
- **Display Note:** Contacts appear in an unpredictable order due to the nature of `HashSet<T>`.

## User Interaction
The application runs continuously, processing user inputs through a simple command-line interface until the user opts to exit. This looping design ensures a dynamic and interactive user experience.

## Development Notes
- **HashSet Benefits:** Utilizes the built-in uniqueness property of `HashSet<T>` which means no manual duplicate checks are needed.
- **Ordering:** Remember, `HashSet<T>` does not maintain the order of elements.

## Bonus Features
To enhance your learning and the application's functionality, consider adding these advanced features:
- **Union:** Combine two lists to see all unique contacts.
- **Intersection:** Identify common contacts between two lists.
- **Difference:** Determine which contacts are unique to one list.

## Getting Started
- Clone the repository, navigate to the project folder, and compile the application.
- Run the application from your command line and follow the on-screen prompts.

This project is an excellent starter for anyone looking to dive deeper into C# collection handling, specifically `HashSet<T>`, and for those developing command-line interface applications. It also provides a practical context for understanding set operations and managing user inputs effectively.
