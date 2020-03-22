using System;
using System.Collections.Generic;

namespace StrategyDesignPattern
{

    public interface IStrategy
    {
        object DoAlgorithm(object data);
    }

    class ConcreteStrategyA : IStrategy
    {
        public object DoAlgorithm(object data)
        {
            var list = data as List<string>;

            list.Sort();

            return list;
        }
    }

    class ConcreteStrategyB : IStrategy
    {
        public object DoAlgorithm(object data)
        {
            var list = data as List<string>;

            list.Sort();
            list.Reverse();

            return list;
        }
    }

    class Context
    {
        private IStrategy strategy;

        public Context() { }

        public Context(IStrategy strategy)
        {
            this.strategy = strategy;
        }

        public void SetStrategy(IStrategy strategy)
        {
            this.strategy = strategy;
        }

        public void DoSomething()
        {
            Console.WriteLine("Context: Sorting Data using strategy...");

            var result = this.strategy.DoAlgorithm(new List<string> { "a", "b", "c", "d", "e" });

            var resultStr = "";

            foreach (var element in result as List<string>)
            {
                resultStr += element + ",";
            }

            Console.WriteLine(resultStr);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var context = new Context();

            Console.WriteLine("Sorting the string in normal manner...");
            context.SetStrategy(new ConcreteStrategyA());
            context.DoSomething();

            Console.WriteLine("Sorting the string in normal manner...");
            context.SetStrategy(new ConcreteStrategyB());
            context.DoSomething();
        }
    }
}
