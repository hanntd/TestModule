export class FileCleanup
{
    static clearInputFiles()
    {
        var fileInputs = document.querySelectorAll("input[type='file'].file-input");
        for (var i = 0; i < fileInputs.length; i++)
        {
            fileInputs[i].value = null;
        }

    }
}

window.FileCleanup = FileCleanup;