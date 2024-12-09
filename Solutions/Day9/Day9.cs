namespace advent_of_code_2024.Solutions
{
    internal class Day9
    {
        public struct DiskFile
        {
            public char Value;
            public int BlockId;

            public DiskFile(char value, int blockId)
            {
                Value = value;
                BlockId = blockId;
            }
        }

        public static long SolveProblem(string diskMap)
        {
            List<DiskFile> diskFiles = new List<DiskFile>();

            for (int i = 0; i < diskMap.Length; i++)
            {
                int current = int.Parse(diskMap[i].ToString());

                for (int j = 0; j < current; j++)
                {
                    if (i % 2 == 0)
                    {
                        int blockId = (i / 2) % 10;
                        string blockIdString = blockId.ToString();

                        for (int k = 0; k < blockIdString.Length; k++)
                        {
                            diskFiles.Add(new DiskFile(blockIdString[k], blockId));
                        }
                    }
                    else
                    {
                        diskFiles.Add(new DiskFile('.', -1));
                    }
                }
            }


            int leftPointer = 0;
            int rightPointer = diskFiles.Count - 1;

            List<DiskFile> compressedDiskFiles = new List<DiskFile>();

            while (leftPointer <= rightPointer)
            {
                if (diskFiles[leftPointer].Value == '.')
                {
                    if (diskFiles[rightPointer].Value != '.')
                    {
                        compressedDiskFiles.Add(diskFiles[rightPointer]);
                        
                    }

                    leftPointer++;
                    rightPointer--;
                }
                else
                {
                    compressedDiskFiles.Add(diskFiles[leftPointer]);
                    leftPointer++;

                    if (diskFiles[rightPointer].Value == '.')
                    {
                        rightPointer--;
                    }
                }

                //Console.WriteLine($"Left: {leftPointer} Right: {rightPointer}");
            }

            long checksum = 0;

            for (int i = 0; i < compressedDiskFiles.Count; i++)
            {
                checksum += i * compressedDiskFiles[i].BlockId;
            }

            //int lastSeenDigit = -1;

            //for (int i = 0; i < compressedDiskFiles.Count; i++)
            //{
            //    if (compressedDiskFiles[i].Value != lastSeenDigit)
            //    {
            //        Console.Write(compressedDiskFiles[i].BlockId);
            //        lastSeenDigit = compressedDiskFiles[i].Value;
            //    }
            //}
            //Console.WriteLine();

            return checksum;
        }
    }
}
