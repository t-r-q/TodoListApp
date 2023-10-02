using System.Threading.Tasks;

internal class ToDoList
{
    private List<TaskItem> tasks = new List<TaskItem>();
    private string dataFilePath = "todolistdata.txt";

/**
* AddTask method for add new task
*/
    public void AddTask(TaskItem task)
    {
        tasks.Add(task);
    }

/**
* EditTask method for Edit the task
*/
    public void EditTask(int index, TaskItem updatedTask)
    {
        if (index >= 0 && index < tasks.Count)
        {
            tasks[index] = updatedTask;
        }
    }

/**
* MarkTaskAsDone method for Edit the task's state to done
*/
    public void MarkTaskAsDone(int index)
    {
        if (index >= 0 && index < tasks.Count)
        {
            tasks[index].IsDone = true;
        }
    }

/**
* RemoveTask method for delete task
*/
    public void RemoveTask(int index)
    {
        if (index >= 0 && index < tasks.Count)
        {
            tasks.RemoveAt(index);
        }
    }

/**
* SortByDueDate method for Sort tasks by Due Date
*/
    public void SortByDueDate()
    {
        tasks = tasks.OrderBy(task => task.DueDate).ToList();
    }

/**
* SortByProject method for Sort tasks by Project
*/
    public void SortByProject()
    {
        tasks = tasks.OrderBy(task => task.Project).ToList();
    }

/**
* DisplayTasks method for print aall tasks in the list
*/
    public void DisplayTasks()
    {
        /*
        print += ", Due Date: " + DueDate.ToString().PadRight(10) + ", Project: 
         */
        int num = 1;
        Console.WriteLine("Num".PadRight(4) + " Title".PadRight(10) + "Status".PadRight(10) + "Due Date ".PadRight(15) + "Project");
        foreach (var task in tasks)
        {
            Console.WriteLine(num + ":  " + task);
            num++;
        }
    }

/**
* SaveDataToFile method for Save tasks to the File
*/
    public void SaveDataToFile()
    {
        using (StreamWriter writer = new StreamWriter(dataFilePath))
        {
            foreach (var task in tasks)
            {
                writer.WriteLine($"{task.Title},{task.DueDate},{task.IsDone},{task.Project}");
            }
        }
    }

/**
* LoadDataFromFile method for reaad data from the File
*/
    public void LoadDataFromFile()
    {
        if (File.Exists(dataFilePath))
        {
            tasks.Clear();
            string[] lines = File.ReadAllLines(dataFilePath);
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                if (parts.Length == 4)
                {
                    string title = parts[0];
                    DateTime dueDate = DateTime.Parse(parts[1]);
                    bool isDone = bool.Parse(parts[2]);
                    string project = parts[3];
                    TaskItem task = new TaskItem(title, dueDate, project)
                    {
                        IsDone = isDone
                    };
                    tasks.Add(task);
                }
            }
        }
    }

/**
 *  CountTasks method for return count of all tasks 
 */
    public int CountTasks()
    {
        return tasks.Count;
    }

/**
 *  CountIncompleteTasks method for return count of just incomplete tasks 
 */
    public int CountIncompleteTasks()
    {
        return tasks.Count(task => !task.IsDone);
    }

/**
*  CountCompletedTasks method for return count of just complete tasks 
*/

    public int CountCompletedTasks()
    {
        return tasks.Count(task => task.IsDone);
    }

}