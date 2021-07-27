using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Data.Entity;

namespace StreamerGame
{
    static class Program
    {
        public static StreamConfig config;
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Load();
            Application.Run(new SGame(config));
            Save();
        }

        public static void Load()
        {
            if (File.Exists("userSetting.sgc"))
            {
                Stream stream = new FileStream("userSetting.sgc", FileMode.Open, FileAccess.Read);
                try
                {
                    IFormatter formatter = new BinaryFormatter();
                    config = (StreamConfig)formatter.Deserialize(stream);
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                    config = new StreamConfig();
                }
                stream.Close();
            }
            else
            {
                config = new StreamConfig();
            }
        }

        public static void Save()
        {
            Stream stream = new FileStream("userSetting.sgc", FileMode.Create, FileAccess.ReadWrite);
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
    }
}
