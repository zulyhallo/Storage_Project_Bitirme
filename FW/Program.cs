using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;

namespace FW
{
    class Program
    {
       
            static HttpClient _httpClient = new HttpClient();
            static void Main(string[] args)
            {
                {
                    //CreateHostBuilder(args).Build().Run
                  

                    FileSystemWatcher watcher = new FileSystemWatcher(@"C:\Users\Tech\Desktop\File"); // Takibi sağlanan klasör
                    watcher.EnableRaisingEvents = true;
                    watcher.IncludeSubdirectories = true;

                    //Dosyada yapılan işlemler
                    watcher.Changed += watcher_Changed;

                    watcher.Created += Watcher_Created;

                    watcher.Deleted += Watcher_Deleted;

                    watcher.Renamed += Watcher_Renamed;

                    Console.Read();


                }

                static void watcher_Changed(object sender, FileSystemEventArgs e)
                {
                    // Dosyada değişiklik olduysa konsola yazdır
                    Console.WriteLine("{0} dosya değiştirilme zamanı:{1},", e.Name, DateTime.Now.ToLocalTime());

                }


                static void Watcher_Renamed(object sender, RenamedEventArgs e)
                {
                    // isim değişikliği
                    Console.WriteLine("File:{0} adı {1} olarak değiştirildi:{2}", e.OldName, e.Name, DateTime.Now.ToLocalTime());


                }

                static void Watcher_Deleted(object sender, FileSystemEventArgs e)
                { 
                    // Dosya silinmesi
                    Console.WriteLine("File:{0} silindi {1}", e.Name, DateTime.Now.ToLocalTime());

                    FileInfo fil = new FileInfo(e.FullPath);

                    var path = fil.Name;
                    ////byte[] fileContent = File.ReadAllBytes(path);
                    //var base64String = Convert.ToBase64String(fileContent);

                    var content = new FormUrlEncodedContent(new List<KeyValuePair<string, string>>
                {

                    new KeyValuePair<string, string>("fileName",path),
                });


                    var result = _httpClient.PostAsync("https://localhost:44309//api/File/Delete", content).Result; //API ucundan silme 
                }

                static void Watcher_Created(object sender, FileSystemEventArgs e)
                {
                     
                    //try
                    //{
                    //Dosya oluşturulması
                    Console.WriteLine("File:{0} oluşturulma zamanı {1}", e.Name, DateTime.Now.ToLocalTime());

                    FileInfo fi = new FileInfo(e.FullPath);

                    var path = e.FullPath;
                    byte[] fileContent = File.ReadAllBytes(path);
                    var base64String = Convert.ToBase64String(fileContent);

                    var content = new FormUrlEncodedContent(new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("fileContent",base64String),
                    new KeyValuePair<string, string>("fileName",fi.Name),
                });

                    var result = _httpClient.PostAsync("https://localhost:44309//api/File/CreateFile", content).Result; //API ucuna POST etme

                    //}
                    //catch (Exception ex )
                    //{

                    //    throw ex;
                    //}



                    //

                }


            }
        }
    }

