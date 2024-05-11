namespace CoordinateChecker
{
    internal static class UserCommunicator
    {
        public static void GreetUser()
        {
            Console.WriteLine("Hello! This program allows you to find out if the point is a part of a cube in three-dimensional coordinates!");
            Console.WriteLine("You will have to input coordinates of cube's tops.");
            Console.WriteLine("Here are the main rules how to do it:");
            Console.WriteLine("1) Input coordinates one by another. The program will check them to be correct (the first is X, the second is Y, the third is Z);");
            Console.WriteLine("2) You will input coordinates of three points, then the program will make a cube automatically, asking  direction for it to grow;");
            Console.WriteLine("3) Cube edges should be parallel to axes;");
            Console.WriteLine("4) Use only integers - they can be either positive or negative;");
        }

        public static void PointCommited()
        {
            Console.WriteLine("Point commited.");
        }
    }
}
