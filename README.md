# DiSUcord Messaging Application (SU Version of Discord)

> **10/2023 – 12/2023**

A lightweight client–server chat system built in C#, inspired by Discord, designed for real-time messaging, channel subscriptions, and multicasting over TCP.

---

## 📋 Table of Contents

1. [Project Overview](#project-overview)
2. [Team Members](#team-members)
3. [Features](#features)
4. [Architecture & Tech Stack](#architecture--tech-stack)
5. [Getting Started](#getting-started)

   * [Prerequisites](#prerequisites)
   * [Installation](#installation)
   * [Usage](#usage)
6. [Project Structure](#project-structure)
7. [License](#license)

---

## 🔍 Project Overview

* **Objective:** Build a two-person client–server messaging application with real-time text communication.
* **Duration:** October – December 2023
* **Key Goals:**

  * Reliable TCP-based message delivery
  * Support for multiple channels and multicast groups
  * Simple, responsive desktop UI

---

## 👥 Team Members

* **Furkan Emre Güler**
* **Halil İbrahim Umut Çolak**

---

## ✨ Features

* **Real-Time Messaging:** Bi-directional text transfer between clients and server.
* **Channel Subscription:** Clients can join or leave named channels dynamically.
* **Multicasting:** Efficient broadcast of messages to all subscribers in a channel.
* **Desktop UI:**

  * Client and server interfaces built in C# (Windows Forms/WPF).
  * User-friendly channel list, message view, and input field.

---

## 🏗 Architecture & Tech Stack

* **Transport:** TCP sockets (System.Net.Sockets)
* **Language:** C# (.NET Framework 4.7.2)
* **UI Framework:** Windows Forms (or WPF)
* **Concurrency:** `async/await` + thread-safe collections for client handling

---

## 🚀 Getting Started

### Prerequisites

* Windows 10 or later
* Visual Studio 2019 (or newer) with .NET desktop workload

### Installation

1. **Clone the repository**

   ```bash
   git clone https://github.com/furkanemreguler/DiSUcord-Messaging-Application.git
   cd DiSUcord-Messaging-Application
   ```

2. **Open the solution**

   * Double-click `DiSUcord.sln` in Visual Studio.

3. **Restore NuGet packages**

   * In Solution Explorer: **Right-click** solution → **Restore NuGet Packages**.

### Usage

1. **Run the Server**

   * Set the Server project as the startup project and press **F5**.
   * Configure listening port if needed in `ServerApp.config`.

2. **Run the Client(s)**

   * Launch one or more instances of the Client application.
   * Enter server IP/port, choose or create a channel, and start chatting.

---

## 📂 Project Structure

```
DiSUcord-Messaging-Application/
├── Server/
│   ├── Program.cs
│   ├── ServerCore.cs
│   └── ServerUI/         # Windows Forms project
├── Client/
│   ├── Program.cs
│   ├── ClientCore.cs
│   └── ClientUI/         # Windows Forms project
├── docs/                 # Design diagrams, protocol specs
├── LICENSE
└── README.md
```

---

## 📜 License

This project is released under the MIT License. See [LICENSE](LICENSE) for details.
