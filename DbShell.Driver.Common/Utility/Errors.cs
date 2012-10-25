using System;
using DbShell.Driver.Common.CommonDataLayer;

namespace DbShell.Driver.Common.Utility
{
    public abstract class AnyError : Exception
    {
        public AnyError(string message, Exception inner)
            : base(message, inner)
        {
        }
    }

    public class ExpectedError : AnyError
    {
        public ExpectedError(string message, Exception inner)
            : base(message, inner)
        {
        }

        public ExpectedError(string message)
            : base(message, null)
        {
        }
    }

    public abstract class UnexpectedError : AnyError
    {
        public UnexpectedError(string message, Exception inner)
            : base(message, inner)
        {
        }
    }

    public class InternalError : UnexpectedError
    {
        public InternalError(string message) : this(message, null) { }

        public InternalError(string message, Exception inner)
            : base(message, inner)
        {
        }
    }

    public class ConnectionFailedError : ExpectedError
    {
        public ConnectionFailedError(string errcode, Exception inner)
            : base(String.Format("{0} Connection failed with error {1}", errcode, inner.Message), inner)
        {
        }
    }

    public class DatabaseNotAccessibleError : ExpectedError
    {
        public DatabaseNotAccessibleError(string dbname, Exception inner)
            : base(String.Format("Database not {0} accessible, {1}", dbname, inner.Message), inner)
        {
        }
    }

    public class NotImplementedError : UnexpectedError
    {
        public NotImplementedError(string errcode)
            : base(errcode + " Operation not implemented", null)
        {
        }
    }

    public class XmlFormatError : ExpectedError
    {
        public XmlFormatError(string message)
            : base(message, null)
        {
        }
    }

    public class DataConversionError : ExpectedError
    {
        public DataConversionError(string message, Exception inner)
            : base(message, inner)
        {
        }
    }

    public class DataParseError : DataConversionError
    {
        public DataParseError(string data, TypeStorage type)
            : base(String.Format("Cannot convert \"{0}\" to type {1}", data, type), null)
        {
        }
    }

    public class QueueClosedError : InternalError
    {
        public QueueClosedError(string errcode)
            : base(errcode + " Queue closed, cannot perform operations on it")
        {
        }

        public QueueClosedError(string errcode, Exception inner)
            : base(errcode + " Queue closed, cannot perform operations on it", inner)
        {
        }
    }
}
