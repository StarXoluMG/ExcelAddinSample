using ExcelDna.Integration;

namespace ExcelApp.ExcelFunctions
{
    public static class BasicFunctions
    {
        [ExcelFunction(Description = "Saying hello")]
        public static string extSayHello(string name)
        {
            return "Hello " + name;
        }
    }
}
