# 🌐 GameWebRequest

A customized Unity package for efficient handling of web requests in game development.

## ⭐ Features

Simple and intuitive API for HTTP requests
- Support for GET, POST, PUT, DELETE methods
- Async/await pattern support
- Built-in error handling
- Request caching capabilities
- Progress tracking for downloads
- JSON serialization/deserialization helpers

## 📦 Installation

1. Open Unity Package Manager
2. Click the + button in the top-left corner
3. Select "Add package from git URL"
4. Enter: `[https://github.com/tindvor239/GameWebRequest.git]`

## 💻 Basic Usage

```csharp
using GameWebRequest.Unity;

// Example GET request
await Requestor.GetRequest("https://api.example.com/data");

// Example POST request
await Requestor.PostRequest("https://api.example.com/submit", jsonData, new KeyValuePair<string, string>("Content-Type", "application/json"));
```
```csharp
using GameWebRequest.HttpClients;

// Example GET request
await Requestor.GetRequest("https://api.example.com/data");

// Example POST request
await Requestor.PostRequest("https://api.example.com/submit", jsonData, new KeyValuePair<string, string>("Content-Type", "application/json"));
```
