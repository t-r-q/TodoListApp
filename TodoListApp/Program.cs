


using System.Threading.Tasks;

ToDoList toDoList = new ToDoList();
toDoList.LoadDataFromFile();

bool isRunning = true;

// Start project with Show Menu in loop to User
while (isRunning)
{
    Console.WriteLine("*** Welcome to ToDoList App ***");
    Console.Write($"You have ");
    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.Write($"{toDoList.CountIncompleteTasks()}");
    Console.ResetColor();
    Console.Write(" tasks to do and ");
    Console.ForegroundColor = ConsoleColor.Blue;
    Console.Write($"{toDoList.CountCompletedTasks()}");
    Console.ResetColor();
    Console.WriteLine(" tasks are done!");
   // Console.WriteLine($"You have {toDoList.CountIncompleteTasks()} tasks to do and {toDoList.CountCompletedTasks()} tasks are done!");
    Console.ResetColor();
    Console.WriteLine("Pick a number option between (1-4):");
    Console.WriteLine("1_ Show Task List (by date or project)");
    Console.WriteLine("2_ Add New Task");
    Console.WriteLine("3_ Edit Task (update, mark as done, remove)");
    Console.WriteLine("4_ Save and Exit");
    Console.WriteLine("-------------------------------------------");
    Console.Write("Enter your choice: ");
    string choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            {
             // Implement to show task list
             ShowTasksList();
             break;
            }
        case "2":
            // Implement logic to add a new task
            GreateNewTask();
            break;
        case "3":
            // Implement logic to edit, mark as done, or remove a task
            EditTask();
            break;
        case "4":
            toDoList.SaveDataToFile();
            isRunning = false;
            break;
        default:
            printToUser("Invalid choice. Please try again.", "red");
            break;
    }
}




void EditTask()
{
    toDoList.DisplayTasks();
    printToUser("Enter the index of the task you want to edit:", "yellow");
 
    if (int.TryParse(Console.ReadLine(), out int editIndex) && editIndex >= 1 && editIndex < toDoList.CountTasks())
    {
        editIndex = editIndex - 1;
        Console.WriteLine("  Choose a number option:");
        Console.WriteLine("1_ Update Task");
        Console.WriteLine("2_ Mark as Done");
        Console.WriteLine("3_ Remove Task");
        Console.Write("Enter your choice: ");
        string editChoice = Console.ReadLine();

        switch (editChoice)
        {
            case "1":
                Console.Write("Enter new task title: ");
                string newTitle = Console.ReadLine();

                // Prompt the user for a new due date (you can add validation here)
                Console.Write("Enter new due date (yyyy-MM-dd): ");
                if (DateTime.TryParse(Console.ReadLine(), out DateTime newDueDate))
                {
                    Console.Write("Enter new project: ");
                    string newProject = Console.ReadLine();

                    TaskItem updatedTask = new TaskItem(newTitle, newDueDate, newProject);
                    toDoList.EditTask(editIndex, updatedTask);

                    printToUser("Task updated successfully.", "green");
                    Console.WriteLine("");
                }
                else
                {
                    printToUser("Invalid due date format. Task not updated.", "red");
                }
                break;

            case "2":
                toDoList.MarkTaskAsDone(editIndex);
                printToUser("Task marked as done.", "green");
                Console.WriteLine("");
                break;

            case "3":
                toDoList.RemoveTask(editIndex);
                printToUser("Task removed.", "green");
                break;

            default:
                printToUser("Invalid sub-choice. Task not updated/removed.", "red");
                break;
        }
    }
    else
    {
        printToUser("Invalid task index. Task not found.", "red");
    }
}

void GreateNewTask()
{
    Console.Write("Enter task title: ");
    string title = Console.ReadLine();

    // Prompt the user for due date 
    Console.Write("Enter due date (yyyy-MM-dd): ");
    if (DateTime.TryParse(Console.ReadLine(), out DateTime dueDate))
    {
        Console.Write("Enter project: ");
        string project = Console.ReadLine();

        TaskItem newTask = new TaskItem(title, dueDate, project);
        toDoList.AddTask(newTask);

        printToUser("Task added successfully.", "green");
    }
    else
    {
        printToUser("Invalid due date format. Task not added.", "red");
    }

}

void ShowTasksList()
{
    bool isShow = true;
    while (isShow)
    {
        Console.Write("1_ Show Task List by ");
        printToUser("Date.", "cy");
        Console.Write("2_ Show Task List by ");
        printToUser("Project.", "mg");
        Console.WriteLine("3_ Return to main page");
        Console.Write("Enter your choice(1,2,3): ");
        string choiceSort = Console.ReadLine();
        if (choiceSort == "1")
        {
            SortByDate();
        }
        else if (choiceSort == "2")
        {
            SortByProjectName();
        }
        else if (choiceSort == "3")
        {
            isShow = false;
        }
        else
            printToUser("Invalid choice. Please try again (1 ,2 , 3).", "red");

    }
}

void SortByProjectName()
{
    toDoList.SortByProject();
    toDoList.DisplayTasks();
    Console.WriteLine("");
}

void SortByDate()
{
    toDoList.SortByDueDate();
    toDoList.DisplayTasks();
    Console.WriteLine("");
}

void printToUser(string txt, string color)
{
    if (!string.IsNullOrEmpty(txt) && color == "red") {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(txt);
        Console.WriteLine("      (X ..... X) ");
        Console.ResetColor();

    } else if (!string.IsNullOrEmpty(txt) && color == "green") {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(txt);
        Console.ResetColor();
    }
    else if (!string.IsNullOrEmpty(txt) && color == "yellow")  {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(txt);
        Console.ResetColor();
    }
    else if (!string.IsNullOrEmpty(txt) && color == "cy")
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(txt);
        Console.ResetColor();
    }
    else if (!string.IsNullOrEmpty(txt) && color == "mg")
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine(txt);
        Console.ResetColor();
    }
    else {
        Console.WriteLine(txt);
    }   
}