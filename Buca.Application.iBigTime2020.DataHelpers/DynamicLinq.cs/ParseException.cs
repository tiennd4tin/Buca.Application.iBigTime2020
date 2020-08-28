﻿using System;

namespace Buca.Application.iBigTime2020.DataHelpers.DynamicLinq.cs
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class ParseException : Exception
    {
        /// <summary>
        /// The position
        /// </summary>
        readonly int _position;

        /// <summary>
        /// Initializes a new instance of the <see cref="ParseException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="position">The position.</param>
        public ParseException(string message, int position)
            : base(message)
        {
            _position = position;
        }

        /// <summary>
        /// Gets the position.
        /// </summary>
        /// <value>
        /// The position.
        /// </value>
        public int Position
        {
            get { return _position; }
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        /// <PermissionSet>
        ///   <IPermission class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" version="1" PathDiscovery="*AllFiles*" />
        ///   </PermissionSet>
        public override string ToString()
        {
            return string.Format(Res.ParseExceptionFormat, Message, _position);
        }
    }
}
