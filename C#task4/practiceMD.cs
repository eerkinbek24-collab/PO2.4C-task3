//task1 
int[] numbers = { 3, 7, 2, 9, 5, 1 };
int sum = 0;
foreach (int n in numbers)
{ sum += n; }
Console.WriteLine("Sum = " + sum);


//task2 
int[] temps = { 12, -3, 45, 0, 28, -10, 33 };
int min = temps[0];
int max = temps[0];
foreach (int t in temps)
{ min = Math.Min(min, t);
max = Math.Max(max, t); }

Console.WriteLine("Min = " + min + ", Max = " + max);
int[] sorted = (int[])temps.Clone();

Array.Sort(sorted);
Console.WriteLine("Min = " + sorted[0] + ", Max = " + sorted[sorted.Length - 1]);


//task3
string[] words = { "apple", "banana", "cherry", "date" };

string[] manual = (string[])words.Clone();
for (int i = 0; i < manual.Length / 2; i++)
{ string temp = manual[i];
manual[i] = manual[manual.Length - 1 - i];
manual[manual.Length - 1 - i] = temp; }
Console.WriteLine(string.Join(" ", manual));

string[] reversed = (string[])words.Clone();
Array.Reverse(reversed);
Console.WriteLine(string.Join(" ", reversed));


//task4 
int[] data = { 4, 7, 2, 11, 6, 9, 14, 3, 8 };
int even = 0, odd = 0;

for (int i = 0; i < data.Length; i++)
{ if (data[i] % 2 == 0) even++;
else odd++; }
Console.WriteLine("Even = " + even + ", Odd = " + odd);


//task5
int[] raw = { 1, 3, 2, 3, 5, 1, 4, 2, 5 };
List<int> unique = new List<int>();
foreach (int n in raw)
{ if (!unique.Contains(n))
unique.Add(n); }

Console.WriteLine(string.Join(" ", unique));

List<int> unique2 = new List<int>();
foreach (int n in raw)
{ if (Array.IndexOf(unique2.ToArray(), n) == -1)
unique2.Add(n); }
Console.WriteLine(string.Join(" ", unique2));


//task6
int[] arr = { 1, 2, 3, 4, 5, 6, 7 } ;
int k = 3;
int[] result = RotateLeft(arr, k);
Console.WriteLine(string.Join(" ", result));
static int[] RotateLeft(int[] arr, int k)
{ int n = arr.Length;
k = k % n;
int[] rotated = new int[n];
for (int i = 0; i < n; i++)
{ rotated[i] = arr[(i + k) % n]; }
return rotated; }

