# Quiz-Backend

## Overview
Quiz-Backend is a RESTful API designed to manage quizzes, user sessions, and quiz history. It supports operations such as starting a quiz, validating answers, tracking user history, and providing quiz statistics.

---

## Features

### 1. Start Quiz
- **Flow**:
  - When the user clicks "Start" on the main screen, the front-end performs two API calls:
    1. `GET /api/quizzes`: Fetches 10 (or a pre-determined number of) random questions from the database.
    2. `POST /api/reset-user-status`: Resets the user's previous quiz history and sets the start time for the quiz exam.

### 2. Answer Validation
- **Flow**:
  - After the user selects an answer for a quiz question, the front-end calls:
    - `GET /api/quizzes/{quizId}/validate?selectedAnswersId={id}`
  - This API validates the selected answer, provides feedback, and saves the user's history to the database.

### 3. Complete Quiz
- **Flow**:
  - When the user clicks the "Finish" button:
    1. The front-end calls `POST /api/quizzes/complete` to set the end time of the quiz exam.
    2. Then, it calls `GET /api/quizzes/statistic` to retrieve statistics for the completed quiz.

### 4. View History
- **Flow**:
  - If the user wants to view their quiz history, they can click "View Answer" on the front-end.
  - The front-end calls `GET /api/quizzes/history` to fetch the quizzes the user has just completed.

---

## User History Management
- **Approach**:
  - The `UserInSession` database table is used to save the device ID. This allows tracking of user activity across devices.
  - To prevent redundancy, user IDs can be periodically removed based on the `LastActiveTime` field.
  - This approach ensures accurate tracking of questions answered by the user and provides reliable statistics.

---

## Opinion on Front-End vs Back-End Handling
- **Handling User History**:
  - The `UserInSession` table is effective for distinguishing between devices and tracking user activity.
- **Handling Quiz Details**:
  - For requirements like detailed time tracking, correct/incorrect answers, and other specifics, it may be more efficient to handle these on the front-end.
  - The front-end can process these details and send the results to the back-end for storage or further processing.
  - Alternatively, the front-end can handle these details entirely and only retrieve results from the back-end when needed.

---

## Technologies Used
- **Framework**: ASP.NET Core
- **Database**: SQL Server
- **ORM**: Entity Framework Core
- **Containerization**: Docker

---

## How to Run
1. Clone the repository.
2. Ensure Docker is installed and running.
3. Use the following command to start the application:
   ```bash
   docker-compose up -d
   ```
4. Access the API documentation at `http://localhost:8080/swagger`.

---

## Test API in Browser
You can test the API in the browser using the following link:

[http://vps-d3de1bea.vps.ovh.ca:8080/](http://vps-d3de1bea.vps.ovh.ca:8080/)

---

## Note on Testing
When testing the API, it is recommended to use tools like Postman or any other API testing tool that can save cookies. This is because when you start the test, the cookie will be saved in the browser, and subsequent requests may rely on it.

---

## API Endpoints

### Quiz Management
- `GET /api/quizzes`: Fetch random quiz questions.
- `POST /api/reset-user-status`: Reset user history and set start time.
- `GET /api/quizzes/{quizId}/validate?selectedAnswersId={id}`: Validate a selected answer.
- `POST /api/quizzes/complete`: Mark the quiz as completed.
- `GET /api/quizzes/statistic`: Retrieve quiz statistics.
- `GET /api/quizzes/history`: Fetch the user's quiz history.

---

## Future Improvements
- Implement periodic cleanup of `UserInSession` data to optimize storage.
- Enhance API security to prevent unauthorized access.
- Add support for more detailed quiz analytics.