using Swashbuckle.Examples;

namespace WebApi.Models.Examples
{
    public class StringResponseExample : IExamplesProvider
    {
        public object GetExamples()
        {
            return "Sample String 1";
        }
    }
}