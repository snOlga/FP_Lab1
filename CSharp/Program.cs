//------------------------task 8

string numStr = File.ReadAllText("input.txt").Replace("\n", "").Replace("\r", "");

char[] charArr = numStr.ToCharArray();

int productSize = int.Parse(charArr[0] + "");
charArr[0] = '0';

int[] numbers = new int[numStr.Length - 1];

for (int i = 0; i < numbers.Length; i++)
{
    numbers[i] = int.Parse(charArr[i] + "");
}

int maxProduct = 1;
int currentProduct = 1;

for (int i = 0; i < numbers.Length - productSize; i++)
{
    currentProduct = numbers[i..(i + productSize)].Aggregate(1, (a, b) => a * b);
    maxProduct = Math.Max(maxProduct, currentProduct);
}

File.WriteAllText("output1.txt", maxProduct + "");

//------------------------task 21

int maxNumber = 10000;
List<(int num, int amicable)> amicableList = new List<(int, int)>();

for (int i = 1; i <= maxNumber; i++)
{
    int mbAmicable = FindSumDivisorOf(i);
    if (i == FindSumDivisorOf(mbAmicable) && i != mbAmicable)
        amicableList.Add((i, mbAmicable));
}

File.WriteAllText("output2.txt", string.Join("\n", amicableList));




int FindSumDivisorOf(int number)
{
    int sum = 0;
    for (int i = 1; i <= number / 2; i++)
    {
        if (number % i == 0)
            sum += i;
    }
    return sum;
}