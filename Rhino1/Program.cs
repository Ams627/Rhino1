using System;
using System.IO;
using Rhino.Mocks;

namespace Rhino1
{
    public interface IData
    {
        void Doit(string s);
    }

    class CData : IData
    {
        public void Doit(string s)
        {
            Console.WriteLine("Hello");
        }
    }


    class X
    {
        public X(IData data)
        {
            data.Doit("Hello");
        }
    }

    class Program
    {

        private static void Main(string[] args)
        {
            try
            {
                var r = MockRepository.GenerateMock<IData>();
                var x = new X(r);
                r.AssertWasCalled(a=>a.Doit(Arg<string>.Is.Equal("Hello")));
            }
            catch (Exception ex)
            {
                var fullname = System.Reflection.Assembly.GetEntryAssembly().Location;
                var progname = Path.GetFileNameWithoutExtension(fullname);
                Console.Error.WriteLine($"{progname} Error: {ex.Message}");
            }

        }
    }
}
