internal class TaskItem
{
    public string Title { get; set; }
    public DateTime DueDate { get; set; }
    public bool IsDone { get; set; }
    public string Project { get; set; }

    public TaskItem(string title, DateTime dueDate, string project)
    {
        Title = title;
        DueDate = dueDate;
        IsDone = false;
        Project = project;
    }

    public override string ToString()
    {
        //  string print = "Title: " + Title.PadRight(8);
        //  print += $", Status: {(IsDone ? "Done" : "Not Done")}".PadRight(10);
        //  print += ", Due Date: " + DueDate.ToString().PadRight(10) + ", Project: " +  Project.PadRight(15);  
        string print = Title.PadRight(10);
        print += $"{(IsDone ? "Done" : "Not Done")}".PadRight(10);
        print += DueDate.ToString("yyyy-MM-dd").PadRight(15) + Project.PadRight(15);

        return print;
    }


}