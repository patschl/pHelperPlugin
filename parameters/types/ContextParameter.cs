namespace Turbo.plugins.patrick.parameters.types
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using parameters;

    public class ContextParameter : AbstractParameter
    {
        public Action<object> setter { get; }
        
        public List<object> options { get; }
        
        public string displayMember { get; }
        
        private ContextParameter(string propertyName, Action<object> setter, List<object> options, string displayMember) : base(propertyName, typeof(object))
        {
            this.setter = setter;
            this.options = options;
            this.displayMember = displayMember;
        }

        public static ContextParameter of<T>(string propertyName, Action<object> setter, IEnumerable<T> options, string displayMember = null)
        {
            return new ContextParameter(propertyName, setter, options.Cast<object>().ToList(), displayMember);
        }

        public override ParameterType parameterType => ParameterType.ContextParameter;
    }
}