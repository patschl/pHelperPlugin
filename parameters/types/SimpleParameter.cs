namespace Turbo.plugins.patrick.parameters.types
{
    using System;
    using parameters;

    public class SimpleParameter<T> : AbstractParameter
    {
        public Action<T> setter { get; }

        public T defaultValue { get; }

        private SimpleParameter(string propertyName, Action<T> setter, T defaultValue = default(T)) : base(propertyName, typeof(T))
        {
            this.defaultValue = defaultValue;
            this.setter = setter;
        }

        public static SimpleParameter<T> of(string attributeName, Action<T> setter, T defaultValue = default(T))
        {
            return new SimpleParameter<T>(attributeName, setter, defaultValue);
        }

        public override ParameterType parameterType
        {
            get
            {
                return ParameterType.Simple;
            }
        }
    }
}