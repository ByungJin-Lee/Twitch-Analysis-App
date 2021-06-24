using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitch_Analysis_App.Models
{
    /// <summary>
    /// Configuration File I/O
    /// </summary>
    class Configuration
    {
        #region EnviromentKeys
        class EnviromentKeys
        {
            public const short CLIENT_AUTH = 0;
            public const short CLIENT_SECECRET_AUTH = 1;
            public const short AUTH_TOKEN = 2;
            public const short AUTH_IRC_TOKEN = 3;
            public const short DATABASE_NAME = 4;
            public const short COLLECTION_NAME = 5;
            public const short DATABASE_IP = 6;
            public const short DATABASE_PORT = 7;
            public const short NICK = 8;
            public const short IRC_IP = 9;
            public const short Length = 10;
        }
        #endregion

        #region Variables

        static private string[] keys = null;

        #endregion

        #region Constructor Destructor
        static Configuration()
        {
            readKeys();
        }

        ~Configuration()
        {
            //Save Keys to File before Exit Programming
            save();
        }

        #endregion

        #region Methods

        static private bool readKeys()
        {
            try
            {
                keys = File.ReadAllLines(@"./TAConfiguration.txt");
                return true;
            }
            catch
            {
                keys = new string[8];
                return false;
            }
        }

        static public void save()
        {
            using (StreamWriter writer = new StreamWriter(@"./TAConfiguration.txt"))
            {
                foreach (string value in keys)
                {
                    writer.WriteLine(value);
                }
            }
        }

        #endregion

        #region Setter Getter
        static public string Client_auth { get => keys[EnviromentKeys.CLIENT_AUTH]; set => keys[EnviromentKeys.CLIENT_AUTH] = value; }
        static public string Client_secret_auth { get => keys[EnviromentKeys.CLIENT_SECECRET_AUTH]; set => keys[EnviromentKeys.CLIENT_SECECRET_AUTH] = value; }
        static public string Auth_token { get => keys[EnviromentKeys.AUTH_TOKEN]; set => keys[EnviromentKeys.AUTH_TOKEN] = value; }
        static public string Auth_irc_token { get => keys[EnviromentKeys.AUTH_IRC_TOKEN]; set => keys[EnviromentKeys.AUTH_IRC_TOKEN] = value; }
        static public string Database_name { get => keys[EnviromentKeys.DATABASE_NAME]; set => keys[EnviromentKeys.DATABASE_NAME] = value; }
        static public string Database_ip { get => keys[EnviromentKeys.DATABASE_IP]; set => keys[EnviromentKeys.DATABASE_IP] = value; }
        static public string Database_port { get => keys[EnviromentKeys.DATABASE_PORT]; set => keys[EnviromentKeys.DATABASE_PORT] = value; }
        static public string Collection_name { get => keys[EnviromentKeys.COLLECTION_NAME]; set => keys[EnviromentKeys.COLLECTION_NAME] = value; }
        static public string NICK { get => keys[EnviromentKeys.NICK]; set => keys[EnviromentKeys.NICK] = value; }
        static public string IRC_IP { get => keys[EnviromentKeys.IRC_IP]; set => keys[EnviromentKeys.IRC_IP] = value; }
        #endregion
    }
}
