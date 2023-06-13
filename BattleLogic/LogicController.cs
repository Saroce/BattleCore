//------------------------------------------------------------
//        File:  LogicController.cs
//       Brief:  LogicController
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-21
//============================================================

using System;
using Battle.Common.Context.Command;
using Battle.Common.Context.Message;
using Battle.Logic.Base;
using Battle.Logic.Base.Clock;
using Battle.Logic.Input.System;
using Core.Lite.Base;
using Core.Lite.DataSystem;
using Core.Lite.DataSystem.Config;
using Core.Lite.RefPool;
using Core.Lite.RefPool.Allocator;
using ExcelConvert.Auto.BattleConf;
using ExcelConvert.Auto.BuffConf;
using ExcelConvert.Auto.DressConf;
using ExcelConvert.Auto.FriendshipConf;
using ExcelConvert.Auto.FunctionConf;
using ExcelConvert.Auto.GeneralConf;
using ExcelConvert.Auto.MonsterConf;
using ExcelConvert.Auto.SkillConf;
using vFrame.Lockstep.Core;

namespace Battle.Logic
{
    public sealed class LogicController : BaseObject<object>, IBattleLogic
    {
        private BattleContext _battleContext;

        private IClock _clock;
        private TSRandom _random;
        private UniqueIdGenerator _idGenerator;
        private FrameCounter _frameCounter;
        private Logger _logger;
        private ConfigReader _configReader;
        
        private LogicContexts _contexts;
        private LogicSystems _logicSystems;
        private CommandSystem _commandSystem;
        
        private MessageQueue<IBattleMessage> _messageQueue;
        private MessageQueue<IBattleRequest> _requestQueue;

        protected override void OnCreate(object args) {
            if (!(args is BattleContext context)) {
                throw new ArgumentException($"args must be an instance of BattleContext!");
            }

            _battleContext = context;
            _logger = new Logger();
            _logger.Create(this);

            _clock = new ScalableClock() { TimeScale = 1f};
            _clock.StepDelta = _battleContext.FrameDeltaInMilliseconds;


            _configReader = new ConfigReader();
            _configReader.Create(context.DataReader, context.ConfigPath);
            ParseSheets(_configReader);
            
            _random = TSRandom.New(_battleContext.Seed);
            _idGenerator = new UniqueIdGenerator();

            _frameCounter = new FrameCounter();
            _messageQueue = new MessageQueue<IBattleMessage>();
            _requestQueue = new MessageQueue<IBattleRequest>();

            _contexts = new LogicContexts(this);
            _logicSystems = new LogicSystems(_contexts);
            _commandSystem = new CommandSystem(_contexts);
            _logicSystems.Initialize();
        }

        private static void ParseSheets(ConfigReader configReader) {
            configReader.ParseSheet<BattleConf_Battle, BattleConf_Battle_Record>("BattleConf_Battle");
            configReader.ParseSheet<GeneralConf_General, GeneralConf_General_Record>("GeneralConf_General");
            configReader.ParseSheet<MonsterConf_Monster, MonsterConf_Monster_Record>("MonsterConf_Monster");
            configReader.ParseSheet<SkillConf_Basic, SkillConf_Basic_Record>("SkillConf_Basic");
            configReader.ParseSheet<SkillConf_SkillLevel, SkillConf_SkillLevel_Record>("SkillConf_SkillLevel");
            configReader.ParseSheet<BuffConf_Buff, BuffConf_Buff_Record>("BuffConf_Buff");
            configReader.ParseSheet<FunctionConf_Function, FunctionConf_Function_Record>("FunctionConf_Function");
            configReader.ParseSheet<DressConf_Dress, DressConf_Dress_Record>("DressConf_Dress");
            configReader.ParseSheet<FriendshipConf_Talk, FriendshipConf_Talk_Record>("FriendshipConf_Talk");
        }
        
        public void EnterFrame() {
            _clock.Step();
            _frameCounter.EnterFrame();
            
            _logicSystems.Execute();
            _logicSystems.Cleanup();
        }

        /// <summary>
        /// 内部消息入列
        /// </summary>
        /// <param name="message"></param>
        internal void EnqueueMessage(IBattleMessage message) {
            message.FrameIndex = _frameCounter.FrameIndex;
            _messageQueue.Enqueue(message);
        }
        
        /// <summary>
        /// 外部消息派发出列
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public bool TryDequeueMessage(out IBattleMessage message) {
            return _messageQueue.TryDequeue(out message);
        }

        /// <summary>
        /// 内部处理请求命令出列
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        internal bool TryDequeueRequest(out IBattleRequest request) {
            return _requestQueue.TryDequeue(out request);
        }
        
        /// <summary>
        /// 外部请求命令入列
        /// </summary>
        /// <param name="request"></param>
        public void EnqueueRequest(IBattleRequest request) {
            _requestQueue.Enqueue(request);
        }

        /// <summary>
        /// 外部轮询命令
        /// </summary>
        public void PollCommands() {
            _commandSystem.Execute();
        }
        
        /// <summary>
        /// 获取战斗现场
        /// </summary>
        /// <returns></returns>
        internal BattleContext GetBattleContext() {
            return _battleContext;
        }

        internal IRefPoolManager RefPoolManager() {
            return GetBattleContext().RefPoolManager;
        }
        
        internal IRefPool<T> GetRefPool<T>() where T : class, new() {
            return RefPoolManager().GetRefPool<T>();
        }

        internal IRefPool<T1> ObjectPool<T1, T2>()
            where T1 : class, new()
            where T2 : IPoolRefAllocator<T1>, new() {
            return RefPoolManager().GetRefPool<T1, T2>();
        }
        
        /// <summary>
        /// 获取时钟
        /// </summary>
        /// <returns></returns>
        internal IClock GetClock() {
            return _clock;
        }
        
        /// <summary>
        /// 获取逻辑帧计数器
        /// </summary>
        /// <returns></returns>
        internal FrameCounter GetFrameCounter() {
            return _frameCounter;
        }
        
        /// <summary>
        /// 获取随机数
        /// </summary>
        /// <returns></returns>
        internal TSRandom GetRandom() {
            return _random;
        }

        internal Logger GetLogger() {
            return _logger;
        }

        internal IConfigReader GetConfigReader() {
            return _configReader;
        }

        internal IDataReader GetDataReader() {
            return GetBattleContext().DataReader;
        }
        
        internal ulong GetIndependentId() {
            return _idGenerator.IndependentId;
        }
        
        protected override void OnDestroy() {
            _logicSystems?.TearDown();
            _logicSystems = null;
            
            // TODO 
            _configReader?.Destroy();
            _configReader = null;
        }
    }
}