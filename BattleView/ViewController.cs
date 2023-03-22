//------------------------------------------------------------
//        File:  ViewController.cs
//       Brief:  ViewController
//
//      Author:  Saroce, Saroce233@163.com
//
//    Modified:  2023-03-21
//============================================================

using System;
using Battle.Common.Context;
using Battle.Common.Interface;
using Battle.View.Base;
using Core.Lite.Base;
using vFrame.Lockstep.Core;

namespace Battle.View
{
    public sealed class ViewController : BaseObject<object>, IBattleView
    {
        private BattleContext _battleContext;
        private TSRandom _random;
        
        private MessageQueue<IBattleMessage> _messageQueue;

        private ViewContexts _contexts;
        private ViewSystems _systems;

        protected override void OnCreate(object args) {
            if (!(args is BattleContext context)) {
                throw new ArgumentException($"args must be an instance of BattleContext!");
            }
            _battleContext = context;
            
            _random = TSRandom.New(context.Seed);
            // TODO 视图层配置数据
            
            // TODO 读表工具

            _messageQueue = new MessageQueue<IBattleMessage>();

            _contexts = new ViewContexts(this);
            _systems = new ViewSystems(_contexts);
            _systems.Initialize();
        }

        public void EnterFrame() {
            _systems.Execute();
            _systems.Cleanup();
        }

        public void EnqueueMessage(IBattleMessage message) {
            _messageQueue.Enqueue(message);
        }
        
        protected override void OnDestroy() {
            _systems?.TearDown();
            _systems = null;
        }
    }
}