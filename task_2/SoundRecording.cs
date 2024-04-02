using System;
namespace task_2
{
    class SoundRecording
    {
        private List<MusicComposition> compositions;

        public SoundRecording()
        {
            compositions = new List<MusicComposition>();
        }

        public void AddComposition(MusicComposition composition)
        {
            compositions.Add(composition);
        }

        public TimeSpan CalculateTotalLength()
        {
            TimeSpan totalDuration = TimeSpan.Zero;
            foreach (var composition in compositions)
            {
                totalDuration += composition.GetLength();
            }
            return totalDuration;
        }
        public void SortByGenre()
        {
            compositions = compositions.OrderBy(c => c.Genre).ToList();
        }

        public void Display()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Список композицій на диск:");
            Console.ResetColor();
            foreach (var composition in compositions)
            {
                Console.WriteLine($"Назва: {composition.Title}, Виконавець: {composition.Artist}, Жанр: {composition.Genre}, Тривалість: {composition.GetLength()}");
            }
        }
        public void DisplaySorted()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nСписок після перестановки композицій диска на основі приналежності до стилю:");
            Console.ResetColor();

            foreach (var composition in compositions)
            {

                Console.WriteLine($"Назва: {composition.Title}, Виконавець: {composition.Artist}, Жанр: {composition.Genre}, Тривалість: {composition.GetLength()}");
            }
        }
        public List<MusicComposition> FindByLengthRange(TimeSpan minLength, TimeSpan maxLength)
        {
            List<MusicComposition> selectCompositions = new List<MusicComposition>();

            foreach (var composition in compositions)
            {
                TimeSpan length= composition.GetLength();
                if (length >= minLength && length <= maxLength)
                {
                    selectCompositions.Add(composition);
                }
            }

            return selectCompositions;
        }

    }
}

