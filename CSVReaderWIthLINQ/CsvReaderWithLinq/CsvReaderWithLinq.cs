namespace CsvReaderWithLinq
{
    public static class CsvReaderWithLinq
    {
        static void Main(string[] args)
        {
            if (args.Length < 3)
            {
                Console.WriteLine("How to Operate: Either Use Visual Studio Compiler or a command line Arguement by entering the following arguements:" +
                    " CsvReaderWithLinq.exe <csvFilePath> <columnNumber> <searchKey>");

                return;
            }

            var csvFilePath = args[0];
            var columnNumber = int.Parse(args[1]);
            var searchKey = args[2];

            try
            {
                var lines = File.ReadAllLines(csvFilePath);
                var matchingLine = lines.FirstOrDefault(line =>
                {
                    var values = line.Split(',');

                    return values.Length > columnNumber && values[columnNumber] == searchKey;
                });

                if (matchingLine == null)
                {
                    Console.WriteLine("No matching entry found.");
                }
                else
                {
                    Console.WriteLine(matchingLine);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}