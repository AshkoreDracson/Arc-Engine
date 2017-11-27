using System.Collections.Generic;

namespace ArcEngine
{
    public class GUISystem : BaseSystem
    {
        public delegate void GUICommand(GraphicContext gc);
        private Queue<GUICommand> CommandQueue { get; }

        public GUISystem()
        {
            CommandQueue = new Queue<GUICommand>();
        }

        internal void EnqueueCommand(GUICommand command)
        {
            CommandQueue.Enqueue(command);
        }

        internal void Draw(GraphicContext gc)
        {
            while (CommandQueue.Count > 0)
            {
                GUICommand command = CommandQueue.Dequeue();
                command(gc);
            }
        }
    }
}