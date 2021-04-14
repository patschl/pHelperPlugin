namespace Turbo.plugins.patrick.skills.castactions
{
    using System;
    using System.Collections.Generic;
    using Plugins;
    using Plugins.Patrick.util;

    public abstract class AbstractCastAction
    {
        public static readonly List<Type> CastActionTypes = Misc.GetAllSubTypesFromType(typeof(AbstractCastAction));
        
        public abstract string name { get; }

        public abstract bool Invoke(IController hud, IPlayerSkill skill);
    }
}