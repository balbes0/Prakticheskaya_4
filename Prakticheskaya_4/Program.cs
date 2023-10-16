using System;

class Program
{
    static List<Note> notes = new List<Note>();
    static int dateindex = 0;

    static void Main(string[] args)
    {
        // Заполняем список заметок
        notes.Add(new Note("Заметка 1", "Сходить в магазин за продуктами", new DateTime(2023, 6, 6)));
        notes.Add(new Note("Заметка 2", "Забрать почту с почтового ящика", new DateTime(2023, 6, 7)));
        notes.Add(new Note("Заметка 3", "Оплатить коммунальные услуги", new DateTime(2023, 6, 8)));
        notes.Add(new Note("Заметка 4", "Зайти в аптеку и купить лекарства", new DateTime(2023, 6, 9)));
        notes.Add(new Note("Заметка 5", "Сделать уборку в доме или квартире", new DateTime(2023, 6, 10)));

        Console.WriteLine("Добро пожаловать в ежедневник!");

        while (true)
        {
            Console.Clear();
            ShowMenu();
            ConsoleKeyInfo key = Console.ReadKey(true);

            switch (key.Key)
            {
                case ConsoleKey.UpArrow:
                    ChangeDate(-1);
                    break;
                case ConsoleKey.DownArrow:
                    ChangeDate(1);
                    break;
                case ConsoleKey.Enter:
                    ViewNoteDetails();
                    break;
            }
        }
    }

    static void ShowMenu()
    {
        Console.WriteLine("Выберите заметку для даты " + notes[dateindex].Date.ToString("dd.MM.yyyy") + ":");
        for (int i = 0; i < notes.Count; i++)
        {
            Console.Write(dateindex == i ? "--> " : "  ");
            Console.WriteLine(notes[i].Title);
        }
    }

    static void ChangeDate(int step)
    {
        dateindex = (dateindex + step + notes.Count) % notes.Count;
    }

    static void ViewNoteDetails()
    {
        Console.Clear();
        Note selectedNote = notes[dateindex];
        Console.WriteLine("Дата: " + selectedNote.Date.ToString("dd.MM.yyyy"));
        Console.WriteLine("Заголовок: " + selectedNote.Title);
        Console.WriteLine("Описание: " + selectedNote.Description);
        Console.WriteLine();
        Console.WriteLine("Нажмите Enter, чтобы вернуться в меню...");
        Console.ReadLine();
    }
}

class Note
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }

    public Note(string title, string description, DateTime date)
    {
        Title = title;
        Description = description;
        Date = date;
    }
}
