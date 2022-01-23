using System;
using ExcelApp.Apis;
using ExcelDna.Integration;

namespace ExcelApp.ExcelFunctions
{
    public static class addInExtNewsFunctions
    {
        [ExcelFunction(Description = "Returns a list of popular articles details, based on name and date")]
        public static object[,] extGetPopularArticlesByNameAndDate(string name, DateTime fromDate)
        {
            //casting to object - this is because excel dna lib, https://github.com/Excel-DNA/ExcelDna/issues/173
            return (object[,]) GetNewsFunctionsWrapper.getPopularArticlesByNameAndDate(name, fromDate);
        }
    }
}
