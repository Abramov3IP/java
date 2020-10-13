import java.util.Scanner;

class Hello
{
	public static void main (String[] args)
	{
		int x = 2;
		int y = 2;
		System.out.println((int)Math.pow(2, -x) - Math.cos(x) + Math.sin(2*x*y));
		System.out.println((int)2 * 1 / Math.tan(3 * x) - 1 / (12 * Math.pow(x, 2) + 7 * x - 5));
	}
}

class circle
{
	public static void main (String[] args)
	{
		double a, b, c, radius, S, p;
		a = 18;
		b = 24;
		c = 30;
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
		double a, b, c, d;
		a = 4;
		b = 2;
		c = 6;
		d = 2;
		if (a / b == c / d)
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
		System.out.println("Enter x:");
		x = in.nextInt();
		System.out.println("Enter y:");
		y = in.nextInt();
		if (x < 5  && x > -5 && y < 5 && y > 0 && x * x + y * y < 18)
		{
			System.out.println(true);
		}
		else
		{
			System.out.println(false);
		}
	}
}





