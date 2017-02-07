using System;
using System.Linq;
using System.Reflection;
using Ornament.Entities;

namespace Ornament.Identity
{
    public abstract class Permission<TRole> : EntityWithTypedId<int>
    {
        public virtual string Remarks { get; set; }


        public virtual int Operator { get; set; }


        public virtual TRole Role { get; set; }

        public virtual string Resource { get; set; }

        public virtual bool Verify<TOperator>(TOperator v)
        {
            return HasOperator((TOperator) Enum.ToObject(typeof(TOperator), Operator), v);
        }

        public static bool HasOperator<T>(T beCheckedOp, T existOperator)
        {
            if (!typeof(T).GetTypeInfo().IsEnum)
                throw new ArgumentOutOfRangeException("beCheckedOp should be enum type.");
            var opVal = Convert.ToInt32(beCheckedOp);
            var operatorVal = Convert.ToInt32(existOperator);
            if (opVal < operatorVal)
                return false;
            return (opVal & operatorVal) == operatorVal;
        }

        public static int[] FindValues<T>(int @operator, Type operatorType)
        {
            var vals = Enum.GetValues(operatorType);
            var v = (T) Enum.ToObject(typeof(T), @operator);
            return
                (from object val in vals where HasOperator(v, (T) val) select Convert.ToInt32(val)).ToArray();
        }
    }
}