using System;

namespace Exceptions
{
    internal class Program
    {
        private static bool IsValidINNFormat(long inn)
        {
            var lastDegree = inn % 10;
            int[] weights = new int[] { 2, 4, 10, 3, 5, 9, 4, 6, 8, 0 };
            long key = 0;

            for (int i = weights.Length - 1; i >= 0; i--) 
            {
                key += weights[i] * (inn % 10);
                inn /= 10;
            }

            var ks = key % 11;

            return ks < 10 ? ks == lastDegree : ks % 10 == lastDegree;
        }

        static void Main(string[] args)
        {           

            try
            {
                try
                {
                    Console.Write("Введите ИНН для организаций: ");
                    string INN = Console.ReadLine();
                    long innNumber = Int64.Parse(INN);
                
                    if (!IsValidINNFormat(innNumber)) throw new FormatException("Не пройдена проверка контрольной суммы");
                }

                catch (OverflowException)
                {
                    throw new OverflowException("ИНН для организаций не может хранить более 10 цифр");
                }

                catch (Exception)
                {
                    throw;
                }

                Console.WriteLine("Все ок!");
            }
            catch (Exception ex) 
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
    }
}
