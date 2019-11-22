using System;
using System.Xml;

namespace DesignPatterns_AbstractFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("DesignPatterns_AbstractFactory!");

            App app = new App(OS.MacOS);
            App app2 = new App(OS.Linux);
            App app3 = new App(OS.Windows);
        }
    }

    public enum OS
    {
        Windows,
        Linux,
        MacOS,
        Other
    }

    public class App
    {
        private IFactory _factory;

        public App(OS os)
        {
            if (os == OS.MacOS)
            {
                _factory = new MacOSFactory();
            }
            else if (os == OS.Windows)
            {
                _factory = new WindowsFactory();
            }

            else
            {
                Console.WriteLine("This OS is not supported");
                return;
            }

            _factory.CreateApp();
        }


    }

    public interface IFactory
    {
        IButton CreateButton();
        ICheckBox CheckBox();
        void CreateApp();
    }

    public interface IButton
    {
        void Paint();
    }

    public interface ICheckBox
    {
        void Paint();
    }

    

    public class MacOSFactory : IFactory
    {
        public ICheckBox CheckBox()
        {
            return new MacOSCheckBox();
        }

        public IButton CreateButton()
        {
            return new MacOSButton();
        }

        public void CreateApp()
        {
            this.CheckBox();
            this.CreateButton();
        }
        
    }

    internal class MacOSButton : IButton
    {
        public MacOSButton()
        {
            Paint();
        }
        public void Paint()
        {
            Console.WriteLine("MacOS button is painted");
        }
    }

    internal class MacOSCheckBox : ICheckBox
    {
        public MacOSCheckBox()
        {
            this.Paint();
        }

        public void Paint()
        {
            Console.WriteLine("MacOS check box is painted");
        }
    }

    

    internal class WindowsButton : IButton
    {
        public WindowsButton()
        {
            Paint();
        }
        public void Paint()
        {
            Console.WriteLine("Windows button is painted");
        }
    }

    internal class WindowsCheckBox : ICheckBox
    {
        public WindowsCheckBox()
        {
            Paint();
        }
        public void Paint()
        {
            Console.WriteLine("Windows check box is painted");
        }
    }
    

    public class WindowsFactory : IFactory
    {
        public ICheckBox CheckBox()
        {
            return new WindowsCheckBox();
        }

        public IButton CreateButton()
        {
            return new WindowsButton();

        }

        public void CreateApp()
        {
            this.CheckBox();
            this.CreateButton();
        }

       
    }


}
