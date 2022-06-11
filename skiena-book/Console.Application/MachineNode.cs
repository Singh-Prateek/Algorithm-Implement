using System;
namespace skiena.book
{
	public class MachineNode
	{

        public static IEnumerable<List<int>> ReadInput(string[] input)
        {
            foreach(var row in input)
            {

                string tempRow = row.TrimEnd();

                if (tempRow.StartsWith('a')) continue;


                yield return tempRow
                        .Split(' ') 
                        .ToList()
                        .Select(roadsTemp => Convert.ToInt32(roadsTemp)).ToList();
        }
            }

        public static int minTime(List<List<int>> roads, List<int> machines)
        {
            var machineRoads = GetMachineNodeWeight(roads, machines).ToList();

            return machineRoads.OrderByDescending(s => s).Skip(1).Sum();
        }

        private static IEnumerable<int> GetMachineNodeWeight(List<List<int>> roads, List<int> machines)
        {

            foreach (var road in roads)
            {
                if (!machines.Any(c => c == road[0] || c == road[1]))
                {
                    continue;
                }
                yield return road[2];
            }
        }

    }
}
