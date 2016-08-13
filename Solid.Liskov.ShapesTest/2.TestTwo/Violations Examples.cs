using System;

namespace Solid.Liskov.ShapesTest._2.TestTwo
{
        /*
        *   LSP violation "Smells"
        *   foreach(var emp in Employees)
        *   {
        *       if(emp is Manager){
        *           _printer.PrintManager(emp as Manager);
        *       }
        *       else{
        *           _printer.PrintEmployee(emp);
        *       }
        *   }
        */

    public abstract class Base
    {
        public abstract void Method1();
        public abstract void Method2();
    }

    public class Child : Base
    {
        public override void Method1()
        {
            //child classes cannot introduce new exceptions
            throw new NotImplementedException();
            // USE ISP so you don't require classes to implement
            // more than they need!
        }

        public override void Method2()
        {
            //do stuff
        }
    }
}
