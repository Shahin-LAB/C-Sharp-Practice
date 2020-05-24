using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExempleQA483
{
    public class TypeToDBDataType
    {
        private void AssignDBDataType()
        {
            //var datetime = DateTime.Now;
            //GetTypeDefault(DateTime);
            DateTime val = DateTime.Now;
            //GetTypeDefault(val,val.GetType());

            //GetTypeDefault(val, typeof (DateTime));

            GetTypeDefault(typeof(DateTime));

            Double d = 10.0;
            //foo(d.GetType());
            var typeMap = new Dictionary<Type, DbType>();

            typeMap[typeof(byte)] = DbType.Byte;
            typeMap[typeof(sbyte)] = DbType.SByte;
            typeMap[typeof(short)] = DbType.Int16;
            typeMap[typeof(ushort)] = DbType.UInt16;
            typeMap[typeof(int)] = DbType.Int32;
            typeMap[typeof(uint)] = DbType.UInt32;
            typeMap[typeof(long)] = DbType.Int64;
            typeMap[typeof(ulong)] = DbType.UInt64;
            typeMap[typeof(float)] = DbType.Single;
            typeMap[typeof(double)] = DbType.Double;
            typeMap[typeof(decimal)] = DbType.Decimal;
            typeMap[typeof(bool)] = DbType.Boolean;
            typeMap[typeof(string)] = DbType.String;
            typeMap[typeof(char)] = DbType.StringFixedLength;
            typeMap[typeof(Guid)] = DbType.Guid;
            typeMap[typeof(DateTime)] = DbType.DateTime;
            typeMap[typeof(DateTimeOffset)] = DbType.DateTimeOffset;
            typeMap[typeof(byte[])] = DbType.Binary;
            typeMap[typeof(byte?)] = DbType.Byte;
            typeMap[typeof(sbyte?)] = DbType.SByte;
            typeMap[typeof(short?)] = DbType.Int16;
            typeMap[typeof(ushort?)] = DbType.UInt16;
            typeMap[typeof(int?)] = DbType.Int32;
            typeMap[typeof(uint?)] = DbType.UInt32;
            typeMap[typeof(long?)] = DbType.Int64;
            typeMap[typeof(ulong?)] = DbType.UInt64;
            typeMap[typeof(float?)] = DbType.Single;
            typeMap[typeof(double?)] = DbType.Double;
            typeMap[typeof(decimal?)] = DbType.Decimal;
            typeMap[typeof(bool?)] = DbType.Boolean;
            typeMap[typeof(char?)] = DbType.StringFixedLength;
            typeMap[typeof(Guid?)] = DbType.Guid;
            typeMap[typeof(DateTime?)] = DbType.DateTime;
            typeMap[typeof(DateTimeOffset?)] = DbType.DateTimeOffset;
            //typeMap[typeof(System.Data.Linq.Binary)] = DbType.Binary;

            var typeDateTime = typeMap[typeof(DateTime)];
            var objDateTime = DoSomethingUseful(typeDateTime);
            Console.WriteLine(objDateTime);

            var typeInt64 = typeMap[typeof(Int64)];
            var objInt64 = DoSomethingUseful(typeInt64);
            Console.WriteLine(objInt64);

            var typeDouble = typeMap[typeof(double)];
            var objDouble = DoSomethingUseful(typeInt64);
            Console.WriteLine(objDouble);



            //foo(d, typeof(Double));
            //DoSomethingUseful()
        }

        public static object DoSomethingUseful(DbType foo)
        {
            switch (foo)
            {
                case DbType.Boolean:
                    return false;
                case DbType.DateTime:
                    return DateTime.MinValue;
                case DbType.Decimal:
                    return 0m;
                case DbType.Int32:
                    return 0;
                case DbType.String:
                    return string.Empty;
                default:
                    // something else
                    return null;
            }
        }

        //public static object foo(Type t)
        //{
        //    var ttype= t.GetType () ;

        //    switch (typeof(t))
        //    {

        //        case typeof(double):
        //            return 0m;

        //        //case t.GetType 
        //        //    // something
        //        //    return DateTime.MinValue;
        //        //case typeof(double):
        //        //    // something else
        //        //    return 0;
        //        default:
        //            return null;
        //    }
        //}


        public static object GetTypeDefault(Type dbDataType)
        {
            switch (dbDataType)
            {
                //    //case Type.DateTime:
                //    //    return DateTime.MinValue;
                //    //case Type.Int32:
                //    //    return 0;
                //    //case Type.Decimal:
                //    //    return 0m;
                //    //default:
                //    //    return null;

                //    case Typeof(DateTime):
                //        return DateTime.MinValue;
                //    case Type.Int32:
                //        return 0;
                //    case Type.Decimal:
                //        return 0m;
                default:
                    return null;



            }

        }
    }
}
