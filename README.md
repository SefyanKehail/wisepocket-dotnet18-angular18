# WisePocket Expense Tracker

An expense tracking application built with **Angular 18** (frontend) and **.NET 8** (backend). This app allows users to track their expenses, set monthly budget limits, and get alerts when they exceed their budget.

---

## 🚀 Features

1. **Expense Management**  
   - View, create, and delete expenses and categories.
   
2. **Monthly Budget Tracking**  
   - Set a monthly budget limit.
   - View current spendings with a progress bar visualization.
   - Receive toast alerts when spending exceeds the budget.

3. **Monthly Budget Analytics**  
   - Track budget limits for each month.
   - Check current and historical spending data.

---

## 🛠 Setup Instructions

### Backend (ASP.NET 8)

1. **Clone the repository and navigate to the backend folder**.  
2. **Set up the database**:  
   - Create a database named `wisepocket-db`.
   - Make sure you're in the backend/api directory.
   - Run the migration commands to set up the database schema:  
     ```bash
     dotnet ef database update
     ```

3. **Run the backend**:  
   Expose the backend:  
   ```bash
   dotnet watch run
   ```
### Frontend (Angular 18)

1. **Navigate to the frontend folder.**

2. **Install the dependencies:**

   ```bash
   npm install
   ```
3. **Start the Angular development server:**

     ```bash
     ng serve
     ```
4. **Open your browser and navigate to:**

     ```bash
     http://localhost:4200
     ```
## ⚙️ Technical Details

### Backend Architecture
- **Repository Pattern**: Used to abstract data access logic for better maintainability.
- **Service Layer**: Contains business logic and uses Data Transfer Objects (DTOs) to communicate with controllers.

### Frontend Architecture
- **State Management**:
  - Utilized `BehaviorSubject` to manage budget limit overflow state.
- **Data Handling**:
  - Used `Observables` for fetching data and handling asynchronous operations.
  - Relied on DTOs for communication with the backend.

## 📊 Future Improvements
- Use a benchmarking tool to evaluate the performance of backend methods with larger datasets.

