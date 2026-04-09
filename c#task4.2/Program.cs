//task7
Console.WriteLine(IsPalindrome("madam"));   // t
Console.WriteLine(IsPalindrome("hello"));   // f
Console.WriteLine(IsPalindrome("racecar")); // t

static bool IsPalindrome(string s)
{
    int left = 0, right = s.Length - 1;
    while (left < right)
    {
        if (s[left] != s[right]) return false;
        left++; right--;
    }
    return true;
}

//task8
Console.WriteLine(Factorial(5)); // 120
Console.WriteLine(Factorial(7)); // 5040
Console.WriteLine(Factorial(0)); // 1

static long Factorial(int n)
{
    long result = 1;
    for (int i = 2; i <= n; i++)
        result *= i;
    return result;
}

//task9
for (int i = 1; i <= 20; i++)
    Console.WriteLine(FizzBuzz(i));

static string FizzBuzz(int n)
{
    if (n % 15 == 0) return "FizzBuzz";
    if (n % 3 == 0) return "Fizz";
    if (n % 5 == 0) return "Buzz";
    return n.ToString();
}

//task10
double[] celsius = { 0, 20, 37, 100, -40 };
foreach (double c in celsius)
{
    double f = ToFahrenheit(c);
    Console.WriteLine(c + "°C = " + f + "°F");
}

static double ToFahrenheit(double c)
{ return c * 9.0 / 5 + 32; }
static double ToCelsius(double f)
{ return (f - 32) * 5.0 / 9; }