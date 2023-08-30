using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace winforms_chat.Utilities
{
    // Custom event handler with 1 argument
    public delegate void CustomEventHandlerArg<T1>(object sender, CustomEventArgs<T1> args);
    public delegate void CustomEventHandlerArg<T1,T2>(object sender, CustomEventArgs<T1,T2> args);
    public delegate void CustomEventHandlerArg<T1,T2,T3>(object sender, CustomEventArgs<T1,T2,T3> args); 
    public delegate void CustomEventHandlerArg<T1,T2,T3,T4>(object sender, CustomEventArgs<T1,T2,T3,T4> args);   

    // Argument class with 1 argument
    public class CustomEventArgs<T1> : EventArgs
    {
        public T1           Arg1 { get; private set; }
        public List<object> Args { get { return new List<object>(){ Arg1 }; } }
        public CustomEventArgs(T1 argument1) { Arg1 = argument1; }
    }

    // Argument class with 2 arguments
    public class CustomEventArgs<T1,T2> : EventArgs
    {
        public T1 Arg1 { get; private set; }
        public T2 Arg2 { get; private set; }
        public List<object> Args { get { return new List<object>() { Arg1, Arg2 }; } }
        public CustomEventArgs(T1 argument1, T2 argument2) { Arg1 = argument1; Arg2 = argument2; }
    }

    // Argument class with 3 arguments
    public class CustomEventArgs<T1,T2,T3> : EventArgs
    {
        public T1 Arg1 { get; private set; }
        public T2 Arg2 { get; private set; }
        public T3 Arg3 { get; private set; }
        public List<object> Args { get { return new List<object>() { Arg1, Arg2, Arg3 }; } }
        public CustomEventArgs(T1 argument1, T2 argument2, T3 argument3) { Arg1 = argument1; Arg2 = argument2; Arg3 = argument3; }
    }

    // Argument class with 4 arguments
    public class CustomEventArgs<T1,T2,T3,T4> : EventArgs
    {
        public T1 Arg1 { get; private set; }
        public T2 Arg2 { get; private set; }
        public T3 Arg3 { get; private set; }
        public T4 Arg4 { get; private set; }
        public List<object> Args { get { return new List<object>() { Arg1, Arg2, Arg3, Arg4 }; } }
        public CustomEventArgs(T1 argument1, T2 argument2, T3 argument3, T4 argument4) { Arg1 = argument1; Arg2 = argument2; Arg3 = argument3; Arg4 = argument4; }
    }
}
