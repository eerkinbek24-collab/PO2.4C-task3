int[] numbers = { -4, -3, -2, -1, 0, 1, 2, 3, 4 };
int result = 0;
foreach (int number in numbers)
{
    if (number > 0)
    {
        result++;
    }
}
Console.WriteLine($"Число элементов больше нуля: {result}");

int[] numbers1 = { -4, -3, -2, -1, 0, 1, 2, 3, 4 };

int n = numbers1.Length; 
int k = n / 2;          
int temp;               
for (int i = 0; i < k; i++)
{
    temp = numbers1[i];
    numbers1[i] = numbers1[n - i - 1];
    numbers1[n - i - 1] = temp;
}
foreach (int i in numbers)
{
    Console.Write($"{i} \t");
}

int[] nums = { 54, 7, -41, 2, 4, 2, 89, 33, -5, 12 };
int temp1;
for (int i = 0; i < nums.Length - 1; i++)
{
    for (int j = i + 1; j < nums.Length; j++)
    {
        if (nums[i] > nums[j])
        {
            temp1 = nums[i];
            nums[i] = nums[j];
            nums[j] = temp1;
        }
    }
}
Console.WriteLine("Вывод отсортированного массива");
for (int i = 0; i < nums.Length; i++)
{
    Console.WriteLine(nums[i]);
}



for (int i = 0; i < nums.Length - 1; i++)
    for (int j = i + 1; j < nums.Length; j++)
        if (nums[i] > nums[j])
        {
            temp = nums[i];
            nums[i] = nums[j];
            nums[j] = temp;
        }