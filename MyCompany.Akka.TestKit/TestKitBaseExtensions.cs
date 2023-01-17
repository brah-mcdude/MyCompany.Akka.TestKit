using Akka.Event;

namespace MyCompany.Akka.TestKit
{
    static public class TestKitBaseExtensions
    {
        static public async Task ExpectLogNoWarningsNorErrorsAsync(this global::Akka.TestKit.Xunit2.TestKit x, Func<Task> actionAsync) => await x.EventFilter
            .Custom(logEvent => Predicate(logEvent))
            .ExpectAsync(0, actionAsync, TimeSpan.FromMilliseconds(3000));

        private static bool Predicate(LogEvent logEvent)
        {
            bool v = logEvent is Error || logEvent is Warning;
            return v;
        }
    }
}