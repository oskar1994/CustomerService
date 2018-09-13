using DataTypes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Helpers
{
    public static class Logger
    {
        #region Constructor
        static Logger()
        {
            _logPath = Paths.ToLogger;
            CreateFileIfNotExists(_logPath);
            ClearFileIfItsHuge(_logPath);    
        }     
        #endregion

        #region Fields
        private static object _syncRoot = new object();
        private static readonly string _logPath;
        #endregion

        #region Methods

        private static void CreateFileIfNotExists(string filePath)
        {
            if (!File.Exists(filePath))
            {
                File.Create(filePath);
            }
        }

        private static void ClearFileIfItsHuge(string filePath)
        {
            FileInfo info = new FileInfo(filePath);
            if (info.Length > 1000000)
            {
                File.WriteAllText(filePath, string.Empty);
            }
        }

        public static void LogException(Exception e)
        {        
            Thread t = new Thread(delegate ()
            {
                lock (_syncRoot)
                {
                    try
                    {
                        File.AppendAllLines(_logPath,
                            new string[]
                            {
                                "= = = EXCEPTION = = =",
                                DateTime.Now.ToString(),
                                e.GetType().ToString(),
                                e.Message,
                                e.StackTrace,
                            });
                        if (e.InnerException != null)
                        {
                            LogInnerExceptions(e.InnerException);
                        }
                    }
                    catch (Exception)
                    {
        
                    }
                }
            });
            t.Start();
        }
        #endregion
        private static void LogInnerExceptions(Exception e)
        {
            File.AppendAllLines(_logPath,
                            new string[]
                            {
                                "= = = ======InnerException====== = = =",
                                DateTime.Now.ToString(),
                                e.GetType().ToString(),
                                e.Message,
                                e.StackTrace,
                                "= = = ======End of InnerException====== = = ="
                            });
            if (e.InnerException != null)
            {
                LogInnerExceptions(e.InnerException);
            }
        }
    }
}
