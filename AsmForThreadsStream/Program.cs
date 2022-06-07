using System.Text;
using System.Threading.Tasks;

namespace AsmForThreadsStream
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var redLamp = new Lamp();
            var greenLamp = new Lamp();
            var blueLamp = new Lamp();
            var yellowLamp = new Lamp();

            var t1 = new ExecutionThread(
                new PutConstantToRigister(true, 0),
                new WhileOperation(new IOperation[]
                    {
                        new ExecuteOperation(ctx => redLamp.TurnOn()),
                        new SleepOperation(200),
                        new ExecuteOperation(ctx => redLamp.TurnOff()),
                        new SleepOperation(1000)
                    })
                ); // x = 0; while (x < 10) cw("Hello");


            var t2 = new ExecutionThread(
                new PutConstantToRigister(true, 0),
                new WhileOperation(new IOperation[]
                    {
                        new ExecuteOperation(ctx => greenLamp.TurnOn()),
                        new SleepOperation(500),
                        new ExecuteOperation(ctx => greenLamp.TurnOff()),
                        new SleepOperation(500)
                    })
                );

            var t3 = new ExecutionThread(
                new PutConstantToRigister(true, 0),
                new WhileOperation(new IOperation[]
                    {
                                    new ExecuteOperation(ctx => blueLamp.TurnOn()),
                                    new SleepOperation(300),
                                    new ExecuteOperation(ctx => blueLamp.TurnOff()),
                                    new SleepOperation(200)
                    })
                );

            var t4 = new ExecutionThread(
                new PutConstantToRigister(true, 0),
                new WhileOperation(new IOperation[]
                    {
                                    new ExecuteOperation(ctx => yellowLamp.TurnOn()),
                                    new SleepOperation(600),
                                    new ExecuteOperation(ctx => yellowLamp.TurnOff()),
                                    new SleepOperation(200)
                    })
                );

            new ThreadPlanner(t1, t2, t3, t4).Execute();
        }
    }
}
