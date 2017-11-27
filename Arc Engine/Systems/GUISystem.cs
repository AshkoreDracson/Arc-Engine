using System;
using System.Collections.Generic;

namespace ArcEngine
{
    public class GUISystem : BaseSystem
    {
        private Queue<Action<GraphicContext>> CommandQueue { get; }

        public GUISystem()
        {
            CommandQueue = new Queue<Action<GraphicContext>>();
        }

        internal void EnqueueCommand(Action<GraphicContext> command)
        {
            CommandQueue.Enqueue(command);
        }

        internal void Draw(GraphicContext gc)
        {
            while (CommandQueue.Count > 0)
            {
                Action<GraphicContext> command = CommandQueue.Dequeue();
                command(gc);
            }
        }
    }
}