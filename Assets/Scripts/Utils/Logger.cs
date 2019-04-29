using System.Collections.Generic;
using System.IO;
using UnityEngine;


public static class Logger {
    public enum LogDestination {
        None,
        Console = 1,
        File = 2,
    }

    public enum LogLevel {
        None,
        Info = 1,
        Waning = 2,
        Error = 3,
    }


    private static bool useLog;
    private static int outputTarget;
    private static int outputLevel;
    private static string filePath;


    static Logger() {
        Application.logMessageReceived += LogCallback;

        filePath = GetPath("LogFile.txt");
        if (File.Exists(filePath)) {
            File.Delete(filePath);
        }

        useLog = true;

        UseOutputMethod(LogDestination.Console, true);
        UseOutputMethod(LogDestination.File, false);  //Do not use file

        UseLogLevel(LogLevel.Info, true);
        UseLogLevel(LogLevel.Waning, true);
        UseLogLevel(LogLevel.Error, true);
    }


    public static void LogCallback(string condition, string stackTrace, LogType type) {
        string result = "";
        if (type == LogType.Error || type == LogType.Log || type == LogType.Warning) {
            result = condition;
        } else {
            result = string.Format("{0}\n{1}", condition, stackTrace);
        }
        OutputFile(result);
    }


    public static void Log(object message) {
        if (!IsOuputLog(LogLevel.Info)) {
            return;
        }

        message = FormatLog(message, 0);
        OutputConsole(message, 0);
    }


    public static void LogWarning(object message) {
        if (!IsOuputLog(LogLevel.Waning)) {
            return;
        }

        message = FormatLog(message, 1);
        OutputConsole(message, 1);
    }


    public static void LogError(object message) {
        if (!IsOuputLog(LogLevel.Error)) {
            return;
        }

        message = FormatLog(message, 2);
        OutputConsole(message, 2);
    }


    private static bool IsOuputLog(LogLevel level) {
        bool result = false;
        bool rule1 = useLog;
        bool rule2 = (outputLevel & (1 << (int)level)) > 0 ? true : false;
        if (rule1 && rule2) {
            result = true;
        }
        return result;
    }


    private static void OutputConsole(object message, int type) {
        if (!IsLogDestination(LogDestination.Console)) {
            return;
        }

        if (type == 0) {
            Debug.Log(message);
        } else if (type == 1) {
            Debug.LogWarning(message);
        } else if (type == 2) {
            Debug.LogError(message);
        }
    }


    private static void OutputFile(string message) {
        if (!IsLogDestination(LogDestination.File)) {
            return;
        }

        FileStream fs = File.Open(filePath, FileMode.Append, FileAccess.Write);
        StreamWriter sw = new StreamWriter(fs);
        sw.WriteLine(message);
        sw.Close();
        fs.Close();
    }


    private static bool IsLogDestination(LogDestination target) {
        bool result = false;
        result = (outputTarget & (1 << (int)target)) > 0 ? true : false;
        return result;
    }


    private static string FormatLog(object message, int type) {
        string result = "";
        switch (type) {
            case 0: {
                    result += "Info: ";
                }
                break;
            case 1: {
                    result += "Warning: ";
                }
                break;
            case 2: {
                    result += "Error: ";
                }
                break;
        }
        result += message;
        return result;
    }


    private static string GetPath(string name) {
        string path = "";
        switch (Application.platform) {
            case RuntimePlatform.Android:
            case RuntimePlatform.IPhonePlayer: {
                    path = Application.persistentDataPath + "/" + name;
                }
                break;
            case RuntimePlatform.OSXEditor:
            case RuntimePlatform.WindowsEditor:
            case RuntimePlatform.WindowsPlayer: {
                    path = Application.dataPath + "/../" + name;
                }
                break;
        }
        return path;
    }


    public static void UseOutputMethod(LogDestination target, bool isOpen) {
        if (isOpen) {
            outputTarget = outputTarget | (1 << (int)target);
        } else {
            outputTarget = outputTarget & (~(1 << (int)target));
        }
    }


    public static void UseLogLevel(LogLevel level, bool isOpen) {
        if (isOpen) {
            outputLevel = outputLevel | (1 << (int)level);
        } else {
            outputLevel = outputLevel & (~(1 << (int)level));
        }
    }
}

