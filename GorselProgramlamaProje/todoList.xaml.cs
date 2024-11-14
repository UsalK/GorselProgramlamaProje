using System.Collections.ObjectModel;

namespace GorselProgramlamaProje;

public partial class todoList : ContentPage
{
    public ObservableCollection<TodoItem> TodoItems { get; set; }

    public todoList()
    {
        InitializeComponent();
        TodoItems = new ObservableCollection<TodoItem>();
        todoListView.ItemsSource = TodoItems;
    }

    private void OnAddButtonClicked(object sender, EventArgs e)
    {
        string todoText = todoEntry.Text?.Trim();
        if (!string.IsNullOrEmpty(todoText))
        {
            TodoItems.Add(new TodoItem { Text = todoText });
            todoEntry.Text = string.Empty; 
        }
    }

    private void OnDeleteButtonClicked(object sender, EventArgs e)
    {
        if (sender is Button button && button.BindingContext is TodoItem todoItem)
        {
            TodoItems.Remove(todoItem);
        }
    }
}

public class TodoItem
{
    public string Text { get; set; }
}
