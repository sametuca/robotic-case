namespace NasaRoboticCase
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Sağ üst köşe koordinatlarını girin (örn. '5 5'): ");
            string[] upperRightInput = Console.ReadLine().Split();
            int upperRightX = int.Parse(upperRightInput[0]);
            int upperRightY = int.Parse(upperRightInput[1]);

            int lowerLeftX = 0;
            int lowerLeftY = 0;

            Console.Write("İlk robotun başlangıç koordinatlarını ve yönünü girin (örn. '1 2 N'): ");
            string[] initialPosition1 = Console.ReadLine().Split();
            int x1 = int.Parse(initialPosition1[0]);
            int y1 = int.Parse(initialPosition1[1]);
            char direction1 = char.Parse(initialPosition1[2]);

            Console.Write("İkinci robotun başlangıç koordinatlarını ve yönünü girin (örn. '3 3 E'): ");
            string[] initialPosition2 = Console.ReadLine().Split();
            int x2 = int.Parse(initialPosition2[0]);
            int y2 = int.Parse(initialPosition2[1]);
            char direction2 = char.Parse(initialPosition2[2]);

            Console.Write("İlk robot için hareket komutlarını girin (örn. 'LMLMLMLMM'): ");
            string commands1 = Console.ReadLine();

            Console.Write("İkinci robot için hareket komutlarını girin (örn. 'MMRMMRMRRM'): ");
            string commands2 = Console.ReadLine();

            // İlk robotun son konumunu hesaplayalım
            var result1 = MoveRover(x1, y1, direction1, commands1);
            // İkinci robotun son konumunu hesaplayalım
            var result2 = MoveRover(x2, y2, direction2, commands2);

            // Son konumları ekrana bastıralım
            Console.WriteLine($"İlk robotun son konumu: {result1.Item1} {result1.Item2} {result1.Item3}");
            Console.WriteLine($"İkinci robotun son konumu: {result2.Item1} {result2.Item2} {result2.Item3}");
        }
        static (int, int, char) MoveRover(int x, int y, char direction, string commands)
        {
            // Yönleri tanımlayalım
            char[] directions = { 'N', 'E', 'S', 'W' };
            // İleri hareketler için koordinat değişimleri
            int[] dx = { 0, 1, 0, -1 };
            int[] dy = { 1, 0, -1, 0 };

            // Başlangıç yönünü indeksleme ile bulalım
            int currentDirectionIndex = Array.IndexOf(directions, direction);

            foreach (char command in commands)
            {
                if (command == 'L')
                {
                    // Sola dön
                    currentDirectionIndex = (currentDirectionIndex - 1 + 4) % 4;
                }
                else if (command == 'R')
                {
                    // Sağa dön
                    currentDirectionIndex = (currentDirectionIndex + 1) % 4;
                }
                else if (command == 'M')
                {
                    // İleri git
                    x += dx[currentDirectionIndex];
                    y += dy[currentDirectionIndex];
                }
            }

            return (x, y, directions[currentDirectionIndex]);
        }
    }
}