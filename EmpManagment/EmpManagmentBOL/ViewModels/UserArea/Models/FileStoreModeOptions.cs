using System;
using System.Collections.Generic;
using System.Text;

namespace EmpManagmentBOL.ViewModels.UserArea.Models
{
    public enum FileStoreModeOptions
    {
        SingleImageSaveToFolder,
        MultipleImageSaveToFolder,
        SingleImageSaveToDatabase,
        MultipleImageSaveToDatabase,
        SingleFileSaveToFolder,
        MultipleFileSaveToFolder,
        SingleFileSaveToDatabase,
        MultipleFileSaveToDatabase,
        ExcelFileDataSaveToDatabase
    }
}
