namespace advent_of_code_2024.Solutions
{
    internal class Day9 : IDay
    {
        private struct DiskFile
        {
            public string Value;
            public int BlockId;

            public DiskFile(string value, int blockId)
            {
                Value = value;
                BlockId = blockId;
            }
        }

        private static long DiskDefragment(string diskMap)
        {
            List<DiskFile> diskFiles = new List<DiskFile>();

            for (int i = 0; i < diskMap.Length; i++)
            {
                int current = int.Parse(diskMap[i].ToString());

                for (int j = 0; j < current; j++)
                {
                    if (i % 2 == 0)
                    {
                        int blockId = i / 2;
                        string blockIdString = blockId.ToString();

                        diskFiles.Add(new DiskFile(blockIdString, blockId));
                    }
                    else
                    {
                        diskFiles.Add(new DiskFile(".", -1));
                    }
                }
            }


            int leftPointer = 0;
            int rightPointer = diskFiles.Count - 1;

            List<DiskFile> compressedDiskFiles = new List<DiskFile>();

            while (leftPointer <= rightPointer)
            {
                if (diskFiles[leftPointer].Value == ".")
                {
                    if (diskFiles[rightPointer].Value != ".")
                    {
                        compressedDiskFiles.Add(diskFiles[rightPointer]);
                        leftPointer++;
                        
                    }

                    rightPointer--;
                }
                else
                {
                    compressedDiskFiles.Add(diskFiles[leftPointer]);

                    if (diskFiles[rightPointer].Value == ".")
                    {
                        rightPointer--;
                    }

                    leftPointer++;
                }

                //Console.WriteLine($"Left: {leftPointer} Right: {rightPointer}");
            }

            long checksum = 0;

            for (int i = 0; i < compressedDiskFiles.Count; i++)
            {
                checksum += i * compressedDiskFiles[i].BlockId;
            }


            for (int i = 0; i < compressedDiskFiles.Count; i++)
            {
                Console.Write(compressedDiskFiles[i].BlockId);
            }

            Console.WriteLine();

            return checksum;
        }

        public static void SolveProblem(string[] input)
        {
            Console.WriteLine(DiskDefragment(input[0]));
        }
    }
}
