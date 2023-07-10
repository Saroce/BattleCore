//------------------------------------------------------------
//        File:  Logger.cs
//       Brief:  Logger
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-04-18
//============================================================

using System.Diagnostics;
using Core.Lite.Loggers;
using Core.Lite.RefPool.Builtin;
using UnityEngine;

namespace Battle.View.Base
{
   internal static class Logger
    {
        private static readonly LogFormatType BattleLogFormatter = LogFormatType.Tag | LogFormatType.Class | LogFormatType.Function;

        private static int GetFrameIndex() {
            return Time.frameCount;
        }

        // [Conditional("DEBUG")]
        private static void LogDebug(LogTag tag, string content, int skip, params object[] args) {
            var builder = StringBuilderPool.Shared.Get();
            builder.Append("<color=green>[VIEW-");
            builder.Append(GetFrameIndex());
            builder.Append("]</color> ");
            builder.Append(content);
            var mask = Core.Lite.Loggers.Logger.LogFormatMask;
            Core.Lite.Loggers.Logger.LogFormatMask = BattleLogFormatter;
            Core.Lite.Loggers.Logger.Debug(skip, tag, builder.ToString(), args);
            Core.Lite.Loggers.Logger.LogFormatMask = mask;
            StringBuilderPool.Shared.Return(builder);
        }

        private static void LogInfo(LogTag tag, string content, int skip, params object[] args) {
            var builder = StringBuilderPool.Shared.Get();
            builder.Append("<color=green>[VIEW-");
            builder.Append(GetFrameIndex());
            builder.Append("]</color> ");
            builder.Append(content);
            var mask = Core.Lite.Loggers.Logger.LogFormatMask;
            Core.Lite.Loggers.Logger.LogFormatMask = BattleLogFormatter;
            Core.Lite.Loggers.Logger.Info(skip, tag, builder.ToString(), args);
            Core.Lite.Loggers.Logger.LogFormatMask = mask;
            StringBuilderPool.Shared.Return(builder);
        }

        private static void LogWarning(LogTag tag, string content, int skip, params object[] args) {
            var builder = StringBuilderPool.Shared.Get();
            builder.Append("<color=yellow>[VIEW-");
            builder.Append(GetFrameIndex());
            builder.Append("]</color> ");
            builder.Append(content);
            var mask = Core.Lite.Loggers.Logger.LogFormatMask;
            Core.Lite.Loggers.Logger.LogFormatMask = BattleLogFormatter;
            Core.Lite.Loggers.Logger.Warning(skip, tag, builder.ToString(), args);
            Core.Lite.Loggers.Logger.LogFormatMask = mask;
            StringBuilderPool.Shared.Return(builder);
        }

        private static void LogError(LogTag tag, string content, int skip, params object[] args) {
            var builder = StringBuilderPool.Shared.Get();
            builder.Append("<color=red>[VIEW-");
            builder.Append(GetFrameIndex());
            builder.Append("]</color> ");
            builder.Append(content);
            var mask = Core.Lite.Loggers.Logger.LogFormatMask;
            Core.Lite.Loggers.Logger.LogFormatMask = BattleLogFormatter;
            Core.Lite.Loggers.Logger.Error(skip, tag, builder.ToString(), args);
            Core.Lite.Loggers.Logger.LogFormatMask = mask;
            StringBuilderPool.Shared.Return(builder);
        }

        public static void LogDebug(LogTag tag, string content, params object[] args) {
            LogDebug(tag, content, 2, args);
        }

        public static void LogInfo(LogTag tag, string content, params object[] args) {
            LogInfo(tag, content, 2, args);
        }

        public static void LogWarning(LogTag tag, string content, params object[] args) {
            LogWarning(tag, content, 2, args);
        }

        public static void LogError(LogTag tag, string content, params object[] args) {
            LogError(tag, content, 2, args);
        }
    }
}