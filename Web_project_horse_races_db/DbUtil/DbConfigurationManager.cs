
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Web_project_horse_races_db.DbUtil
{
    static class DbConfigurationManager
    {
        public static string GetConnectionStringFromJSONFile()
        {
            ConfigurationBuilder builder = new ConfigurationBuilder();
            // установка пути к текущему каталогу
            string directory = @"C:\Users\BENFIN\source\repos\Web_project_horse_races\Web_project_horse_races_db\";
            builder.SetBasePath(directory);
            // получаем конфигурацию из файла appsettings.json
            builder.AddJsonFile("appsettings.json");
            // создаем конфигурацию
            var config = builder.Build();
            // получаем строку подключения
            string connectionString = config.GetConnectionString("DefaultConnection");
            
            return connectionString;
        }
    }
}
