using CustomIntersectProject;

int[] someArr1 = [1, 2, 3, 4, 3];

int[] someArr2 = [2, 2, 3, 4, 5];

var intersectedArray = CustomIntersect.Intersect(someArr1, someArr2);

foreach (int i in intersectedArray)
{
    Console.WriteLine(i);
}