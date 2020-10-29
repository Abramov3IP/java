import java.util.Scanner;

class zad1
{
	public static void main(String[] args)
	{
		Scanner in = new Scanner(System.in);
		int year, month;
		year = month = 0;
		System.out.println("Enter the year:");
		year = in.nextInt();
		while(year < 0)
		{
			System.out.println("Year cannot be negative!");
			year = in.nextInt();
		}
		System.out.println("Enter the month:");
		month = in.nextInt();
		while(month <= 0 || month > 12)
		{
			System.out.println("The month cannot be negative or greater than 12!");
			month = in.nextInt();
		}
		if(month <= 6)
		{
			System.out.println("You entered the first half of the year.");
		}
		else
		{
			System.out.println("You have entered the second half of the year.");
		}
		if(month >= 1 && month <= 3)
		{
			System.out.println("You entered the first quarter.");
		}
		else if(month >= 4 && month <= 6)
		{
			System.out.println("You entered the second quarter.");
		}
		else if(month >= 7 && month <= 9)
		{
			System.out.println("You entered the third quarter.");
		}
		else
		{
			System.out.println("You entered the fourth quarter.");
		}
		if(month == 12 || month == 1 || month == 2)
		{
			System.out.println("The month you entered enters winter.");
		}
		else if(month >= 3 && month <= 5)
		{
			System.out.println("The month you entered enters the spring.");
		}
		else if(month >= 6 && month <= 8)
		{
			System.out.println("The month you entered is included in the summer.");
		}
		else if(month >= 9 && month <= 11)
		{
			System.out.println("The month you entered is included in autumn.");
		}
		int year2 = year;
		if(year2 >= 1000)
		{
			int i;
			for(i = 0; year2 >= 1000; i++)
			{
				year2 -= 1000;
			}
			System.out.println("You entered " + i + " millennium.");
		}
		else
		{
			System.out.println("You entered 0 millennia.");
		}
		if(year2 >= 100)
		{
			int i;
			for(i = 0; year2 >= 100; i++)
			{
				year2 -= 100;
			}
			System.out.println("You entered " + i + " centuries.");
		}
		else
		{
			System.out.println("You entered 0 centuries.");
		}
		int i = year % 4;
		if(i == 0)
		{
			i = year % 100;
			if(i == 0)
			{
				i = year % 400;
				if(i == 0)
				{
					System.out.println("You entered a leap year");
				}
				else
				{
					System.out.println("You entered a non-leap year");
				}
			}
			else
			{
				System.out.println("You entered a non-leap year");
			}
		}
		else
		{
			System.out.println("You entered a non-leap year");
		}
	}
}

class zad2
{
	public static void main(String[] args)
	{
		Scanner in = new Scanner(System.in);
		double a, b, N, eq;
		System.out.println("Enter a natural number for N:");
		N = in.nextInt();
		a = 2;
		b = 1;
		eq = 0;
		if(N <= 0)
		{
			System.out.println("N cannot be less than zero!");
			N = in.nextInt();
		}
		for(int i = 1; i <= N; i++)
		{
			eq += a / b;
			a += 1;
			b += 1;
		}
		eq += (N + 1) / N;
		System.out.println("Result: " + eq);
	}
}

class zad3
{
	public static void main(String[] args)
	{
		Scanner in = new Scanner(System.in);
		int a = 0;
		int b = 0;
		int c = -1;
		int x, y;
		x = y = 0;
		System.out.println("Enter arr nums:");
		a = in.nextInt();
		int[] arr = new int[a];
		System.out.println("Zapolnenie:");
		for(int i = 0; i < a; i++)
		{
			arr[i] = in.nextInt();
		}
		for(int i = 0; i < a; i++)
		{
			if(arr[i] < 0)
			{
				while(arr[b] < 0)
				{
					b++;
				}
				if(arr[b] > 0)
				{
					c += 1;
					x = arr[i];
					y = arr[b];
					arr[i] = y;
					arr[b] = x;
				}
			}
		}
		System.out.println("---------------------------");
		for(int i = 0; i < a; i++)
		{
			System.out.println(arr[i]);
		}
	}
}
