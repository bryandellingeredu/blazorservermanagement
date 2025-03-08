using ServerManagement.Components.Pages;

namespace ServerManagement.Models
{
    public class ToDoItemRepository
    {
        private static List<ToDoItem> toDoItems = new List<ToDoItem>()
        {
           new ToDoItem {Id = 1,  Name = "Item 1"},
           new ToDoItem {Id = 2,  Name = "Item 2"},
           new ToDoItem {Id = 3,  Name = "Item 3"},
           new ToDoItem {Id = 4,  Name = "Item 4"},
             
        };

        public static List<ToDoItem> GetItems() =>
            toDoItems.OrderBy(item => item.IsCompleted).ThenByDescending(item => item.Id).ToList();

        public static void AddToDoItem(ToDoItem toDoItem) =>
            toDoItems.Add(toDoItem is not null ?
                (toDoItem.Id = (toDoItems.Any() ? toDoItems.Max(item => item.Id) + 1 : 1), toDoItem).Item2
                : throw new ArgumentNullException(nameof(toDoItem)));

        public static void UpdateToDoItem(ToDoItem toDoItem) =>
            _ = toDoItem is not null && toDoItems.Any(item => item.Id == toDoItem.Id)
            ? toDoItems[toDoItems.FindIndex(item => item.Id == toDoItem.Id)] = toDoItem
            : throw new KeyNotFoundException($"Item with Id {toDoItem?.Id} not found.");

        public static void DeleteToDoItem(int id) =>
        _ = toDoItems.RemoveAll(item => item.Id == id) > 0
        ? Task.CompletedTask
        : throw new KeyNotFoundException($"Item with Id {id} not found.");

    }

}
