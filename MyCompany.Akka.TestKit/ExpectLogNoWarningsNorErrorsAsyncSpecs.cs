using Akka.Actor;
using Xunit.Abstractions;

namespace MyCompany.Akka.TestKit
{

    public class ExpectLogNoWarningsNorErrorsAsyncSpecs : global::Akka.TestKit.Xunit2.TestKit
    {
        public ExpectLogNoWarningsNorErrorsAsyncSpecs(ITestOutputHelper output) : base(@"
akka 
{
    # test.single-expect-default = 00ms
    stdout-loglevel = DEBUG
    loglevel = DEBUG
    log-config-on-start = on
    actor 
    {
        debug 
        {
            receive = on
            unhandled = on
            autoreceive = on
            lifecycle = on
            event-stream = on
        }
    }
}
", output)
        {

        }

        [Fact]
        public async Task ExpectLogNoWarningsNorErrorsAsync_should_succeed_with_unhandled_message()
        {
            await this.ExpectLogNoWarningsNorErrorsAsync(async delegate
            {
                var someActor = Sys.ActorOf<SomeActor>();
                someActor.Tell("hi");
                await Task.CompletedTask;
            });
        }
    }
}