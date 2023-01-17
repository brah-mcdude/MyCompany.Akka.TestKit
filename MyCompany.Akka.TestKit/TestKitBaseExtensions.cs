using Akka.Event;

namespace MyCompany.Akka.TestKit
{
    static public class TestKitBaseExtensions
    {
        static public async Task ExpectLogNoWarningsNorErrorsAsync(this global::Akka.TestKit.Xunit2.TestKit x, Func<Task> actionAsync) => await x.CreateEventFilter(x.Sys)
        .Custom(logEvent => NewMethod(logEvent))
        .ExpectAsync(0, actionAsync, TimeSpan.FromMilliseconds(1));

        private static bool NewMethod(LogEvent logEvent)
        {
            bool v = logEvent is Info;
            return v;
        }
    }
}