using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.services.interfaces
{
    public interface IFileService
    {
        void WriteLineToFile(string TextLine);
    }
}