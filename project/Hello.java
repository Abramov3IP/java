import java.util.Scanner;

class Hello
{
	public static void main (String[] args)
	{
		Scanner in = new Scanner(System.in);
		int x, y;
		System.out.println("Enter x:");
		x = in.nextInt();
		System.out.println("Enter y:");
		y = in.nextInt();
		System.out.println((int)Math.pow(2, -x) - Math.cos(x) + Math.sin(2*x*y));
		System.out.println((int)2 * 1 / Math.tan(3 * x) - 1 / (12 * Math.pow(x, 2) + 7 * x - 5));
	}
}

class circle
{
	public static void main (String[] args)
	{
		Scanner in = new Scanner(System.in);
		double a, b, c, radius, S, p;
		a = b = c = 0;
		System.out.println("Enter a, b, from the side of the triangle inscribed in the circle:");
		while(a <= 0)
		{
			System.out.println("Side A cannot be 0 or less than 0!");
			System.out.println("Enter A:");
			a = in.nextInt();
		}
		while(b <= 0)
		{
			System.out.println("Side B cannot be 0 or less than 0!");
			System.out.println("Enter B:");
			b = in.nextInt();
		}
		while(c <= 0)
		{
			System.out.println("Side C cannot be 0 or less than 0!");
			System.out.println("Enter C:");
			c = in.nextInt();
		}
		p = (a + b + c) / 2;
		S = Math.sqrt(p*(p-a)*(p-b)*(p-c));
		radius = S / p;
		S = radius * radius;
		System.out.println((float) S);
	}
}

class rectangle
{
	public static void main (String[] args)
	{
		Scanner in = new Scanner(System.in);
		double a, b, c, d;
		a = b = c = d = 0;
		System.out.println("Enter the dimensions of rectangle A, B and rectangle C, D.");
		while(a <= 0)
		{
			System.out.println("A cannot be 0 or less than 0!");
			System.out.println("Enter a:");
			a = in.nextInt();
		}
		while(b <= 0)
		{
			System.out.println("B cannot be 0 or less than 0!");
			System.out.println("Enter b:");
			b = in.nextInt();
		}
		while(c <= 0)
		{
			System.out.println("C cannot be 0 or less than 0!");
			System.out.println("Enter c:");
			c = in.nextInt();
		}
		while(d <= 0)
		{
			System.out.println("D cannot be 0 or less than 0!");
			System.out.println("Enter d:");
			d = in.nextInt();
		}
		if (a / c == b / d)
		{
			System.out.println(true);
		}
		else
		{
			System.out.println(false);
		}
	}
}

class coordinates
{
	public static void main (String[] args)
	{
		Scanner in = new Scanner(System.in);
		int x, y;
		System.out.println("Enter the x, y coordinates:");
		System.out.println("Enter x:");
		x = in.nextInt();
		System.out.println("Enter y:");
		y = in.nextInt();
		if (x < 5  && x > -5 && y < 5 && y >= 0 && x * x + y * y < 18)
		{
			System.out.println(true);
		}
		else
		{
			System.out.println(false);
		}
	}
}






