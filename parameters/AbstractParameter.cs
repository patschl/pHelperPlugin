namespace Turbo.plugins.patrick.parameters
{
    using System;

    public abstract class AbstractParameter
    {
        public string propertyName { get; }
        
        // TODO Used as a cheap parameter to know what to cast to. 
        public Type templateType { get; }
        
        public abstract ParameterType parameterType { get; }

        protected AbstractParameter(string propertyName, Type templateType)
        {
            this.propertyName = propertyName;
            this.templateType = templateType;
        }
    }
}