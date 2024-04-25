public class TaskRepository : ITaskRepository
{
    private readonly TaskTrackerContext _context;

    public TaskRepository(TaskTrackerContext context)
    {
        _context = context;
    }

    public void AddTask(TrackerTask task)
    {
        _context.TrackerTasks.Add(task);
        _context.SaveChanges();

        AccountManager.Logger("task added");
    }

    public void Complete(int id)
    { 
        var task = _context.TrackerTasks.Where(t => t.ID == id).FirstOrDefault();
        task.IsComplete = true;
        _context.SaveChanges();

        AccountManager.Logger("task status - 'Completed'");
    }

    public void DeleteTask(int taskid)
    {   
        _context.TrackerTasks.Where(t => t.ID == taskid).ToList().ForEach(t => _context.TrackerTasks.Remove(t));
        _context.SaveChanges(); 

        AccountManager.Logger("task deleted");
    }

    public List<TrackerTask> GetAllTasks()
    {
        AccountManager.Logger("tasks shown");
        return _context.TrackerTasks.ToList();
    }

    public TrackerTask GetTaskById(int taskId)
    {
        AccountManager.Logger("task shown");
        return _context.TrackerTasks.FirstOrDefault(t => t.ID == taskId);
    }
}