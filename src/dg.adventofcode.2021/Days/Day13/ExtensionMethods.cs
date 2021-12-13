namespace dg.adventofcode._2021.Days.Day13
{
    public static class ExtensionMethods
    {
        public static List<int> ReverseValues(this List<int> list, int max)
        {
            var newList = new List<int>();
            var middleNum = max / 2;

            foreach (var num in list)
            {
                var diff = Math.Abs(middleNum - num);

                if (num == middleNum)
                    newList.Add(num);
                else if (num < middleNum)
                    newList.Add(middleNum + diff);
                else if (num > middleNum)
                    newList.Add(middleNum - diff);
            }

            return newList;
        }
    }
}
