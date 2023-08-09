/* на вход натур число
на выход все нечетные спереди четные позади, очередность сохраняется
12345 -> 13524
3658563 -> 3553686
48 -> 48
5497 -> 5974
 */
int InputNum(string message)
{
    System.Console.Write(message);
    return int.Parse(Console.ReadLine()!);
}
int ExpTen(int n) // возвращает 10 в степени n
{
    if (n == 0)
    {
        return 1;
    }
    int i = 1;
    int b = 10;
    while (i < n)
    {
        b *= 10;
        i++;
    }
    return b;
}
int DigitCount(int num) // возвращает количество цифр в числе
{
    int count = 1;
    while (num / 10 > 0)
    {
        num = num / 10;
        count++;
    }
    return count;
}
int NewNumber(int number, int countDigit) // перебирает цифры в числе меняет их местами
{
    int n = number;
    int count = countDigit;
    int i = countDigit;
    int tmp;
    int res = 0;
    while (count > 0) // перебираем цифры числа слева направо и записывем только нечетные
    {
        tmp = n / ExpTen(count - 1); 
        if (tmp % 2 != 0) // если число нечетное
        {
            res = res + tmp * ExpTen(i - 1); // записываем его слева
            i--; // уменьшаем разряд для следующей цифры
        }
        n = n % ExpTen(count - 1);
        count--;
    }
    n = number;
    count = countDigit;
    while (count > 0) // перебираем цифры числа слева направо и продолжаем записывать только четные
    {
        tmp = n / ExpTen(count - 1);
        if (tmp % 2 == 0) // если число четное
        {
            res = res + tmp * ExpTen(i - 1); // записываем его после нечетных
            i--; // уменьшаем разряд для следующей цифры
        }
        n = n % ExpTen(count - 1);
        count--;
    }
    return res;
}
int num = InputNum("Введи натуральное число: ");
int countDigit = DigitCount(num);
System.Console.WriteLine($"Результат {NewNumber(num, countDigit)}");
