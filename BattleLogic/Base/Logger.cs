//------------------------------------------------------------
//        File:  Logger.cs
//       Brief:  Logger
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-04-17
//============================================================

using System.Diagnostics;
using Core.Lite.Base;
using Core.Lite.Loggers;
using Core.Lite.RefPool.Builtin;
using Logger = Core.Lite.Loggers.Logger;

namespace Battle.Logic.Base
{
    internal class Logger : BaseObject<LogicController>
    {

#if DEBUG
        private static readonly LogFormatType BattleLogFormatter = Core.Lite.Loggers.Logger.DefaultLogFormatMask;
#else
        private static readonly LogFormatType BattleLogFormatter = LogFormatType.Tag | LogFormatType.Class | LogFormatType.Function;
#endif

        private LogicController _controller;

        public bool Enabled { get; set; } = true;

        protected override void OnCreate(LogicController arg1) {
            _controller = arg1;
        }

        protected override void OnDestroy() {
            _controller = null;
        }

        private int GetFrameIndex() {
            var frameCounter = _controller.GetFrameCounter();
            return frameCounter.FrameIndex;
        }

        [Conditional("FULL_LOG")]
        public void LogDebug(LogTag tag, string content, int skip, params object[] args) {
            if (!Enabled) {
                return;
            }
            
            var builder = StringBuilderPool.Shared.Get();
            builder.Append("<color=green>[LOGIC-");
            builder.Append(GetFrameIndex());
            builder.Append("]</color> ");
            builder.Append(content);
            var mask = Core.Lite.Loggers.Logger.LogFormatMask;
            Core.Lite.Loggers.Logger.LogFormatMask = BattleLogFormatter;
            Core.Lite.Loggers.Logger.Debug(skip, tag, builder.ToString(), args);
            Core.Lite.Loggers.Logger.LogFormatMask = mask;
            StringBuilderPool.Shared.Return(builder);
        }

        public void LogInfo(LogTag tag, string content, int skip, params object[] args) {
            if (!Enabled) {
                return;
            }

            var builder = StringBuilderPool.Shared.Get();
            builder.Append("<color=green>[LOGIC-");
            builder.Append(GetFrameIndex());
            builder.Append("]</color> ");
            builder.Append(content);
            var mask = Core.Lite.Loggers.Logger.LogFormatMask;
            Core.Lite.Loggers.Logger.LogFormatMask = BattleLogFormatter;
            Core.Lite.Loggers.Logger.Info(skip, tag, builder.ToString(), args);
            Core.Lite.Loggers.Logger.LogFormatMask = mask;
            StringBuilderPool.Shared.Return(builder);
        }

        public void LogWarning(LogTag tag, string content, int skip, params object[] args) {
            if (!Enabled) {
                return;
            }

            var builder = StringBuilderPool.Shared.Get();
            builder.Append("<color=yellow>[LOGIC-");
            builder.Append(GetFrameIndex());
            builder.Append("]");
            builder.Append(content);
            builder.Append("</color> ");
            var mask = Core.Lite.Loggers.Logger.LogFormatMask;
            Core.Lite.Loggers.Logger.LogFormatMask = BattleLogFormatter;
            Core.Lite.Loggers.Logger.Warning(skip, tag, builder.ToString(), args);
            Core.Lite.Loggers.Logger.LogFormatMask = mask;
            StringBuilderPool.Shared.Return(builder);
        }

        public void LogError(LogTag tag, string content, int skip, params object[] args) {
            if (!Enabled) {
                return;
            }

            var builder = StringBuilderPool.Shared.Get();
            builder.Append("<color=red>[LOGIC-");
            builder.Append(GetFrameIndex());
            builder.Append("]");
            builder.Append(content);
            builder.Append("</color> ");
            var mask = Core.Lite.Loggers.Logger.LogFormatMask;
            Core.Lite.Loggers.Logger.LogFormatMask = BattleLogFormatter;
            Core.Lite.Loggers.Logger.Error(skip, tag, builder.ToString(), args);
            Core.Lite.Loggers.Logger.LogFormatMask = mask;
            StringBuilderPool.Shared.Return(builder);
        }
    }
}
