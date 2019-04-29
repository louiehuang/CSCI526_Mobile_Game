using System.Collections.Generic;
using System.IO;
using UnityEngine;


public class Logger {
    public enum OutputTarget {
        eNone,
        eConsole = 1,
        eUI = 2,
        eFile = 3,
    }

    public enum OutputLevel {
        eNone,
        eLog = 1,
        eLogWaning = 2,
        eLogError = 3,
    }


    private static bool useLog;
    private static int outputTarget;
    private static int outputLevel;

    private static string filePath;
    private const int MAX_LOG_NUM = 1000;
    private static List<string> logList = new List<string>();


    public static void Init() {
        Application.logMessageReceived += LogCallback;

        filePath = GetPath("LogFile.txt");

        if (File.Exists(filePath)) {
            File.Delete(filePath);
        }

        useLog = true;

        SwitchTarget(OutputTarget.eConsole, true);
        SwitchTarget(OutputTarget.eFile, true);

        SwitchLevel(OutputLevel.eLog, true);
        SwitchLevel(OutputLevel.eLogWaning, true);
        SwitchLevel(OutputLevel.eLogError, true);
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


    public static void Log(string message) {
        if (!IsOuputLog(OutputLevel.eLog)) {
            return;
        }

        message = ModifyLog(message, 0);
        OutputConsole(message, 0);
    }


    public static void LogWarning(string message) {
        if (!IsOuputLog(OutputLevel.eLogWaning)) {
            return;
        }

        message = ModifyLog(message, 1);
        OutputConsole(message, 1);
    }


    public static void LogError(string message) {
        if (!IsOuputLog(OutputLevel.eLogError)) {
            return;
        }

        message = ModifyLog(message, 2);
        OutputConsole(message, 2);
    }


    private static void OutputConsole(string message, int type) {
        if (!IsOutputTarget(OutputTarget.eConsole)) {
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
        if (!IsOutputTarget(OutputTarget.eFile)) {
            return;
        }

        FileStream fs = File.Open(filePath, FileMode.Append, FileAccess.Write);
        StreamWriter sw = new StreamWriter(fs);
        sw.WriteLine(message);
        sw.Close();
        fs.Close();
    }


    private static bool IsOuputLog(OutputLevel level) {
        bool result = false;
        bool rule1 = useLog;
        bool rule2 = (outputLevel & (1 << (int)level)) > 0 ? true : false;
        if (rule1 && rule2){
            result = true;
        }
        return result;
    }


    private static bool IsOutputTarget(OutputTarget target) {
        bool result = false;
        result = (outputTarget & (1 << (int)target)) > 0 ? true : false;
        return result;
    }


    private static string ModifyLog(string message, int type) {
        string result = "";
        switch (type) {
            case 0: {
                    result += "common : ";
                }
                break;
            case 1: {
                    result += "warning : ";
                }
                break;
            case 2: {
                    result += "error : ";
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


    public static void SwitchTarget(OutputTarget target, bool isOpen) {
        if (isOpen) {
            outputTarget = outputTarget | (1 << (int)target);
        } else {
            outputTarget = outputTarget & (~(1 << (int)target));
        }
    }


    public static void SwitchLevel(OutputLevel level, bool isOpen) {
        if (isOpen) {
            outputLevel = outputLevel | (1 << (int)level);
        } else {
            outputLevel = outputLevel & (~(1 << (int)level));
        }
    }
}

