namespace AdventOfCode.Year2024
{
    public class DiskCompactor
    {
        public static long GetChecksum(string input, bool noFrag = false)
        {
            var disk = new List<int>();
            var fileId = 0;
            for (int n = 0; n < input.Length; n += 2)
            {
                int fileLength = input[n] - '0';
                int freeSpaceLength = (n + 1 < input.Length) ? input[n + 1] - '0' : 0;
                disk.AddRange(Enumerable.Repeat(fileId, fileLength));
                disk.AddRange(Enumerable.Repeat(-1, freeSpaceLength));
                fileId++;
            }

            if (noFrag)
            {
                CompressWithNoFrag(disk);
            }
            else
            {
                Compress(disk);
            }

            long checksum = 0;
            int readpos = 0;
            while (readpos < disk.Count)
            {
                if (disk[readpos] != -1)
                {
                    checksum += disk[readpos] * readpos;
                }

                readpos++;
            }

            return checksum;
        }

        private static void Compress(List<int> disk)
        {
            int writePos = 0;
            int readpos = disk.Count - 1;
            while (writePos < readpos)
            {
                while (disk[writePos] != -1) writePos++;
                while (disk[readpos] == -1) readpos--;
                if (writePos < readpos)
                {
                    disk[writePos] = disk[readpos];
                    disk[readpos] = -1;
                    readpos--;
                    writePos++;
                }
            }
        }

        private static void CompressWithNoFrag(List<int> disk)
        {
            int readpos = disk.Count - 1;
            int firstEmpty = 0;
            while (readpos >= 0)
            {
                while (readpos >= 0 && disk[readpos] == -1) readpos--;
                if (readpos >= 0)
                {
                    int fileId = disk[readpos];
                    int fileLength = 1;
                    while (readpos > 0 && disk[readpos - 1] == fileId)
                    {
                        readpos--;
                        fileLength++;
                    }

                    var searchPos = firstEmpty;
                    while (disk[searchPos] != -1) searchPos++;
                    firstEmpty = searchPos;

                    int freeSpaceInBlock = 0;
                    int writePos = -1;
                    while (searchPos < readpos && freeSpaceInBlock < fileLength)
                    {
                        if (disk[searchPos] == -1)
                        {
                            if (freeSpaceInBlock == 0)
                            {
                                writePos = searchPos;
                            }

                            freeSpaceInBlock++;
                        }
                        else
                        {
                            freeSpaceInBlock = 0;
                        }

                        searchPos++;
                    }

                    if (freeSpaceInBlock == fileLength && writePos != -1)
                    {
                        int clearPos = readpos;
                        while (fileLength-- > 0)
                        {
                            disk[writePos++] = fileId;
                            disk[clearPos++] = -1;
                        }
                    }

                    readpos--;
                }
            }
        }
    }
}
