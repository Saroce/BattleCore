//------------------------------------------------------------
//        File:  ViewController.cs
//       Brief:  ViewController
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-21
//============================================================

using System;
using Battle.Common.Context.Message;
using Battle.View.Base;
using Core.Lite.Base;
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
using Newtonsoft.Json;
using vFrame.Lockstep.Core;

namespace Battle.View
{
    public sealed class ViewController : BaseObject<object>, IBattleView
    {
        private BattleContext _battleContext;
        private TSRandom _random;
        private UniqueIdGenerator _idGenerator;
        private BattleViewConfig _viewConfig;
        private ConfigReader _configReader;
        
        private MessageQueue<IBattleMessage> _messageQueue;

        private ViewContexts _contexts;
        private ViewSystems _systems;

        protected override void OnCreate(object args) {
            if (!(args is BattleContext context)) {
                throw new ArgumentException($"args must be an instance of BattleContext!");
            }
            _battleContext = context;

            _idGenerator = new UniqueIdGenerator();
            _random = TSRandom.New(context.Seed);
            _viewConfig = JsonConvert.DeserializeObject<BattleViewConfig>(context.ViewConfigJson);
            
            _configReader = new ConfigReader();
            _configReader.Create(context.DataReader, context.ConfigPath);
            ParseSheets(_configReader);

            _messageQueue = new MessageQueue<IBattleMessage>();

            _contexts = new ViewContexts(this);
            _systems = new ViewSystems(_contexts);
            _systems.Initialize();
        }
        
        /// <summary>
        /// TODO 待优化，只删选出View层需要的陪表
        /// </summary>
        /// <param name="configReader"></param>
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

        internal BattleContext GetBattleContext() {
            return _battleContext;
        } 
        
        internal IRefPoolManager RefPoolManager() {
            return GetBattleContext().RefPoolManager;
        }
        
        internal IRefPool<T> GetRefPool<T>() where T : class, new() {
            return RefPoolManager().GetRefPool<T>();
        }

        internal IRefPool<T1> GetRefPool<T1, T2>()
            where T1 : class, new()
            where T2 : IRefPoolAllocator<T1>, new() {
            return RefPoolManager().GetRefPool<T1, T2>();
        }
        
        internal TSRandom GetRandom() {
            return _random;
        }
        
        internal ulong GetIndependentId() {
            return _idGenerator.IndependentId;
        }
        
        internal IConfigReader GetConfigReader() {
            return _configReader;
        }
        
        internal BattleViewConfig GetViewConfig() {
            return _viewConfig;
        }
        
        public void EnterFrame() {
            _systems.Execute();
            _systems.Cleanup();
        }

        internal bool TryDequeueMessage(out IBattleMessage message) {
            return _messageQueue.TryDequeue(out message);
        }
        
        public void EnqueueMessage(IBattleMessage message) {
            _messageQueue.Enqueue(message);
        }
        
        protected override void OnDestroy() {
            _systems?.TearDown();
            _systems = null;
            
            _configReader?.Destroy();
            _configReader = null;
        }
    }
}