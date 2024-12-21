using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_09
{
    internal class FileCopyHelper
    {
        public event EventHandler CopyStarted;
        public event EventHandler CopyCompleted;
        public event EventHandler<int> CopyProgress;

        private readonly string sourceFilePath;
        private readonly string destinationFilePath;
        private readonly int blockSize;

        public FileCopyHelper(string sourceFilePath, string destinationFilePath, int blockSize)
        {
            this.sourceFilePath = sourceFilePath;
            this.destinationFilePath = destinationFilePath;
            this.blockSize = blockSize;
        }

        public void CopyFile()
        {
           
            CopyStarted?.Invoke(this, EventArgs.Empty);

            try
            {
                using (FileStream sourceStream = new FileStream(sourceFilePath, FileMode.Open, FileAccess.Read))
                using (FileStream destinationStream = new FileStream(destinationFilePath, FileMode.Create, FileAccess.Write))
                {
                    long totalBytes = sourceStream.Length;
                    byte[] buffer = new byte[blockSize];
                    long totalBytesRead = 0;

                    int bytesRead;
                    while ((bytesRead = sourceStream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        destinationStream.Write(buffer, 0, bytesRead);
                        totalBytesRead += bytesRead;

                   
                        int progressPercentage = (int)((totalBytesRead * 100) / totalBytes);
                        CopyProgress?.Invoke(this, progressPercentage);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при копировании файла: {ex.Message}");
            }

      
            CopyCompleted?.Invoke(this, EventArgs.Empty);
        }
    }

}
