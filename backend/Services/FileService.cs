using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.services.interfaces;

namespace backend.services
{
    public class FileService : IFileService
    {   
        public async void WriteLineToFile(string TextLine)
        {
            try
            {
                using StreamWriter _fileWriter = new StreamWriter("cat_facts.txt", true);
                await _fileWriter.WriteLineAsync(TextLine);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}