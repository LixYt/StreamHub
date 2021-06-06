using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace StreamHub
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>

        public static SHubConfig config;
        [STAThread]
        
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Load();
            Application.Run(new SHubMain(config));
            //Application.Run(new SHub());
            Save();
           
        }
        public static void Save()
        {
            Stream stream = new FileStream("userSetting.shc", FileMode.Create, FileAccess.ReadWrite);
            try
            {
                IFormatter formatter = new BinaryFormatter();
                
                formatter.Serialize(stream, config);
                
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Echec de l'enregistrement du workspace : {ex.Message}.");
            }
            stream.Close();
        }

        public static void Load()
        {
            if (File.Exists("userSetting.shc"))
            {
                Stream stream = new FileStream("userSetting.shc", FileMode.Open, FileAccess.Read);
                try
                {
                        IFormatter formatter = new BinaryFormatter();
                        config = (SHubConfig)formatter.Deserialize(stream);
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                    config = new SHubConfig();
                }
                stream.Close();
            }
            else
            {
                config = new SHubConfig();
            }
        }
    }

    

}

