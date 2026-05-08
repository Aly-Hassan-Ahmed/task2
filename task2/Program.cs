using System.ComponentModel;

namespace task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int?[] nums = new int?[100];
            int num;
            char choice;

            while (true) {
                Console.WriteLine("Menu Options:");
                Console.WriteLine("P - Print numbers");
                Console.WriteLine("A - Add a number");
                Console.WriteLine("M - Display mean of the numbers");
                Console.WriteLine("S - Display the smallest number");
                Console.WriteLine("L - Display the largest number");
                Console.WriteLine("F - Find a number in the list");
                Console.WriteLine("C - Clear the list");
                Console.WriteLine("Q - Quit");
                Console.Write("Enter Your Choice: ");
                choice = Convert.ToChar(Console.ReadLine());

                if (choice == 'p' || choice == 'P')
                {
                    if (nums[0] == null) { Console.WriteLine("[] - the list is empty"); continue; }
                    Console.Write("[ ");
                    for (int i = 0; i < nums.Length; i++)
                    {
                        Console.Write(nums[i] + " ");
                        if (nums[i + 1] == null) break;
                    }
                    Console.WriteLine("]");
                }
                else if (choice == 'a' || choice == 'A')
                {
                    Console.Write("Enter An integer to add: ");
                    num = Convert.ToInt32(Console.ReadLine());

                    bool flag = false;
                    
                    for (int i = 0; i < nums.Length && nums[i] != null; i++)
                    {
                        if (num == nums[i])
                        {
                            flag = true;
                            break;
                        }
                    }

                    if (flag)
                    {
                        Console.WriteLine($"{num} is already added");
                        continue;
                    }

                    for (int i = 0; i < nums.Length; i++)
                        if (nums[i] == null) { nums[i] = num; break; }
                    Console.WriteLine($"{num} added");
                }
                else if (choice == 'm' || choice == 'M')
                {
                    if (nums[0] == null) { Console.WriteLine(0); continue; }
                    int sum = 0;
                    int count = 0;

                    for (int i = 0; i < nums.Length && nums[i] != null; i++)
                    {
                        sum += nums[i].Value;
                        count++;
                    }
                    Console.WriteLine($"mean: {sum / count}");
                }
                else if (choice == 's' || choice == 'S')
                {
                    if (nums[0] == null) { Console.WriteLine("[] - the list is empty"); continue; }
                    int small_num = nums[0].Value;
                    for (int i = 1; i < nums.Length; i++)
                        if (small_num > nums[i]) small_num = nums[i].Value;
                    Console.WriteLine($"The Smallest Number is {small_num}");
                }
                else if (choice == 'l' || choice == 'L')
                {
                    if (nums[0] == null) { Console.WriteLine("[] - the list is empty"); continue; }
                    int large_num = nums[0].Value;
                    for (int i = 1; i < nums.Length; i++)
                        if (large_num < nums[i]) large_num = nums[i].Value;
                    Console.WriteLine($"The largest Number is {large_num}");
                }
                else if (choice == 'f' || choice == 'F')
                {
                    if (nums[0] == null) { Console.WriteLine("[] - the list is empty"); continue; }
                    Console.Write("Enter An integer to find: ");
                    num = Convert.ToInt32(Console.ReadLine());
                    bool flag = false;
                    int index = 0;
                    for (int i = 0; i < nums.Length && nums[i] != null; i++)
                    {
                        if (num == nums[i])
                        {
                            index = i;
                            flag = true;
                            break;
                        }
                    }
                    if (flag) Console.WriteLine($"{num} is Found At index {index}");
                    else Console.WriteLine($"{num} is not Found");
                }
                else if (choice == 'c' || choice == 'C')
                {
                    if (nums[0] == null) { Console.WriteLine("[] - the list is empty already"); continue; }
                    Console.Write("Are you Sure to clear: ");
                    char isSure = Convert.ToChar(Console.ReadLine());
                    if (isSure == 'y' || isSure == 'Y')
                    {
                        for (int i = 0; i < nums.Length; i++)
                        {
                            if (nums[i] == null) break;
                            nums[i] = null;
                        }
                        Console.WriteLine("the numbers has been deleted");
                    }
                }
                else if (choice == 'q' || choice == 'Q')
                {
                    Console.WriteLine("Good Bye");
                    break;
                }
                else Console.WriteLine("Unknown selection, please try again!!");
            }
        }
    }
}