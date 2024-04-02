using task_2;
class Program
{
    static void Main(string[] args)
    {
        SoundRecording soundRecording = new SoundRecording();

        
        soundRecording.AddComposition(new MusicComposition("Smells Like Teen Spirit", "Nirvana", 301, "Rock"));
        soundRecording.AddComposition(new MusicComposition("Nothing Else Matters", "Metallica", 389, "Rock"));
        soundRecording.AddComposition(new MusicComposition("Baby One More Time", "Britney Spears", 211, "Pop"));
        soundRecording.AddComposition(new MusicComposition("Murder In My Mind", "Kordhell", 145, "Phonk"));
        soundRecording.AddComposition(new MusicComposition("WannaBe", "Spice Girls", 175, "Pop"));
        soundRecording.AddComposition(new MusicComposition("Highway to Hell", "AC/DC", 208, "Rock"));
        

        soundRecording.Display();
        TimeSpan totalDuration = soundRecording.CalculateTotalLength();
        Console.WriteLine($"\nЗагальна тривалість колекції: {totalDuration}");
        soundRecording.SortByGenre();
        soundRecording.DisplaySorted();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\nВведіть діапазон тривалості треків у секундах (мінімальне значення, потім пробіл, максимальне значення):");
        Console.ResetColor();
        string[] input = Console.ReadLine().Split(' ');
        if (input.Length != 2 || !int.TryParse(input[0], out int minDuration) || !int.TryParse(input[1], out int maxDuration))
        {
            Console.WriteLine("Некоректний ввід.");
            return;
        }

        TimeSpan minTimeSpan = TimeSpan.FromSeconds(minDuration);
        TimeSpan maxTimeSpan = TimeSpan.FromSeconds(maxDuration);
        List<MusicComposition> matchingCompositions = soundRecording.FindByLengthRange(minTimeSpan, maxTimeSpan);

        if (matchingCompositions.Count > 0)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"\nКомпозиції у вказаному діапазоні тривалості ({minTimeSpan.TotalSeconds} - {maxTimeSpan.TotalSeconds} секунд):");
            Console.ResetColor();
            foreach (var composition in matchingCompositions)
            {
                Console.WriteLine($"Назва: {composition.Title}, Виконавець: {composition.Artist}, Тривалість: {composition.GetLength()}");
            }
        }
        else
        {
            Console.WriteLine("Немає композицій, які відповідають вказаному діапазону тривалості.");
        }
        
        Console.ReadKey();
    }

}
