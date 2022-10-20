using PCLStorage;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using project1.models;

namespace project1.services
{
    class FileService
    {
        public string FileName { get; set; }
        public string FolderName { get; set; }

        public FileService(string filename, string foldername)
        {
            FileName = filename;
            FolderName = foldername;
        }

        public async Task WriteSomeText(string contentToSave)
        {

            IFolder folder = FileSystem.Current.LocalStorage;
            folder = await folder.CreateFolderAsync(FolderName, CreationCollisionOption.OpenIfExists);

            IFile file = await folder.CreateFileAsync(FileName, CreationCollisionOption.OpenIfExists);
            await file.WriteAllTextAsync(contentToSave);
        }

        public async Task<string> ReadText()
        {

            IFolder folder = FileSystem.Current.LocalStorage;
            folder = await folder.CreateFolderAsync(FolderName, CreationCollisionOption.OpenIfExists);

            IFile file = await folder.CreateFileAsync(FileName, CreationCollisionOption.OpenIfExists);
            string loadedContent = await file.ReadAllTextAsync();
            return loadedContent;
        }

        public async Task WriteJSON(List<CityModel> listOfCities)
        {
            string data = JsonConvert.SerializeObject(listOfCities);
            await WriteSomeText(data);
        }

        public async Task<List<CityModel>> ReadJSON()
        {
            string data = await ReadText();
            List<CityModel> cities = JsonConvert.DeserializeObject<List<CityModel>>(data);
            return cities;
        }
    }
}
